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
            contact.FirstName = "Юлия";
            contact.LastName = "Милонова";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts
                .AddNewContact()
                .FillContactForm(contact)
                .LinkNewContact();
            app.Contacts.ReturnToHomePage();
                
            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactsCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort((left, right) => left.LastName.CompareTo(right.LastName));
            newContacts.Sort((left, right) => left.LastName.CompareTo(right.LastName));

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}

