using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;

public class BaseTest
{
    // Use ThreadLocal to ensure that even if tests share the same class instance,
    // the driver and scope are physically tied to the executing thread.
    private ThreadLocal<IWebDriver> _driver = new();
    private ThreadLocal<IServiceScope> _scope = new();

    // Property for easy access in your tests
    protected IWebDriver driver => _driver.Value;

    [SetUp]
    public void Setup()
    {
        // 1. Get the shared root provider
        var provider = ContainerBuilder.GetProvider();

        // 2. Create a private bucket for THIS test
        var scope = provider.CreateScope();
        _scope.Value = scope;

        // 3. Resolve the driver from the private bucket
        _driver.Value = scope.ServiceProvider.GetRequiredService<IWebDriver>();
    }

    [TearDown]
    public void TearDown()
    {
        // 1. Close the browser
        _driver.Value?.Quit();

        // 2. Dispose the scope (satisfies NUnit 1032 and cleans up DI)
        _scope.Value?.Dispose();

        // 3. Optional: Clear the thread-local values
        _driver.Value = null;
        _scope.Value = null;
    }
}