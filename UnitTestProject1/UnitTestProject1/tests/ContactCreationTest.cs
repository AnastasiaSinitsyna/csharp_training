    using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData();
            contact.FirstName = "Надежда";
            contact.LastName = "Рожкова";

            List<string> oldContacts = app.Contacts.GetContactList();

            app.Contacts
                .AddNewContact()
                .FillContactForm(contact)
                .LinkNewContact();
            app.Contacts.ReturnToHomePage();
            List<string> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact.LastName + contact.FirstName);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}

