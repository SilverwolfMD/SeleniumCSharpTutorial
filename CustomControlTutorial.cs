using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCSharpTutorial
{
    public class CustomControlTutorial
    {
        // these aren't general-purpose controls.  This is a way of segregating and modularizing the code, something like a pageObject.
        // the code below comes from the TestTutorial, but we're setting it up in a different class and running it again with a different query.

        IWebDriver driver;

        public CustomControlTutorial (IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ComboBoxControl(String controlName, String value)
        {
            IWebElement comboControl = driver.FindElement(By.XPath($"//input[@id='{controlName}-awed']"));
            // this is the webElement corresponding to the parent node of the autocomplete menu. 
            // the '$' preceding the string indicates to C# to use string interpolation, where it takes the string value of controlName and concatenates it in the string without having to use so much string arithmetic.  So instead of
            //  String menuOptXpath = "//div[@id='ContentPlaceHolder1_AllMealsCombo-dropmenu']";
            //we can just use
            //  $"//div[@id='{controlName}-dropmenu']";
            //or, for the Xpath expression concatenation we used from TestTutorial:
            //  $"//div[@id='{controlName}-dropmenu']//li[contains(text(),'{value}')]";

            comboControl.Clear(); // clear existing data
            comboControl.SendKeys(value.Substring(0, 2)); // we're looking for an item in an auto-complete menu, so we need to start with a substring query.

            // now there's a bit of a trick, we need to be sure the element even exists.
            if (driver.FindElement(By.XPath($"//div[@id='{controlName}-dropmenu']//li[contains(text(),'{value}')]")).Displayed)
            {
                driver.FindElement(By.XPath($"//div[@id='{controlName}-dropmenu']//li[contains(text(),'{value}')]")).Click();
            }
        }

    }
}