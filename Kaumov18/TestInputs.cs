using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestProjectKaumov
{
    internal class TestInputs
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/inputs");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //Проверить на возможность ввести различные цифровые и нецифровые значения, используя Keys.ARROW_UP И Keys.ARROW_DOWN

            IWebElement numberField = driver.FindElement(By.CssSelector("input[type='number']"));
            numberField.Click();
            numberField.Clear();
            numberField.SendKeys(Keys.ArrowUp);
            string value = numberField.GetAttribute("value");
            Assert.AreEqual("1", value);

            for (int i = 0; i < 10; i++)
            {
                numberField.SendKeys(Keys.ArrowUp);
            }
            value = numberField.GetAttribute("value");
            Assert.AreEqual("11", value);

            for (int i = 0; i > -21; i--)
            {
                numberField.SendKeys(Keys.ArrowDown);
            }
            value = numberField.GetAttribute("value");
            Assert.AreEqual("-10", value);

            numberField.Clear();
            numberField.SendKeys("abcde");
            value = numberField.GetAttribute("value");
            Assert.AreEqual("", value);

            numberField.Clear();
            numberField.SendKeys("!@#$%^&*()");
            value = numberField.GetAttribute("value");
            Assert.AreEqual("", value);


            driver.Quit();
        }
    }
}
