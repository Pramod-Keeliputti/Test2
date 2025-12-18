using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using TestAuto.Core;

public static class ContainerBuilder
{
    private static readonly IServiceProvider _rootProvider;

    static ContainerBuilder()
    {
        var services = new ServiceCollection();
        var settings = Configuration.GetConfiguration();

        services.AddSingleton(settings);

        // Register the Driver as Scoped. 
        // This code ONLY runs when someone calls GetRequiredService<IWebDriver>()
        services.AddScoped<IWebDriver>(provider =>
        {
            var s = provider.GetRequiredService<Settings>();
            // Logic to pick the right browser
            IWebDriver driver = s.BrowserName.ToLower() switch
            {
                "chrome" => new OpenQA.Selenium.Chrome.ChromeDriver(),
                "firefox" => new OpenQA.Selenium.Firefox.FirefoxDriver(),
                _ => throw new Exception("Browser not supported")
            };

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            return driver;
        });

        _rootProvider = services.BuildServiceProvider();
    }

    public static IServiceProvider GetProvider() => _rootProvider;
}