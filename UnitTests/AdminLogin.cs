using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UnitTests
{
    public class AdminLogin
    {
        private readonly IWebDriver _driver;
        public AdminLogin()
        {
            _driver = new ChromeDriver();
        }

        internal void Dispose()
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
            Assert.Equal()
        }

        [Fact]
        public void Reservation()
        {
            Login();
            _driver.Navigate().GoToUrl("https://localhost:7255/Users/Home/Index");
            List<IWebElement> links = new List<IWebElement>();
            links = _driver.FindElements(By.TagName("a")).ToList();
            links[2].Click();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            var select = _driver.FindElement(By.Id("VehicleID"));
            var selectElement = new SelectElement(select);
            selectElement.SelectByIndex(2);
            var selectedOption = selectElement.SelectedOption;
            Assert.NotNull(selectedOption);
            var createButton = _driver.FindElement(
                By.CssSelector("input[itemid='make-reservation'][type='submit'][value='Create'][class='btn btn-primary']"));
            createButton.Click();
            Assert.Equal("https://localhost:7255/Users/Home/Index", _driver.Url);
        }
    }
}