using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace SeleniumApplication.Tests
{
    public class LoginLinkTest
    {
        IWebDriver Browser;

        [SetUp]
        public void Init()
        {
            Browser = new ChromeDriver();
            Browser.Url = "http://www.justanswer.co.uk";
        }

        [Test(Description ="Test clicking 'Login' link on the page redirects to correct page and login button is displayed there")]
        public void ClickLoginLink()
        {
            //Arrange
            IWebElement loginLink = Browser.FindElement(By.Id("JA_HeaderLogin"));

            //Act
            loginLink.Click();

            //Assert
            IWebElement expectedLoginButton = Browser.FindElement(By.Id("ctl00_BodyContent_btnLogin"));
            Assert.AreEqual("https://secure.justanswer.co.uk/login.aspx", Browser.Url);
            Assert.IsTrue(expectedLoginButton.Displayed);
        }

        [TearDown]
        public void TearDown()
        {
            Browser.Close();
        }
    }
}
