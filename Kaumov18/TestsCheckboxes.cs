using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace TestProjectKaumov
{
    public class TestsCheckboxes
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/checkboxes");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //проверить, что первый чекбокс unchecked
            IWebElement checkbox1 = driver.FindElement(By.CssSelector("input[type='checkbox']:nth-of-type(1)"));                                  
            Assert.IsFalse(checkbox1.Selected);

            //отметить первый чекбокс
            checkbox1.Click();

            //проверить что первый чекбокс checked                     
            Assert.IsTrue(checkbox1.Selected);

            //Проверить, что второй чекбокс checked
            IWebElement checkbox2 = driver.FindElement(By.CssSelector("input[type='checkbox']:nth-of-type(2)"));
            Assert.IsTrue(checkbox2.Selected);

            //сделать второй чекбокс unheck
            checkbox2.Click();

            //проверить, что второй чекбокс unchecked            
            Assert.IsFalse(checkbox2.Selected);

            driver.Quit();
        }
    }
}