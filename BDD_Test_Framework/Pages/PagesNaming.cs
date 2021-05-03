using System;
using System.Collections.Generic;

namespace BDD_Test_Framework.Pages
{
    public static class PagesNaming
    {
        public static readonly string SearchPage = "Search";

        public static readonly string SearchResultPage = "Search Result";


        public static readonly IDictionary<string, Type> Pages;

        static PagesNaming()
        {
            Pages = new Dictionary<string, Type>()
            {
                [SearchPage] = typeof(SearchPage),
                [SearchResultPage] = typeof(SearchResultPage),
            };
        }
    }
}
