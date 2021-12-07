using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebAuthorizationTest.PageObjects;

namespace WebAuthorizationTest
{

    public class Tests
    {
        private IWebDriver driver;
        private SearchPageObject searchPageObject;

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://buy-in-10-seconds.company.site/search");
            searchPageObject = new SearchPageObject(driver);
        }

        [Test]
        [TestCase(1, 5)]
        [TestCase(2, 4)]
        public void Test1(int from, int to)
        {
            searchPageObject.Price(from, to);

            //Assert.Pass();
        }

        [Test]
        [TestCase("1")]
        [TestCase("Товар 2")]
        [TestCase("5")]
        public void Test2(string text)
        {
            searchPageObject.Search(text);
        }

        [Test]
        public void Test3()
        {
            searchPageObject.InStock();
        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}
