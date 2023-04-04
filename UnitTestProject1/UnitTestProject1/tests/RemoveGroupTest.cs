﻿using System;
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
            app.Groups.Remove(1);
        }

        
    }
}   

