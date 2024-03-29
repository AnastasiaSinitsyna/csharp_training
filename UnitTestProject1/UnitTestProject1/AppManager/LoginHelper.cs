﻿using OpenQA.Selenium;
using System;
using System.Security.Principal;

namespace WebAddressbookTests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager)
        : base(manager)
        { 
        }
        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }
                Logout();
            }
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                var example = driver.FindElement(By.LinkText("Logout"));
                example.Click();

                while (IsLoggedIn())
                    System.Threading.Thread.Sleep(500);
            }
        }
        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggetUserName() == account.Username;
                
        }

        public string GetLoggetUserName()
        {
           string text = driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
           return text.Substring(1, text.Length-2);
        }
    }
}
