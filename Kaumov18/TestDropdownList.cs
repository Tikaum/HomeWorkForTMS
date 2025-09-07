using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace TestProjectKaumov
{
    public class TestDropdownList
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dropdown");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //Взять все элементы дроп-дауна и проверить их наличие
            
            IWebElement dropdownDefolt = driver.FindElement(By.XPath("//select[@id='dropdown']//option[text()='Please select an option']"));
            IWebElement dropdown1 = driver.FindElement(By.XPath("//select[@id='dropdown']//option[text()='Option 1']"));
            IWebElement dropdown2 = driver.FindElement(By.XPath("//select[@id='dropdown']//option[text()='Option 2']"));
            Assert.That(dropdownDefolt, Is.Not.Null);
            Assert.That(dropdown1, Is.Not.Null);
            Assert.That(dropdown2, Is.Not.Null);
            
            IWebElement dropdownElement = driver.FindElement(By.Id("dropdown"));
            SelectElement dropdown = new SelectElement(dropdownElement);

            //Выбрать первый, проверить, что он выбран
            dropdown.SelectByValue("1");
            Assert.That(dropdown.SelectedOption.Text, Is.EqualTo("Option 1"));
            //Выбрать второй, проверить, что он выбран
            dropdown.SelectByValue("2");
            Assert.That(dropdown.SelectedOption.Text, Is.EqualTo("Option 2"));

            driver.Quit();
        }
    }
}