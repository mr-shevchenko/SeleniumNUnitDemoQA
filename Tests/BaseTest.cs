using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using FrameworkDemoQA.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace FrameworkDemoQA.Tests
{
    public class BaseTest
    {
        protected ExtentReports extentReports;
        protected ExtentTest extentTest;
        protected IWebDriver Driver { get; set; }
        protected PageList Pages { get; private set; }

        internal static string testStartedTime = DateTime.Now.ToString("yyy-MM-dd-HH-mm-ss");
        internal Exception ex;

        [OneTimeSetUp]
        public void SetupReporting()
        {
            extentReports = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(DriverHelper.GetReportPath());
            extentReports.AttachReporter(htmlReporter);
        }

        [SetUp]
        public void SetUp()
        {
            Driver = DriverHelper.GetDriver();
            Pages = new PageList(Driver);
            extentTest = extentReports.CreateTest(TestContext.CurrentContext.Test.FullName);
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
                {
                    extentTest.Log(Status.Pass);
                }
                else
                {
                    var path = DriverHelper.MakeScreenshot(Driver, TestContext.CurrentContext.Test.MethodName, DriverHelper.GetReportPath());
                    extentTest.AddScreenCaptureFromPath(path);
                    if (ex != null)
                    {
                        extentTest.Info($"{ex.Message} \r\n {ex.StackTrace}");
                     }
                    extentTest.Log(Status.Fail);
                }
            }
            finally
            {
                Driver.Quit();
            }
        }

        [OneTimeTearDown]
        public void FlushReport()
        {
            extentReports.Flush();
        }
    }
}
