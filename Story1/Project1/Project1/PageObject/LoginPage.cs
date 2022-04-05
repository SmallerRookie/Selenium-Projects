using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.PageObject
{
    public class LoginPage
    {
        private readonly IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "login_username")]
        private IWebElement userName;

        [FindsBy(How = How.Id, Using = "login_password")]
        private IWebElement passWord;

        [FindsBy(How = How.XPath, Using = "//button[text()='登录']")]
        private IWebElement loginBtn;

        [FindsBy(How = How.XPath, Using = "//input[@name='_remember_me']")]
        private IWebElement rememberMeBtn;

        [FindsBy(How = How.CssSelector, Using = "div[class*='danger']")]
        private IWebElement errorMsg;

        public void RememberBtn()
        {
            Boolean Btn = rememberMeBtn.Selected;
            if (Btn == false)
            {
                rememberMeBtn.Click();
            }
        }

        public void UserInPuts(string username, string password)
        {
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait1.Until(ExpectedConditions.ElementIsVisible(By.Id("login_username")));

            WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait1.Until(ExpectedConditions.ElementIsVisible(By.Id("login_password")));

            userName.SendKeys(username);
            passWord.SendKeys(password);
        }

        public string CheckError()
        {
            WebDriverWait wait1 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait1.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[class*='danger']")));
            return errorMsg.Text;
        }

        public AfterLoginPage PressBtn()
        {
            loginBtn.Click();
            return new AfterLoginPage(driver);
        }



    }
}
