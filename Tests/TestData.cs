using FrameworkDemoQA.Pages;

namespace FrameworkDemoQA.Tests
{
    internal class TestData
    {
        public static IEnumerable<WebTablesDataRow> GetRegistrationFormData()
        {
            yield return new WebTablesDataRow("John", "Smith", 30, "one@gmail.com", 15000, "QA");
            yield return new WebTablesDataRow("Bob", "Grin", 35, "two@gmail.com", 30000, "QA Lead");
        }

        internal static IEnumerable<int> GetNumberOfRows()
        {
            yield return 5;
            yield return 10;
            yield return 20;
            yield return 25;
            yield return 50;
            yield return 100;
        }
    }
}