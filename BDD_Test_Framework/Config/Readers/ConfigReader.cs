using System;
using System.IO;
using BDD_Test_Framework.Driver;
using Microsoft.Extensions.Configuration;

namespace BDD_Test_Framework.Config
{
    /// <summary>
    /// Root of custom config readers.
    /// Represents the sections structure of configuration file.
    /// There is located root configuration sections, or sections are needed to be encapsulate.
    /// </summary>
    public static class ConfigReader
    {
        public static IConfigurationRoot Configure { get; private set; }

        static ConfigReader()
        {
            InitializeConfigFile();
        }

        /// <summary>
        ///  Set up configuration file using predefined folder path.
        /// </summary>
        private static void InitializeConfigFile()
        {
            Configure = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("configuration.json", optional: true)
                   .Build();
        }

        /// <summary>
        ///  Get the configured drivers section.
        /// </summary>
        /// <returns>Drivers configuration section.</returns>
        public static IConfigurationSection GetDriversSection()
        {
            return Configure.GetSection("drivers");
        }

        /// <summary>
        /// Gets the configured web driver.
        /// </summary>
        /// <returns>Current web driver enum value.</returns>
        public static DriverType GetSelectedDriverType()
        {
            var section = GetDriversSection().GetSection("selectedDriver");
            var sectionValue = section.Get<string>().ToLower();

            switch (sectionValue)
            {
                case "chrome":
                    return DriverType.GoogleChrome;
                case "internet explorer":
                    return DriverType.InternetExplorer;
                case "firefox":
                    return DriverType.Firefox;
                default:
                    throw new Exception("Driver to use is not selected in configuration file");
            }
        }

        /// <summary>
        ///  Get the configured utility section.
        /// </summary>
        /// <returns>Utility configuration section.</returns>
        public static IConfigurationSection GetUtilitySection()
        {
            return Configure.GetSection("utility");
        }
    }
}
