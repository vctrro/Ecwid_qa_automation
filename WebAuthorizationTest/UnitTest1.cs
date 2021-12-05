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
            searchPageObject.SearchText("Тов");

            //Assert.Pass();

        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}
