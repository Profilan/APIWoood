define({ "api": [
  {
    "type": "get",
    "url": "/api/woood-artikelview/view/artikelcode/:id",
    "title": "Request one item",
    "version": "1.0.0",
    "name": "GetArticleById",
    "group": "Articles",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "String",
            "optional": false,
            "field": "Authorization",
            "description": "<p>Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)</p>"
          }
        ]
      }
    },
    "parameter": {
      "examples": [
        {
          "title": "Request-Example:",
          "content": "/api/woood-artikelview/view/artikelcode/378569-Z",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1. 200 OK\n{\n    \"ARTIKELCODE\": \"375490\",\n    \"CREATIONDATE\": \"2018-11-28\",\n    \"NL\": \"RETRO BIJZETTAFEL MET 2 LADEN GRENEN WIT - EIKEN POTEN\",\n    \"EN\": \"RETRO SIDETABLE WITH 2 DRAWERS PINE WITH - OAK\",\n    \"DE\": \"RETRO BEISTELLTISCH WEIß\",\n    \"FR\": \"RETRO TABLE D APPOINT PIN BLANC\",\n    \"COLOR_FINISH\": \"WHITE\",\n    \"MATERIAL\": \"PINE\",\n    \"BRAND\": \"WOOOD\",\n    \"ASSORTMENT\": \"LIVING\",\n    \"PRODUCTGROUP_CODE\": \"P05\",\n    \"PRODUCTGROUP\": \"TAFELS\",\n    \"DEFAULT_SUBPRODUCTGROUP_CODE\": \"13\",\n    \"DEFAULT_SUBPRODUCTGROUP_NAME\": \"COFFEE & SIDETABLES\",\n    \"RANGE\": \"OTHER\",\n    \"STATUS\": \"SALE\",\n    \"EXCLUSIV\": \"FREE AVAILABLE\",\n    \"VERKOOPPRIJS\": 56.4,\n    \"VERKOOPEENHEID\": \"ST/PCS  \",\n    \"AANTAL_PAKKETTEN\": 2,\n    \"AFMETING_ARTIKEL_HXBXD\": \"76x60x38\",\n    \"EANCODE\": \"8714713052325\",\n    \"EN_LONG_DESC\": \"This piece of furniture can be used multiple ways: side table, bedside table or storage cabinet. This practical side table is part of the Retro furniture series of the WOOOD brand. The Retro furniture is matched to each other in terms of design and is therefore easy to combine with each other. The series reminds you of the 70's and has a Scandinavian touch because of the exciting material combination. This article is supplied as a simple kit with clear assembly instructions.\",\n    \"NL_LONG_DESC\": \"Multi inzetbaar is dit meubel: bijzettafel, nachtkastje ofopbergkastje. Deze praktische bijzettafel is onderdeel van de meubelserie Retro van het merk WOOOD. De meubels Retro zijn qua design op elkaar afgestemd en zijn daardoor goed met elkaar te combineren. De serie doet je denken aan de jaren 70 en heeft wegens de spannende materialencombi een Scandinavische touch. Dit artikel wordt geleverd als eenvoudig bouwpakket met duidelijke montagehandleiding.\",\n    \"DE_LONG_DESC\": null,\n    \"FR_LONG_DESC\": \"\",\n    \"AANTAL_VERP\": 1,\n    \"SOURCE\": null,\n    \"MRP_RUN\": \"NA\",\n    \"CONSUMENTENPRIJS\": 119,\n    \"CONSUMENTENPRIJS_VAN\": 149,\n    \"ISE_CONSUMENTENPRIJS\": 135,\n    \"ISE_CONSUMENTENPRIJS_VAN\": 165,\n    \"GEWICHT\": 11.5,\n    \"NEW_ARRIVAL\": false,\n    \"VERPAK_DIKTE_MM\": 0,\n    \"VERPAK_LENGTE_MM\": 0,\n    \"VERPAK_BREEDTE_MM\": 0,\n    \"VOL_M3_VERP\": 0.029,\n    \"VRIJEVOORRAAD\": 4,\n    \"ASS_CODE_EXCLUSIV\": \"17\",\n    \"ATP\": null,\n    \"DFF_SHIPMENT\": \"POST\",\n    \"FSC\": false,\n    \"COUNTRY_OF_ORIGIN\": \"NL \",\n    \"INTRASTAT_CODE\": \" 94036010\",\n    \"ASSEMBLY_REQUIRED\": true,\n    \"WEB_VAN_PRIJS_NL\": 0,\n    \"WEB_VAN_PRIJS_ISE\": 0,\n    \"AVAILABILITY_WEEK\": null,\n    \"PAKKETTEN\": [\n        {\n            \"ARTCODE_PAKKET\": \"P375490 1#2\",\n            \"ARTIKELCODE\": \"375490\",\n            \"CREATIONDATE\": \"2018-11-28\",\n            \"NL\": \"PAKKET 1#2 RETRO BIJZETTAFEL\",\n            \"EN\": \"1#2 RETRO SIDETABLE WITH 2 DRAWERS PINE WITH - OAK\",\n            \"DE\": \"1#2 RETRO BEISTELLTISCH WEIß\",\n            \"FR\": \"1#2 RETRO TABLE D APPOINT PIN BLANC\",\n            \"GEWICHT\": 9.5,\n            \"VERPAK_DIKTE_MM\": 638,\n            \"VERPAK_LENGTE_MM\": 528,\n            \"VERPAK_BREEDTE_MM\": 68,\n            \"VOL_M3_VERP\": 0.022906752,\n            \"VRIJEVOORRAADPAKKET\": 4,\n            \"ASS_CODE_EXCLUSIV\": null,\n            \"EANCODE_PAKKET\": \"8714713054817\",\n            \"AANTAL_PAKKETTEN\": 1\n        },\n        ...\n    ]\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "type": "401",
            "optional": false,
            "field": "NotAuthorized",
            "description": "<p>The user is not authorized.</p>"
          }
        ]
      }
    },
    "filename": "./Controllers/Api/ProductController.cs",
    "groupTitle": "Articles"
  },
  {
    "type": "get",
    "url": "/api/woood-artikelview/list",
    "title": "Request list of items (non-paged)",
    "version": "1.0.0",
    "name": "GetArticles",
    "group": "Articles",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "String",
            "optional": false,
            "field": "Authorization",
            "description": "<p>Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)</p>"
          }
        ]
      }
    },
    "parameter": {
      "examples": [
        {
          "title": "Request-Example:",
          "content": "/api/woood-artikelview/list",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1. 200 OK\n[\n    {\n        \"ARTIKELCODE\": \"375490\",\n        \"CREATIONDATE\": \"2018-11-28\",\n        \"NL\": \"RETRO BIJZETTAFEL MET 2 LADEN GRENEN WIT - EIKEN POTEN\",\n        \"EN\": \"RETRO SIDETABLE WITH 2 DRAWERS PINE WITH - OAK\",\n        \"DE\": \"RETRO BEISTELLTISCH WEIß\",\n        \"FR\": \"RETRO TABLE D APPOINT PIN BLANC\",\n        \"COLOR_FINISH\": \"WHITE\",\n        \"MATERIAL\": \"PINE\",\n        \"BRAND\": \"WOOOD\",\n        \"ASSORTMENT\": \"LIVING\",\n        \"PRODUCTGROUP_CODE\": \"P05\",\n        \"PRODUCTGROUP\": \"TAFELS\",\n        \"DEFAULT_SUBPRODUCTGROUP_CODE\": \"13\",\n        \"DEFAULT_SUBPRODUCTGROUP_NAME\": \"COFFEE & SIDETABLES\",\n        \"RANGE\": \"OTHER\",\n        \"STATUS\": \"SALE\",\n        \"EXCLUSIV\": \"FREE AVAILABLE\",\n        \"VERKOOPPRIJS\": 56.4,\n        \"VERKOOPEENHEID\": \"ST/PCS  \",\n        \"AANTAL_PAKKETTEN\": 2,\n        \"AFMETING_ARTIKEL_HXBXD\": \"76x60x38\",\n        \"EANCODE\": \"8714713052325\",\n        \"EN_LONG_DESC\": \"This piece of furniture can be used multiple ways: side table, bedside table or storage cabinet. This practical side table is part of the Retro furniture series of the WOOOD brand. The Retro furniture is matched to each other in terms of design and is therefore easy to combine with each other. The series reminds you of the 70's and has a Scandinavian touch because of the exciting material combination. This article is supplied as a simple kit with clear assembly instructions.\",\n        \"NL_LONG_DESC\": \"Multi inzetbaar is dit meubel: bijzettafel, nachtkastje ofopbergkastje. Deze praktische bijzettafel is onderdeel van de meubelserie Retro van het merk WOOOD. De meubels Retro zijn qua design op elkaar afgestemd en zijn daardoor goed met elkaar te combineren. De serie doet je denken aan de jaren 70 en heeft wegens de spannende materialencombi een Scandinavische touch. Dit artikel wordt geleverd als eenvoudig bouwpakket met duidelijke montagehandleiding.\",\n        \"DE_LONG_DESC\": null,\n        \"FR_LONG_DESC\": \"\",\n        \"AANTAL_VERP\": 1,\n        \"SOURCE\": null,\n        \"MRP_RUN\": \"NA\",\n        \"CONSUMENTENPRIJS\": 119,\n        \"CONSUMENTENPRIJS_VAN\": 149,\n        \"ISE_CONSUMENTENPRIJS\": 135,\n        \"ISE_CONSUMENTENPRIJS_VAN\": 165,\n        \"GEWICHT\": 11.5,\n        \"NEW_ARRIVAL\": false,\n        \"VERPAK_DIKTE_MM\": 0,\n        \"VERPAK_LENGTE_MM\": 0,\n        \"VERPAK_BREEDTE_MM\": 0,\n        \"VOL_M3_VERP\": 0.029,\n        \"VRIJEVOORRAAD\": 4,\n        \"ASS_CODE_EXCLUSIV\": \"17\",\n        \"ATP\": null,\n        \"DFF_SHIPMENT\": \"POST\",\n        \"FSC\": false,\n        \"COUNTRY_OF_ORIGIN\": \"NL \",\n        \"INTRASTAT_CODE\": \" 94036010\",\n        \"ASSEMBLY_REQUIRED\": true,\n        \"WEB_VAN_PRIJS_NL\": 0,\n        \"WEB_VAN_PRIJS_ISE\": 0,\n        \"AVAILABILITY_WEEK\": null,\n        \"PAKKETTEN\": [\n            {\n                \"ARTCODE_PAKKET\": \"P375490 1#2\",\n                \"ARTIKELCODE\": \"375490\",\n                \"CREATIONDATE\": \"2018-11-28\",\n                \"NL\": \"PAKKET 1#2 RETRO BIJZETTAFEL\",\n                \"EN\": \"1#2 RETRO SIDETABLE WITH 2 DRAWERS PINE WITH - OAK\",\n                \"DE\": \"1#2 RETRO BEISTELLTISCH WEIß\",\n                \"FR\": \"1#2 RETRO TABLE D APPOINT PIN BLANC\",\n                \"GEWICHT\": 9.5,\n                \"VERPAK_DIKTE_MM\": 638,\n                \"VERPAK_LENGTE_MM\": 528,\n                \"VERPAK_BREEDTE_MM\": 68,\n                \"VOL_M3_VERP\": 0.022906752,\n                \"VRIJEVOORRAADPAKKET\": 4,\n                \"ASS_CODE_EXCLUSIV\": null,\n                \"EANCODE_PAKKET\": \"8714713054817\",\n                \"AANTAL_PAKKETTEN\": 1\n            },\n            ...\n        ]\n    },\n    ...\n]",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "type": "401",
            "optional": false,
            "field": "NotAuthorized",
            "description": "<p>The user is not authorized.</p>"
          }
        ]
      }
    },
    "filename": "./Controllers/Api/ProductController.cs",
    "groupTitle": "Articles"
  },
  {
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "optional": false,
            "field": "varname1",
            "description": "<p>No type.</p>"
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "varname2",
            "description": "<p>With type.</p>"
          }
        ]
      }
    },
    "type": "",
    "url": "",
    "version": "0.0.0",
    "filename": "./doc/main.js",
    "group": "C__Users_raymond_source_repos_APIWoood_APIWoood_doc_main_js",
    "groupTitle": "C__Users_raymond_source_repos_APIWoood_APIWoood_doc_main_js",
    "name": ""
  },
  {
    "success": {
      "fields": {
        "Success 200": [
          {
            "group": "Success 200",
            "optional": false,
            "field": "varname1",
            "description": "<p>No type.</p>"
          },
          {
            "group": "Success 200",
            "type": "String",
            "optional": false,
            "field": "varname2",
            "description": "<p>With type.</p>"
          }
        ]
      }
    },
    "type": "",
    "url": "",
    "version": "0.0.0",
    "filename": "./obj/Release/Package/PackageTmp/doc/main.js",
    "group": "C__Users_raymond_source_repos_APIWoood_APIWoood_obj_Release_Package_PackageTmp_doc_main_js",
    "groupTitle": "C__Users_raymond_source_repos_APIWoood_APIWoood_obj_Release_Package_PackageTmp_doc_main_js",
    "name": ""
  },
  {
    "type": "get",
    "url": "/api/dashboard",
    "title": "Request Dashboard information",
    "version": "1.0.0",
    "name": "GetDashboard",
    "group": "Dashboard",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "String",
            "optional": false,
            "field": "Authorization",
            "description": "<p>Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)</p>"
          }
        ]
      }
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "debcode",
            "description": "<p>Debtor Code</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "apikey",
            "description": "<p>Unique key for the user</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "/api/dashboard?debcode=000504&apikey=fftt2sQjjaiSXnX2Qnvr3XnahdDB3ZRDLTnRtpJr",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1. 200 OK\n{\n    \"Quantity\": {\n        \"Year\": {\n            \"Items\": [\n                {\n                    \"EAN\": \"8714713056163\",\n                    \"Amount\": 993\n                },\n                {\n                    \"EAN\": \"8714713057887\",\n                    \"Amount\": 875\n                },\n                ...\n            ],\n        \"Quarter\":\n            \"Items\": [\n                {\n                    \"EAN\": \"8714713056163\",\n                    \"Amount\": 993\n                },\n                {\n                    \"EAN\": \"8714713057887\",\n                    \"Amount\": 875\n                },\n                ...\n            ],\n        \"Month\":\n            \"Items\": [\n                {\n                    \"EAN\": \"8714713056163\",\n                    \"Amount\": 993\n                },\n                {\n                    \"EAN\": \"8714713057887\",\n                    \"Amount\": 875\n                },\n                ...\n            ]\n    },\n    \"Sales\": {\n        \"Year\": {\n            \"Items\": [\n                {\n                    \"EAN\": \"8714713056163\",\n                    \"Amount\": 993\n                },\n                {\n                    \"EAN\": \"8714713057887\",\n                    \"Amount\": 875\n                },\n                ...\n            ],\n        \"Quarter\":\n            \"Items\": [\n                {\n                    \"EAN\": \"8714713056163\",\n                    \"Amount\": 993\n                },\n                {\n                    \"EAN\": \"8714713057887\",\n                    \"Amount\": 875\n                },\n                ...\n            ],\n        \"Month\":\n            \"Items\": [\n                {\n                    \"EAN\": \"8714713056163\",\n                    \"Amount\": 993\n                },\n                {\n                    \"EAN\": \"8714713057887\",\n                    \"Amount\": 875\n                },\n                ...\n            ]\n        }\n    }\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "type": "401",
            "optional": false,
            "field": "NotAuthorized",
            "description": "<p>The user is not authorized.</p>"
          },
          {
            "group": "Error 4xx",
            "type": "404",
            "optional": false,
            "field": "NotFound",
            "description": "<p>There are no records for this debtor.</p>"
          }
        ]
      }
    },
    "filename": "./Controllers/Api/DashboardController.cs",
    "groupTitle": "Dashboard"
  },
  {
    "type": "get",
    "url": "/api/woood-deb-order-info/view/debiteurnr/{debiteurnr}?page={page}&limit={limit}",
    "title": "Request debtor orders by debtor",
    "version": "1.0.0",
    "name": "GetDebtorOrderById",
    "group": "DebtorOrders",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "String",
            "optional": false,
            "field": "Authorization",
            "description": "<p>Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)</p>"
          }
        ]
      }
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "debiteurnr",
            "description": "<p>Debtor number</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "page",
            "description": "<p>Page to show</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": true,
            "field": "limit",
            "defaultValue": "25",
            "description": "<p>Number of products on a page</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "/api/woood-deb-order-info/view/debiteurnr/000201?page=1&limit=25",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1. 200 OK\n{\n    \"_embedded\": [\n        {\n            \"ID\": 3241705,\n            \"ORDERNR\": \"54294159\",\n            \"DEBNR\": \"000201\",\n            \"FAKDEBNR\": \"000201\",\n            \"REFERENTIE\": \"TEST 54294159\",\n            \"OMSCHRIJVING\": \"TEST BUITENLAND\",\n            \"ORDDAT\": \"2016-08-16T00:00:00\",\n            \"AANTAL_BESTELD\": 1,\n            \"ITEMCODE\": \"XXXXXX\",\n            \"AFLEVERDATUM\": \"2016-08-16T00:00:00\",\n            \"OMSCHRIJVING_NL\": \"DUMMY ARTIKEL\",\n            \"OMSCHRIJVING_EN\": \"DUMMY ARTICLE\",\n            \"OMSCHRIJVING_DE\": null,\n            \"AANTAL_GELEV\": 1,\n            \"STATUS\": 1,\n            \"DEL_LANDCODE\": \"DE \",\n            \"SELCODE\": \"DE\",\n            \"PRIJS_PER_STUK\": 0,\n            \"SUBTOTAAL\": 0\n        },\n        ...\n    ],\n    \"page_count\": 3901,\n    \"page_size\": 25,\n    \"total_items\": 97518,\n    \"page\": 1\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "type": "401",
            "optional": false,
            "field": "NotAuthorized",
            "description": "<p>The user is not authorized.</p>"
          }
        ]
      }
    },
    "filename": "./Controllers/Api/DebtorOrderController.cs",
    "groupTitle": "DebtorOrders"
  },
  {
    "type": "get",
    "url": "/api/woood-deb-order-info/list",
    "title": "Request non-paged list of debtors",
    "version": "1.0.0",
    "name": "GetDebtors",
    "group": "DebtorOrders",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "String",
            "optional": false,
            "field": "Authorization",
            "description": "<p>Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)</p>"
          }
        ]
      }
    },
    "parameter": {
      "examples": [
        {
          "title": "Request-Example:",
          "content": "/api/woood-debtors/list",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1. 200 OK\n[\n        {\n            \"ID\": 3241705,\n            \"ORDERNR\": \"54294159\",\n            \"DEBNR\": \"000201\",\n            \"FAKDEBNR\": \"000201\",\n            \"REFERENTIE\": \"TEST 54294159\",\n            \"OMSCHRIJVING\": \"TEST BUITENLAND\",\n            \"ORDDAT\": \"2016-08-16T00:00:00\",\n            \"AANTAL_BESTELD\": 1,\n            \"ITEMCODE\": \"XXXXXX\",\n            \"AFLEVERDATUM\": \"2016-08-16T00:00:00\",\n            \"OMSCHRIJVING_NL\": \"DUMMY ARTIKEL\",\n            \"OMSCHRIJVING_EN\": \"DUMMY ARTICLE\",\n            \"OMSCHRIJVING_DE\": null,\n            \"AANTAL_GELEV\": 1,\n            \"STATUS\": 1,\n            \"DEL_LANDCODE\": \"DE \",\n            \"SELCODE\": \"DE\",\n            \"PRIJS_PER_STUK\": 0,\n            \"SUBTOTAAL\": 0\n        },\n        ...\n    ]",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "type": "401",
            "optional": false,
            "field": "NotAuthorized",
            "description": "<p>The user is not authorized.</p>"
          }
        ]
      }
    },
    "filename": "./Controllers/Api/DebtorOrderController.cs",
    "groupTitle": "DebtorOrders"
  },
  {
    "type": "get",
    "url": "/api/woood-deb-order-info/list?page={page}&limit={limit}",
    "title": "Request paged list of debtor orders",
    "version": "1.0.0",
    "name": "GetPagedDebtorOrders",
    "group": "DebtorOrders",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "String",
            "optional": false,
            "field": "Authorization",
            "description": "<p>Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)</p>"
          }
        ]
      }
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "page",
            "description": "<p>Page to show</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": true,
            "field": "limit",
            "defaultValue": "25",
            "description": "<p>Number of products on a page</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "/api/woood-deb-order-info/list?page=1&limit=25",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1. 200 OK\n{\n    \"_embedded\": [\n        {\n            \"ID\": 3241705,\n            \"ORDERNR\": \"54294159\",\n            \"DEBNR\": \"000201\",\n            \"FAKDEBNR\": \"000201\",\n            \"REFERENTIE\": \"TEST 54294159\",\n            \"OMSCHRIJVING\": \"TEST BUITENLAND\",\n            \"ORDDAT\": \"2016-08-16T00:00:00\",\n            \"AANTAL_BESTELD\": 1,\n            \"ITEMCODE\": \"XXXXXX\",\n            \"AFLEVERDATUM\": \"2016-08-16T00:00:00\",\n            \"OMSCHRIJVING_NL\": \"DUMMY ARTIKEL\",\n            \"OMSCHRIJVING_EN\": \"DUMMY ARTICLE\",\n            \"OMSCHRIJVING_DE\": null,\n            \"AANT_GELEV\": 1,\n            \"STATUS\": 1,\n            \"DEL_LANDCODE\": \"DE \",\n            \"SELCODE\": \"DE\",\n            \"PRIJS_PER_STUK\": 0,\n            \"SUBTOTAAL\": 0\n        },\n        ...\n    ],\n    \"page_count\": 3901,\n    \"page_size\": 25,\n    \"total_items\": 97518,\n    \"page\": 1\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "type": "401",
            "optional": false,
            "field": "NotAuthorized",
            "description": "<p>The user is not authorized.</p>"
          }
        ]
      }
    },
    "filename": "./Controllers/Api/DebtorOrderController.cs",
    "groupTitle": "DebtorOrders"
  },
  {
    "type": "get",
    "url": "/api/woood-debtors/view/debiteurnr/{id}",
    "title": "Request debtor by id",
    "version": "1.0.0",
    "name": "GetDebtorById",
    "group": "Debtors",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "String",
            "optional": false,
            "field": "Authorization",
            "description": "<p>Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)</p>"
          }
        ]
      }
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "debiteurnr",
            "description": "<p>Debtor number</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "/api/woood-debtors/view/debiteurnr/000000",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1. 200 OK\n        {\n            \"DEBITEURNR\": \"000000\",\n            \"NAAM\": \"Unknown debtor EEKZWD\",\n            \"TYPE\": \"C\",\n            \"FAKTUURDEBITEURNR\": \"000000\",\n            \"CLASSIFICATIE\": \"CA \",\n            \"CLASS_OMS\": \"Corporate Account\",\n            \"BTWNR\": null,\n            \"BETALINGSCONDITIE\": \"09\",\n            \"BETALINGSCONDITIEOMS\": \"30 DAGEN NETTO\",\n            \"LEVERINGSWIJZE\": \"ZWA  \",\n            \"WOOOD_NL\": 0,\n            \"PORTAL\": 1,\n            \"FACTADRES\": \"Zaadmarkt 25\",\n            \"FACTPC\": \"1681PD\",\n            \"FACTPLAATS\": \"Zwaagdijk\",\n            \"FACTLANDCODE\": \"NL \",\n            \"FACTLAND\": \"NEDERLAND\",\n            \"BEZADRES\": \"Zaadmarkt 25\",\n            \"BEZPC\": \"1681PD\",\n            \"BEZPLAATS\": \"Zwaagdijk\",\n            \"BEZLANDCODE\": \"NL \",\n            \"BEZLAND\": \"NEDERLAND\",\n            \"AFLADRES\": \"Zaadmarkt 25\",\n            \"AFLPC\": \"1681PD\",\n            \"AFLPLAATS\": \"Zwaagdijk\",\n            \"AFLLANDCODE\": \"NL \",\n            \"AFLLAND\": \"NEDERLAND\",\n            \"POSTADRES\": \"Zaadmarkt 25\",\n            \"POSTPC\": \"1681PD\",\n            \"POSTPLAATS\": \"Zwaagdijk\",\n            \"POSTLANDCODE\": \"NL \",\n            \"POSTLAND\": \"NEDERLAND\",\n            \"CMP_NAME\": \"Unknown debtor EEKZWD\",\n            \"KVK\": null,\n            \"FRANCO_LIMIET\": 500,\n            \"MINIMUM_ORDER_LIMIET\": 250,\n            \"ORDER_TOESLAG\": 30,\n            \"ACCOUNTMANAGER\": 500491,\n            \"DFF_ACCESSCODE\": \"1681\",\n            \"OVERRIDE_LIMITS\": 0,\n            \"DEB_NAME_ALIAS\": null,\n            \"DEB_WWW_ALIAS\": null,\n            \"DEALER_ACTIVATION\": 0,\n            \"DEALER_BRANDS\": \"WOOOD;BEPUREHOME;VTWONEN\",\n            \"DEALER_TYPE\": \"DEALER;WEBSHOP\"\n        }",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "type": "401",
            "optional": false,
            "field": "NotAuthorized",
            "description": "<p>The user is not authorized.</p>"
          }
        ]
      }
    },
    "filename": "./Controllers/Api/DebtorController.cs",
    "groupTitle": "Debtors"
  },
  {
    "type": "get",
    "url": "/api/woood-debtors/list",
    "title": "Request non-paged list of debtors",
    "version": "1.0.0",
    "name": "GetDebtors",
    "group": "Debtors",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "String",
            "optional": false,
            "field": "Authorization",
            "description": "<p>Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)</p>"
          }
        ]
      }
    },
    "parameter": {
      "examples": [
        {
          "title": "Request-Example:",
          "content": "/api/woood-debtors/list",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1. 200 OK\n[\n        {\n            \"DEBITEURNR\": \"000000\",\n            \"NAAM\": \"Unknown debtor EEKZWD\",\n            \"TYPE\": \"C\",\n            \"FAKTUURDEBITEURNR\": \"000000\",\n            \"CLASSIFICATIE\": \"CA \",\n            \"CLASS_OMS\": \"Corporate Account\",\n            \"BTWNR\": null,\n            \"BETALINGSCONDITIE\": \"09\",\n            \"BETALINGSCONDITIEOMS\": \"30 DAGEN NETTO\",\n            \"LEVERINGSWIJZE\": \"ZWA  \",\n            \"WOOOD_NL\": 0,\n            \"PORTAL\": 1,\n            \"FACTADRES\": \"Zaadmarkt 25\",\n            \"FACTPC\": \"1681PD\",\n            \"FACTPLAATS\": \"Zwaagdijk\",\n            \"FACTLANDCODE\": \"NL \",\n            \"FACTLAND\": \"NEDERLAND\",\n            \"BEZADRES\": \"Zaadmarkt 25\",\n            \"BEZPC\": \"1681PD\",\n            \"BEZPLAATS\": \"Zwaagdijk\",\n            \"BEZLANDCODE\": \"NL \",\n            \"BEZLAND\": \"NEDERLAND\",\n            \"AFLADRES\": \"Zaadmarkt 25\",\n            \"AFLPC\": \"1681PD\",\n            \"AFLPLAATS\": \"Zwaagdijk\",\n            \"AFLLANDCODE\": \"NL \",\n            \"AFLLAND\": \"NEDERLAND\",\n            \"POSTADRES\": \"Zaadmarkt 25\",\n            \"POSTPC\": \"1681PD\",\n            \"POSTPLAATS\": \"Zwaagdijk\",\n            \"POSTLANDCODE\": \"NL \",\n            \"POSTLAND\": \"NEDERLAND\",\n            \"CMP_NAME\": \"Unknown debtor EEKZWD\",\n            \"KVK\": null,\n            \"FRANCO_LIMIET\": 500,\n            \"MINIMUM_ORDER_LIMIET\": 250,\n            \"ORDER_TOESLAG\": 30,\n            \"ACCOUNTMANAGER\": 500491,\n            \"DFF_ACCESSCODE\": \"1681\",\n            \"OVERRIDE_LIMITS\": 0,\n            \"DEB_NAME_ALIAS\": null,\n            \"DEB_WWW_ALIAS\": null,\n            \"DEALER_ACTIVATION\": 0,\n            \"DEALER_BRANDS\": \"WOOOD;BEPUREHOME;VTWONEN\",\n            \"DEALER_TYPE\": \"DEALER;WEBSHOP\"\n        },\n        ...\n    ]",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "type": "401",
            "optional": false,
            "field": "NotAuthorized",
            "description": "<p>The user is not authorized.</p>"
          }
        ]
      }
    },
    "filename": "./Controllers/Api/DebtorController.cs",
    "groupTitle": "Debtors"
  },
  {
    "type": "get",
    "url": "/api/woood-debtors/list?page={page}&limit={limit}",
    "title": "Request paged list of debtors",
    "version": "1.0.0",
    "name": "GetPagedDebtors",
    "group": "Debtors",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "String",
            "optional": false,
            "field": "Authorization",
            "description": "<p>Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)</p>"
          }
        ]
      }
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "page",
            "description": "<p>Page to show</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": true,
            "field": "limit",
            "defaultValue": "25",
            "description": "<p>Number of products on a page</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "/api/woood-debtors/list?page=1&limit=2",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1. 200 OK\n{\n    \"_embedded\": [\n        {\n            \"DEBITEURNR\": \"000000\",\n            \"NAAM\": \"Unknown debtor EEKZWD\",\n            \"TYPE\": \"C\",\n            \"FAKTUURDEBITEURNR\": \"000000\",\n            \"CLASSIFICATIE\": \"CA \",\n            \"CLASS_OMS\": \"Corporate Account\",\n            \"BTWNR\": null,\n            \"BETALINGSCONDITIE\": \"09\",\n            \"BETALINGSCONDITIEOMS\": \"30 DAGEN NETTO\",\n            \"LEVERINGSWIJZE\": \"ZWA  \",\n            \"WOOOD_NL\": 0,\n            \"PORTAL\": 1,\n            \"FACTADRES\": \"Zaadmarkt 25\",\n            \"FACTPC\": \"1681PD\",\n            \"FACTPLAATS\": \"Zwaagdijk\",\n            \"FACTLANDCODE\": \"NL \",\n            \"FACTLAND\": \"NEDERLAND\",\n            \"BEZADRES\": \"Zaadmarkt 25\",\n            \"BEZPC\": \"1681PD\",\n            \"BEZPLAATS\": \"Zwaagdijk\",\n            \"BEZLANDCODE\": \"NL \",\n            \"BEZLAND\": \"NEDERLAND\",\n            \"AFLADRES\": \"Zaadmarkt 25\",\n            \"AFLPC\": \"1681PD\",\n            \"AFLPLAATS\": \"Zwaagdijk\",\n            \"AFLLANDCODE\": \"NL \",\n            \"AFLLAND\": \"NEDERLAND\",\n            \"POSTADRES\": \"Zaadmarkt 25\",\n            \"POSTPC\": \"1681PD\",\n            \"POSTPLAATS\": \"Zwaagdijk\",\n            \"POSTLANDCODE\": \"NL \",\n            \"POSTLAND\": \"NEDERLAND\",\n            \"CMP_NAME\": \"Unknown debtor EEKZWD\",\n            \"KVK\": null,\n            \"FRANCO_LIMIET\": 500,\n            \"MINIMUM_ORDER_LIMIET\": 250,\n            \"ORDER_TOESLAG\": 30,\n            \"ACCOUNTMANAGER\": 500491,\n            \"DFF_ACCESSCODE\": \"1681\",\n            \"OVERRIDE_LIMITS\": 0,\n            \"DEB_NAME_ALIAS\": null,\n            \"DEB_WWW_ALIAS\": null,\n            \"DEALER_ACTIVATION\": 0,\n            \"DEALER_BRANDS\": \"WOOOD;BEPUREHOME;VTWONEN\",\n            \"DEALER_TYPE\": \"DEALER;WEBSHOP\"\n        },\n        ...\n    ],\n    \"page_count\": 3054,\n    \"page_size\": 2,\n    \"total_items\": 6108,\n    \"page\": 1\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "type": "401",
            "optional": false,
            "field": "NotAuthorized",
            "description": "<p>The user is not authorized.</p>"
          }
        ]
      }
    },
    "filename": "./Controllers/Api/DebtorController.cs",
    "groupTitle": "Debtors"
  },
  {
    "type": "get",
    "url": "/api/woood-leveringswijze/view/code/{code}",
    "title": "Request Delivery Method by Code",
    "version": "1.0.0",
    "name": "GetDeliveryMethodByCode",
    "group": "DeliveryMethods",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "String",
            "optional": false,
            "field": "Authorization",
            "description": "<p>Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)</p>"
          }
        ]
      }
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "code",
            "description": "<p>Code of the Delivery Method</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "/api/woood-leveringswijze/view/code/001",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1. 200 OK\n    {\n        \"CODE\": \"001  \",\n        \"NL_DESC\": \"Afgehaald door ontvanger\",\n        \"EN_DESC\": null,\n        \"DE_DESC\": null,\n        \"FR_DESC\": null\n    }",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "type": "401",
            "optional": false,
            "field": "NotAuthorized",
            "description": "<p>The user is not authorized.</p>"
          }
        ]
      }
    },
    "filename": "./Controllers/Api/DeliveryMethodController.cs",
    "groupTitle": "DeliveryMethods"
  },
  {
    "type": "get",
    "url": "/api/woood-leveringswijze/list",
    "title": "Request Delivery Method List",
    "version": "1.0.0",
    "name": "GetDeliveryMethods",
    "group": "DeliveryMethods",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "String",
            "optional": false,
            "field": "Authorization",
            "description": "<p>Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)</p>"
          }
        ]
      }
    },
    "parameter": {
      "examples": [
        {
          "title": "Request-Example:",
          "content": "/api/woood-leveringswijze/list",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1. 200 OK\n[\n    {\n        \"CODE\": \"001  \",\n        \"NL_DESC\": \"Afgehaald door ontvanger\",\n        \"EN_DESC\": null,\n        \"DE_DESC\": null,\n        \"FR_DESC\": null\n    },\n    {\n        \"CODE\": \"1    \",\n        \"NL_DESC\": \"FRANKO HUIS                             \",\n        \"EN_DESC\": \"FREE HOUSE DELIVERY\",\n        \"DE_DESC\": \"FREI HAUS\",\n        \"FR_DESC\": null\n    },\n    ...\n]",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "type": "401",
            "optional": false,
            "field": "NotAuthorized",
            "description": "<p>The user is not authorized.</p>"
          }
        ]
      }
    },
    "filename": "./Controllers/Api/DeliveryMethodController.cs",
    "groupTitle": "DeliveryMethods"
  },
  {
    "type": "post",
    "url": "/api/woood-order/create",
    "title": "Create orders",
    "version": "1.0.0",
    "name": "CreateOrders",
    "group": "Orders",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "String",
            "optional": false,
            "field": "Authorization",
            "description": "<p>Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)</p>"
          }
        ]
      }
    },
    "parameter": {
      "fields": {
        "Authentication": [
          {
            "group": "Authentication",
            "type": "String",
            "optional": false,
            "field": "api-key",
            "description": "<p>Unique key for the user</p>"
          },
          {
            "group": "Authentication",
            "type": "String",
            "optional": false,
            "field": "username",
            "description": "<p>Username of the user</p>"
          },
          {
            "group": "Authentication",
            "type": "String",
            "optional": false,
            "field": "password",
            "description": "<p>Password of the user</p>"
          }
        ],
        "Order": [
          {
            "group": "Order",
            "type": "String",
            "optional": false,
            "field": "REFERENTIE",
            "description": "<p>Reference</p>"
          },
          {
            "group": "Order",
            "type": "String",
            "optional": false,
            "field": "DEBITEURNR",
            "description": "<p>Debtor Number</p>"
          },
          {
            "group": "Order",
            "type": "String",
            "optional": true,
            "field": "OMSCHRIJVING",
            "description": "<p>Description</p>"
          },
          {
            "group": "Order",
            "type": "Int",
            "optional": true,
            "field": "ACCEPTATIE_VERZAMELEN",
            "defaultValue": "0",
            "description": "<p>Acceptance Collect</p>"
          },
          {
            "group": "Order",
            "type": "Int",
            "optional": true,
            "field": "ACCEPTATIE_ORDERKOSTEN",
            "defaultValue": "0",
            "description": "<p>Acceptance of Order Costs</p>"
          },
          {
            "group": "Order",
            "type": "Int",
            "optional": true,
            "field": "ACCEPTATIE_ORDERSPLITSING",
            "defaultValue": "0",
            "description": "<p>Acceptance of Order Splitting</p>"
          },
          {
            "group": "Order",
            "type": "String",
            "optional": true,
            "field": "SELECTIECODE",
            "description": "<p>Selection Code</p>"
          },
          {
            "group": "Order",
            "type": "String",
            "optional": true,
            "field": "ORDERTOELICHTING",
            "description": "<p>Order Explanation</p>"
          },
          {
            "group": "Order",
            "type": "String",
            "optional": true,
            "field": "DS_NAAM",
            "description": "<p>Delivery Name</p>"
          },
          {
            "group": "Order",
            "type": "String",
            "optional": true,
            "field": "DS_AANSPREEKTITEL",
            "description": "<p>Delivery Gender</p>"
          },
          {
            "group": "Order",
            "type": "String",
            "optional": true,
            "field": "DS_ADRES1",
            "description": "<p>Delivery Address</p>"
          },
          {
            "group": "Order",
            "type": "String",
            "optional": true,
            "field": "DS_POSTCODE",
            "description": "<p>Delivery Postcode</p>"
          },
          {
            "group": "Order",
            "type": "String",
            "optional": true,
            "field": "DS_PLAATS",
            "description": "<p>Delivery City</p>"
          },
          {
            "group": "Order",
            "type": "String",
            "optional": true,
            "field": "DS_LAND",
            "description": "<p>Delivery Country</p>"
          },
          {
            "group": "Order",
            "type": "String",
            "optional": true,
            "field": "DS_TELEFOON",
            "description": "<p>Delivery Phone</p>"
          },
          {
            "group": "Order",
            "type": "String",
            "optional": true,
            "field": "DS_EMAIL",
            "description": "<p>Delivery E-mail</p>"
          },
          {
            "group": "Order",
            "type": "String",
            "optional": true,
            "field": "SR_SERVICE_PRODUCT",
            "description": "<p>Product code of selected product</p>"
          },
          {
            "group": "Order",
            "type": "String",
            "optional": true,
            "field": "SR_AFLEVEREN_AAN",
            "description": "<p>Desired Delivery Address of service part =&gt; B2B (=&quot;RETAILER&quot;) or Consumer (=&quot;CONSUMER&quot;)</p>"
          },
          {
            "group": "Order",
            "type": "String",
            "optional": true,
            "field": "SR_LOCATIE",
            "description": "<p>Location =&gt; Online (=&quot;ONLINE&quot;) or Shop (=&quot;SHOP&quot;)</p>"
          },
          {
            "group": "Order",
            "type": "String",
            "optional": true,
            "field": "SR_BEDRIJFSNAAM",
            "description": "<p>Company Name</p>"
          },
          {
            "group": "Order",
            "type": "String",
            "optional": true,
            "field": "SR_BEWIJS",
            "description": "<p>Proof =&gt; Manual (=&quot;MANUAL) or Copy (=&quot;COPY&quot;)</p>"
          },
          {
            "group": "Order",
            "type": "String",
            "optional": true,
            "field": "SR_ORDERREF",
            "description": "<p>Order Number</p>"
          },
          {
            "group": "Order",
            "type": "String",
            "optional": true,
            "field": "SR_REDEN",
            "description": "<p>Reason</p>"
          },
          {
            "group": "Order",
            "type": "String",
            "optional": true,
            "field": "SR_TOELICHTING",
            "description": "<p>Explanation</p>"
          },
          {
            "group": "Order",
            "type": "String",
            "optional": true,
            "field": "SR_PDF_ATTACHMENT",
            "description": "<p>PDF Attachment</p>"
          },
          {
            "group": "Order",
            "type": "Int",
            "optional": true,
            "field": "PAYMENT_RELEASE_REQUIRED",
            "defaultValue": "0",
            "description": "<p>Payment Release Required</p>"
          }
        ],
        "OrderItem": [
          {
            "group": "OrderItem",
            "type": "String",
            "optional": false,
            "field": "ITEMCODE",
            "description": "<p>Product Code</p>"
          },
          {
            "group": "OrderItem",
            "type": "String",
            "optional": false,
            "field": "AANTAL",
            "description": "<p>Quantity</p>"
          },
          {
            "group": "OrderItem",
            "type": "String",
            "optional": true,
            "field": "VERZENDWEEK",
            "description": "<p>Shipping Week</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "/api/woood-order/create?apikey=fftt2sQjjaiSXnX2Qnvr3XnahdDB3ZRDLTnRtpJr",
          "type": "json"
        }
      ]
    },
    "examples": [
      {
        "title": "Example usage:",
        "content": "{\n     \"header\":\n     {\n         \"api-key\": \"Yi7h9j0gWq4kUX2pPyaYkdNkmu\",\n         \"username\": \"pixel\",\n         \"password\": \"wachtwoord\"\n     },\n     \"body\":\n     {\n         \"order\":[\n             {\n                 \"REFERENTIE\": \"TEST_ORDER_F6u16dKf_5\",\n                 \"OMSCHRIJVING\": \"TEST_ORDER_F6u16dKf\",\n                 \"DEBITEURNR\": \"160405\",\n                 \"SELECTIECODE\": \"CA\",\n                 \"ORDERTOELICHTING\": \"EffectConnect\",\n                 \"DS_NAAM\": \"Jules Dohmen (TESTORDER)\",\n                 \"DS_AANSPREEKTITEL\": \"M\",\n                 \"DS_ADRES1\": \"Tolhuisweg 5A\",\n                 \"DS_POSTCODE\": \"6071RG\",\n                 \"DS_PLAATS\": \"Swalmen\",\n                 \"DS_LAND\": \"NL\",\n                 \"DS_TELEFOON\": \"0859021855\",\n                 \"DS_EMAIL\": \"Info@koekenpeer.nl\",\n                 \"item\": [\n                     {\n                         \"ITEMCODE\": \"341206-Z\",\n                         \"AANTAL\": 1\n                     }\n                 ]\n             }\n         ]\n     }\n}",
        "type": "json"
      }
    ],
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1. 200 OK\n{\n    \"body\": {\n        \"references\": [\n            \"0123456789\"\n            ...\n        ]\n    }\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "type": "400",
            "optional": false,
            "field": "Required",
            "description": "<p>field is missing.</p>"
          },
          {
            "group": "Error 4xx",
            "type": "401",
            "optional": false,
            "field": "NotAuthorized",
            "description": "<p>The user is not authorized.</p>"
          },
          {
            "group": "Error 4xx",
            "type": "409",
            "optional": false,
            "field": "Conflict",
            "description": "<p>The combination of DEBITEURNR and REFERENTIE must be unique.</p>"
          }
        ]
      }
    },
    "filename": "./Controllers/Api/OrderController.cs",
    "groupTitle": "Orders"
  },
  {
    "type": "get",
    "url": "/api/woood-betalingsconditie/view/code/{code}",
    "title": "Request Payment Condition by Code",
    "version": "1.0.0",
    "name": "GetPaymentConditionByCode",
    "group": "PaymentConditions",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "String",
            "optional": false,
            "field": "Authorization",
            "description": "<p>Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)</p>"
          }
        ]
      }
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "code",
            "description": "<p>Code of the Payment Condition</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "/api/woood-betalingsconditie/view/code/74",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1. 200 OK\n    {\n        \"CODE\": \"74\",\n        \"NL_DESC\": \"opennl\",\n        \"EN_DESC\": \"en\",\n        \"DE_DESC\": \"de\",\n        \"FR_DESC\": \"fr\"\n    }",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "type": "401",
            "optional": false,
            "field": "NotAuthorized",
            "description": "<p>The user is not authorized.</p>"
          }
        ]
      }
    },
    "filename": "./Controllers/Api/PaymentConditionController.cs",
    "groupTitle": "PaymentConditions"
  },
  {
    "type": "get",
    "url": "/api/woood-betalingsconditie/list",
    "title": "Request Payment Condition List",
    "version": "1.0.0",
    "name": "GetPaymentConditions",
    "group": "PaymentConditions",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "String",
            "optional": false,
            "field": "Authorization",
            "description": "<p>Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)</p>"
          }
        ]
      }
    },
    "parameter": {
      "examples": [
        {
          "title": "Request-Example:",
          "content": "/api/woood-betalingsconditie/list",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1. 200 OK\n[\n    {\n        \"CODE\": \"74\",\n        \"NL_DESC\": \"opennl\",\n        \"EN_DESC\": \"en\",\n        \"DE_DESC\": \"de\",\n        \"FR_DESC\": \"fr\"\n    },\n    ...\n]",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "type": "401",
            "optional": false,
            "field": "NotAuthorized",
            "description": "<p>The user is not authorized.</p>"
          }
        ]
      }
    },
    "filename": "./Controllers/Api/PaymentConditionController.cs",
    "groupTitle": "PaymentConditions"
  },
  {
    "type": "post",
    "url": "/api/woood-payment-release/create",
    "title": "Create Payment Release",
    "version": "1.0.0",
    "name": "CreatePaymentRelease",
    "group": "PaymentReleases",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "String",
            "optional": false,
            "field": "Authorization",
            "description": "<p>Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)</p>"
          }
        ]
      }
    },
    "parameter": {
      "fields": {
        "Authentication": [
          {
            "group": "Authentication",
            "type": "String",
            "optional": false,
            "field": "api-key",
            "description": "<p>Unique key for the user</p>"
          },
          {
            "group": "Authentication",
            "type": "String",
            "optional": false,
            "field": "username",
            "description": "<p>Username of the user</p>"
          },
          {
            "group": "Authentication",
            "type": "String",
            "optional": false,
            "field": "password",
            "description": "<p>Password of the user</p>"
          }
        ],
        "Order": [
          {
            "group": "Order",
            "type": "String",
            "optional": false,
            "field": "REFERENTIE",
            "description": "<p>Reference</p>"
          },
          {
            "group": "Order",
            "type": "String",
            "optional": false,
            "field": "DEBITEURNR",
            "description": "<p>Debtor Number</p>"
          },
          {
            "group": "Order",
            "type": "Int",
            "optional": false,
            "field": "PAYMENT_RELEASE",
            "description": "<p>Release Payment</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "/api/woood-order/create?apikey=fftt2sQjjaiSXnX2Qnvr3XnahdDB3ZRDLTnRtpJr",
          "type": "json"
        }
      ]
    },
    "examples": [
      {
        "title": "Example usage:",
        "content": "{\n     \"header\":\n     {\n         \"api-key\": \"Yi7h9j0gWq4kUX2pPyaYkdNkmu\",\n         \"username\": \"pixel\",\n         \"password\": \"wachtwoord\"\n     },\n     \"body\":\n     {\n             {\n                 \"REFERENTIE\": \"TEST_ORDER_F6u16dKf_5\",\n                 \"DEBITEURNR\": \"160405\",\n                 \"PAYMENT_RELEASE\": \"1\"\n             }\n     }\n}",
        "type": "json"
      }
    ],
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1. 200 OK\n{\n    \"body\": {\n        \"message\": \"The Release Payment was succesfully added\"\n    }\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "type": "400",
            "optional": false,
            "field": "Required",
            "description": "<p>field is missing.</p>"
          },
          {
            "group": "Error 4xx",
            "type": "401",
            "optional": false,
            "field": "NotAuthorized",
            "description": "<p>The user is not authorized.</p>"
          },
          {
            "group": "Error 4xx",
            "type": "409",
            "optional": false,
            "field": "DEBITEURNR-REFERENTIE",
            "description": "<p>UNKNOWN.</p>"
          }
        ]
      }
    },
    "filename": "./Controllers/Api/PaymentReleaseController.cs",
    "groupTitle": "PaymentReleases"
  },
  {
    "type": "get",
    "url": "/api/woood-pricelist/list?page={page}&limit={limit}",
    "title": "Request paged list of debtor orders",
    "version": "1.0.0",
    "name": "GetPricelists",
    "group": "Pricelists",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "String",
            "optional": false,
            "field": "Authorization",
            "description": "<p>Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)</p>"
          }
        ]
      }
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "page",
            "description": "<p>Page to show</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": true,
            "field": "limit",
            "defaultValue": "25",
            "description": "<p>Number of products on a page</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "/api/woood-pricelist/list?page=1&limit=25",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1. 200 OK\n{\n    \"_embedded\": [\n        {\n            \"ID\": 3241705,\n            \"ORDERNR\": \"54294159\",\n            \"DEBNR\": \"000201\",\n            \"FAKDEBNR\": \"000201\",\n            \"REFERENTIE\": \"TEST 54294159\",\n            \"OMSCHRIJVING\": \"TEST BUITENLAND\",\n            \"ORDDAT\": \"2016-08-16T00:00:00\",\n            \"AANTAL_BESTELD\": 1,\n            \"ITEMCODE\": \"XXXXXX\",\n            \"AFLEVERDATUM\": \"2016-08-16T00:00:00\",\n            \"OMSCHRIJVING_NL\": \"DUMMY ARTIKEL\",\n            \"OMSCHRIJVING_EN\": \"DUMMY ARTICLE\",\n            \"OMSCHRIJVING_DE\": null,\n            \"AANT_GELEV\": 1,\n            \"STATUS\": 1,\n            \"DEL_LANDCODE\": \"DE \",\n            \"SELCODE\": \"DE\",\n            \"PRIJS_PER_STUK\": 0,\n            \"SUBTOTAAL\": 0\n        },\n        ...\n    ],\n    \"page_count\": 3901,\n    \"page_size\": 25,\n    \"total_items\": 97518,\n    \"page\": 1\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "type": "401",
            "optional": false,
            "field": "NotAuthorized",
            "description": "<p>The user is not authorized.</p>"
          }
        ]
      }
    },
    "filename": "./Controllers/Api/PricelistController.cs",
    "groupTitle": "Pricelists"
  },
  {
    "type": "get",
    "url": "/api/woood-pricelist/view/debiteurnr/{debiteurnr}?page={page}&limit={limit}",
    "title": "Request pricelists by debtor",
    "version": "1.0.0",
    "name": "GetPricelistsByDebtor",
    "group": "Pricelists",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "String",
            "optional": false,
            "field": "Authorization",
            "description": "<p>Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)</p>"
          }
        ]
      }
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "debiteurnr",
            "description": "<p>Debtor number</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "page",
            "description": "<p>Page to show</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": true,
            "field": "limit",
            "defaultValue": "25",
            "description": "<p>Number of products on a page</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "/api/woood-pricelist/view/debiteurnr/000201?page=1&limit=25",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1. 200 OK\n{\n    \"_embedded\": [\n        {\n            \"ID\": 3241705,\n            \"ORDERNR\": \"54294159\",\n            \"DEBNR\": \"000201\",\n            \"FAKDEBNR\": \"000201\",\n            \"REFERENTIE\": \"TEST 54294159\",\n            \"OMSCHRIJVING\": \"TEST BUITENLAND\",\n            \"ORDDAT\": \"2016-08-16T00:00:00\",\n            \"AANTAL_BESTELD\": 1,\n            \"ITEMCODE\": \"XXXXXX\",\n            \"AFLEVERDATUM\": \"2016-08-16T00:00:00\",\n            \"OMSCHRIJVING_NL\": \"DUMMY ARTIKEL\",\n            \"OMSCHRIJVING_EN\": \"DUMMY ARTICLE\",\n            \"OMSCHRIJVING_DE\": null,\n            \"AANT_GELEV\": 1,\n            \"STATUS\": 1,\n            \"DEL_LANDCODE\": \"DE \",\n            \"SELCODE\": \"DE\",\n            \"PRIJS_PER_STUK\": 0,\n            \"SUBTOTAAL\": 0\n        },\n        ...\n    ],\n    \"page_count\": 3901,\n    \"page_size\": 25,\n    \"total_items\": 97518,\n    \"page\": 1\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "type": "401",
            "optional": false,
            "field": "NotAuthorized",
            "description": "<p>The user is not authorized.</p>"
          }
        ]
      }
    },
    "filename": "./Controllers/Api/PricelistController.cs",
    "groupTitle": "Pricelists"
  },
  {
    "type": "get",
    "url": "/api/woood-assortimenten-view/list/id/{ass}",
    "title": "Request list of product ranges by range",
    "version": "1.0.0",
    "name": "GetProductRangeByRange",
    "group": "ProductRanges",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "String",
            "optional": false,
            "field": "Authorization",
            "description": "<p>Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)</p>"
          }
        ]
      }
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "ass",
            "description": "<p>Range (Default = 9)</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "/api/woood-assortimenten-view/list/id/9",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1. 200 OK\n[\n    {\n        \"ASS\": 9,\n        \"CODE\": \"10\",\n        \"OMSCHRIJVING\": \"LEENBAKKER [NL-BE-LU]\"\n    },\n    {\n        \"ASS\": 9,\n        \"CODE\": \"10B\",\n        \"OMSCHRIJVING\": \"LEENBAKKER [NL]\"\n    },\n    {\n        \"ASS\": 9,\n        \"CODE\": \"11\",\n        \"OMSCHRIJVING\": \"KARWEI [NL]\"\n    },\n    ...\n]",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "type": "401",
            "optional": false,
            "field": "NotAuthorized",
            "description": "<p>The user is not authorized.</p>"
          }
        ]
      }
    },
    "filename": "./Controllers/Api/ProductRangeController.cs",
    "groupTitle": "ProductRanges"
  },
  {
    "type": "get",
    "url": "/api/woood-artikelview/view/artikelcode/{id}",
    "title": "Request one product",
    "version": "1.0.0",
    "name": "GetProductById",
    "group": "Products",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "String",
            "optional": false,
            "field": "Authorization",
            "description": "<p>Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)</p>"
          }
        ]
      }
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "artikelcode",
            "description": "<p>Article Code</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "/api/woood-artikelview/view/artikelcode/378569-Z",
          "type": "json"
        }
      ]
    },
    "success": {
      "fields": {
        "200": [
          {
            "group": "200",
            "type": "varchar(30)",
            "optional": false,
            "field": "ARTIKELCODE",
            "description": "<p>Article Code</p>"
          },
          {
            "group": "200",
            "type": "varchar(60)",
            "optional": false,
            "field": "NL",
            "description": "<p>Dutch short description</p>"
          },
          {
            "group": "200",
            "type": "varchar(60)",
            "optional": false,
            "field": "EN",
            "description": "<p>English short description</p>"
          },
          {
            "group": "200",
            "type": "varchar(60)",
            "optional": false,
            "field": "DE",
            "description": "<p>German short description</p>"
          },
          {
            "group": "200",
            "type": "varchar(60)",
            "optional": false,
            "field": "FR",
            "description": "<p>French short description</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1. 200 OK\n{\n    \"ARTIKELCODE\": \"375490\",\n    \"CREATIONDATE\": \"2018-11-28\",\n    \"NL\": \"RETRO BIJZETTAFEL MET 2 LADEN GRENEN WIT - EIKEN POTEN\",\n    \"EN\": \"RETRO SIDETABLE WITH 2 DRAWERS PINE WITH - OAK\",\n    \"DE\": \"RETRO BEISTELLTISCH WEIß\",\n    \"FR\": \"RETRO TABLE D APPOINT PIN BLANC\",\n    \"COLOR_FINISH\": \"WHITE\",\n    \"MATERIAL\": \"PINE\",\n    \"BRAND\": \"WOOOD\",\n    \"ASSORTMENT\": \"LIVING\",\n    \"PRODUCTGROUP_CODE\": \"P05\",\n    \"PRODUCTGROUP\": \"TAFELS\",\n    \"DEFAULT_SUBPRODUCTGROUP_CODE\": \"13\",\n    \"DEFAULT_SUBPRODUCTGROUP_NAME\": \"COFFEE & SIDETABLES\",\n    \"RANGE\": \"OTHER\",\n    \"STATUS\": \"SALE\",\n    \"EXCLUSIV\": \"FREE AVAILABLE\",\n    \"VERKOOPPRIJS\": 56.4,\n    \"VERKOOPEENHEID\": \"ST/PCS  \",\n    \"AANTAL_PAKKETTEN\": 2,\n    \"AFMETING_ARTIKEL_HXBXD\": \"76x60x38\",\n    \"EANCODE\": \"8714713052325\",\n    \"EN_LONG_DESC\": \"This piece of furniture can be used multiple ways: side table, bedside table or storage cabinet. This practical side table is part of the Retro furniture series of the WOOOD brand. The Retro furniture is matched to each other in terms of design and is therefore easy to combine with each other. The series reminds you of the 70's and has a Scandinavian touch because of the exciting material combination. This article is supplied as a simple kit with clear assembly instructions.\",\n    \"NL_LONG_DESC\": \"Multi inzetbaar is dit meubel: bijzettafel, nachtkastje ofopbergkastje. Deze praktische bijzettafel is onderdeel van de meubelserie Retro van het merk WOOOD. De meubels Retro zijn qua design op elkaar afgestemd en zijn daardoor goed met elkaar te combineren. De serie doet je denken aan de jaren 70 en heeft wegens de spannende materialencombi een Scandinavische touch. Dit artikel wordt geleverd als eenvoudig bouwpakket met duidelijke montagehandleiding.\",\n    \"DE_LONG_DESC\": null,\n    \"FR_LONG_DESC\": \"\",\n    \"AANTAL_VERP\": 1,\n    \"SOURCE\": null,\n    \"MRP_RUN\": \"NA\",\n    \"CONSUMENTENPRIJS\": 119,\n    \"CONSUMENTENPRIJS_VAN\": 149,\n    \"ISE_CONSUMENTENPRIJS\": 135,\n    \"ISE_CONSUMENTENPRIJS_VAN\": 165,\n    \"GEWICHT\": 11.5,\n    \"NEW_ARRIVAL\": false,\n    \"VERPAK_DIKTE_MM\": 0,\n    \"VERPAK_LENGTE_MM\": 0,\n    \"VERPAK_BREEDTE_MM\": 0,\n    \"VOL_M3_VERP\": 0.029,\n    \"VRIJEVOORRAAD\": 4,\n    \"ASS_CODE_EXCLUSIV\": \"17\",\n    \"ATP\": null,\n    \"DFF_SHIPMENT\": \"POST\",\n    \"FSC\": false,\n    \"COUNTRY_OF_ORIGIN\": \"NL \",\n    \"INTRASTAT_CODE\": \" 94036010\",\n    \"ASSEMBLY_REQUIRED\": true,\n    \"WEB_VAN_PRIJS_NL\": 0,\n    \"WEB_VAN_PRIJS_ISE\": 0,\n    \"AVAILABILITY_WEEK\": null,\n    \"PAKKETTEN\": [\n        {\n            \"ARTCODE_PAKKET\": \"P375490 1#2\",\n            \"ARTIKELCODE\": \"375490\",\n            \"CREATIONDATE\": \"2018-11-28\",\n            \"NL\": \"PAKKET 1#2 RETRO BIJZETTAFEL\",\n            \"EN\": \"1#2 RETRO SIDETABLE WITH 2 DRAWERS PINE WITH - OAK\",\n            \"DE\": \"1#2 RETRO BEISTELLTISCH WEIß\",\n            \"FR\": \"1#2 RETRO TABLE D APPOINT PIN BLANC\",\n            \"GEWICHT\": 9.5,\n            \"VERPAK_DIKTE_MM\": 638,\n            \"VERPAK_LENGTE_MM\": 528,\n            \"VERPAK_BREEDTE_MM\": 68,\n            \"VOL_M3_VERP\": 0.022906752,\n            \"VRIJEVOORRAADPAKKET\": 4,\n            \"ASS_CODE_EXCLUSIV\": null,\n            \"EANCODE_PAKKET\": \"8714713054817\",\n            \"AANTAL_PAKKETTEN\": 1\n        },\n        ...\n    ]\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "type": "401",
            "optional": false,
            "field": "NotAuthorized",
            "description": "<p>The user is not authorized.</p>"
          }
        ]
      }
    },
    "filename": "./Controllers/Api/ProductController.cs",
    "groupTitle": "Products"
  },
  {
    "type": "get",
    "url": "/api/woood-productview/list",
    "title": "Request Product information (paged)",
    "version": "1.0.0",
    "name": "GetProducts",
    "group": "Products",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "String",
            "optional": false,
            "field": "Authorization",
            "description": "<p>Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)</p>"
          }
        ]
      }
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": true,
            "field": "page",
            "defaultValue": "1",
            "description": "<p>Page to show</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": true,
            "field": "limit",
            "defaultValue": "25",
            "description": "<p>Number of products on a page</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "/api/woood-productview/list?page=2&limit=50",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1. 200 OK\n{\n    \"_embedded\": [\n         {\n             \"ARTIKELCODE\": \"362101-GOW\",\n             \"CREATIONDATE\": \"2018-11-28\",\n             \"NL\": \"LOCK KAST 3-DEURS WIT [fsc]\",\n             \"EN\": \"LOCK CABINET 3-DOOR WHITE PINE UNBRUSHED [fsc]\",\n             \"DE\": \"LOCK SCHRANK 3-TÜRIG KIEFER UNGEBÜRSTET WEIß [fsc]\",\n             \"FR\": \"LOCK ARMOIRE 3 PORTES PIN BLANC (FSC)\",\n             \"COLOR_FINISH\": \"WHITE\",\n             \"MATERIAL\": \"PINE\",\n             \"BRAND\": \"WOOOD\",\n             \"ASSORTMENT\": \"LIVING\",\n             \"PRODUCTGROUP_CODE\": \"P04\",\n             \"PRODUCTGROUP\": \"OPBERGEN\",\n             \"DEFAULT_SUBPRODUCTGROUP_CODE\": \"19\",\n             \"DEFAULT_SUBPRODUCTGROUP_NAME\": \"WARDROBES & BEDROOM STORAGE\",\n             \"RANGE\": \"COLLECTION\",\n             \"STATUS\": \"COLLECTION\",\n             \"EXCLUSIV\": \"KARWEI [NL]\",\n             \"VERKOOPPRIJS\": 205.5,\n             \"VERKOOPEENHEID\": \"ST/PCS  \",\n             \"AANTAL_PAKKETTEN\": 4,\n             \"AFMETING_ARTIKEL_HXBXD\": \"195x140x53\",\n             \"EANCODE\": \"8714713040681\",\n             \"EN_LONG_DESC\": \"The WOOOD cabinet Lock (hxbxd) 195x140x53 cm is a 3-door cabinet with solid metal hinges in the color white. The cabinet is made of solid pine except the shelves, middle panel, bottom and top panel, these are made of chipboard covered with white foil. The back panel is of white lacquered hardboard. The 3 doors of the cabinet have a vertical V-groove line and this combined with the accents of a locker cabinet give the cabinet a tough and rural look. The interior of the cabinet consists of 5 chipboard shelves and a middle wall covered with white foil and a rod. This Lock cupboard fits into any space. Behind the right door of the cabinet is the cabinet with 4 shelves. Behind the left and middle door is the cabinet with one wide shelf at the top and a wide rod underneath. This cabinet has been designed in such a way that it can be expanded by connecting one or more Lock 2 doors or Lock 3 door versions. This wardrobe Lock is also available in a 2-door version. This cabinet is delivered as seperate elements and is easy to assemble using the supplied assembly instructions.\",\n             \"NL_LONG_DESC\": \"De WOOOD kast Lock (hxbxd) 195x140x53 cm is een 3-deurs kast met solide metalen scharnieren in de kleur wit. De kast is gemaakt van massief grenen hout m.u.v. de legplanken, middenwand, bodem- en bovenplaat, deze zijn van spaanplaat bekleedt met witte folie en de achterwand is van wit gelakt hardboard. De 3 deuren van de kast hebben een verticale V-groef lijn en dit gecombineerd met de accenten van een lockerkast geven de kast een stoere en landelijke uitstraling. Het interieur van de kast bestaat uit 5 spaanplaat legplanken en een middenwand bekleedt met witte folie en een roede. Deze kast Lock past in iedere ruimte. Achter de rechterdeur van de kast is de kast voorzien van 4 legplanken. Achter de linker- en middelste deur is de kast voorzien van één brede legplank bovenin en daaronder een brede roede. Deze kast is zo geconstrueerd dat deze uit te breiden is door middel van het koppelen van één of meerdere Lock 2-deurs of Lock 3-deurs uitvoering. Deze kledingkast Lock is ook in een 2-deurs uitvoering verkrijgbaar.\\r\\n\\r\\nLevering\\r\\nDeze kast wordt als bouwpakket geleverd en is makkelijk te monteren met behulp van de bijgeleverde montage instructie.\",\n             \"DE_LONG_DESC\": null,\n             \"FR_LONG_DESC\": \"\",\n             \"AANTAL_VERP\": 1,\n             \"SOURCE\": null,\n             \"MRP_RUN\": \"NA\",\n             \"CONSUMENTENPRIJS\": 419,\n             \"CONSUMENTENPRIJS_VAN\": 0,\n             \"ISE_CONSUMENTENPRIJS\": 465,\n             \"ISE_CONSUMENTENPRIJS_VAN\": 0,\n             \"GEWICHT\": 88.5,\n             \"NEW_ARRIVAL\": false,\n             \"VERPAK_DIKTE_MM\": 0,\n             \"VERPAK_LENGTE_MM\": 0,\n             \"VERPAK_BREEDTE_MM\": 0,\n             \"VOL_M3_VERP\": 0.204,\n             \"VRIJEVOORRAAD\": 100,\n             \"ASS_CODE_EXCLUSIV\": \"11\",\n             \"ATP\": \"14-09-2018\",\n             \"DFF_SHIPMENT\": \"POST\",\n             \"FSC\": true,\n             \"COUNTRY_OF_ORIGIN\": \"NL \",\n             \"INTRASTAT_CODE\": \" 94035000\",\n             \"ASSEMBLY_REQUIRED\": true,\n             \"WEB_VAN_PRIJS_NL\": 0,\n             \"WEB_VAN_PRIJS_ISE\": 0,\n             \"AVAILABILITY_WEEK\": \"2018-37\",\n             \"PAKKETTEN\": [\n                 {\n                     \"ARTCODE_PAKKET\": \"P362101-GOW 1#4\",\n                     \"ARTIKELCODE\": \"362101-GOW\",\n                     \"CREATIONDATE\": \"2018-11-28\",\n                     \"NL\": \"PAKKET 1#4 LOCK KAST 3-DEURS WIT [fsc]\",\n                     \"EN\": \"P1#4 LOCK CABINET 3-DOOR WHITE PINE UNBRUSHED [fsc]\",\n                     \"DE\": \"P1#4 LOCK SCHRANK 3-TÜRIG KIEFER UNGEBÜRSTET WEIß [fsc]\",\n                     \"FR\": \"P1#4 ARMOIRE 3 PORTES PIN BLANC (FSC)\",\n                     \"GEWICHT\": 22.5,\n                     \"VERPAK_DIKTE_MM\": 60,\n                     \"VERPAK_LENGTE_MM\": 1430,\n                     \"VERPAK_BREEDTE_MM\": 530,\n                     \"VOL_M3_VERP\": 0.045474,\n                     \"VRIJEVOORRAADPAKKET\": 170,\n                     \"ASS_CODE_EXCLUSIV\": null,\n                     \"EANCODE_PAKKET\": \"8714713042869\",\n                     \"AANTAL_PAKKETTEN\": 1\n                 },\n                 ...\n            ]\n        },\n        ...\n    ],\n    \"page_count\": 428,\n    \"page_size\": 25,\n    \"total_items\": 1282,\n    \"page\": 50\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "type": "401",
            "optional": false,
            "field": "NotAuthorized",
            "description": "<p>The user is not authorized.</p>"
          }
        ]
      }
    },
    "filename": "./Controllers/Api/ProductController.cs",
    "groupTitle": "Products"
  },
  {
    "type": "get",
    "url": "/api/woood-verkooppunt-view/view/artikelcode/{artikelcode}",
    "title": "Request list of selling points by article",
    "version": "1.0.0",
    "name": "GetSellingPointByArticle",
    "group": "SellingPoints",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "String",
            "optional": false,
            "field": "Authorization",
            "description": "<p>Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)</p>"
          }
        ]
      }
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "artikelcode",
            "description": "<p>Article code</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "/api/woood-verkooppunt-view/view/artikelcode/340358",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1. 200 OK\n[\n    {\n        \"ARTIKELCODE\": \"340358\",\n        \"FACTUURDEBITEURNR\": \"28\",\n        \"FACTUURDEBITEURNAAM\": \"GIGA MEUBEL\",\n        \"FACTUURDEBITEUR_NAAM_ALIAS\": \"Giga Meubel Soest\",\n        \"FACTUURDEBITEURWEB\": \"WWW.GIGAMEUBEL.NL\",\n        \"FACTUURDEBITEUR_WEB_ALIAS\": \"www.gigameubel.nl\",\n        \"FACTUURDEBITEURLAND\": \"NL\"\n    },\n    {\n        \"ARTIKELCODE\": \"340358\",\n        \"FACTUURDEBITEURNR\": \"107275\",\n        \"FACTUURDEBITEURNAAM\": \"FONQ.nl B.V.\",\n        \"FACTUURDEBITEUR_NAAM_ALIAS\": \"FonQ.nl\",\n        \"FACTUURDEBITEURWEB\": \"www.fonq.nl\",\n        \"FACTUURDEBITEUR_WEB_ALIAS\": \"www.fonq.nl\",\n        \"FACTUURDEBITEURLAND\": \"NL\"\n    },\n    ...\n]",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "type": "401",
            "optional": false,
            "field": "NotAuthorized",
            "description": "<p>The user is not authorized.</p>"
          }
        ]
      }
    },
    "filename": "./Controllers/Api/SellingPointController.cs",
    "groupTitle": "SellingPoints"
  },
  {
    "type": "get",
    "url": "/api/woood-verkooppunt-view/list",
    "title": "Request list of selling points",
    "version": "1.0.0",
    "name": "GetSellingPoints",
    "group": "SellingPoints",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "String",
            "optional": false,
            "field": "Authorization",
            "description": "<p>Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)</p>"
          }
        ]
      }
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "apikey",
            "description": "<p>Unique key for the user</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "/api/woood-verkooppunt-view/list",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1. 200 OK\n[\n    {\n        \"ARTIKELCODE\": \"340358\",\n        \"FACTUURDEBITEURNR\": \"28\",\n        \"FACTUURDEBITEURNAAM\": \"GIGA MEUBEL\",\n        \"FACTUURDEBITEUR_NAAM_ALIAS\": \"Giga Meubel Soest\",\n        \"FACTUURDEBITEURWEB\": \"WWW.GIGAMEUBEL.NL\",\n        \"FACTUURDEBITEUR_WEB_ALIAS\": \"www.gigameubel.nl\",\n        \"FACTUURDEBITEURLAND\": \"NL\"\n    },\n    {\n        \"ARTIKELCODE\": \"340358\",\n        \"FACTUURDEBITEURNR\": \"107275\",\n        \"FACTUURDEBITEURNAAM\": \"FONQ.nl B.V.\",\n        \"FACTUURDEBITEUR_NAAM_ALIAS\": \"FonQ.nl\",\n        \"FACTUURDEBITEURWEB\": \"www.fonq.nl\",\n        \"FACTUURDEBITEUR_WEB_ALIAS\": \"www.fonq.nl\",\n        \"FACTUURDEBITEURLAND\": \"NL\"\n    },\n    ...\n]",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "type": "401",
            "optional": false,
            "field": "NotAuthorized",
            "description": "<p>The user is not authorized.</p>"
          }
        ]
      }
    },
    "filename": "./Controllers/Api/SellingPointController.cs",
    "groupTitle": "SellingPoints"
  },
  {
    "type": "get",
    "url": "/api/stock-data/{id}",
    "title": "Request Stock Data by Itemcode",
    "version": "1.0.0",
    "name": "GetStockDataByItemcode",
    "group": "StockData",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "String",
            "optional": false,
            "field": "Authorization",
            "description": "<p>Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)</p>"
          }
        ]
      }
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "apikey",
            "description": "<p>Api Key provided by De Eekhoorn Woodworkings B.V.</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "itemcode",
            "description": "<p>Item Code</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "/api/stock-data/001-ANT?apikey=0123456789abc",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1. 200 OK\n{\n    \"ITEMCODE\": \"001-ANT\",\n    \"EAN\": \"8714713087440\",\n    \"STOCKLEVEL\": 0,\n    \"STATUS\": \"COLLECTION\",\n    \"ATP\": {\n        \"date\": \"2019-02-15 00:00:00.000000\",\n        \"timezone_type\": 3,\n        \"timezone\": \"Europe/Amsterdam\"\n    },\n    \"DFF_SHIPMENT\": \"CARRIER\",\n    \"_links\": {\n        \"self\": {\n            \"href\": \"http://apitest.dutchfurniturefulfilment.local/api/stock-data/001-ANT\"\n        }\n    }\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "type": "401",
            "optional": false,
            "field": "NotAuthorized",
            "description": "<p>The user is not authorized.</p>"
          }
        ]
      }
    },
    "filename": "./Controllers/Api/StockDataController.cs",
    "groupTitle": "StockData"
  },
  {
    "type": "get",
    "url": "/api/stock-data",
    "title": "Request Stock Data",
    "version": "1.0.0",
    "name": "GetStockDataList",
    "group": "StockData",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "String",
            "optional": false,
            "field": "Authorization",
            "description": "<p>Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)</p>"
          }
        ]
      }
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "apikey",
            "description": "<p>Api Key provided by De Eekhoorn Woodworkings B.V.</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": true,
            "field": "page",
            "defaultValue": "1",
            "description": "<p>Page to show</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": true,
            "field": "limit",
            "defaultValue": "25",
            "description": "<p>Number of products on a page</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "/api/stock-data?apikey=0123456789abc&page=1&limit=25",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1. 200 OK\n{\n    \"_links\": {\n        \"self\": {\n            \"href\": \"http://apitest.dutchfurniturefulfilment.local/api/stock-data?page=1\"\n        },\n        \"first\": {\n            \"href\": \"http://apitest.dutchfurniturefulfilment.local/api/stock-data\"\n        },\n        \"last\": {\n            \"href\": \"http://apitest.dutchfurniturefulfilment.local/api/stock-data?page=2833\"\n        },\n        \"next\": {\n            \"href\": \"http://apitest.dutchfurniturefulfilment.local/api/stock-data?page=2\"\n        }\n    },\n    \"_embedded\": {\n        \"stock_data\": [\n            {\n                \"ITEMCODE\": \"001-ANT\",\n                \"EAN\": \"8714713087440\",\n                \"STOCKLEVEL\": 0,\n                \"STATUS\": \"COLLECTION\",\n                \"ATP\": {\n                    \"date\": \"2019-02-15 00:00:00.000000\",\n                    \"timezone_type\": 3,\n                    \"timezone\": \"Europe/Amsterdam\"\n                },\n                \"DFF_SHIPMENT\": \"CARRIER\",\n                \"_links\": {\n                    \"self\": {\n                        \"href\": \"http://apitest.dutchfurniturefulfilment.local/api/stock-data/001-ANT\"\n                    }\n                }\n            },\n            ...\n        ]\n    },\n    \"page_count\": 2833,\n    \"page_size\": 25,\n    \"total_items\": 2833,\n    \"page\": 1\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "type": "401",
            "optional": false,
            "field": "NotAuthorized",
            "description": "<p>The user is not authorized.</p>"
          }
        ]
      }
    },
    "filename": "./Controllers/Api/StockDataController.cs",
    "groupTitle": "StockData"
  },
  {
    "type": "get",
    "url": "/api/stock-data",
    "title": "Request Stock Data by Debtorcode",
    "version": "1.0.0",
    "name": "GetStockDataListByDebtor",
    "group": "StockData",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "String",
            "optional": false,
            "field": "Authorization",
            "description": "<p>Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)</p>"
          }
        ]
      }
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "apikey",
            "description": "<p>Api Key provided by De Eekhoorn Woodworkings B.V.</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "debcode",
            "description": "<p>Debtor Code</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": true,
            "field": "page",
            "defaultValue": "1",
            "description": "<p>Page to show</p>"
          },
          {
            "group": "Parameter",
            "type": "String",
            "optional": true,
            "field": "limit",
            "defaultValue": "25",
            "description": "<p>Number of products on a page</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "/api/stock-data?apikey=0123456789abc&page=1&limit=25&debcode=123",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1. 200 OK\n{\n    \"_links\": {\n        \"self\": {\n            \"href\": \"http://apitest.dutchfurniturefulfilment.local/api/stock-data?page=1\"\n        },\n        \"first\": {\n            \"href\": \"http://apitest.dutchfurniturefulfilment.local/api/stock-data\"\n        },\n        \"last\": {\n            \"href\": \"http://apitest.dutchfurniturefulfilment.local/api/stock-data?page=2833\"\n        },\n        \"next\": {\n            \"href\": \"http://apitest.dutchfurniturefulfilment.local/api/stock-data?page=2\"\n        }\n    },\n    \"_embedded\": {\n        \"stock_data\": [\n            {\n                \"ITEMCODE\": \"001-ANT\",\n                \"EAN\": \"8714713087440\",\n                \"STOCKLEVEL\": 0,\n                \"STATUS\": \"COLLECTION\",\n                \"ATP\": {\n                    \"date\": \"2019-02-15 00:00:00.000000\",\n                    \"timezone_type\": 3,\n                    \"timezone\": \"Europe/Amsterdam\"\n                },\n                \"DFF_SHIPMENT\": \"CARRIER\",\n                \"_links\": {\n                    \"self\": {\n                        \"href\": \"http://apitest.dutchfurniturefulfilment.local/api/stock-data/001-ANT\"\n                    }\n                }\n            },\n            ...\n        ]\n    },\n    \"page_count\": 2833,\n    \"page_size\": 25,\n    \"total_items\": 2833,\n    \"page\": 1\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "type": "401",
            "optional": false,
            "field": "NotAuthorized",
            "description": "<p>The user is not authorized.</p>"
          }
        ]
      }
    },
    "filename": "./Controllers/Api/StockDataController.cs",
    "groupTitle": "StockData"
  },
  {
    "type": "get",
    "url": "/api/woood-structureview/view/artikelcode/{artikelcode}",
    "title": "Request structure by Article Code",
    "version": "1.0.0",
    "name": "GetStructureByArticle",
    "group": "StructureView",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "String",
            "optional": false,
            "field": "Authorization",
            "description": "<p>Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)</p>"
          }
        ]
      }
    },
    "parameter": {
      "examples": [
        {
          "title": "Request-Example:",
          "content": "/api/woood-structureview/view/artikelcode/340447-N",
          "type": "json"
        }
      ],
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "artikelcode",
            "description": "<p>Article Code</p>"
          }
        ]
      }
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1. 200 OK\n        {\n            \"340447-N\": {\n                \"LVL\": 0,\n                \"SEQ_NO\": \"000\",\n                \"SEQ_FULL\": \"000\",\n                \"ARTIKELCODE\": \"340447-N\",\n                \"NL_DESCR\": \"MEREL HOEKBANK LINKS NATUREL\",\n                \"EN_DESCR\": \"MEREL CORNER SOFA LEFT NATUREL\",\n                \"DE_DESCR\": \"MEREL ECKCOUCH LINKEN NATUREL\",\n                \"FR_DESCR\": \"MEREL CANAPE D ANGLE CÔTELÉ GAUCHE NATURELLE\",\n                \"QTY\": 1,\n                \"001\": {\n                    \"LVL\": 1,\n                    \"SEQ_NO\": \"001\",\n                    \"SEQ_FULL\": \"001\",\n                    \"ARTIKELCODE\": \"P340447-N 1#3\",\n                    \"NL_DESCR\": \"MEREL HOEKBANK LINKS NATUREL\",\n                    \"EN_DESCR\": \"P1#2 MEREL CORNER SOFA LEFT NATUREL\",\n                    \"DE_DESCR\": \"P1#2 MEREL ECKCOUCH LINKEN NATUREL\",\n                    \"FR_DESCR\": \"P1#2 MEREL CANAPE D ANGLE CÔTELÉ GAUCHE NATURELLE\",\n                    \"QTY\": 1\n                },\n                \"002\": {\n                    \"LVL\": 1,\n                    \"SEQ_NO\": \"002\",\n                    \"SEQ_FULL\": \"002\",\n                    \"ARTIKELCODE\": \"P340447-N 2#3\",\n                    \"NL_DESCR\": \"MEREL HOEKBANK LINKS NATUREL\",\n                    \"EN_DESCR\": \"P2#2 MEREL CORNER SOFA LEFT NATUREL\",\n                    \"DE_DESCR\": \"P2#2 MEREL ECKCOUCH LINKEN NATUREL\",\n                    \"FR_DESCR\": \"P2#2 MEREL CANAPE D ANGLE CÔTELÉ GAUCHE NATURELLE\",\n                    \"QTY\": 1\n                },\n                \"003\": {\n                    \"LVL\": 1,\n                    \"SEQ_NO\": \"003\",\n                    \"SEQ_FULL\": \"003\",\n                    \"ARTIKELCODE\": \"P340447-N 3#3\",\n                    \"NL_DESCR\": \"MEREL HOEKBANK LINKS NATUREL\",\n                    \"EN_DESCR\": \"P3#3 MEREL CORNER SOFA LEFT NATUREL\",\n                    \"DE_DESCR\": \"P3#3 MEREL ECKCOUCH LINKEN NATUREL\",\n                    \"FR_DESCR\": \"3#3 MEREL CANAPE D ANGLE CÔTELÉ GAUCHE NATURELLE\",\n                    \"QTY\": 1\n                }\n            }\n        }",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "type": "401",
            "optional": false,
            "field": "NotAuthorized",
            "description": "<p>The user is not authorized.</p>"
          }
        ]
      }
    },
    "filename": "./Controllers/Api/StructureController.cs",
    "groupTitle": "StructureView"
  },
  {
    "type": "get",
    "url": "/api/woood-structureview/list[?page={page}&limit={limit}",
    "title": "Request structure view list",
    "version": "1.0.0",
    "name": "GetStructureList",
    "group": "StructureView",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "String",
            "optional": false,
            "field": "Authorization",
            "description": "<p>Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)</p>"
          }
        ]
      }
    },
    "parameter": {
      "examples": [
        {
          "title": "Request-Example:",
          "content": "/api/woood-structureview/list[?page=20&limit=2",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1. 200 OK\n{\n    \"_embedded\": [\n        {\n            \"340447-N\": {\n                \"LVL\": 0,\n                \"SEQ_NO\": \"000\",\n                \"SEQ_FULL\": \"000\",\n                \"ARTIKELCODE\": \"340447-N\",\n                \"NL_DESCR\": \"MEREL HOEKBANK LINKS NATUREL\",\n                \"EN_DESCR\": \"MEREL CORNER SOFA LEFT NATUREL\",\n                \"DE_DESCR\": \"MEREL ECKCOUCH LINKEN NATUREL\",\n                \"FR_DESCR\": \"MEREL CANAPE D ANGLE CÔTELÉ GAUCHE NATURELLE\",\n                \"QTY\": 1,\n                \"001\": {\n                    \"LVL\": 1,\n                    \"SEQ_NO\": \"001\",\n                    \"SEQ_FULL\": \"001\",\n                    \"ARTIKELCODE\": \"P340447-N 1#3\",\n                    \"NL_DESCR\": \"MEREL HOEKBANK LINKS NATUREL\",\n                    \"EN_DESCR\": \"P1#2 MEREL CORNER SOFA LEFT NATUREL\",\n                    \"DE_DESCR\": \"P1#2 MEREL ECKCOUCH LINKEN NATUREL\",\n                    \"FR_DESCR\": \"P1#2 MEREL CANAPE D ANGLE CÔTELÉ GAUCHE NATURELLE\",\n                    \"QTY\": 1\n                },\n                \"002\": {\n                    \"LVL\": 1,\n                    \"SEQ_NO\": \"002\",\n                    \"SEQ_FULL\": \"002\",\n                    \"ARTIKELCODE\": \"P340447-N 2#3\",\n                    \"NL_DESCR\": \"MEREL HOEKBANK LINKS NATUREL\",\n                    \"EN_DESCR\": \"P2#2 MEREL CORNER SOFA LEFT NATUREL\",\n                    \"DE_DESCR\": \"P2#2 MEREL ECKCOUCH LINKEN NATUREL\",\n                    \"FR_DESCR\": \"P2#2 MEREL CANAPE D ANGLE CÔTELÉ GAUCHE NATURELLE\",\n                    \"QTY\": 1\n                },\n                \"003\": {\n                    \"LVL\": 1,\n                    \"SEQ_NO\": \"003\",\n                    \"SEQ_FULL\": \"003\",\n                    \"ARTIKELCODE\": \"P340447-N 3#3\",\n                    \"NL_DESCR\": \"MEREL HOEKBANK LINKS NATUREL\",\n                    \"EN_DESCR\": \"P3#3 MEREL CORNER SOFA LEFT NATUREL\",\n                    \"DE_DESCR\": \"P3#3 MEREL ECKCOUCH LINKEN NATUREL\",\n                    \"FR_DESCR\": \"3#3 MEREL CANAPE D ANGLE CÔTELÉ GAUCHE NATURELLE\",\n                    \"QTY\": 1\n                }\n            }\n        },\n        {\n            \"340448-N\": {\n                \"LVL\": 0,\n                \"SEQ_NO\": \"000\",\n                \"SEQ_FULL\": \"000\",\n                \"ARTIKELCODE\": \"340448-N\",\n                \"NL_DESCR\": \"MEREL HOEKBANK RECHTS NATUREL\",\n                \"EN_DESCR\": \"MEREL CORNER SOFA RIGHT NATUREL\",\n                \"DE_DESCR\": \"MEREL ECKCOUCH RECHTS NATUREL\",\n                \"FR_DESCR\": \"MEREL CANAPE D ANGLE CÔTELÉ DROITE NATURELLE\",\n                \"QTY\": 1,\n                \"001\": {\n                    \"LVL\": 1,\n                    \"SEQ_NO\": \"001\",\n                    \"SEQ_FULL\": \"001\",\n                    \"ARTIKELCODE\": \"P340448-N 1#3\",\n                    \"NL_DESCR\": \"MEREL HOEKBANK RECHTS NATUREL\",\n                    \"EN_DESCR\": \"P1#2 MEREL CORNER SOFA RIGHT NATUREL\",\n                    \"DE_DESCR\": \"P1#2 MEREL ECKCOUCH RECHTS NATUREL\",\n                    \"FR_DESCR\": \"P1#2 MEREL CANAPE D ANGLE CÔTELÉ DROITE NATURELLE\",\n                    \"QTY\": 1\n                },\n                \"002\": {\n                    \"LVL\": 1,\n                    \"SEQ_NO\": \"002\",\n                    \"SEQ_FULL\": \"002\",\n                    \"ARTIKELCODE\": \"P340448-N 2#3\",\n                    \"NL_DESCR\": \"MEREL HOEKBANK RECHTS NATUREL\",\n                    \"EN_DESCR\": \"P2#2 MEREL CORNER SOFA RIGHT NATUREL\",\n                    \"DE_DESCR\": \"P2#2 MEREL ECKCOUCH RECHTS NATUREL\",\n                    \"FR_DESCR\": \"P2#2 MEREL CANAPE D ANGLE CÔTELÉ DROITE NATURELLE\",\n                    \"QTY\": 1\n                },\n                \"003\": {\n                    \"LVL\": 1,\n                    \"SEQ_NO\": \"003\",\n                    \"SEQ_FULL\": \"003\",\n                    \"ARTIKELCODE\": \"P340448-N 3#3\",\n                    \"NL_DESCR\": \"MEREL HOEKBANK RECHTS NATUREL\",\n                    \"EN_DESCR\": \"P3#3 MEREL CORNER SOFA RIGHT NATUREL\",\n                    \"DE_DESCR\": \"P3#3 MEREL ECKCOUCH RECHTS NATUREL\",\n                    \"FR_DESCR\": \"P3#3 MEREL CANAPE D ANGLE CÔTELÉ DROITE NATURELLE\",\n                    \"QTY\": 1\n                }\n            }\n        }\n    ],\n    \"page_count\": 4992,\n    \"page_size\": 2,\n    \"total_items\": 9983,\n    \"page\": 20\n}",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "type": "401",
            "optional": false,
            "field": "NotAuthorized",
            "description": "<p>The user is not authorized.</p>"
          }
        ]
      }
    },
    "filename": "./Controllers/Api/StructureController.cs",
    "groupTitle": "StructureView"
  },
  {
    "type": "get",
    "url": "/api/woood-web-availability/list",
    "title": "Request web availability list",
    "version": "1.0.0",
    "name": "GetWebAvailability",
    "group": "WebAvailability",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "String",
            "optional": false,
            "field": "Authorization",
            "description": "<p>Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)</p>"
          }
        ]
      }
    },
    "parameter": {
      "examples": [
        {
          "title": "Request-Example:",
          "content": "/api/woood-web-availability/list",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1. 200 OK\n[\n    {\n        \"FAKDEBNR\": \"1097685\",\n        \"ITEMCODE\": \"376090\",\n        \"TOELICHTING_NL\": null,\n        \"TOELICHTING_EN\": null,\n        \"TOELICHTING_DE\": null,\n        \"TOELICHTING_FR\": null,\n        \"LEVERWEEK\": 0,\n        \"LEVERWEEK_JJJJWW\": \"2018-44\",\n        \"OMSCHRIJVING_NL\": \"LAMSVACHT (ASSORTI) INCL VERPAKKING\",\n        \"OMSCHRIJVING_EN\": \"LAMBSKIN (MIX COLOR)\",\n        \"OMSCHRIJVING_DE\": \"LAMMFELL (MIX COLOR)\",\n        \"OMSCHRIJVING_FR\": \"PEAU D' AGNEAU (COULEURS MULTIPLES)\",\n        \"BRAND\": \"BEPUREHOME\",\n        \"EXCLUSIVE\": \"BE PURE DEALERS ONLY\",\n        \"EANCODE\": \"8714713048151\"\n    },\n    {\n        \"FAKDEBNR\": \"1097685\",\n        \"ITEMCODE\": \"800739-67\",\n        \"TOELICHTING_NL\": null,\n        \"TOELICHTING_EN\": null,\n        \"TOELICHTING_DE\": null,\n        \"TOELICHTING_FR\": null,\n        \"LEVERWEEK\": 0,\n        \"LEVERWEEK_JJJJWW\": \"2018-37\",\n        \"OMSCHRIJVING_NL\": \"SPOOL ROLKUSSEN FLUWEEL GRIJS\",\n        \"OMSCHRIJVING_EN\": \"SPOOL CUSHION VELVET GREY\",\n        \"OMSCHRIJVING_DE\": \"SPOOL KISSEN VELVET GRAU\",\n        \"OMSCHRIJVING_FR\": \"SPOOL COUSSIN VELVET GRIS\",\n        \"BRAND\": \"BEPUREHOME\",\n        \"EXCLUSIVE\": \"BE PURE DEALERS ONLY\",\n        \"EANCODE\": \"8714713070466\"\n    },\n    ...\n]",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "type": "401",
            "optional": false,
            "field": "NotAuthorized",
            "description": "<p>The user is not authorized.</p>"
          }
        ]
      }
    },
    "filename": "./Controllers/Api/WebAvailabilityController.cs",
    "groupTitle": "WebAvailability"
  },
  {
    "type": "get",
    "url": "/api/woood-web-availability/view/fakdebnr/{fakdebnr}",
    "title": "Request web availability list by Debtor",
    "version": "1.0.0",
    "name": "GetWebAvailabilityByDebtor",
    "group": "WebAvailability",
    "header": {
      "fields": {
        "Header": [
          {
            "group": "Header",
            "type": "String",
            "optional": false,
            "field": "Authorization",
            "description": "<p>Basic Authorization value (provided by De Eekhoorn Woodworkings B.V.)</p>"
          }
        ]
      }
    },
    "parameter": {
      "fields": {
        "Parameter": [
          {
            "group": "Parameter",
            "type": "String",
            "optional": false,
            "field": "fakdebnr",
            "description": "<p>Debtor Code on the Invoice</p>"
          }
        ]
      },
      "examples": [
        {
          "title": "Request-Example:",
          "content": "/api/woood-web-availability/view/fakdebnr/1097685",
          "type": "json"
        }
      ]
    },
    "success": {
      "examples": [
        {
          "title": "Success-Response:",
          "content": "HTTP/1.1. 200 OK\n[\n    {\n        \"FAKDEBNR\": \"1097685\",\n        \"ITEMCODE\": \"376090\",\n        \"TOELICHTING_NL\": null,\n        \"TOELICHTING_EN\": null,\n        \"TOELICHTING_DE\": null,\n        \"TOELICHTING_FR\": null,\n        \"LEVERWEEK\": 0,\n        \"LEVERWEEK_JJJJWW\": \"2018-44\",\n        \"OMSCHRIJVING_NL\": \"LAMSVACHT (ASSORTI) INCL VERPAKKING\",\n        \"OMSCHRIJVING_EN\": \"LAMBSKIN (MIX COLOR)\",\n        \"OMSCHRIJVING_DE\": \"LAMMFELL (MIX COLOR)\",\n        \"OMSCHRIJVING_FR\": \"PEAU D' AGNEAU (COULEURS MULTIPLES)\",\n        \"BRAND\": \"BEPUREHOME\",\n        \"EXCLUSIVE\": \"BE PURE DEALERS ONLY\",\n        \"EANCODE\": \"8714713048151\"\n    },\n    {\n        \"FAKDEBNR\": \"1097685\",\n        \"ITEMCODE\": \"800739-67\",\n        \"TOELICHTING_NL\": null,\n        \"TOELICHTING_EN\": null,\n        \"TOELICHTING_DE\": null,\n        \"TOELICHTING_FR\": null,\n        \"LEVERWEEK\": 0,\n        \"LEVERWEEK_JJJJWW\": \"2018-37\",\n        \"OMSCHRIJVING_NL\": \"SPOOL ROLKUSSEN FLUWEEL GRIJS\",\n        \"OMSCHRIJVING_EN\": \"SPOOL CUSHION VELVET GREY\",\n        \"OMSCHRIJVING_DE\": \"SPOOL KISSEN VELVET GRAU\",\n        \"OMSCHRIJVING_FR\": \"SPOOL COUSSIN VELVET GRIS\",\n        \"BRAND\": \"BEPUREHOME\",\n        \"EXCLUSIVE\": \"BE PURE DEALERS ONLY\",\n        \"EANCODE\": \"8714713070466\"\n    },\n    ...\n]",
          "type": "json"
        }
      ]
    },
    "error": {
      "fields": {
        "Error 4xx": [
          {
            "group": "Error 4xx",
            "type": "401",
            "optional": false,
            "field": "NotAuthorized",
            "description": "<p>The user is not authorized.</p>"
          }
        ]
      }
    },
    "filename": "./Controllers/Api/WebAvailabilityController.cs",
    "groupTitle": "WebAvailability"
  }
] });
