using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
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
        public void Test1()
        {
            Thread.Sleep(6000);
            searchPageObject.Search("Тов");

            searchPageObject.Price(2, 5);

            //searchPageObject.InStock();
            //Assert.Pass();

        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}
