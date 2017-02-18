using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using CoasterQuery.Business.Services;
using CoasterQuery.Data.Models;
using CoasterQuery.Data.Repositories;

namespace CoasterQuery.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*", SupportsCredentials = true)]
    public class ParkController : ApiController
    {
        private readonly IParkService _parkService; 

        public ParkController(IParkService parkService)
        {
            _parkService = parkService;
        }

        public async Task<IHttpActionResult> Get()
        {
            var result = await _parkService.GetAllParks();
            return Ok(result);
        }
    }
}