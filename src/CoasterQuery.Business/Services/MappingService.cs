using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flurl.Http;

namespace CoasterQuery.Business.Services
{
    public class MappingService : IMappingService
    {
        public async Task<LatLong> GetLatLong(string street, string city, string state, string zip)
        {
            RootObject response = await
                $"http://maps.googleapis.com/maps/api/geocode/json?address={street.CleanSpaces()}+{city.CleanSpaces()}+{state.CleanSpaces()}+{zip.CleanSpaces()}".GetJsonAsync<RootObject>();
           
            //try to get the first result. Thats all I care about for right now.
            var firstResponse = response?.results?.First();

            if (firstResponse?.geometry?.location != null)
                return new LatLong(firstResponse.geometry.location.lat, firstResponse.geometry.location.lng);

            return new LatLong(43.9473, 15.3717);//cool island if we cant find it or something else goes wrong.
            //Real world add some logging around this.
        }

        //We both know this isn't pretty. There is a good c# wrapper for google maps that sadly isn't converted to .net standard yet.  
        private class AddressComponent
        {
            public string long_name { get; set; }
            public string short_name { get; set; }
            public List<string> types { get; set; }
        }

        private class Location
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        private class Northeast
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        private class Southwest
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        private class Viewport
        {
            public Northeast northeast { get; set; }
            public Southwest southwest { get; set; }
        }

        private class Geometry
        {
            public Location location { get; set; }
            public string location_type { get; set; }
            public Viewport viewport { get; set; }
        }

        private class Result
        {
            public List<AddressComponent> address_components { get; set; }
            public string formatted_address { get; set; }
            public Geometry geometry { get; set; }
            public string place_id { get; set; }
            public List<string> types { get; set; }
        }

        private class RootObject
        {
            public List<Result> results { get; set; }
            public string status { get; set; }
        }
    }

}