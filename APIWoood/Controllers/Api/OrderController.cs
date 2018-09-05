using APIWoood.Logic.Models;
using APIWoood.Logic.Repositories;
using APIWoood.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIWoood.Controllers.Api
{
    public class OrderController : ApiController
    {
        private readonly UserRepository userRepository;
        private readonly OrderRepository orderRepository;

        public OrderController()
        {
            userRepository = new UserRepository();
            orderRepository = new OrderRepository();
        }


        /**
         * @api {post} /api/woood-order/create Create orders
         * @apiVersion 1.0.0
         * @apiName CreateOrders
         * @apiGroup Orders
         * 
         *
         * @apiHeader {String} Authorization Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)
         * 
         * @apiParam (Authentication) {String} api-key Unique key for the user
         * @apiParam (Authentication) {String} username Username of the user
         * @apiParam (Authentication) {String} password Password of the user
         * 
         * @apiParam (Order) {String} REFERENTIE Reference
         * @apiParam (Order) {String} DEBITEURNR Debtor Number
         * @apiParam (Order) {String} [OMSCHRIJVING] Description
         * @apiParam (Order) {Int} [ACCEPTATIE_VERZAMELEN=0] Acceptance Collect
         * @apiParam (Order) {Int} [ACCEPTATIE_ORDERKOSTEN=0] Acceptance of Order Costs
         * @apiParam (Order) {Int} [ACCEPTATIE_ORDERSPLITSING=0] Acceptance of Order Splitting
         * @apiParam (Order) {String} [SELECTIECODE] Selection Code
         * @apiParam (Order) {String} [ORDERTOELICHTING] Order Explanation
         * @apiParam (Order) {String} [DS_NAAM] Delivery Name
         * @apiParam (Order) {String} [DS_AANSPREEKTITEL] Delivery Gender
         * @apiParam (Order) {String} [DS_ADRES1] Delivery Address
         * @apiParam (Order) {String} [DS_POSTCODE] Delivery Postcode
         * @apiParam (Order) {String} [DS_PLAATS] Delivery City
         * @apiParam (Order) {String} [DS_LAND] Delivery Country
         * @apiParam (Order) {String} [DS_TELEFOON] Delivery Phone
         * @apiParam (Order) {String} [DS_EMAIL] Delivery E-mail
         * @apiParam (Order) {Int} [PAYMENT_RELEASE_REQUIRED=0] Payment Release Required
         * 
         * @apiParam (OrderItem) {String} ITEMCODE Product Code
         * @apiParam (OrderItem) {String} AANTAL Quantity
         * @apiParam (OrderItem) {String} [VERZENDWEEK] Shipping Week
         * 
         * @apiParamExample Request-Example:
         *      /api/woood-order/create?apikey=fftt2sQjjaiSXnX2Qnvr3XnahdDB3ZRDLTnRtpJr
         *      
         * @apiExample {json} Example usage:
         * {
         *      "header":
         *      {
         *          "api-key": "Yi7h9j0gWq4kUX2pPyaYkdNkmu",
         *          "username": "pixel",
         *          "password": "wachtwoord"
         *      },
         *      "body":
         *      {
         *          "order":[
         *              {
         *                  "REFERENTIE": "TEST_ORDER_F6u16dKf_5",
         *                  "OMSCHRIJVING": "TEST_ORDER_F6u16dKf",
         *                  "DEBITEURNR": "160405",
         *                  "SELECTIECODE": "CA",
         *                  "ORDERTOELICHTING": "EffectConnect",
         *                  "DS_NAAM": "Jules Dohmen (TESTORDER)",
         *                  "DS_AANSPREEKTITEL": "M",
         *                  "DS_ADRES1": "Tolhuisweg 5A",
         *                  "DS_POSTCODE": "6071RG",
         *                  "DS_PLAATS": "Swalmen",
         *                  "DS_LAND": "NL",
         *                  "DS_TELEFOON": "0859021855",
         *                  "DS_EMAIL": "Info@koekenpeer.nl",
         *                  "item": [
         *                      {
         *                          "ITEMCODE": "341206-Z",
         *                          "AANTAL": 1
         *                      }
         *                  ]
         *              }
         *          ]
         *      }
         * }
         *      
         * @apiSuccessExample {json} Success-Response:
         *      HTTP/1.1. 200 OK
         *      {
         *          "body": {
         *              "references": [
         *                  "0123456789"
         *                  ...
         *              ]
         *          }
         *      }
         * 
         * @apiError (Error 4xx) {400} Required field is missing.
         * @apiError (Error 4xx) {401} NotAuthorized The user is not authorized.
         * @apiError (Error 4xx) {401} NotAuthorized API key is missing.
          * @apiError (Error 4xx) {409} Conflict The combination of DEBITEURNR and REFERENTIE must be unique.
        * 
         */
        [Route("api/woood-order/create")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult Post([FromBody]OrderData data)
        {
            string apiKey;
            try
            {
                apiKey = data.header.apikey;
            }
            catch (System.Exception)
            {
                return Content(HttpStatusCode.Unauthorized, "API key is missing.");
            }

            var user = userRepository.GetByUsername(data.header.username);
            if (apiKey != user.ApiKey)
            {
                return Content(HttpStatusCode.Unauthorized, "API key is not correct. Get a right API key from the service provider.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var references = new List<string>();
            int orderCount = 0;
            foreach (var order in data.body.order)
            {
                try
                {
                    var orderIdentifier = new OrderIdentifier(order.REFERENTIE, order.DEBITEURNR);

                    var existingOrders = orderRepository.GetByIdentifier(orderIdentifier);
                    if (existingOrders.Count() > 0)
                    {
                        return Content(HttpStatusCode.BadRequest, "The combination of DEBITEURNR and REFERENTIE must be unique");
                    }

                    if (order.item.Count() == 0)
                    {

                    }

                    var orderToPost = new OrderHeader()
                    {
                        OrderIdentifier = orderIdentifier,
                        OMSCHRIJVING = order.OMSCHRIJVING,
                        STATUS = order.STATUS,
                        ORDERNR = order.ORDERNR,
                        SELECTIECODE = order.SELECTIECODE,
                        ORDERTOELICHTING = order.ORDERTOELICHTING,
                        ACCEPTATIE_VERZAMELEN = order.ACCEPTATIE_VERZAMELEN,
                        ACCEPTATIE_ORDERKOSTEN = order.ACCEPTATIE_ORDERKOSTEN,
                        DS_NAAM = order.DS_NAAM,
                        DS_AANSPREEKTITEL = order.DS_AANSPREEKTITEL,
                        DS_ADRES1 = order.DS_ADRES1,
                        DS_POSTCODE = order.DS_POSTCODE,
                        DS_PLAATS = order.DS_PLAATS,
                        DS_LAND = order.DS_LAND,
                        DS_TELEFOON = order.DS_TELEFOON,
                        DS_EMAIL = order.DS_EMAIL,
                        AUTHENTICATED_USER = data.header.username,
                        ACCEPTATIE_ORDERSPLITSING = order.ACCEPTATIE_ORDERSPLITSING,
                        PAYMENT_RELEASE_REQUIRED = order.PAYMENT_RELEASE_REQUIRED
                    };

                    int orderLineCount = 0;
                    foreach (var item in order.item)
                    {
                        var orderLineToPost = new OrderLine()
                        {
                            OrderIdentifier = orderToPost.OrderIdentifier,
                            ITEMCODE = item.ITEMCODE,
                            AANTAL = item.AANTAL,
                            STATUS = item.STATUS,
                            ORDERNR = item.ORDERNR,
                            VERZENDWEEK = item.VERZENDWEEK
                        };

                        orderToPost.Lines.Add(orderLineToPost);
                        ++orderLineCount;
                    }

                    orderRepository.Insert(orderToPost);
                    ++orderCount;
                    references.Add(orderIdentifier.REFERENTIE);
                }
                catch (System.Exception e)
                {
                    return InternalServerError(e);
                }
            }

            if (orderCount == 0)
            {
                return BadRequest("No orders added");
            }

            return Ok(new {
                body = new
                {
                    references
                }
            });
        }

        
    }
}
