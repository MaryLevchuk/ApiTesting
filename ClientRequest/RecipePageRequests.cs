using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ClientRequest;
using HtmlAgilityPack;

namespace Castello.ClientRequest
{
    public class RecipePageRequests
    {
        public IRestClient Client = new RestClient(ConfigurationManager.AppSettings["StageUrl"]);
        public IRestRequest Request = new RestRequest();

        public RecipePageRequests()
        {
        }

        public IRestRequest Get(string url)
        {
            Request.Resource = url;
            Request.Method = Method.GET;
            
            return Request;
        }

        public IRestResponse GetRecipesFromCurrentPage(string pageNum)
        {
            var recipes = "/api/recipes/search/?pageNumber=" + pageNum;
            var request = Get(recipes);
            IRestResponse<RecipePageResponse> response = Client.Execute<RecipePageResponse>(request);
            return response;
        }

        public int GetResipesNumberFromPage(string responseString)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(responseString);
            var nodes = doc.DocumentNode.Descendants("h4")
                        .Select(y => y.Descendants().Where(x => x.Attributes["class"].Value == "recipe-card__title")).ToList();
            return nodes.Count;
        }

        public int GetNumberOfRecipesFromCurrentPage(int pageNumber)
        {
            var response = GetRecipesFromCurrentPage(pageNumber.ToString());
            var result = GetResipesNumberFromPage(response.Content);
            return result;

        }

        public int GetNumberOfPagesByNumberOfRecipesAndPageSize(int recipesNumber, int pageSize)
        {
            int recipesRemainder = recipesNumber % pageSize;
            int numberOfPages = recipesRemainder != 0 ? recipesNumber / pageSize + 1 : recipesNumber / pageSize;
            return numberOfPages;
        }
    }
}
