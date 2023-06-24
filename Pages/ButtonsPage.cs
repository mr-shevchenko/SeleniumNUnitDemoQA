using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace FrameworkDemoQA.Pages
{
    public class ButtonsPage : BasePage
    {
        protected override string Url => "https://demoqa.com/buttons";

        private IWebElement _doubleClick => _driver.FindElement(By.Id("doubleClickBtn"));
        private IWebElement _rightClick => _driver.FindElement(By.Id("rightClickBtn"));
        private IWebElement _click => _driver.FindElement(By.XPath("//*[text()='Click Me']"));
        private IWebElement _doubleClickMessage => _driver.FindElement(By.Id("doubleClickMessage"));
        private IWebElement _rightClickMessage => _driver.FindElement(By.Id("rightClickMessage"));
        private IWebElement _clickMessage => _driver.FindElement(By.Id("dynamicClickMessage"));

        public ButtonsPage(IWebDriver driver) : base(driver) { }

        public void DoDoubleClick()
        {
            var actions = new Actions(_driver);
            actions.MoveToElement(_doubleClick);
            actions.DoubleClick(_doubleClick);
            actions.Perform();
        }

        public void DoRightClick()
        {
            var actions = new Actions(_driver);
            actions.MoveToElement(_rightClick);
            actions.ContextClick(_rightClick);
            actions.Perform();
        }

        public void DoClick()
        {
            var actions = new Actions(_driver);
            actions.MoveToElement(_click);
            actions.Click(_click);
            actions.Perform();
        }

        public string GetDoubleClickMessage() => _doubleClickMessage.Text;
        public string GetRightClickMessage() => _rightClickMessage.Text;
        public string GetClickMeMessage() => _clickMessage.Text;
    }
}