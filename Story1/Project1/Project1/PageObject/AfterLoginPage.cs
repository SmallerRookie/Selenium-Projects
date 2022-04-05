using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.PageObject
{
    public class AfterLoginPage
    {
        private readonly IWebDriver driver;

        public AfterLoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "a[class='dropdown-toggle']")]
        private IWebElement avatar;

        [FindsBy(How = How.CssSelector, Using = "li[class*='header']")]
        private IWebElement userName;

        public void AvatarHover()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".avatar-xs")));
            Actions action = new Actions(driver);
            action.MoveToElement(avatar).Perform();
        }

        public string CheckUser()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("li[class*='header']")));
            return userName.Text;
        }

    }
}
