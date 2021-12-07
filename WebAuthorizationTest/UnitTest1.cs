using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebAuthorizationTest.PageObjects;

namespace WebAuthorizationTest
{

    public class Tests
    {
        private IWebDriver _webDriver;
        private SearchPageObject _searchPageObject;
        private WebDriverWait _wait;

        private readonly string _siteURL = "https://buy-in-10-seconds.company.site";

        private readonly By _markerForSearch = By.XPath("//a[@class='grid-product__title']");
        private readonly By _markerForPrice = By.XPath("//div[@class='grid-product__price-value ec-price-item']");
        private readonly By _markerForStockAndSale = By.XPath("//div[@class='grid-product__image-wrap']");

        [SetUp]
        public void Setup()
        {
            _webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();
            _searchPageObject = new SearchPageObject(_webDriver);
            _webDriver.Navigate().GoToUrl(_siteURL + _searchPageObject.PageURN);
            _wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(6));
        }

        [Test]
        [TestCase("1")]
        [TestCase("ТОвар")]
        [TestCase("5")]
        public void SearchTest(string keywords)
        {
            _searchPageObject.Search(keywords);
            Thread.Sleep(1000);

            var searchResults = _wait.Until(webDriver => _webDriver.FindElements(_markerForSearch));

            keywords = keywords.ToLower();
            foreach (var element in searchResults)
            {
                if (element.Text.ToLower().Contains(keywords) == false)
                    Assert.Fail($"\n\"{element.Text}\" не содержит \"{keywords}\"");
            }

            Assert.Pass();
        }

        [Test]
        [TestCase(0, 1)]
        [TestCase(1, 5)]
        public void PriceTest(int from, int to)
        {
            _searchPageObject.Price(from, to);
            Thread.Sleep(1000);

            var searchResults = _wait.Until(webDriver => _webDriver.FindElements(_markerForPrice));

            foreach (var element in searchResults)
            {
                var price = Convert.ToDouble(element.Text.Substring(1));
 
                if (price > to || price < from) Assert.Fail($"\nЦена \"{price}\" не соответствует диапазону \"{from}\" - \"{to}\"");
            }

            Assert.Pass();
        }

        [Test]
        public void InStockTest()
        {
            _searchPageObject.InStock();
            Thread.Sleep(1000);

            var searchResults = _wait.Until(webDriver => _webDriver.FindElements(_markerForStockAndSale));

            foreach (var element in searchResults)
            {
                if (element.Text.ToLower().Contains("распродано") == true)
                    Assert.Fail($"\nПоказаны товары без скидки");
            }

            Assert.Pass();
        }

        [Test]
        public void OnSaleTest()
        {
            _searchPageObject.OnSale();
            Thread.Sleep(1000);

            var searchResults = _wait.Until(webDriver => _webDriver.FindElements(_markerForStockAndSale));

            foreach (var element in searchResults)
            {
                if (element.Text.ToLower().Contains("распродажа") == false)
                    Assert.Fail($"\nНе все показанные товары в наличии");
            }

            Assert.Pass();
        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}
