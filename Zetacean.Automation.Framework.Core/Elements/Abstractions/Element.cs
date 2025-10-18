namespace Zetacean.Automation.Framework.Core.Elements.Abstractions
{
    public abstract class Element
    {
        public abstract Task<bool> Displayed();
        public abstract Task Click();
        public abstract Task<string> GetText();
        public abstract Task TypeText(string text);
        public abstract Task<string> GetAttribute(string attributeName);
    }
}
