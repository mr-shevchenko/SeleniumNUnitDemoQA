using FrameworkDemoQA.Pages;
using OpenQA.Selenium;

namespace FrameworkDemoQA.Framework
{
    public class PageList
    {
        private readonly IWebDriver _driver;
        private ButtonsPage _buttonsPage;
        private WebTablesPage _webTablesPage;

        public PageList(IWebDriver driver)
        {
            _driver = driver;
        }

        public ButtonsPage ButtonsPage => _buttonsPage ??= new ButtonsPage(_driver);
        public WebTablesPage WebTablesPage => _webTablesPage ??= new WebTablesPage(_driver);
    }
}