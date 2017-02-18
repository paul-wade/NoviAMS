using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using CoasterQuery.Business.Services;

namespace CoasterQuery.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*", SupportsCredentials = true)]
    public class MappingController : ApiController
    {
        private readonly IMappingService _mappingService;

        public MappingController(IMappingService mappingService)
        {
            _mappingService = mappingService;
        }

        public async Task<IHttpActionResult> GetLatLong(string street, string city, string state, string zip)
        {
            var latLong = await _mappingService.GetLatLong(street, city, state, zip);
            return Ok(latLong);
        }

    }
}
