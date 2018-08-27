using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Web_Testing
{
    [TestFixture]
    public class CheckAddNewTaskTest
    {
        ChromeDriver chrome = null;
        private String addedTaskXpath = "//*[@class = 'text sel_item_content']";

        public CheckAddNewTaskTest()
        {
            chrome = new ChromeDriver();
            this.chrome = chrome;
        }

        [Test]
        public void CheckAddNewTask()
        {
            LoginPageObject login = new LoginPageObject(chrome);
            login.Login();

            MainPageObject mainPage = new MainPageObject(chrome);
            mainPage.AddTask();

            IWebElement addedTask = chrome.FindElementByXPath(addedTaskXpath);
            NUnit.Framework.Assert.AreEqual("Initial test task", addedTask.Text);
        }

        [TearDown]
        public void CloseBrowser()
        {
            MainPageObject mainPage = new MainPageObject(chrome);
            mainPage.CloseBrowser();
        }
    }
}
