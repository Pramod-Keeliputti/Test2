using OpenQA.Selenium;

namespace TestAuto.Core.Interfaces
{
    public interface IDriverFactory <out T> where T : IWebDriver
    {
        string BrowserName { get; }

        IWebDriver Create();
    }
}
