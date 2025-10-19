using Microsoft.Playwright;
using Zetacean.Automation.Framework.Core.Elements.Abstractions;

namespace Zetacean.Automation.Framework.Core.Elements
{
    public class WebElement(ILocator locator) : Element
    {
        private readonly ILocator _locator = locator;

        public override async Task<bool> Displayed() => await _locator.IsVisibleAsync();

        public override async Task Click() => await _locator.ClickAsync();

        public override async Task<string> GetText() => await _locator.TextContentAsync();

        public override async Task TypeText(string text) => await _locator.FillAsync(text);

        public override async Task<string> GetAttribute(string attributeName) =>
            await _locator.GetAttributeAsync(attributeName);
    }
}
