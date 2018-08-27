using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Web_Testing
{
    class MainPageObject
        
    {
        private ChromeDriver chrome = null;
        private String deleteTaskButton = "(//div[@class = 'menu_label' and contains(text(), 'Delete task')])[2]";
        private String confirmDeleteButtonXpath = "//*[@class = 'ist_button ist_button_red']";
        private String addTaskXpath = "//*[@class='agenda_add_task']";
        private String taskNameTextFieldXpath = "//*[@class='richtext_editor sel_richtext_editor']";
        private String addTaskSubmitButtonxPath = "//*[@class='ist_button ist_button_red submit_btn']";
        private String nameOfTestTask = "Initial test task";
        private String addedTaskXpath = "//*[@class = 'text sel_item_content']";
        private String menuCss = "ul.items.day_list.ul_today div.icon.menu.cmp_menu_on.gear_menu";
        private String smallInboxXpath = "//*[@class = 'column_project task_content_item']";
        private TimeSpan sec = TimeSpan.FromSeconds(30);


        public MainPageObject(ChromeDriver chrome)
        {
            this.chrome = chrome;
        }
        
            public void AddTask()
        {
            WebDriverWait wait = new WebDriverWait(chrome, sec);
            chrome.FindElementByXPath(addTaskXpath).Click();
            chrome.FindElementByXPath(taskNameTextFieldXpath).SendKeys(nameOfTestTask);
            chrome.FindElementByXPath(addTaskSubmitButtonxPath).Click();
        }

        public void ClickOnMenu()
        {
            IWebElement smallInbox = chrome.FindElementByXPath(smallInboxXpath);
            Actions action = new Actions(chrome);
            action.MoveToElement(smallInbox).Perform();
            chrome.FindElementByCssSelector(menuCss).Click();
        }

        public void DeleteTask()
        {
            chrome.FindElementByXPath(deleteTaskButton).Click();
            chrome.FindElementByXPath(confirmDeleteButtonXpath).Click();
        }

        public void CloseBrowser()
        {
            chrome.Quit();
        }

        public bool PresenceOfAddedTask()
        {
            try
            {
                chrome.FindElement(By.XPath(addedTaskXpath));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

    }
}
