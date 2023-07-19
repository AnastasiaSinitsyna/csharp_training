using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class RemoveContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestRemoveContactFromGroup()
        {
            GroupData group = GroupData.GetAll()[1];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = oldList.First();
            //ContactData contact = ContactData.GetAll().Except(oldList).First();

            app.Contacts.RemoveContactFromGroup(contact, group);

            //actions

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            newList.Sort((left, right) => left.LastName.CompareTo(right.LastName));
            oldList.Sort((left, right) => left.LastName.CompareTo(right.LastName));
            Assert.AreEqual(oldList, newList);
        }
    }
}
