using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UnitTests
{
    public class AdminLogin
    {
        private readonly IWebDriver _driver;
        public AdminLogin()
        {
            _driver = new ChromeDriver();
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Fact]
        public void Login()
        {
            _driver.Navigate().GoToUrl("https://localhost:7255/Identity/Account/Login");
            _driver.FindElement(By.Id("Input_Email")).SendKeys("admin@admin.admin");
            _driver.FindElement(By.Id("Input_Password")).SendKeys("@dmin4DMIN");
            _driver.FindElement(By.Id("login-submit")).Click();
            Assert.Equal("https://localhost:7255/", _driver.Url);
        }
    }
}