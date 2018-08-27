using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Web_Testing.Steps;

namespace Web_Testing
{
    [TestFixture]

    public class CheckDeletedTaskTest
    {
        ChromeDriver chrome = null;

        public CheckDeletedTaskTest()
        {
        chrome = new ChromeDriver();
        this.chrome = chrome;
        }

        [Test]
        public void DeleteTask()
        {
            AddTaskSteps addSteps = new AddTaskSteps(chrome);
            addSteps.AddTask();

            MainPageObject mainPage = new MainPageObject(chrome);
            mainPage.ClickOnMenu();
            mainPage.DeleteTask();

            Thread.Sleep(1000);
            NUnit.Framework.Assert.IsFalse(mainPage.PresenceOfAddedTask());
            
        }

        [TearDown]
        public void CloseBrowser()
        {
            MainPageObject mainPage = new MainPageObject(chrome);
            mainPage.CloseBrowser();
        }
        
    }
}
