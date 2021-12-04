using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAuthorizationTest
{
    public class Tests
    {
        private IWebDriver driver;

        private readonly By _singInButton = By.XPath("//span[text()='Войти'");
        private readonly By _telInput = By.XPath("//input[@name='tel']");
        private readonly By _emailInput = By.XPath("//input[@name='username']");


        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://cian.ru");
        }

        [Test]
        public void Test1()
        {
            var singIn = driver.FindElement(_singInButton);
            singIn.Click();

            var tel = driver.FindElement(_telInput);
            tel.SendKeys("7937345678");

            var email = driver.FindElement(_emailInput);
            email.SendKeys("test@test.ru");

            //Assert.Pass();

        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}
