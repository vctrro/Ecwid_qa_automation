using System;
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

        private readonly string _siteURL = "https://buy-in-10-seconds.company.site";

        [SetUp]
        public void Setup()
        {
            _webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();
            _searchPageObject = new SearchPageObject(_webDriver);
            _webDriver.Navigate().GoToUrl(_siteURL + _searchPageObject.PageURN);
        }

        [Test]
        [TestCase("1")]
        [TestCase("ТОвар")]
        [TestCase("5")]
        public void SearchTest(string keywords)
        {
            var searchResults =  _searchPageObject.Search(keywords);

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
            var searchResults = _searchPageObject.Price(from, to);

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
            var searchResults = _searchPageObject.InStock();

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
            var searchResults = _searchPageObject.OnSale(); 

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
