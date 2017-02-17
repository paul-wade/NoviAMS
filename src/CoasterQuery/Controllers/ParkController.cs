using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using CoasterQuery.Data.Models;
using CoasterQuery.Data.Repositories;

namespace CoasterQuery.Controllers
{
    public class ParkController : ApiController
    {
        private readonly IRepository<Park> _repository;

        public ParkController(IRepository<Park> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Park>> Get()
        {
            return await _repository.GetAll();
        }
    }
}