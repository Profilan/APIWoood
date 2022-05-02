using APIWoood.Logic.Repositories;
using APIWoood.Logic.Services;
using APIWoood.Logic.SharedKernel;
using APIWoood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIWoood.Filters;

namespace APIWoood.Controllers.Api
{
    [IdentityBasicAuthentication]
    [AuthorizeApi]
    public class ProductController : WooodApiController
    {
        private readonly ProductRepository productRepository;
        private readonly PackageRepository packageRepository;
        private SystemLogger logger;

        public ProductController() : base()
        {
            productRepository = new ProductRepository();
            packageRepository = new PackageRepository();
            logger = new SystemLogger();
        }

        /**
         * @api {get} /api/woood-artikelview/list Request list of items (non-paged)
         * @apiVersion 1.0.0
         * @apiName GetArticles
         * @apiGroup Articles
         * 
         *
         * @apiHeader {String} Authorization Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)
         * 
         * @apiParamExample Request-Example:
         *      /api/woood-artikelview/list
         *      
         * @apiSuccessExample {json} Success-Response:
         *      HTTP/1.1. 200 OK
         *      [
         *          {
         *              "ARTIKELCODE": "375490",
         *              "CREATIONDATE": "2018-11-28",
         *              "NL": "RETRO BIJZETTAFEL MET 2 LADEN GRENEN WIT - EIKEN POTEN",
         *              "EN": "RETRO SIDETABLE WITH 2 DRAWERS PINE WITH - OAK",
         *              "DE": "RETRO BEISTELLTISCH WEIß",
         *              "FR": "RETRO TABLE D APPOINT PIN BLANC",
         *              "COLOR_FINISH": "WHITE",
         *              "MATERIAL": "PINE",
         *              "BRAND": "WOOOD",
         *              "ASSORTMENT": "LIVING",
         *              "PRODUCTGROUP_CODE": "P05",
         *              "PRODUCTGROUP": "TAFELS",
         *              "DEFAULT_SUBPRODUCTGROUP_CODE": "13",
         *              "DEFAULT_SUBPRODUCTGROUP_NAME": "COFFEE & SIDETABLES",
         *              "RANGE": "OTHER",
         *              "STATUS": "SALE",
         *              "EXCLUSIV": "FREE AVAILABLE",
         *              "VERKOOPPRIJS": 56.4,
         *              "VERKOOPEENHEID": "ST/PCS  ",
         *              "AANTAL_PAKKETTEN": 2,
         *              "AFMETING_ARTIKEL_HXBXD": "76x60x38",
         *              "EANCODE": "8714713052325",
         *              "EN_LONG_DESC": "This piece of furniture can be used multiple ways: side table, bedside table or storage cabinet. This practical side table is part of the Retro furniture series of the WOOOD brand. The Retro furniture is matched to each other in terms of design and is therefore easy to combine with each other. The series reminds you of the 70's and has a Scandinavian touch because of the exciting material combination. This article is supplied as a simple kit with clear assembly instructions.",
         *              "NL_LONG_DESC": "Multi inzetbaar is dit meubel: bijzettafel, nachtkastje ofopbergkastje. Deze praktische bijzettafel is onderdeel van de meubelserie Retro van het merk WOOOD. De meubels Retro zijn qua design op elkaar afgestemd en zijn daardoor goed met elkaar te combineren. De serie doet je denken aan de jaren 70 en heeft wegens de spannende materialencombi een Scandinavische touch. Dit artikel wordt geleverd als eenvoudig bouwpakket met duidelijke montagehandleiding.",
         *              "DE_LONG_DESC": null,
         *              "FR_LONG_DESC": "",
         *              "AANTAL_VERP": 1,
         *              "SOURCE": null,
         *              "MRP_RUN": "NA",
         *              "CONSUMENTENPRIJS": 119,
         *              "CONSUMENTENPRIJS_VAN": 149,
         *              "ISE_CONSUMENTENPRIJS": 135,
         *              "ISE_CONSUMENTENPRIJS_VAN": 165,
         *              "GEWICHT": 11.5,
         *              "NEW_ARRIVAL": false,
         *              "VERPAK_DIKTE_MM": 0,
         *              "VERPAK_LENGTE_MM": 0,
         *              "VERPAK_BREEDTE_MM": 0,
         *              "VOL_M3_VERP": 0.029,
         *              "VRIJEVOORRAAD": 4,
         *              "ASS_CODE_EXCLUSIV": "17",
         *              "ATP": null,
         *              "DFF_SHIPMENT": "POST",
         *              "FSC": false,
         *              "COUNTRY_OF_ORIGIN": "NL ",
         *              "INTRASTAT_CODE": " 94036010",
         *              "ASSEMBLY_REQUIRED": true,
         *              "WEB_VAN_PRIJS_NL": 0,
         *              "WEB_VAN_PRIJS_ISE": 0,
         *              "AVAILABILITY_WEEK": null,
         *              "PAKKETTEN": [
         *                  {
         *                      "ARTCODE_PAKKET": "P375490 1#2",
         *                      "ARTIKELCODE": "375490",
         *                      "CREATIONDATE": "2018-11-28",
         *                      "NL": "PAKKET 1#2 RETRO BIJZETTAFEL",
         *                      "EN": "1#2 RETRO SIDETABLE WITH 2 DRAWERS PINE WITH - OAK",
         *                      "DE": "1#2 RETRO BEISTELLTISCH WEIß",
         *                      "FR": "1#2 RETRO TABLE D APPOINT PIN BLANC",
         *                      "GEWICHT": 9.5,
         *                      "VERPAK_DIKTE_MM": 638,
         *                      "VERPAK_LENGTE_MM": 528,
         *                      "VERPAK_BREEDTE_MM": 68,
         *                      "VOL_M3_VERP": 0.022906752,
         *                      "VRIJEVOORRAADPAKKET": 4,
         *                      "ASS_CODE_EXCLUSIV": null,
         *                      "EANCODE_PAKKET": "8714713054817",
         *                      "AANTAL_PAKKETTEN": 1
         *                  },
         *                  ...
         *              ]
         *          },
         *          ...
         *      ]
         * 
         * @apiError (Error 4xx) {401} NotAuthorized The user is not authorized.
         * 
         */
        [Route("api/woood-artikelview/list")]
        [HttpGet]
        public IHttpActionResult GetArticles()
        {
            try
            {
                var items = productRepository.List();

                var products = new List<Product>();
                foreach (var item in items)
                {
                    var product = CreateProduct(item);

                    // Get the packages which belong to this product, if AANTAL_PAKKETTEN > 1
                    if (item.AANTAL_PAKKETTEN > 1)
                    {
                        var packageItems = packageRepository.ListByArtikelCode(item.ARTIKELCODE);

                        foreach (var packageItem in packageItems)
                        {
                            var package = CreatePackage(packageItem);

                            product.PAKKETTEN.Add(package);
                        }
                    }
                    else // Create a package like main product
                    {
                        var package = CreatePackage(item);

                        product.PAKKETTEN.Add(package);
                    }

                    products.Add(product);
                }

                logger.Log(ErrorType.INFO, "GetArticles()", RequestContext.Principal.Identity.Name, "Total in query: " + products.Count, "api/woood-artikelview/list", startDate);

                return Ok(products);
            }
            catch (Exception e)
            {
                logger.Log(ErrorType.ERR, "GetArticles()", RequestContext.Principal.Identity.Name, e.Message, "api/woood-artikelview/list");

                return InternalServerError(e);
            }
        }

