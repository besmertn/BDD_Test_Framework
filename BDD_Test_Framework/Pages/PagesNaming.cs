using System;
using System.Collections.Generic;

namespace BDD_Test_Framework.Pages
{
    public static class PagesNaming
    {
        public static readonly string LoginPage = "Login";


        public static readonly IDictionary<string, Type> Pages;

        static PagesNaming()
        {
            Pages = new Dictionary<string, Type>()
            {
                [LoginPage] = typeof(LoginPage),
            };
        }
    }
}
