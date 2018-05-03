using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CastelloApiTests
{
    public class Tests
    {
        public Tests()
        {
            int recipesNumber = GetRecipesFromRdbByListId(string listID);
            int pageSize = 6;
            int recipesRemaider = recipesNumber % pageSize;
            int numberOfPages = recipesRemaider != 0 ? recipesNumber / pageSize + 1 : recipesNumber / pageSize;
        }

        [Test]
        public void PaginationReturnsRecipes(int maxPages)
        {
            https://castello-tie.cmsstage.com/en/api/recipes/search/?pageNumber=currentPageNumber


        }

    }
}
