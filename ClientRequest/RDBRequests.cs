using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ClientRequest;

namespace Castello.ClientRequest
{
    public class RDBRequests
    {
        public IRestClient Client = new RestClient(ConfigurationManager.AppSettings["TestRdbApiUrl"]);
        //public IRestClient Client = new RestClient("https://api-testrdb.arla.com");
        public IRestRequest Request = new RestRequest();

        public RDBRequests()
        {            
            Request.AddHeader("Accept", "application/json");
            Request.AddHeader("auth-apikey", "0b5eb46b8a99496199629aec4a2e8c79");
        }

        public IRestRequest Get(string url)
        {
            Request.Resource = url;
            Request.Method = Method.GET;
            return Request;
        }

        public IRestResponse GetAllRecipesFromRdb()
        {
            var request = Get(ConfigurationManager.AppSettings["AllRecipes"]);
            IRestResponse response = Client.Execute(request);
            return response;
        }

        public int GetNumberOfRecipes(IRestResponse response)
        {
            JArray objects = JsonConvert.DeserializeObject<JArray>(response.Content);
            return objects.Count;
        }

        public int GetNumberOfRecipesInInstance()
        {
            var response = GetAllRecipesFromRdb();
            int result = GetNumberOfRecipes(response);
            return result;
        }        
    }
}
