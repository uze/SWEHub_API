using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace SWEHub
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public class Results
        {
            public string year { get; set; }
            public string population { get; set; }
            public string violent_crime { get; set; }
            public string robbery { get; set; }
            public string burglary { get; set; }
        }

        public class CrimeData
        {
            public Results[] results { get; set; }
        }

        public string Crime(string state)
        {
            string json = string.Empty;
            string crime_api_key = "YF8g83aabG9IFLyQp4U5aUM0FkqxCUF1SSbTHI5D";
            string url = @"https://api.usa.gov/crime/fbi/ucr/estimates/states/" + state + "?page=1&per_page=10&output=json&api_key=" + crime_api_key;

            json = GetRequest(url);

            CrimeData crimeData = JsonConvert.DeserializeObject<CrimeData>(json);

            return "In the year " + crimeData.results[9].year + ", The population in " + state + " is " + crimeData.results[9].population + "\nThe number of violent crimes was: " + crimeData.results[9].violent_crime + ".\nThe number of robberies was: " + crimeData.results[9].robbery + ".\nThe number of burgleries was: " + crimeData.results[9].burglary + ".\n";
        }

        public class GoogleGeoCodeResponse
        {
            public string status { get; set; }
            public results[] results { get; set; }
        }

        public class results
        {
            public string formatted_address { get; set; }
            public geometry geometry { get; set; }
            public string[] types { get; set; }
            public address_component[] address_components { get; set; }
        }

        public class geometry
        {
            public string location_type { get; set; }
            public location location { get; set; }
        }

        public class location
        {
            public string lat { get; set; }
            public string lng { get; set; }
        }

        public class address_component
        {
            public string long_name { get; set; }
            public string short_name { get; set; }
            public string[] types { get; set; }
        }

        public class NrelResponse
        {
            public Outputs outputs { get; set; }
        }

        public class Outputs
        {
            public Avg_dni avg_dni { get; set; }
        }

        public class Avg_dni
        {
            public double annual { get; set; }
        }

        public string Weather(string city)
        {
            string latitude;
            string longitude;

            string NrelResult = string.Empty;
            string GeocodeResult = string.Empty;

            string nrel_api_key = "SLtwKpcnZ6dQ2iT1LLFyJzJSlsgnrWGRAXSd43c6";
            string google_api_key = "AIzaSyACHx0lKjPIXLhqoaVfFeKp8sXqXQw-i8U";

            string geocode_url = @"https://maps.googleapis.com/maps/api/geocode/json?address=" + city + "&key=" + google_api_key;

            string geocode_result = GetRequest(geocode_url);

            GoogleGeoCodeResponse coordinates = JsonConvert.DeserializeObject<GoogleGeoCodeResponse>(geocode_result);

            latitude = coordinates.results[0].geometry.location.lat;
            longitude = coordinates.results[0].geometry.location.lng;

            string url = @"https://developer.nrel.gov/api/solar/solar_resource/v1.json?api_key=" + nrel_api_key + "&lat=" + latitude + "&lon=" + longitude;

            string weather_request = GetRequest(url);

            NrelResponse nrelResponse = JsonConvert.DeserializeObject<NrelResponse>(weather_request);

            return "The average daily amount of strong sunlight in " + city + " is: " + nrelResponse.outputs.avg_dni.annual + " hours.";
        }

        public string GetRequest(string url)
        {
            string json = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }

            return json;
        }

        public int test(int num)
        {
            return num;
        }
    }
}
