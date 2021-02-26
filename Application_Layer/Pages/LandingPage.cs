using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCSharpTutorial.Application_Layer.Pages
{
    public class LandingPage
    {

        public String pageURL = "http://eaapp.somee.com";
        IWebDriver driver;

        public LandingPage(IWebDriver drv)
        {
            this.driver = drv;
        }

        // Method 1: the lambda expression
        IWebElement loginLnk => driver.FindElement(By.Id("loginLink")); // in one line, the pageObject has found the webElement and assigned it to an object, so we don't need a @FindBy annotation.

        // PageObject method: we're going to try to be efficient like with Java, so let's use driver to instantiate the next pageObject:
        public LoginPage LoginLink()
        {
            loginLnk.Click(); // carry out the action of actually going to the Login page
            LoginPage retPage = new LoginPage(driver);
            return retPage;
        }

        // alternatively, we could just perform the click action as:
        //public void LoginLink() => loginLnk.Click();
        // ...and then instantiate a new webdriver in the test script.

        private IWebElement logoutForm => driver.FindElement(By.Id("logoutForm"));
        // if we need the WebElement itself, we can write a function to return it.
        // in C#, a lot more of the actual action code can be written into the pageObject, while the test class simply administers the test.  Consult with the project lead for best practices and client requests.
        public bool LogoutFormPresent() => logoutForm.Displayed;  // note that this is a property (a variable), not a function.
        // since we only need one line of code, we can get away with putting the actual test mechanism in the pageObject. However, the mechanism must be operable and assertable in the test class.

    }
}
