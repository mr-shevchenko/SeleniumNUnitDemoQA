using FrameworkDemoQA.Framework;
using FrameworkDemoQA.Tests;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace FrameworkDemoQA.Pages
{
    public class WebTablesPage : BasePage
    {
        protected override string Url => "https://demoqa.com/webtables";

        private IWebElement _addButton => _driver.FindElement(By.Id("addNewRecordButton"));
        private IWebElement _searchBox => _driver.FindElement(By.Id("searchBox"));
        private IWebElement _tableBody => _driver.FindElement(By.XPath("//*[contains(@class,'rt-tbody')]"));
        private IWebElement _previousButton => _driver.FindElement(By.XPath("//*[contains(text(),'Previous')]"));
        private IWebElement _pageNumber => _driver.FindElement(By.XPath("//*[contains(@aria-label,'jump to page')]"));
        private IWebElement _rowsPerPage => _driver.FindElement(By.XPath("//*[contains(@aria-label,'rows per page')]"));
        private IWebElement _nextButton => _driver.FindElement(By.XPath("//*[contains(text(),'Next')]"));

        #region Registration Form
        private IWebElement _firstName => _driver.FindElement(By.Id("firstName"));
        private IWebElement _lastName => _driver.FindElement(By.Id("lastName"));
        private IWebElement _userEmail => _driver.FindElement(By.Id("userEmail"));
        private IWebElement _age => _driver.FindElement(By.Id("age"));
        private IWebElement _salary => _driver.FindElement(By.Id("salary"));
        private IWebElement _department => _driver.FindElement(By.Id("department"));
        private IWebElement _closeButton => _driver.FindElement(By.XPath("//*[contains(@class,'close')]"));
        private IWebElement _submitButton => _driver.FindElement(By.Id("submit"));
        #endregion

        public WebTablesPage(IWebDriver driver) : base(driver) { }

        internal void AddNewRow(WebTablesDataRow row)
        {
            var actions = new Actions(_driver);
            actions.MoveToElement(_addButton);
            actions.Click(_addButton);
            actions.Perform();

            _firstName.SendKeys(row.FirstName);
            _lastName.SendKeys(row.LastName);
            _userEmail.SendKeys(row.Email);
            _age.SendKeys(Convert.ToString(row.Age));
            _salary.SendKeys(Convert.ToString(row.Salary));
            _department.SendKeys(row.Department);

            actions.MoveToElement(_submitButton);
            actions.Click(_submitButton);
            actions.Perform();
        }

        internal WebTablesDataRow GetLatestRowValues()
        {
            var row = new WebTablesDataRow();

            // Find all the rows within the "rt-tbody" element
            IReadOnlyCollection<IWebElement> rows = _tableBody.FindElements(By.XPath(".//*[contains(@class,'rt-tr-group')]"));

            IWebElement latestRow = DriverHelper.GetLatestRow(rows);

            IReadOnlyCollection<IWebElement> cells = latestRow.FindElements(By.XPath(".//*[contains(@class,'rt-td')]"));

            IWebElement cell = cells.ElementAt(0);
            row.FirstName = cell.Text;

            cell = cells.ElementAt(1);
            row.LastName = cell.Text;

            cell = cells.ElementAt(2);
            row.Age = Convert.ToInt32(cell.Text);

            cell = cells.ElementAt(3);
            row.Email = cell.Text;

            cell = cells.ElementAt(4);
            row.Salary = Convert.ToInt32(cell.Text);

            cell = cells.ElementAt(5);
            row.Department = cell.Text;

            return row;
        }

        internal void Search(string searchString)
        {
            _searchBox.SendKeys(searchString);
        }

        internal void SetRowsPerPage(string rowsPerPage)
        {
            _rowsPerPage.SendKeys(rowsPerPage);
        }

        internal int GetRowsPerPage()
        {
            IReadOnlyCollection<IWebElement> rows = _tableBody.FindElements(By.XPath(".//*[contains(@class,'rt-tr-group')]"));
            return rows.Count;
        }
    }

    public class WebTablesDataRow
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; } = 0;
        public string Email { get; set; } = string.Empty;
        public int Salary { get; set; } = 0;
        public string Department { get; set; } = string.Empty;

        public WebTablesDataRow() { }
        public WebTablesDataRow(string firstName, string lastName, int age, string email, int salary, string department)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Email = email;
            Salary = salary;
            Department = department;
        }
    }
}
