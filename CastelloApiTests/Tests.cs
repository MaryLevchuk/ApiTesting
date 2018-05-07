using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Castello.ClientRequest;
using RestSharp;

namespace Castello.ApiTests
{
    public class Tests
    {
        public RDBRequests RdbApi = new RDBRequests();
        public RecipePageRequests Page = new RecipePageRequests();


        public Tests()
        {
        }

        [Test]
        public void EachPageReturnsRecipes()
        {
            var recipesNumberFromRdb = RdbApi.GetNumberOfRecipesInInstance();
            int pageSize = 6;
            int numberOfPages = Page.GetNumberOfPagesByNumberOfRecipesAndPageSize(recipesNumberFromRdb, pageSize);

            for (int i = 1; i <= numberOfPages; i++)
            {
                var recipesOnCurrentPage = Page.GetNumberOfRecipesFromCurrentPage(i);
                Assert.AreNotEqual(0, recipesOnCurrentPage);
            }
         
        }

    }
}

