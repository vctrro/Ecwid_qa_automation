using System;
using OpenQA.Selenium;

namespace WebAuthorizationTest.PageObjects
{
    public class SearchPageObject
    {
        private IWebDriver _webDriver;

        private readonly By _searchInput = By.Name("keyword");
        private readonly By _priceFromInput = By.XPath("//input[@aria-label='от']");
        private readonly By _priceToInput = By.XPath("//input[@aria-label='до']");
        private readonly By _inStockCheckBox = By.XPath("//input[@id='checkbox-in_stock']");

        public SearchPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void Search(string text)
        {
            _webDriver.FindElement(_searchInput).SendKeys(text);
        }

        public void InStock()
        {
            _webDriver.FindElement(_inStockCheckBox).Click();
        }

        public void Price(int from, int to)
        {
            _webDriver.FindElement(_priceFromInput).SendKeys(from.ToString());
            _webDriver.FindElement(_priceToInput).SendKeys(to.ToString());
        }



    }
}
