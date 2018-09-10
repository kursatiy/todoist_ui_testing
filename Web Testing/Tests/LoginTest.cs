using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Web_Testing;

namespace TBExample
{

    [TestFixture]
    public class LoginTest
    {
        ChromeDriver chrome = null;

        public LoginTest()
        {
            chrome = new ChromeDriver();
        }

        [Test]
        public void CheckLoginTest()
        {
            LoginPageObject login = new LoginPageObject(chrome);
            login.Login();
            Assert.IsTrue(login.IsCurrentPage());
        }

        [TearDown]
        public void CloseBrowser()
        {
            MainPageObject mainPage = new MainPageObject(chrome);
            mainPage.CloseBrowser();
        }
    }
}


