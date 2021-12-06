using System.Threading;
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
        public void Test1()
        {
            driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(6);
            //Thread.Sleep(6000);

            searchPageObject.Search("Тов");

            searchPageObject.Price(2, 5);

            WebElement tempElement = (new WebDriverWait(driver, System.TimeSpan.FromSeconds(6))
                .Until<WebElement>((driver) => (WebElement)driver.FindElement(By.XPath("//input[@id='checkbox-in_stock']"))));

            tempElement.Click();

            //searchPageObject.InStock();

            //Assert.Pass();

        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}
