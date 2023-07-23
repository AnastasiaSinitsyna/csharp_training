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
            //Проверка наличия групп
            if (!app.Groups.GroupAvailable()) 
                app.Groups.Create(new GroupData("Test1", "Test2", "Test3"));

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            List<ContactData> allContacts = ContactData.GetAll();

            //Проверка доступности контактов
            if (oldList.Count == 0)
            {
                app.Contacts.CreateSomeContaсt();
                List<ContactData> newContacts = ContactData.GetAll();
                ContactData contactToRemove = newContacts.Except(allContacts).ToList().First();
                app.Contacts.AddContactToGroup(contactToRemove, group);
                oldList = group.GetContacts();
            }

            ContactData contact = oldList.First();

            app.Contacts.RemoveContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            newList.Sort((left, right) => left.LastName.CompareTo(right.LastName));
            oldList.Sort((left, right) => left.LastName.CompareTo(right.LastName));
            Assert.AreEqual(oldList, newList);
        }
    }
}
