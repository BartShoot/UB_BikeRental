using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [Fact]
        public void ReservationTest()
        {
            var test = new AdminLogin();
            test.Login();
            _driver.Navigate().GoToUrl("https://localhost:7255/Users/Home/Index");
        }
    }
}
