using System.IO;
using BDD_Test_Framework.Config.Readers;
using BDD_Test_Framework.Driver;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BDD_Test_Framework.Config
{
    /// <summary>
    /// Common config reader for web drivers.
    /// </summary>
    public class DriverConfigReader : IConfigReader
    {
        private readonly IConfigurationSection driversConfigurationSection;
        private readonly DriverType driverType;

        private DriverOptions driverOptions;

        public bool ManageInactiveBrowserProcesses { get; }

        public string DownloadsDirectory => this.GetDownloadsDirectory();

        public DriverOptions DriverOptions => this.driverOptions ??= this.GetOptions(this.driverType);

        public DriverConfigReader()
        {
            this.driversConfigurationSection = ConfigReader.GetDriversSection();
            this.ManageInactiveBrowserProcesses = this.GetManageInactiveBrowserProcessesValue();
            this.driverType = ConfigReader.GetSelectedDriverType();
        }

        /// <summary>
        /// Get configured flag indicating whether to kill inactive driver and browser processes from previous test runs.
        /// </summary>
        private bool GetManageInactiveBrowserProcessesValue()
        {
            var driverServiceInactivityInMinutes = this.driversConfigurationSection.GetSection("manageInactiveBrowserProcesses");
            return driverServiceInactivityInMinutes.Get<bool>();
        }

        /// <summary>
        /// Get driver type options.
        /// </summary>
        /// <param name="driverType">Driver type to choose.</param>
        /// <returns>Selected driver options.</returns>
        private DriverOptions GetOptions(DriverType driverType)
        {
            var selectedDriverSection = this.GetDriverSection(driverType);
            var optionsType = DriverTypes.DriverOptionsDictionary[driverType];

            var optionSection = selectedDriverSection.GetSection("options");
            var driverOptions = (DriverOptions)optionSection.Get(optionsType);
            if (driverType == DriverType.GoogleChrome)
            {
                ((ChromeOptions)driverOptions)
                    .AddUserProfilePreference(
                        "download.default_directory",
                        Directory.GetCurrentDirectory() + this.DownloadsDirectory);
                ((ChromeOptions)driverOptions).AddArgument("--allow-insecure-localhost");
            }

            return driverOptions;
        }

        /// <summary>
        /// Getting config section that inculudes all configured properties of chosen web driver.
        /// </summary>
        /// <param name="driverType">Driver type.</param>
        private IConfigurationSection GetDriverSection(DriverType driverType)
        {
            switch (driverType)
            {
                case DriverType.GoogleChrome:
                    return this.driversConfigurationSection.GetSection("chrome");
                case DriverType.InternetExplorer:
                    return this.driversConfigurationSection.GetSection("internetExplorer");
                case DriverType.Firefox:
                    return this.driversConfigurationSection.GetSection("firefox");
                default:
                    return this.driversConfigurationSection.GetSection("internetExplorer");
            }
        }

        private string GetDownloadsDirectory()
        {
            return this.driversConfigurationSection.GetSection("downloadDefaultDirectory").Get<string>();
        }
    }
}
