using NUnit.Framework;
using Project1.PageObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.E2E_Test
{
    public class TestCases: Base
    {
        [Test, TestCaseSource("AddTestCaseData"),Category("Test1")]
        [Parallelizable(ParallelScope.All)]
        public void Login(string user, string pass)
        {
            HomePage homePage = new HomePage(GeTDriver());
            LoginPage logIn = homePage.PressBtn();
            logIn.RememberBtn();
            logIn.UserInPuts(user, pass);
            logIn.PressBtn();
        }


        [Test, TestCase("Hi","123"), Category("Test2")]     
        public void LoginFailed(string user, string pass)
        {
            HomePage homePage = new HomePage(GeTDriver());
            LoginPage logIn = homePage.PressBtn();
            logIn.UserInPuts(user, pass);
            logIn.PressBtn();
            StringAssert.Contains("用户名或密码错误",logIn.CheckError());
        }

        [Test,TestCase("test001","Test1234"), Category("Test3")]

        public void LoginSuccess(string user, string pass)
        {
            HomePage homePage = new HomePage(GeTDriver());
            LoginPage logIn = homePage.PressBtn();
            logIn.UserInPuts(user, pass);
            AfterLoginPage afterLoginPage = logIn.PressBtn();
            afterLoginPage.AvatarHover();
            StringAssert.Contains("test001", afterLoginPage.CheckUser());

        }


       public static IEnumerable<TestCaseData> AddTestCaseData()
        {
            yield return new TestCaseData(extractData().ExtractData("username"), extractData().ExtractData("password"));
            yield return new TestCaseData(extractData().ExtractData("wrongUsername"), extractData().ExtractData("wrongPassword"));
        }

       
    }
}
