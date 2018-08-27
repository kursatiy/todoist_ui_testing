using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Web_Testing;

namespace TBExample
{

    [TestFixture]
    public class LoginPage
    {
        ChromeDriver chrome = null;

        public LoginPage()
        {
            chrome = new ChromeDriver();
        }

        [Test]
        public void Login()
        {
            LoginPageObject login = new LoginPageObject(chrome);
            login.Login();
            NUnit.Framework.Assert.IsTrue(login.IsCurrentPage());
        }

        [TearDown]
        public void CloseBrowser()
        {
            MainPageObject mainPage = new MainPageObject(chrome);
            mainPage.CloseBrowser();
        }
    }
}


