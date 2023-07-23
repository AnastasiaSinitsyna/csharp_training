using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            //Проверка наличия групп
            if (!app.Groups.GroupAvailable())
                app.Groups.Create(new GroupData("Test1", "Test2", "Test3"));

            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            List <ContactData> allContacts = ContactData.GetAll();

            //Проверка доступности контактов
            if (oldList.Count == allContacts.Count || allContacts.Count == 0)
            {
                app.Contacts.CreateSomeContaсt();
                allContacts = ContactData.GetAll();
            }
  
            ContactData contact = allContacts.Except(oldList).ToList().First();

            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort((left, right) => left.LastName.CompareTo(right.LastName));
            oldList.Sort((left, right) => left.LastName.CompareTo(right.LastName));
            Assert.AreEqual(oldList, newList);
        }
    }
}
