using System;
using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;

namespace Tests.BDD.Steps
{
    [Binding]
    public class BrowserLaunchStepDefinitions
    {
        private readonly IWebDriver _driver;
        
        string url = "";

        public BrowserLaunchStepDefinitions(IObjectContainer container)
        {
            _driver = container.Resolve<IWebDriver>();
        }

       
        [Given("I have {string} url")]
        public void GivenIHaveUrl(string app)
        {
            url = $"https://www.{app}.com";
        }

        [When("I launch url in browser")]
        public void WhenILaunchUrlInBrowser()
        {
            _driver.Navigate().GoToUrl(url);
        }

        [Then("{string} application is launched")]
        public void ThenApplicationIsLaunched(string app)
        {
            Assert.That(_driver.Title.ToLower().Contains(app),$"Expected= {app} , Actual = {_driver.Title.ToLower()}");
        }
    }
}