        /**
         * @api {get} /api/woood-artikelview/view/artikelcode/:id Request one item
         * @apiVersion 1.0.0
         * @apiName GetArticleById
         * @apiGroup Articles
         *
         * @apiHeader {String} Authorization Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)
         * 
         * @apiParamExample Request-Example:
         *      /api/woood-artikelview/view/artikelcode/378569-Z
         *      
         * @apiSuccessExample {json} Success-Response:
         *      HTTP/1.1. 200 OK
         *      {
         *          "ARTIKELCODE": "375490",
         *          "CREATIONDATE": "2018-11-28",
         *          "NL": "RETRO BIJZETTAFEL MET 2 LADEN GRENEN WIT - EIKEN POTEN",
         *          "EN": "RETRO SIDETABLE WITH 2 DRAWERS PINE WITH - OAK",
         *          "DE": "RETRO BEISTELLTISCH WEIß",
         *          "FR": "RETRO TABLE D APPOINT PIN BLANC",
         *          "COLOR_FINISH": "WHITE",
         *          "MATERIAL": "PINE",
         *          "BRAND": "WOOOD",
         *          "ASSORTMENT": "LIVING",
         *          "PRODUCTGROUP_CODE": "P05",
         *          "PRODUCTGROUP": "TAFELS",
         *          "DEFAULT_SUBPRODUCTGROUP_CODE": "13",
         *          "DEFAULT_SUBPRODUCTGROUP_NAME": "COFFEE & SIDETABLES",
         *          "RANGE": "OTHER",
         *          "STATUS": "SALE",
         *          "EXCLUSIV": "FREE AVAILABLE",
         *          "VERKOOPPRIJS": 56.4,
         *          "VERKOOPEENHEID": "ST/PCS  ",
         *          "AANTAL_PAKKETTEN": 2,
         *          "AFMETING_ARTIKEL_HXBXD": "76x60x38",
         *          "EANCODE": "8714713052325",
         *          "EN_LONG_DESC": "This piece of furniture can be used multiple ways: side table, bedside table or storage cabinet. This practical side table is part of the Retro furniture series of the WOOOD brand. The Retro furniture is matched to each other in terms of design and is therefore easy to combine with each other. The series reminds you of the 70's and has a Scandinavian touch because of the exciting material combination. This article is supplied as a simple kit with clear assembly instructions.",
         *          "NL_LONG_DESC": "Multi inzetbaar is dit meubel: bijzettafel, nachtkastje ofopbergkastje. Deze praktische bijzettafel is onderdeel van de meubelserie Retro van het merk WOOOD. De meubels Retro zijn qua design op elkaar afgestemd en zijn daardoor goed met elkaar te combineren. De serie doet je denken aan de jaren 70 en heeft wegens de spannende materialencombi een Scandinavische touch. Dit artikel wordt geleverd als eenvoudig bouwpakket met duidelijke montagehandleiding.",
         *          "DE_LONG_DESC": null,
         *          "FR_LONG_DESC": "",
         *          "AANTAL_VERP": 1,
         *          "SOURCE": null,
         *          "MRP_RUN": "NA",
         *          "CONSUMENTENPRIJS": 119,
         *          "CONSUMENTENPRIJS_VAN": 149,
         *          "ISE_CONSUMENTENPRIJS": 135,
         *          "ISE_CONSUMENTENPRIJS_VAN": 165,
         *          "GEWICHT": 11.5,
         *          "NEW_ARRIVAL": false,
         *          "VERPAK_DIKTE_MM": 0,
         *          "VERPAK_LENGTE_MM": 0,
         *          "VERPAK_BREEDTE_MM": 0,
         *          "VOL_M3_VERP": 0.029,
         *          "VRIJEVOORRAAD": 4,
         *          "ASS_CODE_EXCLUSIV": "17",
         *          "ATP": null,
         *          "DFF_SHIPMENT": "POST",
         *          "FSC": false,
         *          "COUNTRY_OF_ORIGIN": "NL ",
         *          "INTRASTAT_CODE": " 94036010",
         *          "ASSEMBLY_REQUIRED": true,
         *          "WEB_VAN_PRIJS_NL": 0,
         *          "WEB_VAN_PRIJS_ISE": 0,
         *          "AVAILABILITY_WEEK": null,
         *          "PAKKETTEN": [
         *              {
         *                  "ARTCODE_PAKKET": "P375490 1#2",
         *                  "ARTIKELCODE": "375490",
         *                  "CREATIONDATE": "2018-11-28",
         *                  "NL": "PAKKET 1#2 RETRO BIJZETTAFEL",
         *                  "EN": "1#2 RETRO SIDETABLE WITH 2 DRAWERS PINE WITH - OAK",
         *                  "DE": "1#2 RETRO BEISTELLTISCH WEIß",
         *                  "FR": "1#2 RETRO TABLE D APPOINT PIN BLANC",
         *                  "GEWICHT": 9.5,
         *                  "VERPAK_DIKTE_MM": 638,
         *                  "VERPAK_LENGTE_MM": 528,
         *                  "VERPAK_BREEDTE_MM": 68,
         *                  "VOL_M3_VERP": 0.022906752,
         *                  "VRIJEVOORRAADPAKKET": 4,
         *                  "ASS_CODE_EXCLUSIV": null,
         *                  "EANCODE_PAKKET": "8714713054817",
         *                  "AANTAL_PAKKETTEN": 1
         *              },
         *              ...
         *          ]
         *      }
         * 
         * @apiError (Error 4xx) {401} NotAuthorized The user is not authorized.
         * 
         */
        [Route("api/woood-artikelview/view/artikelcode/{id}")]
        [HttpGet]
         public IHttpActionResult GetArticleById(string id)
        {
            try
            {
                var item = productRepository.GetById(id);

                if (item != null)
                {
                    var product = CreateProduct(item);

                    if (item.AANTAL_PAKKETTEN > 1)
                    {
                        var packageItems = packageRepository.ListByArtikelCode(item.ARTIKELCODE);

                        foreach (var packageItem in packageItems)
                        {
                            var package = CreatePackage(packageItem);

                            product.PAKKETTEN.Add(package);
                        }
                    }
                    else // Create a package like main product
                    {
                        var package = CreatePackage(item);

                        product.PAKKETTEN.Add(package);
                    }

                    logger.Log(ErrorType.INFO, "GetArticleById(" + id + ")", RequestContext.Principal.Identity.Name, "", "api/woood-artikelview/view/artikelcode", startDate);

                    var products = new List<Product>();
                    products.Add(product);

                    return Ok(products);

                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                logger.Log(ErrorType.ERR, "GetArticleById(" + id + ")", e.Message, "", "api/woood-artikelview/view/artikelcode");

                return InternalServerError(e);
            }
        }

        /**
         * @api {get} /api/woood-productview/list Request Product information (paged)
         * @apiVersion 1.0.0
         * @apiName GetProducts
         * @apiGroup Products
         * 
         *
         * @apiHeader {String} Authorization Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)
         * 
         * @apiParam {String} [page=1] Page to show
         * @apiParam {String} [limit=25] Number of products on a page
         * 
         * @apiParamExample Request-Example:
         *      /api/woood-productview/list?page=2&limit=50
         *      
         * @apiSuccessExample {json} Success-Response:
         *      HTTP/1.1. 200 OK
         *      {
         *          "_embedded": [
         *               {
         *                   "ARTIKELCODE": "362101-GOW",
         *                   "CREATIONDATE": "2018-11-28",
         *                   "NL": "LOCK KAST 3-DEURS WIT [fsc]",
         *                   "EN": "LOCK CABINET 3-DOOR WHITE PINE UNBRUSHED [fsc]",
         *                   "DE": "LOCK SCHRANK 3-TÜRIG KIEFER UNGEBÜRSTET WEIß [fsc]",
         *                   "FR": "LOCK ARMOIRE 3 PORTES PIN BLANC (FSC)",
         *                   "COLOR_FINISH": "WHITE",
         *                   "MATERIAL": "PINE",
         *                   "BRAND": "WOOOD",
         *                   "ASSORTMENT": "LIVING",
         *                   "PRODUCTGROUP_CODE": "P04",
         *                   "PRODUCTGROUP": "OPBERGEN",
         *                   "DEFAULT_SUBPRODUCTGROUP_CODE": "19",
         *                   "DEFAULT_SUBPRODUCTGROUP_NAME": "WARDROBES & BEDROOM STORAGE",
         *                   "RANGE": "COLLECTION",
         *                   "STATUS": "COLLECTION",
         *                   "EXCLUSIV": "KARWEI [NL]",
         *                   "VERKOOPPRIJS": 205.5,
         *                   "VERKOOPEENHEID": "ST/PCS  ",
         *                   "AANTAL_PAKKETTEN": 4,
         *                   "AFMETING_ARTIKEL_HXBXD": "195x140x53",
         *                   "EANCODE": "8714713040681",
         *                   "EN_LONG_DESC": "The WOOOD cabinet Lock (hxbxd) 195x140x53 cm is a 3-door cabinet with solid metal hinges in the color white. The cabinet is made of solid pine except the shelves, middle panel, bottom and top panel, these are made of chipboard covered with white foil. The back panel is of white lacquered hardboard. The 3 doors of the cabinet have a vertical V-groove line and this combined with the accents of a locker cabinet give the cabinet a tough and rural look. The interior of the cabinet consists of 5 chipboard shelves and a middle wall covered with white foil and a rod. This Lock cupboard fits into any space. Behind the right door of the cabinet is the cabinet with 4 shelves. Behind the left and middle door is the cabinet with one wide shelf at the top and a wide rod underneath. This cabinet has been designed in such a way that it can be expanded by connecting one or more Lock 2 doors or Lock 3 door versions. This wardrobe Lock is also available in a 2-door version. This cabinet is delivered as seperate elements and is easy to assemble using the supplied assembly instructions.",
         *                   "NL_LONG_DESC": "De WOOOD kast Lock (hxbxd) 195x140x53 cm is een 3-deurs kast met solide metalen scharnieren in de kleur wit. De kast is gemaakt van massief grenen hout m.u.v. de legplanken, middenwand, bodem- en bovenplaat, deze zijn van spaanplaat bekleedt met witte folie en de achterwand is van wit gelakt hardboard. De 3 deuren van de kast hebben een verticale V-groef lijn en dit gecombineerd met de accenten van een lockerkast geven de kast een stoere en landelijke uitstraling. Het interieur van de kast bestaat uit 5 spaanplaat legplanken en een middenwand bekleedt met witte folie en een roede. Deze kast Lock past in iedere ruimte. Achter de rechterdeur van de kast is de kast voorzien van 4 legplanken. Achter de linker- en middelste deur is de kast voorzien van één brede legplank bovenin en daaronder een brede roede. Deze kast is zo geconstrueerd dat deze uit te breiden is door middel van het koppelen van één of meerdere Lock 2-deurs of Lock 3-deurs uitvoering. Deze kledingkast Lock is ook in een 2-deurs uitvoering verkrijgbaar.\r\n\r\nLevering\r\nDeze kast wordt als bouwpakket geleverd en is makkelijk te monteren met behulp van de bijgeleverde montage instructie.",
         *                   "DE_LONG_DESC": null,
         *                   "FR_LONG_DESC": "",
         *                   "AANTAL_VERP": 1,
         *                   "SOURCE": null,
         *                   "MRP_RUN": "NA",
         *                   "CONSUMENTENPRIJS": 419,
         *                   "CONSUMENTENPRIJS_VAN": 0,
         *                   "ISE_CONSUMENTENPRIJS": 465,
         *                   "ISE_CONSUMENTENPRIJS_VAN": 0,
         *                   "GEWICHT": 88.5,
         *                   "NEW_ARRIVAL": false,
         *                   "VERPAK_DIKTE_MM": 0,
         *                   "VERPAK_LENGTE_MM": 0,
         *                   "VERPAK_BREEDTE_MM": 0,
         *                   "VOL_M3_VERP": 0.204,
         *                   "VRIJEVOORRAAD": 100,
         *                   "ASS_CODE_EXCLUSIV": "11",
         *                   "ATP": "14-09-2018",
         *                   "DFF_SHIPMENT": "POST",
         *                   "FSC": true,
         *                   "COUNTRY_OF_ORIGIN": "NL ",
         *                   "INTRASTAT_CODE": " 94035000",
         *                   "ASSEMBLY_REQUIRED": true,
         *                   "WEB_VAN_PRIJS_NL": 0,
         *                   "WEB_VAN_PRIJS_ISE": 0,
         *                   "AVAILABILITY_WEEK": "2018-37",
         *                   "PAKKETTEN": [
         *                       {
         *                           "ARTCODE_PAKKET": "P362101-GOW 1#4",
         *                           "ARTIKELCODE": "362101-GOW",
         *                           "CREATIONDATE": "2018-11-28",
         *                           "NL": "PAKKET 1#4 LOCK KAST 3-DEURS WIT [fsc]",
         *                           "EN": "P1#4 LOCK CABINET 3-DOOR WHITE PINE UNBRUSHED [fsc]",
         *                           "DE": "P1#4 LOCK SCHRANK 3-TÜRIG KIEFER UNGEBÜRSTET WEIß [fsc]",
         *                           "FR": "P1#4 ARMOIRE 3 PORTES PIN BLANC (FSC)",
         *                           "GEWICHT": 22.5,
         *                           "VERPAK_DIKTE_MM": 60,
         *                           "VERPAK_LENGTE_MM": 1430,
         *                           "VERPAK_BREEDTE_MM": 530,
         *                           "VOL_M3_VERP": 0.045474,
         *                           "VRIJEVOORRAADPAKKET": 170,
         *                           "ASS_CODE_EXCLUSIV": null,
         *                           "EANCODE_PAKKET": "8714713042869",
         *                           "AANTAL_PAKKETTEN": 1
         *                       },
         *                       ...
         *                  ]
         *              },
         *              ...
         *          ],
         *          "page_count": 428,
         *          "page_size": 25,
         *          "total_items": 1282,
         *          "page": 50
         *      }
         * @apiError (Error 4xx) {401} NotAuthorized The user is not authorized.
         * 
         */
        [Route("api/woood-productview/list")]
        [HttpGet]
        public IHttpActionResult GetProducts(int page = 1, int limit = 25)
        {
            try
            {
                var result = productRepository.List("ARTIKELCODE_ASC", limit, page);

                var products = new List<Product>();
                foreach (var item in result.Results)
                {
                    var product = CreateProduct(item);

                    // Get the packages which belong to this product, if AANTAL_PAKKETTEN > 1
                    if (item.AANTAL_PAKKETTEN > 1)
                    {
                        var packageItems = packageRepository.ListByArtikelCode(item.ARTIKELCODE);

                        foreach (var packageItem in packageItems)
                        {
                            var package = CreatePackage(packageItem);

                            product.PAKKETTEN.Add(package);
                        }
                    }
                    else // Create a package like main product
                    {
                        var package = CreatePackage(item);

                        product.PAKKETTEN.Add(package);
                    }

                    products.Add(product);
                }

                var collection = new PagedCollection<Product>()
                {
                    _embedded = products,
                    page_size = result.PageSize,
                    page = result.CurrentPage,
                    total_items = result.RowCount,
                    page_count = result.PageCount
                };

                logger.Log(ErrorType.INFO, "GetProducts()", RequestContext.Principal.Identity.Name, "Total in query: " + products.Count, "api/woood-productview/list", startDate);

                return Ok(collection);
            }
            catch (Exception e)
            {
                logger.Log(ErrorType.ERR, "GetProducts()", RequestContext.Principal.Identity.Name, e.Message, "api/woood-productview/list");

                return InternalServerError(e);
            }
        }

        [Route("api/woood-productview/list")]
        [HttpPost]
        public IHttpActionResult PostProducts(int page = 1, int limit = 25)
        {
            try
            {
                var result = productRepository.List("ARTIKELCODE_ASC", limit, page);

                var products = new List<Product>();
                foreach (var item in result.Results)
                {
                    var product = CreateProduct(item);

                    // Get the packages which belong to this product, if AANTAL_PAKKETTEN > 1
                    if (item.AANTAL_PAKKETTEN > 1)
                    {
                        var packageItems = packageRepository.ListByArtikelCode(item.ARTIKELCODE);

                        foreach (var packageItem in packageItems)
                        {
                            var package = CreatePackage(packageItem);

                            product.PAKKETTEN.Add(package);
                        }
                    }
                    else // Create a package like main product
                    {
                        var package = CreatePackage(item);

                        product.PAKKETTEN.Add(package);
                    }

                    products.Add(product);
                }

                var collection = new PagedCollection<Product>()
                {
                    _embedded = products,
                    page_size = result.PageSize,
                    page = result.CurrentPage,
                    total_items = result.RowCount,
                    page_count = result.PageCount
                };

                logger.Log(ErrorType.INFO, "GetProducts()", RequestContext.Principal.Identity.Name, "Total in query: " + products.Count, "api/woood-productview/list", startDate);

                return Ok(collection);
            }
            catch (Exception e)
            {
                logger.Log(ErrorType.ERR, "GetProducts()", RequestContext.Principal.Identity.Name, e.Message, "api/woood-productview/list");

                return InternalServerError(e);
            }
        }

        /**
         * @api {get} /api/woood-artikelview/view/artikelcode/{id} Request one product
         * @apiVersion 1.0.0
         * @apiName GetProductById
         * @apiGroup Products
         *
         * @apiHeader {String} Authorization Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)
         * 
         * @apiParam {String} artikelcode Article Code
         * 
         * @apiParamExample Request-Example:
         *      /api/woood-artikelview/view/artikelcode/378569-Z
         *      
         * @apiSuccess (200) {varchar(30)} ARTIKELCODE Article Code
         * @apiSuccess (200) {varchar(60)} NL Dutch short description
         * @apiSuccess (200) {varchar(60)} EN English short description
         * @apiSuccess (200) {varchar(60)} DE German short description
         * @apiSuccess (200) {varchar(60)} FR French short description
         * 
         * @apiSuccessExample {json} Success-Response:
         *      HTTP/1.1. 200 OK
         *      {
         *          "ARTIKELCODE": "375490",
         *          "CREATIONDATE": "2018-11-28",
         *          "DATEFROM": "2018-11-28",
         *          "NL": "RETRO BIJZETTAFEL MET 2 LADEN GRENEN WIT - EIKEN POTEN",
         *          "EN": "RETRO SIDETABLE WITH 2 DRAWERS PINE WITH - OAK",
         *          "DE": "RETRO BEISTELLTISCH WEIß",
         *          "FR": "RETRO TABLE D APPOINT PIN BLANC",
         *          "COLOR_FINISH": "WHITE",
         *          "MATERIAL": "PINE",
         *          "BRAND": "WOOOD",
         *          "ASSORTMENT": "LIVING",
         *          "PRODUCTGROUP_CODE": "P05",
         *          "PRODUCTGROUP": "TAFELS",
         *          "DEFAULT_SUBPRODUCTGROUP_CODE": "13",
         *          "DEFAULT_SUBPRODUCTGROUP_NAME": "COFFEE & SIDETABLES",
         *          "RANGE": "OTHER",
         *          "STATUS": "SALE",
         *          "EXCLUSIV": "FREE AVAILABLE",
         *          "VERKOOPPRIJS": 56.4,
         *          "VERKOOPEENHEID": "ST/PCS  ",
         *          "AANTAL_PAKKETTEN": 2,
         *          "AFMETING_ARTIKEL_HXBXD": "76x60x38",
         *          "EANCODE": "8714713052325",
         *          "EN_LONG_DESC": "This piece of furniture can be used multiple ways: side table, bedside table or storage cabinet. This practical side table is part of the Retro furniture series of the WOOOD brand. The Retro furniture is matched to each other in terms of design and is therefore easy to combine with each other. The series reminds you of the 70's and has a Scandinavian touch because of the exciting material combination. This article is supplied as a simple kit with clear assembly instructions.",
         *          "NL_LONG_DESC": "Multi inzetbaar is dit meubel: bijzettafel, nachtkastje ofopbergkastje. Deze praktische bijzettafel is onderdeel van de meubelserie Retro van het merk WOOOD. De meubels Retro zijn qua design op elkaar afgestemd en zijn daardoor goed met elkaar te combineren. De serie doet je denken aan de jaren 70 en heeft wegens de spannende materialencombi een Scandinavische touch. Dit artikel wordt geleverd als eenvoudig bouwpakket met duidelijke montagehandleiding.",
         *          "DE_LONG_DESC": null,
         *          "FR_LONG_DESC": "",
         *          "AANTAL_VERP": 1,
         *          "SOURCE": null,
         *          "MRP_RUN": "NA",
         *          "CONSUMENTENPRIJS": 119,
         *          "CONSUMENTENPRIJS_VAN": 149,
         *          "ISE_CONSUMENTENPRIJS": 135,
         *          "ISE_CONSUMENTENPRIJS_VAN": 165,
         *          "GEWICHT": 11.5,
         *          "NEW_ARRIVAL": false,
         *          "VERPAK_DIKTE_MM": 0,
         *          "VERPAK_LENGTE_MM": 0,
         *          "VERPAK_BREEDTE_MM": 0,
         *          "VOL_M3_VERP": 0.029,
         *          "VRIJEVOORRAAD": 4,
         *          "ASS_CODE_EXCLUSIV": "17",
         *          "ATP": null,
         *          "DFF_SHIPMENT": "POST",
         *          "FSC": false,
         *          "COUNTRY_OF_ORIGIN": "NL ",
         *          "INTRASTAT_CODE": " 94036010",
         *          "ASSEMBLY_REQUIRED": true,
         *          "WEB_VAN_PRIJS_NL": 0,
         *          "WEB_VAN_PRIJS_ISE": 0,
         *          "AVAILABILITY_WEEK": null,
         *          "PAKKETTEN": [
         *              {
         *                  "ARTCODE_PAKKET": "P375490 1#2",
         *                  "ARTIKELCODE": "375490",
         *                  "CREATIONDATE": "2018-11-28",
         *                  "DATEFROM": "2018-11-28",
         *                  "NL": "PAKKET 1#2 RETRO BIJZETTAFEL",
         *                  "EN": "1#2 RETRO SIDETABLE WITH 2 DRAWERS PINE WITH - OAK",
         *                  "DE": "1#2 RETRO BEISTELLTISCH WEIß",
         *                  "FR": "1#2 RETRO TABLE D APPOINT PIN BLANC",
         *                  "GEWICHT": 9.5,
         *                  "VERPAK_DIKTE_MM": 638,
         *                  "VERPAK_LENGTE_MM": 528,
         *                  "VERPAK_BREEDTE_MM": 68,
         *                  "VOL_M3_VERP": 0.022906752,
         *                  "VRIJEVOORRAADPAKKET": 4,
         *                  "ASS_CODE_EXCLUSIV": null,
         *                  "EANCODE_PAKKET": "8714713054817",
         *                  "AANTAL_PAKKETTEN": 1
         *              },
         *              ...
         *          ]
         *      }
         * 
         * @apiError (Error 4xx) {401} NotAuthorized The user is not authorized.
         * 
         */
        [Route("api/woood-productview/view/artikelcode/{id}")]
        [HttpGet]
        public IHttpActionResult GetProductById(string id)
        {
            try
            {
                var item = productRepository.GetById(id);

                if (item != null)
                {
                    var product = CreateProduct(item);

                    if (item.AANTAL_PAKKETTEN > 1)
                    {
                        var packageItems = packageRepository.ListByArtikelCode(item.ARTIKELCODE);

                        foreach (var packageItem in packageItems)
                        {
                            var package = CreatePackage(packageItem);

                            product.PAKKETTEN.Add(package);
                        }
                    }
                    else // Create a package like main product
                    {
                        var package = CreatePackage(item);

                        product.PAKKETTEN.Add(package);
                    }

                    logger.Log(ErrorType.INFO, "GetProductById(" + id + ")", RequestContext.Principal.Identity.Name, "", "api/woood-productview/view/artikelcode", startDate);

                    var products = new List<Product>();
                    products.Add(product);

                    return Ok(products);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                logger.Log(ErrorType.ERR, "GetProductById(" + id + ")", e.Message, "", "api/woood-productview/view/artikelcode/" + id);

                return InternalServerError(e);
            }
        }

        private Product CreateProduct(Logic.Models.Product item)
        {
            var product = new Product()
            {
                ARTIKELCODE = item.ARTIKELCODE,
                // CREATIONDATE = item.CREATIONDATE.ToString("yyyy-MM-dd"),
                CREATIONDATE = item.DATEFROM.ToString("yyyy-MM-dd"),
                // DATEFROM = item.DATEFROM.ToString("yyyy-MM-dd"),
                NL = item.NL,
                EN = item.EN,
                DE = item.DE,
                FR = item.FR,
                COLOR_FINISH = item.COLOR_FINISH,
                MATERIAL = item.MATERIAL,
                BRAND = item.BRAND,
                ASSORTMENT = item.ASSORTMENT,
                PRODUCTGROUP_CODE = item.PRODUCTGROUP_CODE,
                PRODUCTGROUP = item.PRODUCTGROUP,
                DEFAULT_SUBPRODUCTGROUP_CODE = item.DEFAULT_SUBPRODUCTGROUP_CODE,
                DEFAULT_SUBPRODUCTGROUP_NAME = item.DEFAULT_SUBPRODUCTGROUP_NAME,
                RANGE = item.RANGE,
                STATUS = item.STATUS,
                EXCLUSIV = item.EXCLUSIV,
                VERKOOPPRIJS = item.VERKOOPPRIJS,
                VERKOOPEENHEID = item.VERKOOPEENHEID,
                AANTAL_PAKKETTEN = item.AANTAL_PAKKETTEN,
                AFMETING_ARTIKEL_HXBXD = item.AFMETING_ARTIKEL_HXBXD,
                EANCODE = item.EANCODE,
                EN_LONG_DESC = item.EN_LONG_DESC != null ? item.EN_LONG_DESC : "",
                NL_LONG_DESC = item.NL_LONG_DESC != null ? item.NL_LONG_DESC : "",
                DE_LONG_DESC = item.DE_LONG_DESC != null ? item.DE_LONG_DESC : "",
                FR_LONG_DESC = item.FR_LONG_DESC != null ? item.FR_LONG_DESC : "",
                AANTAL_VERP = item.AANTAL_VERP,
                SOURCE = item.SOURCE,
                MRP_RUN = item.MRP_RUN,
                CONSUMENTENPRIJS = item.CONSUMENTENPRIJS,
                CONSUMENTENPRIJS_VAN = item.CONSUMENTENPRIJS_VAN,
                ISE_CONSUMENTENPRIJS = item.ISE_CONSUMENTENPRIJS,
                ISE_CONSUMENTENPRIJS_VAN = item.ISE_CONSUMENTENPRIJS_VAN,
                GEWICHT = item.GEWICHT,
                NEW_ARRIVAL = Convert.ToInt32(item.NEW_ARRIVAL),
                VERPAK_DIKTE_MM = item.VERPAK_DIKTE_MM,
                VERPAK_LENGTE_MM = item.VERPAK_LENGTE_MM,
                VERPAK_BREEDTE_MM = item.VERPAK_BREEDTE_MM,
                VOL_M3_VERP = item.VOL_M3_VERP,
                VRIJEVOORRAAD = item.VRIJEVOORRAAD,
                ASS_CODE_EXCLUSIV = item.ASS_CODE_EXCLUSIV,
                ATP = item.ATP,
                DFF_SHIPMENT = item.DFF_SHIPMENT,
                FSC = Convert.ToInt32(item.FSC),
                COUNTRY_OF_ORIGIN = item.COUNTRY_OF_ORIGIN,
                INTRASTAT_CODE = item.INTRASTAT_CODE,
                ASSEMBLY_REQUIRED = Convert.ToInt32(item.ASSEMBLY_REQUIRED),
                WEB_VAN_PRIJS_NL = item.WEB_VAN_PRIJS_NL,
                WEB_VAN_PRIJS_ISE = item.WEB_VAN_PRIJS_ISE,
                AVAILABILITY_WEEK = item.AVAILABILITY_WEEK
            };

            return product;
        }

        private Package CreatePackage(Logic.Models.Package item)
        {
            var package = new Package()
            {
                ARTIKELCODE = item.ARTIKELCODE,
                // CREATIONDATE = item.CREATIONDATE.ToString("yyyy-MM-dd"),
                CREATIONDATE = item.DATEFROM.ToString("yyyy-MM-dd"),
                // DATEFROM = item.DATEFROM.ToString("yyyy-MM-dd"),
                ARTCODE_PAKKET = item.ARTCODE_PAKKET,
                NL = item.NL,
                EN = item.EN,
                DE = item.DE,
                FR = item.FR,
                GEWICHT = item.GEWICHT,
                VERPAK_DIKTE_MM = item.VERPAK_DIKTE_MM,
                VERPAK_LENGTE_MM = item.VERPAK_LENGTE_MM,
                VERPAK_BREEDTE_MM = item.VERPAK_BREEDTE_MM,
                VOL_M3_VERP = item.VOL_M3_VERP,
                VRIJEVOORRAADPAKKET = item.VRIJEVOORRAADPAKKET,
                ASS_CODE_EXCLUSIV = item.ASS_CODE_EXCLUSIV != null ? item.ASS_CODE_EXCLUSIV : "0",
                EANCODE_PAKKET = item.EANCODE_PAKKET,
                AANTAL_PAKKETTEN = item.AANTAL_PAKKETTEN
            };

            return package;
        }

        private Package CreatePackage(Logic.Models.Product item)
        {
            var package = new Package()
            {
                ARTIKELCODE = item.ARTIKELCODE,
                // CREATIONDATE = item.CREATIONDATE.ToString("yyyy-MM-dd"),
                CREATIONDATE = item.DATEFROM.ToString("yyyy-MM-dd"),
                // DATEFROM = item.DATEFROM.ToString("yyyy-MM-dd"),
                ARTCODE_PAKKET = item.ARTIKELCODE,
                NL = item.NL,
                EN = item.EN,
                DE = item.DE,
                FR = item.FR,
                GEWICHT = item.GEWICHT,
                VERPAK_DIKTE_MM = item.VERPAK_DIKTE_MM,
                VERPAK_LENGTE_MM = item.VERPAK_LENGTE_MM,
                VERPAK_BREEDTE_MM = item.VERPAK_BREEDTE_MM,
                VOL_M3_VERP = item.VOL_M3_VERP,
                VRIJEVOORRAADPAKKET = item.VRIJEVOORRAAD,
                ASS_CODE_EXCLUSIV = item.ASS_CODE_EXCLUSIV,
                EANCODE_PAKKET = item.EANCODE,
                AANTAL_PAKKETTEN = item.AANTAL_PAKKETTEN
            };

            return package;
        }
    }
}
