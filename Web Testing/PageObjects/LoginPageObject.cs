using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace Web_Testing
{
  public class LoginPageObject
    {
        private String url = "https://en.todoist.com";
        private TimeSpan sec = TimeSpan.FromSeconds(30);
        private String login = "jupibew@bit-degree.com";
        private String password = "123456";
        private ChromeDriver chrome = null;
        private String frame = "GB_frame";
        private String emailId = "email";
        private String passwordId = "password";
        private String loginOnTheMainTabXpath = "//*[@class = 'td-header__action-link sel_login']";
        private String submitButtonXpath = "//*[@class = 'submit_btn ist_button ist_button_red sel_login']";
        private String itemNameClass = "item_name";

        public LoginPageObject(ChromeDriver chrome)
        {
            this.chrome = chrome;     
        }

        public void Login()
        {
            WebDriverWait wait = new WebDriverWait(chrome, sec);
            chrome.Navigate().GoToUrl(url);
            chrome.Manage().Window.Maximize();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(loginOnTheMainTabXpath))).Click();
            chrome.SwitchTo().Frame(frame);
            chrome.SwitchTo().Frame(frame);
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(emailId))).SendKeys(login);
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(passwordId))).SendKeys(password);
            chrome.FindElement(By.XPath(submitButtonXpath)).Click();
            chrome.SwitchTo().DefaultContent();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName(itemNameClass)));
        }

        public bool IsCurrentPage()
        {
           return chrome.FindElementByClassName(itemNameClass).Displayed;
        }
    }
}
