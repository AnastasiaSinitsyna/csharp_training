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
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("One");
            group.Header = "Two";
            group.Footer = "Three";

            app.Groups.Create(group);
            app.Navigator.ReturnToHome();
            app.Auth.LogOut();
        }
        [Test]
        public void EmptyGroupCreationTest()
        {  
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Groups.Create(group);
            app.Navigator.ReturnToHome();   
            app.Auth.LogOut();

        }
    }
}

