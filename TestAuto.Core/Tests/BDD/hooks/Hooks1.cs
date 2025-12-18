using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;

namespace Tests.BDD.hooks
{
    [Binding]
    public sealed class Hooks1
    {
        private readonly IObjectContainer _container;


        public Hooks1(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario("google","facebook")]
        public void BeforeScenario()
        {
            var provider = ContainerBuilder.GetProvider();
            var scope= provider.CreateScope();

            var driver = scope.ServiceProvider.GetRequiredService<IWebDriver>();

            _container.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _container.Resolve<IWebDriver>().Dispose();
        }
    }
}