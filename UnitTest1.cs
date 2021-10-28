using NUnit.Framework;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Befimmo
{
    public class Tests
    {
        private IWebDriver driver;
        private IJavaScriptExecutor js;
        public IDictionary<string, object> vars { get; private set; }

        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            js = (IJavaScriptExecutor)driver;
            vars = new Dictionary<string, object>();
        }

        [Test]
        public void Buildings()
        {
            driver.Navigate().GoToUrl("https://www.standaard.be");
            driver.FindElement(By.Id("didomi-notice-agree-button")).Click();
            driver.FindElement(By.LinkText("Buitenland")).Click();
            driver.FindElement(By.LinkText("Corona")).Click();
            driver.FindElement(By.CssSelector(".searchbox-toggle")).Click();
            driver.FindElement(By.Name("keyword")).Click();
            driver.FindElement(By.Name("keyword")).SendKeys("nieuwnieuws");
            driver.FindElement(By.Name("keyword")).SendKeys(Keys.Enter);
        }

        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }
    }
}
