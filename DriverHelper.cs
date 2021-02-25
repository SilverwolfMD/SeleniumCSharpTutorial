using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCSharpTutorial
{
    public class DriverHelper
    {

        public IWebDriver driver { get; set; } // this is a property statement on an instantiated object.  This class acts as a "parking spot" for a WebDriver object so it can be accessed by classes which inherit this object.

    }
}
