using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebAuthorizationTest.PageObjects
{
    public class SearchPageObject
    {
        private readonly IWebDriver _webDriver;
        private readonly WebDriverWait _wait;

        private readonly string _pageURL = "https://buy-in-10-seconds.company.site/search";
        private readonly By _searchInput = By.Name("keyword");
        private readonly By _priceFromInput = By.XPath("//input[@aria-label='от']");
        private readonly By _priceToInput = By.XPath("//input[@aria-label='до']");
        private readonly By _inStockCheckBox = By.XPath("//input[@id='checkbox-in_stock']");
        private readonly By _onSaleCheckBox = By.XPath("//input[@id='checkbox-on_sale']");

        public SearchPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _webDriver.Navigate().GoToUrl(_pageURL);
            _wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(6));
        }

        public void Search(string text)
        {
            IWebElement searchField = _wait.Until<IWebElement>(webDriver => _webDriver.FindElement(_searchInput));
            searchField.SendKeys(text);
            searchField.SendKeys(Keys.Enter);
        }

        public void InStock()
        {
            IWebElement inStockCheckBox = _wait.Until<IWebElement>(webDriver => _webDriver.FindElement(_inStockCheckBox));
            inStockCheckBox.Click();
        }

        public void OnSale()
        {
            IWebElement onSaleCheckBox = _wait.Until<IWebElement>(webDriver => _webDriver.FindElement(_onSaleCheckBox));
            onSaleCheckBox.Click();
        }

        public void Price(int from, int to)
        {
            IWebElement priceFromField = _wait.Until<IWebElement>(webDriver => _webDriver.FindElement(_priceFromInput));
            IWebElement priceToInput = _webDriver.FindElement(_priceToInput);
            priceFromField.SendKeys(from.ToString());
            priceToInput.SendKeys(to.ToString());
            priceToInput.SendKeys(Keys.Enter);
        }



    }
}
