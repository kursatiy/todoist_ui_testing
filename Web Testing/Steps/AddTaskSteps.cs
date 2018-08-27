using OpenQA.Selenium.Chrome;

namespace Web_Testing.Steps
{
    class AddTaskSteps
    {
        ChromeDriver chrome = null;

        public AddTaskSteps(ChromeDriver chrome)
        {
            this.chrome = chrome;
        }

        public void AddTask()
        {
            LoginPageObject login = new LoginPageObject(chrome);
            login.Login();

            MainPageObject mainPage = new MainPageObject(chrome);
            mainPage.AddTask();
        }
    }
}
