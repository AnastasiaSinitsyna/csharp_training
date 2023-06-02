using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
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
            return this;
        }
        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);
            return this;
        }

        public ContactHelper AddNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper Modify(int v, ContactData newData)
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
        }
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
            return this;
        }
        public ContactHelper Edit(int index)
        {
            int i = index + 1;
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr["+ i +"]/td[8]/a/img")).Click();
            return this;
        }
        public ContactHelper Remove(int v)
        {
        if (ContactAvailable())
            {
                manager.Navigator.OpenHomePage();
                SelectContact(v);
                RemoveContact();
                CloseAlert();
                return this;
            }
        else
            {
                manager.Navigator.OpenHomePage();
                CreateSomeContaсt();
                SelectContact(v);
                RemoveContact();
                CloseAlert();
                return this;
            }
        }
        public ContactHelper CloseAlert()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }
        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
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
        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.OpenHomePage();
            ICollection<IWebElement> rows = driver.FindElements(By.XPath("//table[@id='maintable']/tbody/tr[@name = 'entry']"));
            foreach (IWebElement row in rows)
            {
                string lastName = row.FindElement(By.XPath("./td[2]")).Text;
                string firstName = row.FindElement(By.XPath("./td[3]")).Text;
                contacts.Add(new ContactData(firstName, lastName));
            }
            return contacts;
        }
    }
}
