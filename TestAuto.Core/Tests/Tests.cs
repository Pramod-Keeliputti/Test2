

using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;

[assembly: Parallelizable(ParallelScope.All)]
namespace Tests
{
    [TestFixture]
    public class Tests : BaseTest
    {

        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl("http://www.google.com");
            Assert.That(driver.Title.ToLower().Contains("google"));
        }

        [Test]
        public void Test2()
        {
            driver.Navigate().GoToUrl("http://www.facebook.com");
            Assert.That(driver.Title.ToLower().Contains("facebook"));
        }

        [Test]
        public void Test3()
        {
            driver.Navigate().GoToUrl("http://www.amazon.com");
            Assert.That(driver.Title.ToLower().Contains("amazon"));
        }
    }
}
