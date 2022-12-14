using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System.Text;

namespace WebAddressbookTests
{
    public class TestBase
    {
        protected IWebDriver driver;
        protected string baseURL;

        protected ApplicationManager app;

        [SetUp] 
        public void SetupTest()
        {
            app = new ApplicationManager();
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }
    }
}