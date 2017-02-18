using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using CoasterQuery.Data.Models;
using CoasterQuery.Data.Repositories;

namespace CoasterQuery.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*", SupportsCredentials = true)]
    public class ParkController : ApiController
    {
        private readonly IRepository<Park> _repository;

        public ParkController(IRepository<Park> repository)
        {
            _repository = repository;
        }

        public async Task<IHttpActionResult> Get()
        {
            var result = await _repository.GetAll();
            return Ok(result);
        }
    }
}