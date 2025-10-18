using Zetacean.Automation.Framework.Core.Browsers;
using Zetacean.Automation.Framework.Core.Browsers.Abstractions;
using Zetacean.Automation.Framework.Core.Elements;

namespace Zetacean.Automation.Framework.Tests
{
    public class Tests
    {
        private static Driver s_driver;

        [SetUp]
        public async Task Setup()
        {
            s_driver = new LoggingDriver(new WebCoreDriver());
            await s_driver.Start(Browser.Chrome);
        }

        [TearDown]
        public async Task TearDown()
        {
            if (s_driver is IAsyncDisposable asyncDisposable)
            {
                await asyncDisposable.DisposeAsync();
            }
        }

        [Test]
        public async Task TestSimpleLogin()
        {
            await s_driver.GoToUrl("https://www.saucedemo.com/");
            var txtUsername = new LogElement(s_driver.FindLocator("#user-name"));
            var txtPassword = new LogElement(s_driver.FindLocator("#password"));
            var btnLogin = new LogElement(s_driver.FindLocator("#login-button"));
            var txtFirstProduct = new LogElement(
                s_driver.FindLocator("[data-test='inventory-list'] > div:nth-child(1)")
            );
            await txtUsername.TypeText("standard_user");
            await txtPassword.TypeText("secret_sauce");
            await btnLogin.Click();
            Assert.That(await txtFirstProduct.Displayed(), Is.True);
        }
    }
}
