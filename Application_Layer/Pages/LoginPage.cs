using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCSharpTutorial.Application_Layer.Pages
{
    public class LoginPage
    {

        String pageURL = "http://eaapp.somee.com/Account/Login";
        IWebDriver driver;
        
        public LoginPage(IWebDriver drv)
        {
            this.driver = drv;
        }

        // Page Objects
        private IWebElement userNameField => driver.FindElement(By.Id("UserName"));
        private IWebElement passField => driver.FindElement(By.Id("Password"));
        private IWebElement loginButton => driver.FindElement(By.XPath("//input[@type='submit']"));
        // we can make these private to prevent accession of the identifier information directly.

        public void LoginSequence(String user = null, String pass = null) // This would be a complete login sequence which allows the tester to leave empty fields if desired for nonfunctional tests.
        {
            if (user != null)
            {
                userNameField.SendKeys(user);
            }
            if (pass != null)
            {
                passField.SendKeys(pass);
            }
            loginButton.Click();
        }

    }
}
