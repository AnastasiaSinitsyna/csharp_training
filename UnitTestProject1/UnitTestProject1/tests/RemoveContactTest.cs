using System;
using System.Collections.Generic;
using System.Linq;
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

            List<string> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Remove(n);
            //app.Navigator.OpenHomePage();

            List<string> newContacts = app.Contacts.GetContactList();
            oldContacts.Sort();
            newContacts.Sort();
            oldContacts.RemoveAt(n-1);
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
