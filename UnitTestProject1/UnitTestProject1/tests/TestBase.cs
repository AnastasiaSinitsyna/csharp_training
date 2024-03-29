﻿using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System.Text;
using System;

namespace WebAddressbookTests
{
    public class TestBase
    {
        /*protected IWebDriver driver;
        protected string baseURL;*/

        protected ApplicationManager app;
        public static bool PERFORM_LONG_UI_CHECKS = true;

        [SetUp] 
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

        public static Random rnd = new Random();
        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for(int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));
            }
            return builder.ToString();
        }

    }
}