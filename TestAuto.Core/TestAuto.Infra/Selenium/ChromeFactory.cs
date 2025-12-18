using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestAuto.Core;
using TestAuto.Core.Interfaces;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace TestAuto.Infra.Selenium
{
    public class ChromeFactory :IDriverFactory<IWebDriver>
    {
        private readonly Settings settings;

        public ChromeFactory(Settings AppSettings)
        {
            settings = AppSettings;
        }

        public string BrowserName => "chrome";

        public IWebDriver Create()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            var options = new ChromeOptions();
            if (settings.Headless)
                options.AddArgument("--headless");
            return new ChromeDriver(options);
        }
    }
}
