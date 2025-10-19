using Zetacean.Automation.Framework.Core.Elements.Abstractions;

namespace Zetacean.Automation.Framework.Core.Elements
{
    public class LogElement(Element element) : ElementDecorator(element)
    {
        public override async Task<bool> Displayed()
        {
            var status = await _element.Displayed();
            Console.WriteLine($"Element Displayed = {status}");
            return status;
        }

        public override async Task Click()
        {
            Console.WriteLine("Element Clicked");
            await _element.Click();
        }

        public override async Task<string> GetAttribute(string attributeName)
        {
            Console.WriteLine($"Get Element's Attribute = {attributeName}");
            return await _element.GetAttribute(attributeName);
        }

        public override async Task<string> GetText()
        {
            var text = await _element.GetText();
            Console.WriteLine($"Element Text = {text}");
            return text;
        }

        public override async Task TypeText(string text)
        {
            Console.WriteLine($"Type Text = {text}");
            await _element.TypeText(text);
        }
    }
}
