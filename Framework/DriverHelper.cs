using FrameworkDemoQA.Tests;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FrameworkDemoQA.Framework
{
    internal class DriverHelper
    {
        public static IWebDriver GetDriver()
        {
            var driver = new ChromeDriver();

            return driver;
        }

        internal static string MakeScreenshot(IWebDriver driver, string testName, string reportPath)
        {
            string screenshotPath = string.Empty;

            if (driver != null)
            {
                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();

                var dateTimeStr = DateTime.Now.ToString("yyy-MM-dd-HH-mm-ss");
                var screenshotName = $"{testName}-{dateTimeStr}.png";

                screenshotPath = Path.Combine(reportPath, screenshotName);
                screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
            }

            return screenshotPath;
        }

        internal static string GetReportPath()
        {
            var className = TestContext.CurrentContext.Test.ClassName;
            var groupOfTestsName = className.Substring(className.LastIndexOf('.') + 1);

            return $"D:\\Reports\\{BaseTest.testStartedTime}\\{groupOfTestsName}\\";
        }

        internal static IWebElement GetLatestRow(IReadOnlyCollection<IWebElement> rows)
        {
            IWebElement latestRow = null;

            // Iterate over the rows in reverse order
            for (int i = rows.Count - 1; i >= 0; i--)
            {
                IWebElement row = rows.ElementAt(i);
                IReadOnlyCollection<IWebElement> cells = row.FindElements(By.XPath(".//*[contains(@class,'rt-td')]"));

                // Check if the row has non-empty cells
                bool isRowFilledWithData = cells.Any(cell => !string.IsNullOrEmpty(cell.Text) && (cell.Text!=" "));

                if (isRowFilledWithData)
                {
                    latestRow = row;
                    break;
                }
            }
            return latestRow;
        }
    }
}
