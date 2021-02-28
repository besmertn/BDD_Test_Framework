using System;
using BDD_Test_Framework.Config;
using OpenQA.Selenium;

namespace BDD_Test_Framework.Driver
{
    /// <summary>
    /// The wrapper that incapsulate operations for managing chosen web driver.
    /// </summary>
    public class DriverManager
    {
        private readonly DriverConfigReader сonfigReader;
        private readonly Type webDriverType;

        private IWebDriver webDriver;

        public DriverManager(Type webDriverType, DriverConfigReader сonfigReader)
        {
            this.сonfigReader = сonfigReader;
            this.webDriverType = webDriverType;
        }

        /// <summary>
        /// Gets web driver. If driver not initialized - creates it.
        /// </summary>
        public IWebDriver WebDriver
        {
            get
            {
                if (this.webDriver == null)
                {
                    this.CreateWebDriver();
                }

                return this.webDriver;
            }
        }

        private void CreateWebDriver()
        {
            var optionsSection = this.сonfigReader.DriverOptions;
            this.webDriver = (IWebDriver)Activator.CreateInstance(this.webDriverType, optionsSection);
        }

        /// <summary>
        /// Quitting managing driver closing all associated windows.
        /// </summary>
        public void QuitWebDriver()
        {
            if (this.webDriver != null)
            {
                this.webDriver.Quit();
                this.webDriver = null;
            }
        }
    }
}
