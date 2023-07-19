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
            int n = 2; //порядковый номер удаляемого контакта

            List<ContactData> oldContacts = ContactData.GetAll();

            if (oldContacts.Count < n)
            {
                do
                {
                    app.Contacts.CreateSomeContaсt();
                    oldContacts = ContactData.GetAll();
                }
                while (oldContacts.Count < n);
            }
            ContactData toBeRemoved = oldContacts[n - 1];

            app.Contacts.RemoveContactById(toBeRemoved);

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactsCount());

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.Sort((left, right) => left.LastName.CompareTo(right.LastName));
            newContacts.Sort((left, right) => left.LastName.CompareTo(right.LastName));

            oldContacts.RemoveAt(n-1);
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}
