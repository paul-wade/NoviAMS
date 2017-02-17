using System.Collections.Generic;
using System.Web.Http;
using CoasterQuery.Data.Models;

namespace CoasterQuery.Controllers
{
    public class ParkController : ApiController
    {
       
        [HttpGet]
        public List<Park> Get()
        {
            return new List<Park>();
        }
    }
}
