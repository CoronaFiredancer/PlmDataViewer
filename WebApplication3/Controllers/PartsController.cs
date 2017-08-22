using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlmConnector.Connectors;

using PlmConnector.Models;
using PlmConnector.Services;

namespace WebApplication3.Controllers
{
    public class PartsController : ApiController
    {
	    private KamInnovatorItem Item { get; set; }
	    private IPartsService _partsService;

		//ref the IOM.dll
		//each GET call should use the IOM to fetch data from PLM

	    public PartsController(IPartsService partsService)
	    {
		    _partsService = partsService;
	    }

	    public IHttpActionResult Get(string itemNumber)
	    {

			var part = new Part{ItemNumber = itemNumber};

		    return Ok(part);
	    }

	    public IEnumerable<Part> Get()
	    {
		    var partList = new List<Part>();

		    return partList;
	    }
		
    }
}
