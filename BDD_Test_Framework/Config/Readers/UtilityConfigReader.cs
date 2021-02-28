using System;
using BDD_Test_Framework.Driver;
using BDD_Test_Framework.Models;
using Microsoft.Extensions.Configuration;

namespace BDD_Test_Framework.Config.Readers
{
    /// <summary>
    /// Config reader for utility section of configuration file.
    /// </summary>
    public class UtilityConfigReader : IConfigReader
    {
        private readonly IConfigurationSection utilityConfigurationSection;
        private string baseUrl;

        public DriverType SelectedDriverByDefault { get; }

        public TimeOption WaitInMilliseconds { get; }

        public int DriverServiceInactivityInMinutes { get; }

        public int RetryCount { get; }

        public string BaseUrl => this.baseUrl ??= this.GetBaseUrl();

        public UtilityConfigReader()
        {
            this.SelectedDriverByDefault = ConfigReader.GetSelectedDriverType();
            this.utilityConfigurationSection = ConfigReader.GetUtilitySection();
            this.WaitInMilliseconds = this.GetWaitValue();
            this.DriverServiceInactivityInMinutes = this.GetDriverServiceInactivityInMinutesValue();
            this.RetryCount = this.GetRetryCountValue();
        }

        /// <summary>
        /// Get configured wait value in minutes.
        /// </summary>
        /// <returns>Wait value in minutes.</returns>
        private int GetDriverServiceInactivityInMinutesValue()
        {
            var driverServiceInactivityInMinutes = this.utilityConfigurationSection.GetSection("driverServiceInactivityInMinutes");
            return driverServiceInactivityInMinutes.Get<int>();
        }

        /// <summary>
        /// Get configured wait value in milliseconds.
        /// </summary>
        /// <returns>Wait value in milliseconds.</returns>
        private TimeOption GetWaitValue()
        {
            var timeOption = new TimeOption();

            var waitInMilliseconds = this.utilityConfigurationSection.GetSection("shortWaitInMilliseconds").Get<int>();
            timeOption.Short = TimeSpan.FromMilliseconds(waitInMilliseconds);

            waitInMilliseconds = this.utilityConfigurationSection.GetSection("mediumWaitInMilliseconds").Get<int>();
            timeOption.Medium = TimeSpan.FromMilliseconds(waitInMilliseconds);

            waitInMilliseconds = this.utilityConfigurationSection.GetSection("longWaitInMilliseconds").Get<int>();
            timeOption.Long = TimeSpan.FromMilliseconds(waitInMilliseconds);

            return timeOption;
        }

        /// <summary>
        /// Get baseUrl property from utility section.
        /// </summary>
        /// <returns>Base url.</returns>
        private string GetBaseUrl()
        {
            var baseUrl = this.utilityConfigurationSection.GetSection("baseUrl");
            return baseUrl.Get<string>();
        }

        /// <summary>
        /// Get retryCount property value from utility section.
        /// </summary>
        /// <returns>Retry count.</returns>
        private int GetRetryCountValue()
        {
            var retryCount = this.utilityConfigurationSection.GetSection("retryCount");
            return retryCount.Get<int>();
        }
    }
}
