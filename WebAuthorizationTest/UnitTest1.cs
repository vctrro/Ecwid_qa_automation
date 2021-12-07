﻿using System;
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
        [TestCase("Товар")]
        [TestCase("5")]
        public void SearchTest(string keywords)
        {
            _searchPageObject.Search(keywords);
            Thread.Sleep(1000);

            var searchResults = _wait.Until(webDriver => _webDriver.FindElements(_markerForSearch));

            foreach (var element in searchResults)
            {
                if (!element.Text.Contains(keywords)) Assert.Fail($"\n\"{element.Text}\" not contain \"{keywords}\"");
            }

            Assert.Pass();
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
            _webDriver.Quit();
        }
    }
}
