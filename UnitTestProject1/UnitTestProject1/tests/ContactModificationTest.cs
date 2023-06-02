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
            int n = 1; //порядковый номер редактируемого контакта
            ContactData newData = new ContactData();
            newData.FirstName = "Павел";
            newData.LastName = "Дуров";

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Modify(n, newData);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[n-1] = newData;
            oldContacts.Sort((left, right) => left.LastName.CompareTo(right.LastName));
            newContacts.Sort((left, right) => left.LastName.CompareTo(right.LastName));
            Assert.AreEqual(oldContacts, newContacts);

        }
    }
}
