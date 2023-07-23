using Google.Protobuf.WellKnownTypes;
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

        public GroupHelper UnitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper Remove()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }
        public GroupHelper RemoveGroupByNumber(int number)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroupByNumber(number);
            Remove();
            ReturnToGroupsPage();
            return this;
        }
        public GroupHelper RemoveGroupById(GroupData groups)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroupById(groups.Id);
            Remove();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper SelectGroupByNumber(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + (index) + "]/input")).Click();
            return this;
        }
        public GroupHelper SelectGroupById(string id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='"+id+"'])")).Click();
            return this;
        }
        public GroupHelper LinkSubmit()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }
        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }
        public bool GroupAvailable()
        {
            return IsElementPresent(By.XPath("/html/body/div/div[4]/form[2]/div[4]/select/option"));
        }

        public GroupHelper UnitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
        public GroupHelper GroupModificationById(GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroupById(newData.Id);
            UnitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }

        private List<GroupData> groupCache = null;
        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(null)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });

                    string allGroupNames = driver.FindElement(By.CssSelector("div#content form")).Text;
                    string[] parts = allGroupNames.Split('\n');
                    int shift = groupCache.Count-parts.Length;
                    for (int i = 0; i < groupCache.Count; i++)
                    {
                        if (i < shift)
                        {
                            groupCache[i].Name = "";
                        }
                        else 
                        {
                            groupCache[i].Name = parts[i-shift].Trim();
                        } 
                    }
                }
            }
            return new List<GroupData>(groupCache);
        }

        public int GetGroupCount()
        {
            manager.Navigator.GoToGroupsPage();
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }
    }
}
