using Microsoft.Playwright;
using Zetacean.Automation.Framework.Core.Elements.Abstractions;

namespace Zetacean.Automation.Framework.Core.Browsers.Abstractions
{
    public abstract class DriverDecorator(Driver driver) : Driver, IAsyncDisposable
    {
        protected readonly Driver _driver = driver;

        public override async Task Start(Browser browser) => await _driver?.Start(browser);

        public override async Task GoToUrl(string url) => await _driver?.GoToUrl(url);

        public override Element FindLocator(string selector) => _driver.FindLocator(selector);

        public override Element FindLocator(ILocator locator, string selector) =>
            _driver.FindLocator(locator, selector);

        public override async Task<IReadOnlyCollection<Element>> FindLocators(string selector) =>
            await _driver.FindLocators(selector);

        public override async Task<IReadOnlyCollection<Element>> FindLocators(
            ILocator locator,
            string selector
        ) => await _driver.FindLocators(locator, selector);

        public virtual async ValueTask DisposeAsync()
        {
            if (_driver is IAsyncDisposable asyncDisposable)
                await asyncDisposable.DisposeAsync();

            GC.SuppressFinalize(this);
        }
    }
}
