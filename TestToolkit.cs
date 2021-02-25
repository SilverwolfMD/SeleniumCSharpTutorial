using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using System;


namespace SeleniumCSharpTutorial
{
    
    public static class TestToolkit
    {
        //global variables
        public enum Browser { CHROME, FIREFOX, MSIE, EDGE, SAFARI, OPERA, REMOTE, PROP };
        static String driversDir = @"E:\Users\Fionn\Documents\Web drivers\";

        public static IWebDriver InitWebDrv(String choice, ChromeOptions chroOpt = null, FirefoxOptions fireOpt = null) // ah, welcome back, default variables.  This makes C sooooo much easier.
        {
            //variables section
            Browser exeChoice;

            Enum.TryParse(choice.ToUpper(), out exeChoice);
            switch (exeChoice)
            {
                case Browser.CHROME:
                    {
                        if (chroOpt == null)
                        {
                            return new ChromeDriver(driversDir);
                        }
                        else
                        {
                            return new ChromeDriver(driversDir, chroOpt);
                        }
                    }
                case Browser.FIREFOX: // the code seems repetitive, but it's a requirement because these are seperate classes.
                    {
                        if (fireOpt == null)
                        {
                            return new FirefoxDriver(driversDir);
                        }
                        else
                        {
                            return new FirefoxDriver(driversDir, fireOpt);
                        }
                    }
                case Browser.MSIE:
                    {
                        return new InternetExplorerDriver(driversDir);
                    }
                case Browser.EDGE:
                    {
                        return new EdgeDriver(driversDir);
                    }
                case Browser.SAFARI:
                    {
                        return new SafariDriver(driversDir);
                    }
                case Browser.OPERA:
                    {
                        return null;
                    }
                case Browser.REMOTE:
                    {
                        return null;
                    }
                case Browser.PROP:
                    {
                        return null;
                    }
                default:
                    {
                        throw new ArgumentException("No valid browser choice in argument or properties file.");
                    }
            }//end switch exeChoice
            
        }//end InitWebDrv


    }
}
