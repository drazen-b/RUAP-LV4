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
        private WebDriverWait wait;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
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
        public void TheUntitledTestCaseTest1()
        {
            driver.Navigate().GoToUrl("https://demowebshop.tricentis.com/");
            driver.FindElement(By.Id("small-searchterms")).Click();
            driver.FindElement(By.Id("small-searchterms")).Clear();
            driver.FindElement(By.Id("small-searchterms")).SendKeys("laptop");
            driver.FindElement(By.XPath("//input[@value='Search']")).Click();
        }

        [Test]
        public void TheUntitledTestCaseTest2()
        {
            driver.Navigate().GoToUrl("https://demowebshop.tricentis.com/");
            driver.Navigate().GoToUrl("https://demowebshop.tricentis.com/");
            driver.FindElement(By.XPath("//img[@alt='Picture of 14.1-inch Laptop']")).Click();
            driver.FindElement(By.Id("addtocart_31_EnteredQuantity")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | id=addtocart_31_EnteredQuantity | ]]
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
            driver.FindElement(By.Id("BillingNewAddress_LastName")).SendKeys("Peric");
            driver.FindElement(By.Id("BillingNewAddress_Email")).Click();
            driver.FindElement(By.Id("BillingNewAddress_Email")).Clear();
            driver.FindElement(By.Id("BillingNewAddress_Email")).SendKeys("test@mail.com");
            driver.FindElement(By.Id("BillingNewAddress_CountryId")).Click();
            new SelectElement(driver.FindElement(By.Id("BillingNewAddress_CountryId"))).SelectByText("Costa Rica");
            driver.FindElement(By.XPath("//option[@value='23']")).Click();
            driver.FindElement(By.Id("BillingNewAddress_Address1")).Click();
            driver.FindElement(By.Id("BillingNewAddress_Address1")).Clear();
            driver.FindElement(By.Id("BillingNewAddress_Address1")).SendKeys("Sjenjak");
            driver.FindElement(By.Id("BillingNewAddress_City")).Click();
            driver.FindElement(By.Id("BillingNewAddress_City")).Clear();
            driver.FindElement(By.Id("BillingNewAddress_City")).SendKeys("Osijek");
            driver.FindElement(By.Id("BillingNewAddress_ZipPostalCode")).Click();
            driver.FindElement(By.Id("BillingNewAddress_ZipPostalCode")).Clear();
            driver.FindElement(By.Id("BillingNewAddress_ZipPostalCode")).SendKeys("123");
            driver.FindElement(By.Id("BillingNewAddress_PhoneNumber")).Click();
            driver.FindElement(By.Id("BillingNewAddress_PhoneNumber")).Clear();
            driver.FindElement(By.Id("BillingNewAddress_PhoneNumber")).SendKeys("0991234567");
            
            driver.FindElement(By.XPath("//input[@value='Continue']")).Click();
            wait.Until(driver => driver.FindElement(By.Id("billing-buttons-container"))).Click();
            driver.FindElement(By.Id("billing-buttons-container")).Click();
            //driver.SwitchTo().Frame(driver.FindElement(By.XPath("//div[@id='shipping-buttons-container']/input")));
            wait.Until(driver => driver.FindElement(By.XPath("//div[@id='shipping-buttons-container']/input"))).Click();
            //driver.FindElement(By.XPath("//div[@id='shipping-buttons-container']/input")).Click();

            driver.FindElement(By.XPath("//div[@id='shipping-method-buttons-container']/input")).Click();
            
            driver.FindElement(By.XPath("//div[@id='payment-method-buttons-container']/input")).Click();
            
            driver.FindElement(By.XPath("//div[@id='payment-info-buttons-container']/input")).Click();
            
            driver.FindElement(By.XPath("//input[@value='Confirm']")).Click();
        }

        [Test]
        public void TheUntitledTestCaseTest3()
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

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
