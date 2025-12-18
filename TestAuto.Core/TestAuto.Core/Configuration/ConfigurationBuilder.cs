using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAuto.Core
{
    public static class Configuration
    {
        private static IConfiguration _config;

        public static Settings? GetConfiguration()
        {
           var config =  new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Appsettings.json").Build();

            return config.Get<Settings>();
        }
    }


    public class Settings
    {
        public string BrowserName { get; set; }
        public int ImplicitWaitTime { get; set; }
        public bool Headless { get; set; }

        public bool UseGrid { get; set; }

        public string GridUrl { get; set; }
    }
}
