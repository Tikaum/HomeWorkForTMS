using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using AngleSharp.Css.Parser;

namespace Kaumov19
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestForLocators()
        {
            IWebDriver driver = new FirefoxDriver(); // ������� ��� �����, �.�. � ����� ��������� � ������� ��������
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.Manage().Window.Maximize();
            
            //����� ������� ��� ����������� ���������� ������ �� �����, � �� �� ����� � ������ ����� ������

            //�������� ��� id
            IWebElement userNameField = driver.FindElement(By.Id("user-name"));
            userNameField.Click();
            userNameField.SendKeys("standard_user");
            IWebElement passwordField = driver.FindElement(By.Id("password"));
            passwordField.Click();
            passwordField.SendKeys("secret_sauce");
            driver.FindElement(By.Id("login-button")).Click();

            //�������� ��� classname � name
            driver.FindElement(By.ClassName("shopping_cart_link")).Click();
            driver.FindElement(By.Name("checkout"));
            driver.Navigate().Back();

            //�������� ��� linktext
            //driver.FindElement(By.ClassName("bm-burger-button")).Click();
            //driver.FindElement(By.LinkText("https://saucelabs.com/")).Click(); - ��� ����� �� ���� �������, ����� ����� �� ������
            //driver.FindElement(By.PartialLinkText("inventory"));              - ��� �� ��������� ������

            //����� �� ��������, �������� By.xpath("//tag[@attribute='value']");
            driver.FindElement(By.XPath("//*[@data-test='inventory-item-price']"));

            //����� �� ������, �������� By.xpath("//tag[text()='text']");
            driver.FindElement(By.XPath("//button[text()='Add to cart']")).Click();

            //����� �� ���������� ���������� ��������, �������� By.xpath("//tag[contains(@attribute,'text')]");
            driver.FindElement(By.XPath("//div[contains(@data-test,'item-name')]")).Click();

            //ancestor, �������� //*[text()='Enterprise Testing']//ancestor::div
            driver.FindElement(By.XPath("//*[text()= '29.99']//ancestor::div"));
            driver.Navigate().Back();

            //descendant
            driver.FindElement(By.XPath("//div[@class='inventory_item_label']//descendant::div"));

            //following
            driver.FindElement(By.XPath("//div[@class='inventory_list']//following-sibling::div[2]"));

            //parent
            driver.FindElement(By.XPath("//div[contains(text(),'red light')]/parent::*"));

            //preceding
            driver.FindElement(By.XPath("//div[contains(text(),'Backpack')]/preceding::*"));

            //����� �������� � �������� AND
            driver.FindElement(By.XPath("//*[@id='item_1_title_link' and @data-test='item-1-title-link']"));

            //CSS
            //.class
            driver.FindElement(By.CssSelector(".inventory_item_price"));
            //.class1.class2
            driver.FindElement(By.CssSelector(".btn.btn_small"));
            //.class1 .class2
            driver.FindElement(By.CssSelector(".inventory_item .inventory_item_name "));
            //#id
            driver.FindElement(By.CssSelector("#item_0_title_link"));
            //tagname
            driver.FindElement(By.CssSelector("button"));
            //tagname.class
            driver.FindElement(By.CssSelector("div.inventory_item_price"));
            //[attribute=value]
            driver.FindElement(By.CssSelector("[data-test='inventory-container']"));
            //[attribute~= value]
            driver.FindElement(By.CssSelector("[class~='btn_small']"));
            //[attribute|= value]
            driver.FindElement(By.CssSelector("[name|='add']"));
            //[attribute^=value]
            driver.FindElement(By.CssSelector("[id^='contents']"));
            //[attribute$=value]
            driver.FindElement(By.CssSelector("[name$='-backpack']"));
            //[attribute*=value] 0-title
            driver.FindElement(By.CssSelector("[data-test*='0-title']"));



        }
    }
}