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
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(index);
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
            int index = 1; //Порядковый номер контакта
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(index);
            string fromDetailsForm = app.Contacts.GetContactInformationFromDetailsForm(index);

            string SumText = fromForm.FirstName + fromForm.LastName 
                + fromForm.Address 
                + fromForm.PhoneHome + fromForm.PhoneMobile + fromForm.PhoneWork 
                + fromForm.Email + fromForm.Email2 + fromForm.Email3;
            SumText = SumText.Replace(" ", "");

            //verification
            Assert.AreEqual(SumText, fromDetailsForm);
        }

    }
}
