using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            int n = 7; //порядковый номер модифицируемого контакта
            ContactData newData = new ContactData();
            newData.FirstName = "Павел";
            newData.LastName = "Дуров";

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldData;

            if (oldContacts.Count < n)
            {
                do
                {
                    app.Contacts.CreateSomeContaсt();
                    oldContacts = app.Contacts.GetContactList();
                }
                while (oldContacts.Count < n);
            }
       
            oldData = oldContacts[n - 1];
            app.Contacts.Edit(n)
            .FillContactForm(newData)
            .SubmitContactModification()
            .ReturnToHomePage();

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[n-1] = newData;
            oldContacts.Sort((left, right) => left.LastName.CompareTo(right.LastName));
            newContacts.Sort((left, right) => left.LastName.CompareTo(right.LastName));
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.LastName, contact.LastName);
                }
            }

        }
    }
}
