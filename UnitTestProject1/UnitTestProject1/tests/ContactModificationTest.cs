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
            int n = 4; //порядковый номер модифицируемого контакта
            ContactData newData = new ContactData();
            newData.FirstName = "Лена";
            newData.LastName = "Весёлая";
            newData.Address = "Ул. Пушкина 71, Москва";

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldData;

            if (oldContacts.Count < n)
            {
                do
                {
                    app.Contacts.CreateSomeContaсt();
                    oldContacts = ContactData.GetAll();
                }
                while (oldContacts.Count < n);
            }
       
            oldData = oldContacts[n - 1];
            newData.Id = oldData.Id;

            app.Contacts.ContactModificationById(newData);

            List<ContactData> newContacts = ContactData.GetAll();
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
