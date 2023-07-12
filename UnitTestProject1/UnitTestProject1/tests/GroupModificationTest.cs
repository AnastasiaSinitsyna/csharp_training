using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            int n = 9; // модифицируемый элемент, начиная с 1
            GroupData newData = new GroupData("Mod1");
            newData.Header = "Mod2";
            newData.Footer = "Mod3";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            GroupData oldData;

            if (oldGroups.Count < n)
            {
                do
                {
                    app.Groups.Create(new GroupData("Test1", "Test2", "Test3"));
                    oldGroups = app.Groups.GetGroupList();
                }
                while (oldGroups.Count < n);
            }

            oldData = oldGroups[n - 1];
            app.Navigator.GoToGroupsPage();
            app.Groups.SelectGroupByNumber(n)
            .UnitGroupModification()
            .FillGroupForm(newData)
            .SubmitGroupModification()
            .ReturnToGroupsPage();

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
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
