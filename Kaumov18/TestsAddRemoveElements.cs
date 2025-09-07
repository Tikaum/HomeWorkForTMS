using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Xml.Linq;

namespace TestProjectKaumov
{
    public class TestsAddRemoveElements
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/add_remove_elements/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.XPath("//button[text()='Add Element']")).Click();
            driver.FindElement(By.XPath("//button[text()='Add Element']")).Click();
            driver.FindElement(By.XPath("//button[text()='Delete']")).Click();
            int del = driver.FindElements(By.XPath("//button[text()='Delete']")).Count();
            Assert.IsTrue(del == 1);            
            driver.Quit();
        }
    }
}