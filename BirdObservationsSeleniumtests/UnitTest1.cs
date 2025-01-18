using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;



namespace BirdObservationsSeleniumtests
{
    [TestClass]
    public class UnitTest1
    {
        private static readonly string DriverDirectory = "C:\\webDrivers";
        private static IWebDriver _driver;
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new ChromeDriver(DriverDirectory);
           
        }
        [TestMethod]
        public void TestMethod1()
        {
            _driver.Navigate().GoToUrl("file:///C:/Users/victor/Desktop/EksamensaetE/WebappEksamenSaetE/Index.html");
            Assert.AreEqual("Bird Observations", _driver.Title);
        }
    }
}