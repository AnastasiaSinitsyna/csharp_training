using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }
        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            UnitNewGroupCreation();
            FillGroupForm(group);
            LinkSubmit();
            ReturnToGroupsPage();
            return this;
        }
        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper Modify(int v, GroupData newData)
        {
            if (GroupAvailable())
            {
                manager.Navigator.GoToGroupsPage();
                SelectGroup(v);
                UnitGroupModification();
                FillGroupForm(newData);
                SubmitGroupModification();
                ReturnToGroupsPage();
                return this;
            }
            else
            {
                CreateSomeGroup();
                manager.Navigator.GoToGroupsPage();
                SelectGroup(v);
                UnitGroupModification();
                FillGroupForm(newData);
                SubmitGroupModification();
                ReturnToGroupsPage();
                return this;
            }
        }

        public GroupHelper UnitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + (index + 1) + "]/input")).Click();
            return this;
        }
        public GroupHelper LinkSubmit()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }
        public bool GroupAvailable()
        {
            return IsElementPresent(By.Name("selected[]"));
        }

        public GroupHelper Remove(int p)
        {
            if (GroupAvailable()) 
            {
                manager.Navigator.GoToGroupsPage();
                SelectGroup(p);
                RemoveGroup();
                ReturnToGroupsPage();
                return this;
            }
            else
            {
                CreateSomeGroup();
                manager.Navigator.GoToGroupsPage();
                SelectGroup(p);
                RemoveGroup();
                ReturnToGroupsPage();
                return this;
            }
        }

        private void CreateSomeGroup()
        {
            GroupData group = new GroupData("Test");
            group.Header = "Test2";
            group.Footer = "Test3";

            Create(group);
        }

        public GroupHelper UnitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();
            manager.Navigator.GoToGroupsPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement element in elements)
            {
                groups.Add(new GroupData(element.Text));
            }
            return groups;
        }
    }
}
