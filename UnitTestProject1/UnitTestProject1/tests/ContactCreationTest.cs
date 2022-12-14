    using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            app.Contacts
                .AddNewContact()
                .FillContactForm("Viktor", "Sokolov")
                .LinkNewContact();
            app.Navigator.ReturnToHome();
            app.Auth.LogOut();
        }
    }
}

