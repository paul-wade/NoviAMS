using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl.Http;

namespace CoasterQuery.Business.Services
{
    public class MappingService : IMappingService
    {
        public async Task<LatLong> GetLatLong(string street, string city, string state, string zip)
        {
            var response = await
                $"http://maps.googleapis.com/maps/api/geocode/json?address={street.CleanSpaces()}+{city.CleanSpaces()}+{state.CleanSpaces()}+{zip.CleanSpaces()}".GetJsonAsync<Result>();
            //we could shirnk this down to a tenary if but I like to keep things readable. Not too dense when it counts.
            if (response?.geometry?.location != null)
                return new LatLong(response.geometry.location.lat, response.geometry.location.lng);

            return new LatLong(43.9473, 15.3717);//cool island if we cant find it or something else goes wrong.
            //Real world add some logging around this.
        }

        //We both know this isn't pretty. There is a good c# wrapper for google maps that sadly isn't converted to .net standard yet. 
        //Real world I would at the very least fix the class names to avoid collisions I.E. result. Declaring here for now. 
        public class AddressComponent
        {
            public string long_name { get; set; }
            public string short_name { get; set; }
            public List<string> types { get; set; }
        }

        public class Location
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Northeast
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Southwest
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Viewport
        {
            public Northeast northeast { get; set; }
            public Southwest southwest { get; set; }
        }

        public class Geometry
        {
            public Location location { get; set; }
            public string location_type { get; set; }
            public Viewport viewport { get; set; }
        }

        public class Result
        {
            public List<AddressComponent> address_components { get; set; }
            public string formatted_address { get; set; }
            public Geometry geometry { get; set; }
            public string place_id { get; set; }
            public List<string> types { get; set; }
        }

        public class RootObject
        {
            public List<Result> results { get; set; }
            public string status { get; set; }
        }
    }

    public static class StringExtensions
    {
        public static string CleanSpaces(this string input)
        {
            return input.Replace(' ', '+');
        }
    }

}