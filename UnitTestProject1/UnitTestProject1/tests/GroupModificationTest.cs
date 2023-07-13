using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            int n = 1; // модифицируемый элемент, начиная с 1
            GroupData newData = new GroupData("Mod1");
            newData.Header = "Mod2";
            newData.Footer = "Mod3";

            List<GroupData> oldGroups = GroupData.GetAll();

            GroupData oldData;

            if (oldGroups.Count < n)
            {
                do
                {
                    app.Groups.Create(new GroupData("Test1", "Test2", "Test3"));
                    oldGroups = GroupData.GetAll();
                }
                while (oldGroups.Count < n);
            }
            oldData = oldGroups[n - 1];
            newData.Id = oldData.Id;
            app.Groups.GroupModificationById(newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[n-1].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach(GroupData group in newGroups) 
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual (newData.Name, group.Name);
                }
            }
        }
    }
}
