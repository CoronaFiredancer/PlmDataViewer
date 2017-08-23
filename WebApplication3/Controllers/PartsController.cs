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
	    private readonly IPartsService _partsService;

	    public PartsController(IPartsService partsService)
	    {
		    _partsService = partsService;
	    }

	    public IHttpActionResult Get(string id)
	    {

		    var part = _partsService.GetByItemNumber(id);

		    return Ok(part);
	    }

	    public IEnumerable<Part> Get()
	    {
		    var partList = _partsService.GetAll();

		    return partList;
	    }
		
    }
}
