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
            int n = 6; //порядковый номер удаляемого контакта

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            if (oldContacts.Count < n)
            {
                do
                {
                    app.Contacts.CreateSomeContaсt();
                    oldContacts = app.Contacts.GetContactList();
                }
                while (oldContacts.Count < n);
            }

                app.Navigator.OpenHomePage();
                app.Contacts.SelectContact(n)
                .RemoveContact()
                .CloseAlert();
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
