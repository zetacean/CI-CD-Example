using Microsoft.Playwright;
using Zetacean.Automation.Framework.Core.Browsers.Abstractions;
using Zetacean.Automation.Framework.Core.Elements.Abstractions;

namespace Zetacean.Automation.Framework.Core.Browsers
{
    public class LoggingDriver(Driver driver) : DriverDecorator(driver)
    {
        public override async Task Start(Browser browser)
        {
            Console.WriteLine($"Start browser = {Enum.GetName(typeof(Browser), browser)}");
            await _driver?.Start(browser);
        }

        public override async Task GoToUrl(string url)
        {
            Console.WriteLine($"Go to URL = {url}");
            await _driver?.GoToUrl(url);
        }

        public override Element FindLocator(string selector)
        {
            Console.WriteLine("Find Locator");
            return _driver?.FindLocator(selector);
        }

        public override Element FindLocator(ILocator locator, string selector)
        {
            Console.WriteLine("Find Locator");
            return _driver?.FindLocator(locator, selector);
        }

        public override async Task<IReadOnlyCollection<Element>> FindLocators(string selector)
        {
            Console.WriteLine("Find Locatos");
            return await _driver?.FindLocators(selector);
        }

        public override Task<IReadOnlyCollection<Element>> FindLocators(
            ILocator locator,
            string selector
        )
        {
            Console.WriteLine("Find Locatos");
            return _driver?.FindLocators(locator, selector);
        }
    }
}
