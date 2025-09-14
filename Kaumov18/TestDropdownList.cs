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
            Assert.That(dropdownDefolt, Is.Not.Null, "The required element (dropdownDefolt) was not found");
            Assert.That(dropdown1, Is.Not.Null, "The required element (dropdown1) was not found");
            Assert.That(dropdown2, Is.Not.Null, "The required element (dropdown2) was not found");            
            IWebElement dropdownElement = driver.FindElement(By.Id("dropdown"));
            SelectElement dropdown = new SelectElement(dropdownElement);
            //Выбрать первый, проверить, что он выбран
            dropdown.SelectByValue("1");
            Assert.That(dropdown.SelectedOption.Text, Is.EqualTo("Option 1"), "The required element (dropdown1) is not selected");
            //Выбрать второй, проверить, что он выбран
            dropdown.SelectByValue("2");
            Assert.That(dropdown.SelectedOption.Text, Is.EqualTo("Option 2"), "The required element (dropdown2) is not selected");
            driver.Quit();
        }
    }
}