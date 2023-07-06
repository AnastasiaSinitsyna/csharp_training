using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static WebAddressbookTests.ContactHelper;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager)
        : base(manager)
        { 
        }
        public bool ContactAvailable()
        {
            return IsElementPresent(By.Name("entry"));
        }
        public ContactHelper LinkNewContact()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            contactCache = null;
            return this;
        }
        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);
            Type(By.Name("address"), contact.Address);
            return this;
        }

        public ContactHelper AddNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
       /* public ContactHelper Modify(int v, ContactData newData)
        {
            manager.Navigator.OpenHomePage();
            if (ContactAvailable())
            {
                Edit(v);
                FillContactForm(newData);
                SubmitContactModification();
                ReturnToHomePage();
                return this;
            }
            else
            {
                CreateSomeContaсt();
                Edit(v);
                FillContactForm(newData);
                SubmitContactModification();
                ReturnToHomePage();
                return this;
            }
        }*/
        public ContactHelper CreateSomeContaсt()
        {
            ContactData contact = new ContactData();
            contact.FirstName = "Test";
            contact.LastName = "Test2";

            AddNewContact();
            FillContactForm(contact);
            LinkNewContact();
            ReturnToHomePage();
            return this;
        }
        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }
        public ContactHelper Edit(int index)
        {
            int i = index + 1;
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr["+ i +"]/td[8]/a/img")).Click();
            return this;
        }

        public ContactHelper CloseAlert()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }
        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }
        public ContactHelper SelectContact(int index)
        {
            int n = index + 1;
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr["+ n +"]/td/input")).Click();
            return this;
        }
        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        private List<ContactData> contactCache = null;
        public List<ContactData> GetContactList()
        {
            
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.OpenHomePage();
                ICollection<IWebElement> rows = driver.FindElements(By.XPath("//table[@id='maintable']/tbody/tr[@name = 'entry']"));
                foreach(IWebElement row in rows)
                {   
                    string lastName = row.FindElement(By.XPath("./td[2]")).Text;
                    string firstName = row.FindElement(By.XPath("./td[3]")).Text;
                    contactCache.Add(new ContactData(firstName, lastName)
                    {
                        Id = row.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            return new List<ContactData>(contactCache);
        }
        public int GetContactsCount()
        {
            System.Threading.Thread.Sleep(500);
            return driver.FindElements(By.XPath("//table[@id='maintable']/tbody/tr[@name = 'entry']")).Count;
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.OpenHomePage();   
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmail = cells[4].Text;
            string allPhone = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhone = allPhone,
                AllEmail = allEmail
            };
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.OpenHomePage();
            Edit(index);

            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string phoneHome = driver.FindElement(By.Name("home")).GetAttribute("value");
            string phoneMobile = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string phoneWork = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                PhoneHome = phoneHome,
                PhoneMobile = phoneMobile,
                PhoneWork = phoneWork,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };
        }

        public string GetContactInformationFromDetailsForm(int index)
        {
            manager.Navigator.OpenHomePage();
            OpenDetailsInfoAboutContact(index);

            IWebElement different = driver.FindElement(By.Id("content"));
            string allInfoAboutContact = different.Text;

            return allInfoAboutContact;
            //Replace("\r\n", "").Replace("H: ", "").Replace("M: ", "").Replace("W: ", "").Replace(" ", "")
        }

        public void OpenDetailsInfoAboutContact(int index)
        {
            index = index + 2;
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr["+ index +"]/td[7]/a/img")).Click();
        }

        public string SumText(ContactData fromForm)
        {
            string sumText = "";
            if (fromForm.FirstName != "") 
                sumText = fromForm.FirstName;
            if (fromForm.LastName != "") 
                sumText += " " + fromForm.LastName;
            if (fromForm.Address != "") 
                sumText += "\r\n" + fromForm.Address;
            if (fromForm.PhoneHome != "") 
                sumText += "\r\n\r\nH: " + fromForm.PhoneHome;
            if (fromForm.PhoneMobile != "") 
                sumText += "\r\nM: " + fromForm.PhoneMobile;
            if (fromForm.PhoneWork != "") 
                sumText += "\r\nW: " + fromForm.PhoneWork;
            if (fromForm.Email != "")
                sumText += "\r\n\r\n" + fromForm.Email;
            if (fromForm.Email2 != "")
                sumText += "\r\n" + fromForm.Email2;
            if (fromForm.Email3 != "")
                sumText += "\r\n" + fromForm.Email3;
            return sumText;
        }
    }
}
