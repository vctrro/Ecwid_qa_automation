using System;
using OpenQA.Selenium;

namespace WebAuthorizationTest.PageObjects
{
    public class SearchPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _searchInput = By.XPath("//input[@name='keyword']");

        public SearchPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void SearchText(string text)
        {
            _webDriver.FindElement(_searchInput).SendKeys(text);
        }


    }
}
