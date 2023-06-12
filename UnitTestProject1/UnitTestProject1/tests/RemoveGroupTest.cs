using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;   

namespace WebAddressbookTests
{
    [TestFixture]
    public class RemoveGroupTests : AuthTestBase
    {

        [Test]
        public void RemoveGroupTest()
        {
            int n = 6; // удаляемый элемент, начиная с 1

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Navigator.GoToGroupsPage();
            if (oldGroups.Count >= n)
            {
                app.Groups.SelectGroup(n)
                .RemoveGroup()
                .ReturnToGroupsPage();
            }
            else
            {
                do
                {
                    app.Groups.Create(new GroupData ("Test1", "Test2", "Test3"));
                    oldGroups = app.Groups.GetGroupList();
                }
                while (oldGroups.Count < n);

                app.Navigator.GoToGroupsPage();
                app.Groups.SelectGroup(n)
                .RemoveGroup()
                .ReturnToGroupsPage();
            }

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();

            GroupData toBeRemoved = oldGroups[n-1];

            oldGroups.RemoveAt(n-1);
            Assert.AreEqual(oldGroups, newGroups);

            foreach(GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        } 
    }
}   

