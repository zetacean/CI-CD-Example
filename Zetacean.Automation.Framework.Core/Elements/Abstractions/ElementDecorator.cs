using System;

namespace Zetacean.Automation.Framework.Core.Elements.Abstractions
{
    public abstract class ElementDecorator(Element element) : Element
    {
        protected readonly Element _element = element;

        public override async Task<bool> Displayed() => await _element.Displayed();

        public override async Task Click() => await _element.Click();

        public override async Task<string> GetAttribute(string attributeName) =>
            await _element.GetAttribute(attributeName);

        public override async Task<string> GetText() => await _element.GetText();

        public override async Task TypeText(string text) => await _element.TypeText(text);
    }
}
