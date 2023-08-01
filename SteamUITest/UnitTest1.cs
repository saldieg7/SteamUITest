using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using NUnit.Framework;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using System;
using System.Threading;
using System.Collections.Generic;

namespace SteamUITests
{
    [TestFixture]
    public class Task2Tests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void InvalidLoginTest()
        {
            int waitingTime = 1000;
            // Navigate to the URL
            driver.Navigate().GoToUrl("https://store.steampowered.com/");

            // Click the login button
            IWebElement loginButton = driver.FindElement(By.ClassName("global_action_link"));
            loginButton.Click();
            Thread.Sleep(waitingTime);

            // Input random user password and click the sign-in button          

            IList<IWebElement> textInputs = driver.FindElements(By.ClassName("newlogindialog_TextInput_2eKVn"));
            IWebElement usernameInput = textInputs[0];
            IWebElement passwordInput = textInputs[1];

            Thread.Sleep(waitingTime);
            IWebElement signInButton = driver.FindElement(By.ClassName("newlogindialog_SubmitButton_2QgFE"));
            Thread.Sleep(waitingTime);

            string randomUsername = "random" + System.DateTime.Now.Millisecond;
            Thread.Sleep(waitingTime);
            string randomPassword = "randompwd" + System.DateTime.Now.Millisecond;
            Thread.Sleep(waitingTime);

            usernameInput.SendKeys(randomUsername);
            Thread.Sleep(waitingTime);
            passwordInput.SendKeys(randomPassword);
            Thread.Sleep(waitingTime);
            signInButton.Click();
            Thread.Sleep(waitingTime);

            // Wait for the loading element and error text to be displayed
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            

            // Assert expected results
            Assert.IsTrue(driver.Url.Contains("https://store.steampowered.com/"), "Main page is not displayed.");
            Assert.IsTrue(driver.Url.Contains("https://store.steampowered.com/login/"), "Login page is not displayed.");
            Thread.Sleep(waitingTime);
        }
    }
}

