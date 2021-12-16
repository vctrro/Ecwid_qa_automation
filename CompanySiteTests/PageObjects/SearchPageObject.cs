using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace CompanySiteTests.PageObjects
{
    public class SearchPageObject
    {

        private readonly IWebDriver _webDriver;
        private readonly WebDriverWait _wait;

        private readonly string _pageURN = "/search";

        private readonly By _searchInput = By.Name("keyword");
        private readonly By _priceFromInput = By.XPath("//input[@aria-label='от']");
        private readonly By _priceToInput = By.XPath("//input[@aria-label='до']");
        private readonly By _inStockCheckBox = By.XPath("//input[@id='checkbox-in_stock']");
        private readonly By _onSaleCheckBox = By.XPath("//input[@id='checkbox-on_sale']");

        private readonly By _markerForSearch = By.XPath("//a[@class='grid-product__title']");
        private readonly By _markerForPrice = By.XPath("//div[@class='grid-product__price-value ec-price-item']");
        private readonly By _markerForStockAndSale = By.XPath("//div[@class='grid-product__image-wrap']");


        public string PageURN { get => _pageURN;  }

        public SearchPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(6));
        }

        public IEnumerable<IWebElement> Search(string text)
        {
            IWebElement searchField = _wait.Until<IWebElement>(webDriver => _webDriver.FindElement(_searchInput));
            searchField.SendKeys(text);
            searchField.SendKeys(Keys.Enter);

            Thread.Sleep(1000);

            return _wait.Until(webDriver => _webDriver.FindElements(_markerForSearch));
        }

        public IEnumerable<IWebElement> InStock()
        {
            IWebElement inStockCheckBox = _wait.Until<IWebElement>(webDriver => _webDriver.FindElement(_inStockCheckBox));
            inStockCheckBox.Click();

            Thread.Sleep(1000);

            return _wait.Until(webDriver => _webDriver.FindElements(_markerForStockAndSale));
        }

        public IEnumerable<IWebElement> OnSale()
        {
            IWebElement onSaleCheckBox = _wait.Until<IWebElement>(webDriver => _webDriver.FindElement(_onSaleCheckBox));
            onSaleCheckBox.Click();

            Thread.Sleep(1000);

            return _wait.Until(webDriver => _webDriver.FindElements(_markerForStockAndSale));
        }

        public IEnumerable<IWebElement> Price(int from, int to)
        {
            IWebElement priceFromField = _wait.Until<IWebElement>(webDriver => _webDriver.FindElement(_priceFromInput));
            IWebElement priceToField = _webDriver.FindElement(_priceToInput);
            priceFromField.SendKeys(from.ToString());
            priceToField.SendKeys(to.ToString());
            priceToField.SendKeys(Keys.Enter);

            Thread.Sleep(1000);

            return _wait.Until(webDriver => _webDriver.FindElements(_markerForPrice));

            //Actions action = new Actions(_webDriver);
            //action.
        }



    }
}
