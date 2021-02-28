using System;
using BDD_Test_Framework.Config;
using BDD_Test_Framework.Config.Readers;
using BDD_Test_Framework.Factories;
using BDD_Test_Framework.Helpers;
using BDD_Test_Framework.Pages;
using BoDi;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BDD_Test_Framework.Steps
{
    [Binding]
    public class BaseSteps : TechTalk.SpecFlow.Steps
    {
        public IObjectContainer ObjectContainer { get; }

        public IWebDriver WebDriver { get; }

        public By CurrentIFrameLocator { get; set; }

        public JavaScriptExecutionManager JavaScriptExecutionManager { get; }

        public RetryPolicyFactory RetryPolicyFactory { get; }

        protected BasePage Page => this.GetPageInstance(this.PageName);

        protected virtual string PageName { get; set; }

        protected UtilityConfigReader UtilityConfigReader { get; private set; }

        protected DriverConfigReader DriverConfigReader { get; private set; }

        public BaseSteps(IObjectContainer objectContainer)
        {
            this.ObjectContainer = objectContainer;
            this.WebDriver = this.ObjectContainer.Resolve<IWebDriver>();
            this.RetryPolicyFactory = this.ObjectContainer.Resolve<RetryPolicyFactory>();
            this.JavaScriptExecutionManager = this.ObjectContainer.Resolve<JavaScriptExecutionManager>();
            this.UtilityConfigReader = ObjectContainer.Resolve<UtilityConfigReader>();
            this.DriverConfigReader = ObjectContainer.Resolve<DriverConfigReader>();
        }

        /// <summary>
        /// Get registered page instance. (Create and register the page if not registered).
        /// </summary>
        /// <param name="pageName">The page name. (In help - 'PagesNaming' class that stores page names).</param>
        /// <returns>The page instance.</returns>
        public BasePage GetPageInstance(string pageName)
        {
            var isPageRegistered = this.ObjectContainer.IsRegistered<BasePage>(pageName);

            BasePage page;
            if (isPageRegistered)
            {
                page = this.ObjectContainer.Resolve<BasePage>(pageName);
            }
            else
            {
                var isPageClassificationExists = PagesNaming.Pages.Keys.Contains(pageName);

                if (!isPageClassificationExists)
                {
                    throw new NotFoundException($@"The ""{pageName}"" page instance not found");
                }

                var pageTypeToCreate = PagesNaming.Pages[pageName];
                page = (BasePage)Activator.CreateInstance(pageTypeToCreate, this.WebDriver, this.RetryPolicyFactory);
                this.ObjectContainer.RegisterInstanceAs(page, pageName);
            }

            this.WebDriver.SwitchTo().DefaultContent();
            if (page.IFrameLocator != null)
            {
                this.WebDriver.SwitchTo().Frame(this.WebDriver.FindElement(page.IFrameLocator));
                this.CurrentIFrameLocator = page.IFrameLocator;
            }

            return page;
        }
    }
}
