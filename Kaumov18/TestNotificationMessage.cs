using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Xml.XPath;

namespace TestProjectKaumov
{
    internal class TestNotificationMessage
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/notification_message_rendered");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Actions actions = new Actions(driver);

            //проверить соответствие текста ожиданиям           
            string notification = driver.FindElement(By.TagName("p")).Text;            
            Assert.AreEqual("The message displayed above the heading is a notification message."+
                " It is often used to convey information about an action previously taken by the user."+
                "\r\n\r\nSome rudimentary examples include 'Action successful',"+
                " 'Action unsuccessful, please try again', etc." +
                "\r\n\r\nClick here to load a new message.", notification);
            driver.Quit();
        }
    }
}
