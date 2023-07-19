using Google.Protobuf.WellKnownTypes;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V106.Network;
using OpenQA.Selenium.Support.UI;
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
        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.OpenHomePage();
            CleanGroupFilter();
            SelectContactById(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }
        public void RemoveContactFromGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.OpenHomePage();
            GroupFilterByGroup(group.Name);
            SelectContactById(contact.Id);
            RemoveFromGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void RemoveFromGroup()
        {
            driver.FindElement(By.Name("remove")).Click();
        }

        public void GroupFilterByGroup(string name)
        {
            driver.FindElement(By.Name("group")).Click();
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText(name);
        }

        public ContactHelper RemoveContactById(ContactData contact)
        {
            manager.Navigator.OpenHomePage();
            SelectContactById(contact.Id);
            RemoveContact();
            CloseAlert();
            ReturnToHomePage();
            return this;
        }
        public ContactHelper Create(ContactData contact)
        {
            AddNewContact();
            FillContactForm(contact);
            LinkNewContact();
            ReturnToHomePage();
            return this;
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
        public ContactHelper ContactModificationById(ContactData newData)
        {
            EditById(newData.Id);
            FillContactForm(newData);
            SubmitContactModification();
            ReturnToHomePage();
            return this;
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
        public ContactHelper RemoveContactByNumber(int n)
        {
            manager.Navigator.OpenHomePage();
            SelectContactByNumber(n);
            RemoveContact();
            CloseAlert();
            manager.Navigator.OpenHomePage();
            return this;
        }

        public ContactHelper AddNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }
        public ContactHelper EditByNumber(int index)
        {
            int i = index + 1;
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr["+ i +"]/td[8]/a/img")).Click();
            return this;
        }
        public ContactHelper EditById(string id)
        {
            driver.FindElement(By.XPath("//a[@href='edit.php?id="+id+"']")).Click();
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
        public ContactHelper SelectContactByNumber(int index)
        {
            int n = index + 1;
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr["+ n +"]/td/input")).Click();
            return this;
        }
        public ContactHelper SelectContactById(string id)
        {
            driver.FindElement(By.Id(id)).Click();
            return this;
        }
        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }
        public int GetContactsCount()
        {
            System.Threading.Thread.Sleep(500);
            return driver.FindElements(By.XPath("//table[@id='maintable']/tbody/tr[@name = 'entry']")).Count;
        }

        public void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        public void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        public void CleanGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        public void OpenDetailsInfoAboutContact(int index)
        {
            index = index + 2;
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + index + "]/td[7]/a/img")).Click();
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
            EditByNumber(index);

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

            if (fromForm.PhoneMobile != "" && fromForm.PhoneHome != "") 
                sumText += "\r\nM: " + fromForm.PhoneMobile;
            else if (fromForm.PhoneMobile != "")
                sumText += "\r\n\r\nM: " + fromForm.PhoneMobile;

            if (fromForm.PhoneWork != "" && (fromForm.PhoneHome != "" || fromForm.PhoneHome != "")) 
                sumText += "\r\nW: " + fromForm.PhoneWork;
            else if (fromForm.PhoneWork != "")
                sumText += "\r\n\r\nW: " + fromForm.PhoneWork;

            if (fromForm.Email != "")
                sumText += "\r\n\r\n" + fromForm.Email;

            if (fromForm.Email2 != "" && fromForm.Email != "")
                sumText += "\r\n" + fromForm.Email2;
            else if (fromForm.Email2 != "")
                sumText += "\r\n\r\n" + fromForm.Email2;

            if (fromForm.Email3 != "" && (fromForm.Email != "" || fromForm.Email2 !=""))
                sumText += "\r\n" + fromForm.Email3;
            else if (fromForm.Email3 != "")
                sumText += "\r\n\r\n" + fromForm.Email3;

            return sumText;
        }
    }
}
