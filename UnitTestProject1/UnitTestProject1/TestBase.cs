using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System.Text;

namespace WebAddressbookTests
{
    public class TestBase
    {
        protected IWebDriver driver;
        protected StringBuilder verificationErrors;
        protected string baseURL;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook/";
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
    }
}