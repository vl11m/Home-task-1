using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers; 
using System;
using System.Collections.Generic;

namespace Home_task_1
{
    [TestFixture]
    public class Tests
    {
        IWebDriver driver;
        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }
        [OneTimeTearDown]
        public void AfterTest()
        {
            driver.Quit();
        }
        [Test]
        public void Test1()
        {

            {
                string url = "https://www.demoblaze.com/index.html";
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl(url);

                IWebElement loginButton = driver.FindElement(By.Id("login2"));
                loginButton.Click();

                IWebElement loginFeild = driver.FindElement(By.Id("loginusername"));
                loginFeild.Clear();
                loginFeild.SendKeys("test");

                IWebElement passFeild = driver.FindElement(By.Id("loginpassword"));
                passFeild.Clear();
                passFeild.SendKeys("test");

                IWebElement sendLogin = driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[3]/button[2]"));
                sendLogin.Click();

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("logout2")));
                Assert.IsTrue(driver.FindElement(By.Id("logout2")).Displayed);
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("logout2")));
                Assert.IsTrue(driver.FindElement(By.Id("nameofuser")).Displayed);
            }
        }
        private static IEnumerable<TestCaseData> LoginAndPass
        {
            get
            {
                yield return new TestCaseData("JohnDoe", "passwOrd");
                yield return new TestCaseData("LiliaJY", "isNotMe");
                yield return new TestCaseData("GoingTo", "beAuto!");
            }
        }
        [TestCaseSource("LoginAndPass")]
        public void Test2(string login, string password)
        {

            {
                string url = "http://automationpractice.com/index.php";
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl(url);

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div/div[1]/header/div[2]/div/div/nav/div[1]/a")));


                IWebElement loginButton = driver.FindElement(By.XPath("/html/body/div/div[1]/header/div[2]/div/div/nav/div[1]/a"));
                loginButton.Click();

                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("email")));



                IWebElement loginFeild = driver.FindElement(By.Id("email"));
                loginFeild.Clear();
                loginFeild.SendKeys(login);

                IWebElement passFeild = driver.FindElement(By.Id("passwd"));
                passFeild.Clear();
                passFeild.SendKeys(password);

                IWebElement logInButton = driver.FindElement(By.XPath("/html/body/div/div[2]/div/div[3]/div/div/div[2]/form/div/p[2]/button/span"));
                logInButton.Click();

                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='center_column']/div[1]/ol/li")));

                Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='center_column']/div[1]/ol/li")).Displayed);
            }
        }
    }
}