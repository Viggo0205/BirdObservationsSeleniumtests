using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;



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

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void TestMethod1()
        {
            _driver.Navigate().GoToUrl("file:///C:/Users/victor/Desktop/EksamensaetE/WebappEksamenSaetE/Index.html");
            Assert.AreEqual("Bird Observations", _driver.Title);

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            IWebElement inputElement = _driver.FindElement(By.Id("inputName"));
            inputElement.SendKeys("TestBird");
            IWebElement inputElement2 = _driver.FindElement(By.Id("inputHowMany"));
            inputElement2.SendKeys("1337");
            IWebElement buttonCreateElement = _driver.FindElement(By.Id("createButton"));
            buttonCreateElement.Click();
            IWebElement outputMessage = wait.Until(x => x.FindElement(By.Id("addMessage")));
            Assert.AreEqual("response 201 Created", outputMessage.Text);

            ReadOnlyCollection<IWebElement> listElements2 = _driver.FindElements(By.TagName("tr"));

            // Test af DELETE
            IWebElement deleteInput = _driver.FindElement(By.Id("deleteInput"));
            deleteInput.SendKeys((listElements2[5]).Text.Split(" ")[0]);
            IWebElement deleteButton = _driver.FindElement(By.Id("deleteButton"));
            deleteButton.Click();
            IWebElement deleteMessage = wait.Until(x => x.FindElement(By.Id("deleteMessage")));
            Assert.AreEqual("200 OK", deleteMessage.Text);


        }
    }
}