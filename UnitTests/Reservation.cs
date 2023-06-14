using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace UnitTests
{
    public class Reservation
    {
        private readonly IWebDriver _driver;
        public Reservation()
        {
            _driver = new ChromeDriver();
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        //[Fact]
        public void ReservationTest()
        {
            var test = new AdminLogin();
            test.Login();
            _driver.Navigate().Refresh();
            _driver.Navigate().GoToUrl("https://localhost:7255/Users/Home/Index");
            List<IWebElement> links = new List<IWebElement>();
            links = _driver.FindElements(By.LinkText("a")).ToList();
            links[1].Click();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            var select = _driver.FindElement(By.Id("VehicleID"));
            var selectElement = new SelectElement(select);
            selectElement.SelectByIndex(2);
            var selectedOption = selectElement.SelectedOption;
            Assert.NotNull(selectedOption);
            _driver.FindElement(By.CssSelector("btn btn-primary")).Click();
            Assert.Equal("https://localhost:7255/Users/Home/MakeReservation", _driver.Url);
        }
    }
}
