using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace HelloAppTestv4
{
    [TestClass]
    public class UnitTest1
    {
        private static readonly string DriverDirectory = "C:\\webDrivers";
        // Download drivers to your driver folder.
        // Driver version must match your browser version.
        // http://chromedriver.chromium.org/downloads
        // https://developer.microsoft.com/en-us/microsoft-edge/tools/webdriver/

        private static IWebDriver _driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            //_driver = new ChromeDriver(DriverDirectory); // fast
            _driver = new FirefoxDriver(DriverDirectory);  
            //_driver = new EdgeDriver(DriverDirectory); //  fast
            // Driver file must be renamed to MicrosoftWebDriver.exe OR msedgedriver.exe
            // depending on the version of Selenium?
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void TestMethod()
        {
            string url = "file:///C:/andersb/javascript/sayhelloVue3/index.htm";
            //string url = "https://anbo-sayhello.azurewebsites.net/";
            //string url = "http://localhost:5502/index.htm";
            _driver.Navigate().GoToUrl(url);

            Assert.AreEqual("Say Hello", _driver.Title);

            IWebElement inputElement = _driver.FindElement(By.Id("inputField"));
            inputElement.SendKeys("Anders");

            IWebElement buttonElement = _driver.FindElement(By.Id("button"));
            buttonElement.Click();

            IWebElement outputElement = _driver.FindElement(By.Id("outputField"));
            string text = outputElement.Text;

            Assert.AreEqual("Hello Anders", text);
        }
    }