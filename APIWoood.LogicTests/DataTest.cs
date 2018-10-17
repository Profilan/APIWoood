using System;
using APIWoood.Logic.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using APIWoood.Logic.Models;
using HibernatingRhinos.Profiler.Integration;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using APIWoood.Logic.SharedKernel;

namespace APIWoood.LogicTests
{
    [TestClass]
    public class DataTest
    {

        public DataTest()
        {
//            var captureProfilerOutput = new CaptureProfilerOutput(@"");
//            captureProfilerOutput.StartListening();

            NHibernateProfiler.Initialize();
        }

        [TestMethod]
        public void ProductList()
        {
            var rep = new ProductRepository();

            var products = rep.List();

            products.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void PackageList()
        {
            var rep = new PackageRepository();

            var packages = rep.List();

            packages.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void StructureList()
        {
            var rep = new StructureRepository();

            var structures = rep.List("MAINPROD_ASC");

            structures.Should().NotBeNull();
        }

        [TestMethod]
        public void StructureListByProduct()
        {
            var rep = new StructureRepository();

            var structures = rep.List("373666-E");

            structures.Should().NotBeNullOrEmpty();
        }


        [TestMethod]
        public void UserList()
        {
            var rep = new UserRepository();

            var users = rep.List();

            users.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void DebtorList()
        {
            var rep = new DebtorRepository();

            var debtors = rep.List("DEBITEURNR_ASC");

            debtors.Results.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void DebtorOrderList()
        {
            var rep = new DebtorOrderRepository();

            var items = rep.List("DEBITEURNR_ASC");

            items.Results.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void OrderList()
        {
            var rep = new OrderRepository();

            var items = rep.List("ID_DESC");

            items.Results.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void OrderCreate()
        {
            var rep = new OrderRepository();

            var order = new OrderHeader()
            {
                OrderIdentifier = new OrderIdentifier("000002", "160405"),
                OMSCHRIJVING = "TEST_ORDER_F6u16dKf",
                SELECTIECODE = "CA",
                ORDERTOELICHTING = "EffectConnect",
                DS_NAAM = "Jules Dohmen (TESTORDER)",
                DS_AANSPREEKTITEL = "M",
                DS_ADRES1 = "Tolhuisweg 5A",
                DS_POSTCODE = "6071RG",
                DS_PLAATS = "Swalmen",
                DS_LAND = "NL",
                DS_TELEFOON = "0859021855",
                DS_EMAIL = "Info@koekenpeer.nl"
                
            };

            order.Lines.Add(new OrderLine()
            {
                OrderIdentifier = order.OrderIdentifier,
                ITEMCODE = "341206-A",
                AANTAL = 1
            });

            order.Lines.Add(new OrderLine()
            {
                OrderIdentifier = order.OrderIdentifier,
                ITEMCODE = "341206-B",
                AANTAL = 4
            });

            rep.Insert(order);


        }

        [TestMethod]
        public void SellingPointList()
        {
            var rep = new SellingPointRepository();

            var sellingPoints = rep.List();

            sellingPoints.Should().NotBeNull();
        }

        [TestMethod]
        public void Pricelist()
        {
            var rep = new PricelistRepository();

            var items = rep.ListByDebtor("109776");

            items.Should().NotBeNull();
        }

        [TestMethod]
        public void ProductRangeList()
        {
            var rep = new ProductRangeRepository();

            var items = rep.ListByRange(1);

            items.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void WebAvailabilityList()
        {
            var rep = new WebAvailabilityRepository();

            var items = rep.ListByDebtor("109663");

            items.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void PaymentConditionList()
        {
            var rep = new PaymentConditionRepository();

            var items = rep.List();

            items.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void DeliveryMethodList()
        {
            var rep = new DeliveryMethodRepository();

            var items = rep.List();

            items.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void CreatePaymentRelease()
        {
            var rep = new PaymentReleaseRepository();

            var paymentRelease = new PaymentRelease()
            {
                OrderIdentifier = new OrderIdentifier("27567", "108751"),
                PAYMENT_RELEASE = 1
            };

            rep.Insert(paymentRelease);
        }

        [TestMethod]
        public void GetLatestErrors()
        {
            var logRepository = new LogRepository();

            var logErrors = logRepository.List(Period.month, ErrorType.ERR, "api/woood-pricelist/list");

            logErrors.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void UpdateUser()
        {
            var userRep = new UserRepository();

            var user = userRep.GetByUsername("raymond");

            /*
            user.Urls.Clear();
            var urlRep = new UrlRepository();

            var url1 = urlRep.GetByName("api/woood-web-availability/list");
            var url2 = urlRep.GetByName("api/woood-structureview/list");

            user.Urls.Add(url1);
            user.Urls.Add(url2);
            */
            user.Debtors.Clear();
            var debtorRep = new DebtorRepository();

            var url1 = debtorRep.GetById("1001502");

            user.Debtors.Add(url1);

            userRep.Update(user);
        }

        [TestMethod]
        public void DeleteUser()
        {
            var rep = new UserRepository();

            rep.Delete(27);

        }
    }
}
