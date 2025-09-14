using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace TestProjectKaumov
{
    internal class TestTypos
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/typos");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //Проверка орфографии 
            IList<IWebElement> paragraphs = driver.FindElements(By.TagName("p"));
            string paragraph1 = paragraphs[0].Text;
            string paragraph2 = paragraphs[1].Text;
            Assert.AreEqual("This example demonstrates a typo being introduced. It does it randomly on each page load.", paragraph1,
                "Paragraph #1 has incorrect spelling.");
            Assert.AreEqual("Sometimes you'll see a typo, other times you won't.", paragraph2, "Paragraph #2 has incorrect spelling.");
            driver.Quit();
        }
    }
}
