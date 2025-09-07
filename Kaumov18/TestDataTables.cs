using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestProjectKaumov
{
    internal class TestDataTables
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/tables");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);            

            //Проверка содержимого 1 ячейки 1 строки (не считая заголовка) 1 таблицы
            string cellValue = driver.FindElement(By.XPath("(//table)[1]//tr[1]/td[1]")).Text;
            Assert.AreEqual("Smith", cellValue);

            //Проверка содержимого 4 ячейки 3 строки (не считая заголовка) 1 таблицы
            cellValue = driver.FindElement(By.XPath("(//table)[1]//tr[3]/td[4]")).Text;
            Assert.AreEqual("$100.00", cellValue);

            //Проверка содержимого 2 ячейки 4 строки (не считая заголовка) 1 таблицы
            cellValue = driver.FindElement(By.XPath("(//table)[1]//tr[4]/td[2]")).Text;
            Assert.AreEqual("Tim", cellValue);

            //Проверка содержимого 1 ячейки 4 строки (не считая заголовка) 2 таблицы
            cellValue = driver.FindElement(By.XPath("(//table)[2]//tr[4]/td[1]")).Text;
            Assert.AreEqual("Conway", cellValue);

            //Проверка содержимого 5 ячейки 3 строки (не считая заголовка) 2 таблицы
            cellValue = driver.FindElement(By.XPath("(//table)[2]//tr[3]/td[5]")).Text;
            Assert.AreEqual("http://www.jdoe.com", cellValue);

            driver.Quit();
        }
    }
}

