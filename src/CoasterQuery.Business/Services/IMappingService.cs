using System.Threading.Tasks;

namespace CoasterQuery.Business.Services
{
    public interface IMappingService
    {
        Task<LatLong> GetLatLong(string street, string city, string state, string zip);
    }
}
