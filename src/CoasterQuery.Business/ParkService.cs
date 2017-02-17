using System.Collections.Generic;
using System.Threading.Tasks;
using CoasterQuery.Data.Models;
using CoasterQuery.Data.Repositories;

namespace CoasterQuery.Business
{
    public class ParkService
    {
        private readonly IRepository<Park> _repository;

        public ParkService(IRepository<Park> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Park>> GetAllParks()
        {
            return await _repository.GetAll();
        }
    }
}