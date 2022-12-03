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
            driver.FindElement(By.XPath("//img[@alt='Picture of 14.1-inch Laptop']")).Click();
            driver.FindElement(By.Id("addtocart_31_EnteredQuantity")).Click();
            driver.FindElement(By.Id("addtocart_31_EnteredQuantity")).Clear();
            driver.FindElement(By.Id("addtocart_31_EnteredQuantity")).SendKeys("2");
            driver.FindElement(By.Id("add-to-cart-button-31")).Click();
            driver.FindElement(By.XPath("//li[@id='topcartlink']/a/span")).Click();
            driver.FindElement(By.Id("termsofservice")).Click();
            driver.FindElement(By.Id("checkout")).Click();
            driver.FindElement(By.XPath("//input[@value='Checkout as Guest']")).Click();
            driver.FindElement(By.Id("BillingNewAddress_FirstName")).Click();
            driver.FindElement(By.Id("BillingNewAddress_FirstName")).Clear();
            driver.FindElement(By.Id("BillingNewAddress_FirstName")).SendKeys("Pero");
            driver.FindElement(By.Id("BillingNewAddress_LastName")).Click();
            driver.FindElement(By.Id("BillingNewAddress_LastName")).Clear();
            driver.FindElement(By.Id("BillingNewAddress_LastName")).SendKeys("Perić");
            driver.FindElement(By.Id("BillingNewAddress_Email")).Click();
            driver.FindElement(By.Id("BillingNewAddress_Email")).Clear();
            driver.FindElement(By.Id("BillingNewAddress_Email")).SendKeys("test@mail.com");
            driver.FindElement(By.Id("BillingNewAddress_CountryId")).Click();
            new SelectElement(driver.FindElement(By.Id("BillingNewAddress_CountryId"))).SelectByText("Croatia");
            driver.FindElement(By.XPath("//option[@value='24']")).Click();
            driver.FindElement(By.Id("BillingNewAddress_City")).Click();
            driver.FindElement(By.Id("BillingNewAddress_City")).Clear();
            driver.FindElement(By.Id("BillingNewAddress_City")).SendKeys("Osijek");
            driver.FindElement(By.Id("BillingNewAddress_Address1")).Click();
            driver.FindElement(By.Id("BillingNewAddress_Address1")).Clear();
            driver.FindElement(By.Id("BillingNewAddress_Address1")).SendKeys("Sjenjak 5");
            driver.FindElement(By.Id("BillingNewAddress_ZipPostalCode")).Click();
            driver.FindElement(By.Id("BillingNewAddress_ZipPostalCode")).Clear();
            driver.FindElement(By.Id("BillingNewAddress_ZipPostalCode")).SendKeys("123");
            driver.FindElement(By.Id("BillingNewAddress_PhoneNumber")).Click();
            driver.FindElement(By.Id("BillingNewAddress_PhoneNumber")).Clear();
            driver.FindElement(By.Id("BillingNewAddress_PhoneNumber")).SendKeys("0991234567");
            driver.FindElement(By.XPath("//input[@value='Continue']")).Click();
            driver.FindElement(By.XPath("//div[@id='shipping-buttons-container']/input")).Click();
            driver.FindElement(By.XPath("//div[@id='shipping-method-buttons-container']/input")).Click();
            driver.FindElement(By.XPath("//div[@id='payment-method-buttons-container']/input")).Click();
            driver.FindElement(By.XPath("//div[@id='payment-info-buttons-container']/input")).Click();
            driver.FindElement(By.XPath("//input[@value='Confirm']")).Click();
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
