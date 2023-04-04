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
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData();
            contact.FirstName = "Viktor";
            contact.LastName = "Sokolov";

            app.Contacts
                .AddNewContact()
                .FillContactForm(contact)
                .LinkNewContact();
            app.Contacts.ReturnToHomePage();
        }
    }
}

