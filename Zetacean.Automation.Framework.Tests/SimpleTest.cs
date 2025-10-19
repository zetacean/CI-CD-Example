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

        private async Task FillLoginInformation(string username)
        {
            await s_driver.GoToUrl("https://www.saucedemo.com/");
            var txtUsername = new LogElement(s_driver.FindLocator("#user-name"));
            var txtPassword = new LogElement(s_driver.FindLocator("#password"));
            var btnLogin = new LogElement(s_driver.FindLocator("#login-button"));

            await txtUsername.TypeText(username);
            await txtPassword.TypeText("secret_sauce");
            await btnLogin.Click();
        }

        [Test]
        public async Task TestSimpleLogin()
        {
            await FillLoginInformation("standard_user");
            var txtFirstProduct = new LogElement(
                s_driver.FindLocator("[data-test='inventory-list'] > div:nth-child(1)")
            );
            Assert.That(
                await txtFirstProduct.Displayed(),
                Is.True,
                "The element was not displayed"
            );
        }

        [Test]
        public async Task TestSimpleLoginFailed()
        {
            await FillLoginInformation("locked_out_user");
            var txtFirstProduct = new LogElement(
                s_driver.FindLocator("[data-test='inventory-list'] > div:nth-child(1)")
            );
            Assert.That(
                await txtFirstProduct.Displayed(),
                Is.True,
                "The element was not displayed"
            );
        }
    }
}
