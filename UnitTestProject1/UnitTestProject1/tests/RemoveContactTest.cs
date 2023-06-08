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
    public class RemoveContactTests : AuthTestBase
    {
        [Test]
        public void RemoveContactTest()
        {
            int n = 1; //порядковый номер удаляемого контакта

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            
            app.Contacts.Remove(n);
            app.Navigator.OpenHomePage();

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactsCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Sort((left, right) => left.LastName.CompareTo(right.LastName));
            newContacts.Sort((left, right) => left.LastName.CompareTo(right.LastName));

            ContactData toBeRemoved = oldContacts[n-1];

            oldContacts.RemoveAt(n-1);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}
