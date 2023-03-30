using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class RemoveContactTests : TestBase
    {
        [Test]
        public void RemoveContactTest()
        {
            app.Contacts.Remove(1);
        }
    }
}
