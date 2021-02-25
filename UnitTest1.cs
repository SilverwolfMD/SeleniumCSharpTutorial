using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace SeleniumCSharpTutorial
{
    public class Tests
    {

        //class variables
        public IWebDriver driver; // yep, just like Java, so let's get familliar with the code before we write a toolkit.
        String testSite = "https://executeautomation.com"; // target site
        
        [SetUp]
        public void Setup() // Initialization goes here
        {
            Console.WriteLine("Setup"); // This is the .NET equivalent of System.out.println() or cout <<.
            //driver = new ChromeDriver(driverPath); // this is a function overload in the C# ChromeDriver function.
            driver = TestToolkit.InitWebDrv("firefox");
            /*
             * ChromeDriver(path) is one overload, there's also ChromeDriver(path, ChromeOptions);
             * TestToolkit will need to be updated for this.
             */

        }//end setup

        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl(testSite);
            Console.WriteLine("Test1");
            Assert.Pass();
        }//end Test1
    }
}