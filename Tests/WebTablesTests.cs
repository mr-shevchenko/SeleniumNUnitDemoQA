using FrameworkDemoQA.Pages;
using NUnit.Framework.Interfaces;

namespace FrameworkDemoQA.Tests
{
    [TestFixture]
    public class WebTablesTests : BaseTest
    {
        [Test]
        [TestCaseSource(typeof(TestData), nameof(TestData.GetRegistrationFormData))]
        public void AddRowTest(WebTablesDataRow newRow)
        {
            try
            {
                Pages.WebTablesPage.Open();

                Pages.WebTablesPage.AddNewRow(newRow);

                var returnedRow = Pages.WebTablesPage.GetLatestRowValues();

                Assert.True(newRow.FirstName == returnedRow.FirstName);
                Assert.True(newRow.LastName == returnedRow.LastName);
                Assert.True(newRow.Age == returnedRow.Age);
                Assert.True(newRow.Email == returnedRow.Email);
                Assert.True(newRow.Salary == returnedRow.Salary);
                Assert.True(newRow.Department == returnedRow.Department);
            }
            catch (Exception e)
            {
                ex = e;
            }
        }

        [Test]
        [TestCase("TestSearchValue")]
        public void SearchTest(string testValue)
        {
            try
            {
                Pages.WebTablesPage.Open();

                Pages.WebTablesPage.AddNewRow(new WebTablesDataRow(testValue, "Fake Value", 20, "fake@gmail.com", 10000, "Fake Value"));

                Pages.WebTablesPage.AddNewRow(new WebTablesDataRow("Fake Value", "Fake Value", 20, "fake@gmail.com", 10000, "Fake Value"));

                Pages.WebTablesPage.Search(testValue);

                var latestRow = Pages.WebTablesPage.GetLatestRowValues();

                Assert.True(testValue == latestRow.FirstName);
            }
            catch (Exception e)
            {
                ex = e;
            }
        }

        [Test]
        [TestCaseSource(typeof(TestData), nameof(TestData.GetNumberOfRows))]
        public void RowsPerPageTest(int numberOfRows)
        {
            try
            {
                Pages.WebTablesPage.Open();

                Pages.WebTablesPage.SetRowsPerPage(string.Concat(numberOfRows, " rows"));

                int actualNumberOfRows = Pages.WebTablesPage.GetRowsPerPage();

                Assert.True(numberOfRows == actualNumberOfRows);
            }
            catch (Exception e) {
                ex = e;
            }
        }
    }
}
