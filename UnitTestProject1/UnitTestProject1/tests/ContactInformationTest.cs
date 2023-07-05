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
    public class ContactInformationTest : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            int index = 1; //Порядковый номер контакта
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(index - 1);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(index);

            //verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhone, fromForm.AllPhone);
            Assert.AreEqual(fromTable.AllEmail, fromForm.AllEmail);
        }
        [Test]
        public void TestContactDetailsInformation()
        {
            int index = 3; //Порядковый номер контакта
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(index);
            string fromDetailsForm = app.Contacts.GetContactInformationFromDetailsForm(index - 1);
            string sumText = app.Contacts.SumText(fromForm);
            //verification
            Assert.AreEqual(sumText, fromDetailsForm);
        }

    }
}
