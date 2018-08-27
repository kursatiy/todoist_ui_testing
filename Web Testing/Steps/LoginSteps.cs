using OpenQA.Selenium.Chrome;

namespace Web_Testing.Steps
{
    public class LoginSteps
    {
        ChromeDriver chrome = null;

        public LoginSteps()
        {
         chrome = new ChromeDriver();
        }
         
        public void LoginToTodoist()
        {
            LoginPageObject login = new LoginPageObject(chrome);
            login.Login();
        }
    }
}
