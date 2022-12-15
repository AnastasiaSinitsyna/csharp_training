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
            OpenHomePage();
            Login("admin", "secret");
            GoToGroupsPage();
            UnitNewGroupCreation();
            FillGroupForm("One", "Two", "Three");
            LinkSubmit();
            ReturnToHome();
            LogOut();
        } 
    }
}

