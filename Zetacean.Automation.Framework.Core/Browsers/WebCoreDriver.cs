using Microsoft.Playwright;
using Zetacean.Automation.Framework.Core.Browsers.Abstractions;
using Zetacean.Automation.Framework.Core.Elements;
using Zetacean.Automation.Framework.Core.Elements.Abstractions;

namespace Zetacean.Automation.Framework.Core.Browsers
{
    public class WebCoreDriver : Driver, IAsyncDisposable
    {
        private IPlaywright _playwright;
        private IPage _page;
        private IBrowser _browser;
        private bool _disposed;

        public override async Task Start(Browser browser)
        {
            _playwright = await Playwright.CreateAsync();
            switch (browser)
            {
                case Browser.Chrome:
                    _browser = await _playwright.Chromium.LaunchAsync(
                        new BrowserTypeLaunchOptions() { Headless = true }
                    );
                    _page = await _browser.NewPageAsync();
                    break;
            }
        }

        public override async Task GoToUrl(string url) => await _page.GotoAsync(url);

        public override Element FindLocator(string selector)
        {
            var locator = _page.Locator(selector);
            return new WebElement(locator);
        }

        public override Element FindLocator(ILocator locator, string selector)
        {
            var insideLocator = locator.Locator(selector);
            return new WebElement(insideLocator);
        }

        public override async Task<IReadOnlyCollection<Element>> FindLocators(string selector)
        {
            var locators = new List<Element>();
            foreach (var element in await _page.Locator(selector).AllAsync())
            {
                locators.Add(new WebElement(element));
            }

            return locators;
        }

        public override async Task<IReadOnlyCollection<Element>> FindLocators(
            ILocator locator,
            string selector
        )
        {
            var locators = new List<Element>();
            foreach (var element in await locator.Locator(selector).AllAsync())
            {
                locators.Add(new WebElement(element));
            }

            return locators;
        }

        public async ValueTask DisposeAsync()
        {
            if (_disposed)
                return;

            if (_page is not null)
            {
                await _page.CloseAsync();
                _page = null;
            }

            if (_browser is not null)
            {
                await _browser.CloseAsync();
                _browser = null;
            }

            _playwright?.Dispose();
            _playwright = null;

            _disposed = true;

            GC.SuppressFinalize(this);
        }
    }
}
