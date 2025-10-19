using Microsoft.Playwright;
using Zetacean.Automation.Framework.Core.Elements.Abstractions;

namespace Zetacean.Automation.Framework.Core.Browsers.Abstractions
{
    public abstract class Driver
    {
        public abstract Task Start(Browser browser);
        public abstract Task GoToUrl(string url);
        public abstract Element FindLocator(string selector);
        public abstract Element FindLocator(ILocator locator, string selector);
        public abstract Task<IReadOnlyCollection<Element>> FindLocators(string selector);
        public abstract Task<IReadOnlyCollection<Element>> FindLocators(
            ILocator locator,
            string selector
        );
    }
}
