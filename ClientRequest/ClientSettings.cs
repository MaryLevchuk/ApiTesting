using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Configuration;

namespace Castello.ClientRequest
{
    public abstract class ClientSettings
    {
        public IRestClient Client = new RestClient(ConfigurationManager.AppSettings["ApiUrl"]);
        public IRestRequest Request = new RestRequest();
        public string Url;

        public ClientSettings()
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

       
    }
}
