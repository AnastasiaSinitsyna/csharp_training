using System;
using System.Collections.Generic;
using System.Linq;
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
            ContactData newData = new ContactData();
            newData.FirstName = "Павел";
            newData.LastName = "Дуров";

            List<string> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Modify(1, newData);

            List<string> newContacts = app.Contacts.GetContactList();
            oldContacts[0] = newData.LastName + newData.FirstName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }
    }
}
