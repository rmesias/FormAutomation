using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using SeleniumTest.TestActions;
using SeleniumTest;

namespace SeleniumTest.Tests
{
    [TestFixture()]
    public class FormMain
    {
        //public IWebDriver driver;
        public AppiumOptions dc;
        AppiumDriver<AppiumWebElement> adriver;
        public Boolean present;
        private string[,] testSamples = {
            { "mark34", "", "pass1223", "AG56" } , //test data with emply password
            { "", "pass1223", "pass1223", "AG56" }, //test data with emply username
            { "mark34", "pass1223", "pass1223", "AG56" }, //correct test data
            { "mark34#", "pass1223", "pass1223", "AG56" },//test data with special character in username
            { "mark34", "pass122", "pass1223", "AG56" }, //test data with incorrect password
            { "mar", "pass1223", "pass1223", "AG56" }, //test data 3 characters in username
            { "mark24", "p12", "p12", "AG56" } }; //test data with 3 character on passwords

        private string[] errorMessage = { 
            "Username must be 4 to 12 alphanumeric characters only. No special characters allowed.", 
            "CAPTCHA IS INCORRECT", 
            "Password must be 6 to 12 alphanumreic including special characters." };

        [OneTimeSetUp]
        public void SetUp()
        {

            dc = new AppiumOptions();
            dc.AddAdditionalCapability("platformName", "Android");
            dc.AddAdditionalCapability("chromedriverExecutable", "/Users/rmesias/Downloads/chromedriver");
            dc.AddAdditionalCapability("platformVersion", "9.0");
            dc.AddAdditionalCapability("deviceName", "nexus_6p_pie_9_0_-_api_28");
            dc.AddAdditionalCapability("browserName", "chrome");

            //driver = new RemoteWebDriver(new Uri("http://127.0.0.1:4723/wd/hub"), dc);
            adriver = new AndroidDriver<AppiumWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), dc);

        }

        [Test, Order(1)]
        public void HomePage()
        {
            adriver.Navigate().GoToUrl("http://i881.app.template.development.aonewallet.com");
        }

        [Test, Order(2)]
        public void NavAdds()
        {

            TestActions.FormTestAction.ActionNavigateAdd(adriver);
        }

        [Test, Order(3)]
        public void GoToRegisterPage()
        {
            TestActions.FormTestAction.ActionToRegPage(adriver);
        }

        [Test, Order(4)]
        public void EnterUsername()
        {
            TestActions.FormTestAction.inputUsername(adriver, testSamples[2, 0]);

        }

 
        [Test, Order(5)]
        public void EnterPassword()
        {
            TestActions.FormTestAction.inputPassword(adriver, testSamples[2, 1]);
            Assert.AreEqual(testSamples[2, 1], adriver.FindElement(By.Name("password")).GetAttribute("value"));

        }

        [Test, Order(6)]
        public void ViewEnteredPassword()
        {
            TestActions.FormTestAction.clickVeiwPass(adriver);
            Thread.Sleep(2000);
            Assert.AreEqual("text", adriver.FindElement(By.Name("password")).GetAttribute("type"));
        }

        [Test, Order(7)]
        public void ReTypePassword()
        {
            TestActions.FormTestAction.retypePass(adriver, testSamples[2, 2]);
            Assert.AreEqual(testSamples[2, 1], adriver.FindElement(By.Name("repassword")).GetAttribute("value"));
        }

        [Test, Order(8)]
        public void ViewReTypePassword()
        {
            TestActions.FormTestAction.clickViewrePass(adriver);
            Thread.Sleep(2000);
            Assert.AreEqual("text", adriver.FindElement(By.Name("password")).GetAttribute("type"));
        }

        [Test, Order(9)]
        public void ByPasscaptcha()
        {
            TestActions.FormTestAction.enterCaptcha(adriver, testSamples[2, 3]);
            //Can't Automate with image capcha

        }

        [Test, Order(10)]
        public void RegButton()
        {
            TestActions.FormTestAction.checkRegBtnAvailability(adriver);
        }

        [Test, Order(11)]

        public void checkDataValidity()
        {

            Assert.AreEqual(errorMessage[1], adriver.FindElement(By.XPath("/html/body/div/div/div[3]/div[2]/div/div/p")).Text);

        }


    }


}
