using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class UntitledTestCase
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheUntitledTestCaseTest()
        {
            driver.Navigate().GoToUrl("https://demowebshop.tricentis.com/");
            driver.Navigate().GoToUrl("https://demowebshop.tricentis.com/");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='$25 Virtual Gift Card'])[1]/following::img[1]")).Click();
            driver.FindElement(By.XPath("//input[@value='Email a friend']")).Click();
            driver.FindElement(By.Id("FriendEmail")).Click();
            driver.FindElement(By.Id("FriendEmail")).Clear();
            driver.FindElement(By.Id("FriendEmail")).SendKeys("test1@mail.com");
            driver.FindElement(By.Id("YourEmailAddress")).Click();
            driver.FindElement(By.Id("YourEmailAddress")).Clear();
            driver.FindElement(By.Id("YourEmailAddress")).SendKeys("test2@mail.com");
            driver.FindElement(By.Id("PersonalMessage")).Click();
            driver.FindElement(By.Id("PersonalMessage")).Clear();
            driver.FindElement(By.Id("PersonalMessage")).SendKeys("Osobna poruka.");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Email a friend'])[1]/following::div[4]")).Click();
            driver.FindElement(By.Name("send-email")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
