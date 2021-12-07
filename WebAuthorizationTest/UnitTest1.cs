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
        //[TestCase("Товар 2")]
        //[TestCase("5")]
        public void SearchTest(string text)
        {
            _searchPageObject.Search(text);
        }

        [Test]
        [TestCase(1, 5)]
        //[TestCase(2, 4)]
        public void PriceTest(int from, int to)
        {
            _searchPageObject.Price(from, to);

            //Assert.Pass();
        }

        [Test]
        public void InStockTest()
        {
            _searchPageObject.InStock();
        }
        
        [Test]
        public void OnSaleTest()
        {
            _searchPageObject.OnSale();
        }

        [TearDown]
        public void TearDown()
        {
            //driver.Quit();
        }
    }
}
