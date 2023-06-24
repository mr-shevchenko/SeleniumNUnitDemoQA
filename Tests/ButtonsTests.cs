namespace FrameworkDemoQA.Tests
{
    [TestFixture]
    public class ButtonsTests : BaseTest
    {
        [Test]
        public void DoubleClickButtonTest()
        {
            Pages.ButtonsPage.Open();

            Pages.ButtonsPage.DoDoubleClick();
            Assert.True(Pages.ButtonsPage.GetDoubleClickMessage() == "You have done a double click");
        }

        [Test]
        public void RightClickButtonTest()
        {
            Pages.ButtonsPage.Open();

            Pages.ButtonsPage.DoRightClick();
            Assert.True(Pages.ButtonsPage.GetRightClickMessage() == "You have done a right click");
        }

        [Test]
        public void ClickButtonTest()
        {
            Pages.ButtonsPage.Open();

            Pages.ButtonsPage.DoClick();
            Assert.True(Pages.ButtonsPage.GetClickMeMessage() == "You have done a dynamic click");
        }
    }
}
