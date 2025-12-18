using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAuto.Core;
using TestAuto.Core.Interfaces;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace TestAuto.Infra.Selenium
{
    public class EdgeFactory : IDriverFactory<IWebDriver>
    {
        private readonly Settings _settings;

        public string BrowserName => "edge";

        public EdgeFactory(Settings settings)
        {
            _settings = settings;
        }

        public IWebDriver Create()
        {
            new DriverManager().SetUpDriver(new EdgeConfig(),VersionResolveStrategy.MatchingBrowser);
            var options = new EdgeOptions();
            if (_settings.Headless)
                options.AddArgument("--headless");
            return new EdgeDriver(options);
        }
    }
}
