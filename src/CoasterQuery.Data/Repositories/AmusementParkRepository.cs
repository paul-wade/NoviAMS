using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoasterQuery.Data.Models;
using Flurl.Http;

namespace CoasterQuery.Data.Repositories
{
    public class AmusementParkRepository : IRepository<Park>
    {
        // This endpoint is an API end (JSON or XML) with all amusement parks:
        // GET https://coasterbuzz.com/api/park
        // This endpoint uses the ParkID from the above entries to get just a single park (replace {id} with ID):
        // GET https://coasterbuzz.com/api/park/{id}

        public Task<Park> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Park>> GetAll()
        {
            var getResponse = await "https://coasterbuzz.com/api/park".GetJsonAsync<IEnumerable<Park>>();
            return getResponse;
        }
    }

    public interface IRepository<T>
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
    }
}