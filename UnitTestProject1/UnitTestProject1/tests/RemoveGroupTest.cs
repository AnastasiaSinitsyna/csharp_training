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
            int n = 1; // удаляемый элемент, начиная с 1

            List<GroupData> oldGroups = GroupData.GetAll();

            if (oldGroups.Count < n)
            {
                do
                {
                    app.Groups.Create(new GroupData ("Test1", "Test2", "Test3"));
                    oldGroups = GroupData.GetAll();
                }
                while (oldGroups.Count < n);
            }
            GroupData toBeRemoved = oldGroups[n - 1];

            app.Groups.RemoveGroupById(toBeRemoved);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();



            oldGroups.RemoveAt(n-1);
            Assert.AreEqual(oldGroups, newGroups);

            foreach(GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        } 
    }
}   

