using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using SeleniumTest;



namespace SeleniumTest.TestActions
{
    public class FormTestAction
    {
        private string[,] testSamples = {
            { "mark34", "", "pass1223", "AG56" } , //test data with emply password
            { "", "pass1223", "pass1223", "AG56" }, //test data with emply username
            { "mark34", "pass1223", "pass1223", "AG56" }, //correct test data
            { "mark34#", "pass1223", "pass1223", "AG56" },//test data with special character in username
            { "mark34", "pass122", "pass1223", "AG56" }, //test data with incorrect password
            { "mar", "pass1223", "pass1223", "AG56" }, //test data 3 characters in username
            { "mark24", "p12", "p12", "AG56" } }; //test data with 3 character on passwords


        public static void ActionNavigateAdd(AppiumDriver<AppiumWebElement> driver)
        {

            Thread.Sleep(10000);
            driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/span[2]")).Click();
            driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/span[3]")).Click();
            driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/span[4]")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("/html/body/div/div/div/div[1]/div[4]/button")).Click();

        }

        public static void ActionToRegPage(AppiumDriver<AppiumWebElement> driver)
        {
            Thread.Sleep(2000);
            driver.FindElement(By.Id("signup")).Click();
        }

        public static void inputUsername(AppiumDriver<AppiumWebElement> driver, String testSample)
        {
            driver.FindElement(By.Name("username")).SendKeys(testSample);
        }

        public static void inputPassword(AppiumDriver<AppiumWebElement> driver, String testSample)
        {
            driver.FindElement(By.Name("password")).SendKeys(testSample);

        }

        public static void clickVeiwPass(AppiumDriver<AppiumWebElement> driver)
        {
            driver.FindElement(By.XPath("/html/body/div/div/div[3]/div[1]/form/div/div[2]/div/div/div[2]/button")).Click();
        }

        public static void retypePass(AppiumDriver<AppiumWebElement> driver, String testSample)
        {
            driver.FindElement(By.Name("repassword")).SendKeys(testSample);
        }

        public static void clickViewrePass(AppiumDriver<AppiumWebElement> driver)
        {
            driver.FindElement(By.XPath("/html/body/div/div/div[3]/div[1]/form/div/div[3]/div/div/div[2]/button")).Click();
        }

        public static void enterCaptcha(AppiumDriver<AppiumWebElement> driver, String testSample)
        {
            driver.FindElement(By.Name("captcha")).SendKeys(testSample);
        }

        public static void checkRegBtnAvailability(AppiumDriver<AppiumWebElement> driver)
        {
            Thread.Sleep(2000);

            var element = driver.FindElement(By.XPath("/html/body/div/div/div[3]/div[1]/form/div/button"));

            bool button = element.Enabled;
            if (!button)
            {
                Console.WriteLine("Missing Fields returns disabled register button");
                driver.Quit();
            }
            else
            {
                driver.FindElement(By.XPath("/html/body/div/div/div[3]/div[1]/form/div/button")).Click();
            }
        }



    }
}