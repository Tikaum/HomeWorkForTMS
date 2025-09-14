using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Xml.XPath;

namespace TestProjectKaumov
{
    internal class TestHovers
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/hovers");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            Actions actions = new Actions(driver);
            //проверка что нет 404 ошибки. Повторить для каждого из профилей
            //Профиль 1            
            IWebElement element1 = driver.FindElement(By.XPath("(//img[@alt='User Avatar'])[1]"));
            actions.MoveToElement(element1).Perform();
            IWebElement nameField1 = driver.FindElement(By.XPath("//h5[1]"));
            string name1 = nameField1.Text;            
            Assert.IsTrue(name1 == "name: user1", "The username #1 is incorrect");
            IWebElement elementmove1 = driver.FindElement(By.XPath("//a[@href='/users/1']"));
            actions.Click(elementmove1).Perform();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            string ups = driver.FindElement(By.TagName("h1")).Text;
            Assert.IsFalse(ups == "Not Found", "The page specified in the user link was not found");
            driver.Navigate().Back();
            //Профиль 2
            IWebElement element2 = driver.FindElement(By.XPath("(//img[@alt='User Avatar'])[2]"));
            actions.MoveToElement(element2).Perform();
            IWebElement nameField2 = driver.FindElement(By.XPath("//h5[2]"));
            string name2 = nameField1.Text;
            Assert.IsTrue(name1 == "name: user2", "The username #2 is incorrect");
            IWebElement elementmove2 = driver.FindElement(By.XPath("//a[@href='/users/2']"));
            actions.Click(elementmove2).Perform();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            ups = driver.FindElement(By.TagName("h1")).Text;
            Assert.IsFalse(ups == "Not Found", "The page specified in the user link was not found");
            driver.Navigate().Back();
            //Профиль 3
            IWebElement element3 = driver.FindElement(By.XPath("(//img[@alt='User Avatar'])[3]"));
            actions.MoveToElement(element3).Perform();
            IWebElement nameField3 = driver.FindElement(By.XPath("//h5[3]"));
            string name3 = nameField1.Text;
            Assert.IsTrue(name3 == "name: user1", "The username #3 is incorrect");
            IWebElement elementmove3 = driver.FindElement(By.XPath("//a[@href='/users/3']"));
            actions.Click(elementmove3).Perform();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            ups = driver.FindElement(By.TagName("h1")).Text;
            Assert.IsFalse(ups == "Not Found", "The page specified in the user link was not found");
            driver.Quit();
        }
    }
}
