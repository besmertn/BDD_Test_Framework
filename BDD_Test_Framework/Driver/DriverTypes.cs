using System;
using System.Collections.Generic;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace BDD_Test_Framework.Driver
{
    /// <summary>
    /// Contains identities between custom types/enums to selenium web drivers types.
    /// </summary>
    public static class DriverTypes
    {
        public static readonly IDictionary<DriverType, Type> DriverTypesDictionary;
        public static readonly IDictionary<DriverType, Type> DriverOptionsDictionary;

        static DriverTypes()
        {
            // Register new identities whenever project extends with new web driver types
            DriverOptionsDictionary = new Dictionary<DriverType, Type>()
            {
                [DriverType.InternetExplorer] = typeof(InternetExplorerOptions),
                [DriverType.Firefox] = typeof(FirefoxOptions),
                [DriverType.GoogleChrome] = typeof(ChromeOptions),
            };

            // Register new identities whenever project extends with new web driver types
            DriverTypesDictionary = new Dictionary<DriverType, Type>()
            {
                [DriverType.InternetExplorer] = typeof(InternetExplorerDriver),
                [DriverType.Firefox] = typeof(FirefoxDriver),
                [DriverType.GoogleChrome] = typeof(ChromeDriver),
            };
        }
    }

    /// <summary>
    /// Represents existing project driver types.
    /// </summary>
    /// Add new value whenever project extends with new web driver types
    public enum DriverType
    {
        InternetExplorer,
        Firefox,
        GoogleChrome
    }
}
