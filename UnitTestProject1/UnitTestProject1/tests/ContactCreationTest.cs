using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml;
using System.Xml.Serialization;
using NUnit.Framework.Constraints;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData
                {
                    FirstName = GenerateRandomString(20),
                    LastName = GenerateRandomString(30)
                });
            }
            return contacts;
        }
        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            return (List<ContactData>)
                new XmlSerializer(typeof(List<ContactData>))
                    .Deserialize(new StreamReader(@"contacts.xml"));
        }
        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(@"contacts.json"));
        }

            [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(ContactData contact)
        {
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

            [Test, TestCaseSource("ContactDataFromXmlFile")]
            public void FromXmlFile(ContactData contact)
            {
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

            [Test, TestCaseSource("ContactDataFromJsonFile")]
            public void FromJsonFile(ContactData contact)
            {
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

