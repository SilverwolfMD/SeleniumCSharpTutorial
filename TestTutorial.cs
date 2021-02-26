using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumCSharpTutorial.Application_Layer.Pages;
using SeleniumCSharpTutorial.Framework.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCSharpTutorial
{
    class TestTutorial : DriverHelper  // this is the equivalent to Java's "extends" keyword.
    {

      
        //class variables
        //public IWebDriver driver; // this part is not needed, as the driver (with the same identifier) is inherited from DriverHelper.

        String aspNetSite = "https://demowf.aspnetawesome.com/"; // target site for Test1
        String autoCompFldID = "ContentPlaceHolder1_Meal"; // the target field.  ChroPath nailed this one.  We can add on the necessary characters for CSS or XPathing.
        String ajaxCheckboxXpath = "//div[@class='awe-display o-ochk']"; // locates the checkbox list and provides a foundation for element traverse
        String ajaxCheckLabelXpath = "//label[@class='awe-label']"; // localizes elements in the checkbox list by label

        // alternatively, we can use a sibling traverse from:
        String ajaxMonstrosityXpath = "//input[@name='ctl00$ContentPlaceHolder1$ChildMeal1']"; // more unique, but ludicrous, not usually done unless there's no other way to generate a unique locator.

        // but there's a compromise that provides an opportunity to learn sibling traverse while keeping the XPath locators reasonable.

        [SetUp]
        public void Setup() // Initialization goes here
        {
            //begin setup
            Console.WriteLine("Setup"); // Until we have a properties file, we'll use this to remind us here.
            driver = TestToolkit.InitWebDrv("chrome");
          
        }//end setup

        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl(aspNetSite);
            //in java, we'd use driver.findElement(By.cssSelector(autoCompFldCSS)).sendKeys("Text");
            driver.FindElement(By.Id(autoCompFldID)).SendKeys("Text"); // same syntax, just with capitals.

            //remember that compromise above?  This uses the sibling traverse.
            driver.FindElement(By.XPath(ajaxCheckboxXpath + "//input/following-sibling::div[text()='Celery']")).Click();
            // Now keep in mind that this is clicking on the label, which, on this site, is a valid input.  However, if we needed the checkbox, we could use a parent-child traverse to the common parent node, then back down to the checkbox.

            // this example uses dynamic menus:
            String comboBoxXPath= "//input[@id='ContentPlaceHolder1_AllMealsCombo-awed']";
            String menuOptXpath = "//div[@id='ContentPlaceHolder1_AllMealsCombo-dropmenu']";
            String query = "Almonds";

            driver.FindElement(By.XPath(comboBoxXPath)).Clear(); // clear existing data
            driver.FindElement(By.XPath(comboBoxXPath)).SendKeys(query.Substring(0, 2)); // we're looking for almonds.

            // now there's a bit of a trick, we need to be sure the element even exists.
            if (driver.FindElement(By.XPath(menuOptXpath + "//li[contains(text(),'" + query + "')]")).Displayed)
            {
                driver.FindElement(By.XPath(menuOptXpath + "//li[contains(text(),'" + query + "')]")).Click();
            }
            // this is a lot simpler than the extra method created using Java.

            // using a Custom control for a UI component:
            String comboBoxID = "ContentPlaceHolder1_AllMealsCombo"; // the raw ID which can be used directly or concatenated into an XPath or CSS expression.  This string is reduced to the substring common to elements of the combo box.  Other elements can be added as needed.

            CustomControlTutorial customControl = new CustomControlTutorial(driver); // instantiation of the custom control class as an object, much like we would with a pageObject.  The problem, however, is that this class also extends DriverHelper, so instantiation effectively clears the object out and makes it null.

            //driver = TestToolkit.InitWebDrv("chrome"); This does not work, it only instantiates a new WebDriver, it doesn't recover the information from our old one.
            
            query = "Tomato"; // new query to be sure we're not re-using the old one
            customControl.ComboBoxControl(comboBoxID, query);

            Assert.Pass();
        }//end Test1

        [Test]
        public void LoginTest() // items after the [Test] annotation are executed as independent test programs, much like methods flagged with @Test in TestNG.  Also, much like in TestNG, the [Test] identifier has to precede each of the test functions.
        {

            LandingPage landingPg = new LandingPage(driver);

            driver.Navigate().GoToUrl(landingPg.pageURL); // we stored the page URL in the pageObject.
            LoginPage loginPg = landingPg.LoginLink(); // click login and instantiate the page object for the login page itself using the same webDriver object.
            loginPg.LoginSequence("admin", "password"); // Use the test credentials to authenticate.
            Assert.That(landingPg.LogoutFormPresent(), Is.True, "User did not log into page."); // this is a more english-language means of using identifiers, and it also has a custom message.
            Assert.True(landingPg.LogoutFormPresent()); // also works if we're not breaking the coding stride.

        }

    }
}
