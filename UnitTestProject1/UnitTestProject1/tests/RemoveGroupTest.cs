using System;
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
    public class RemoveGroupTest : TestBase
    {

        [Test]
        public void GroupCreationTest()
        {
            app.Navigator.GoToGroupsPage();
            app.Groups
                .SelectGroup(1)
                .RemoveGroup()
                .ReturnToGroupsPage();
            app.Navigator.ReturnToHome();
            app.Auth.LogOut();
        }
    }
}   

