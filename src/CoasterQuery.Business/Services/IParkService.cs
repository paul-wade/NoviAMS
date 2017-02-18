using System.Collections.Generic;
using System.Threading.Tasks;
using CoasterQuery.Data.Models;

namespace CoasterQuery.Business.Services
{
    public interface IParkService
    {
        Task<IEnumerable<Park>> GetAllParks();
    }
}