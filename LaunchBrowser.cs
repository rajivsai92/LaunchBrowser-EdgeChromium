using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Microsoft.Edge.SeleniumTools;
namespace UnitTestProject1
{
    [TestClass]
   public class UnitTest1
    {

        // Used to launch Microsoft Edge browser using remotewebdriver and
        // 9515 is the port number of EdgeWebdriver  
        private string RemoteWebDriverURI = "http://127.0.0.1:9515";

        private string Username = "";
        private string Password = "";
        private string ApplicationURL = "https://www.google.com/";
        private string EdgeDriverPath= @"C:\UnitTestProject1\packages";


        [TestMethod]
        public void LaunchEdgeBrowserUsingRemoteWebdriver()
        {
            //Edge option is from 'Microsoft.Edge.SeleniumTools'
            var optionsEdge = new EdgeOptions();
            optionsEdge.UseChromium = true;  
            
            SwitchUser(Username, Password);  
            
            IWebDriver driver = new RemoteWebDriver(new Uri(RemoteWebDriverURI), optionsEdge);
            driver.Navigate().GoToUrl(ApplicationURL);
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void LaunchEdgeBrowser()
        {
            //Edge option and Edgedriver are from namespace 'Microsoft.Edge.SeleniumTools'
            var optionsEdge = new EdgeOptions();
            optionsEdge.UseChromium = true;

            // C:\UnitTestProject1\packages is the path where Edge driver exists
            IWebDriver driver = new EdgeDriver(@"C:\UnitTestProject1\packages", optionsEdge);
            driver.Navigate().GoToUrl(ApplicationURL);
            driver.Manage().Window.Maximize();
        }

        /// <summary>
        ///  SwitchUser - is used to launch edge driver with application credentials , it looks like a console window with port number
        /// </summary>
        /// <param name="username">login Username </param>
        /// <param name="password">login passward </param>
        /// <param name="domainname">if the username contains domain then we need to use Domain variable in definition ex: test/rajivsai92 - here test is domainname</param>
        /// <param name="workingdirectory">working directory for the process to start ex: C:, D: etc..</param>
        /// <param name="EdgeDriverPath">path of Edge driver including driver name like --"C:\UnitTestProject1\packages\msedgedriver.exe</param>
        public void SwitchUser(String username, String password, string domainname="test", string workingdirectory="C:", string EdgeDriverPath=@"C:\UnitTestProject1\packages\msedgedriver.exe")
        {
            var secure = new System.Security.SecureString();
            foreach (char c in password)
            {secure.AppendChar(c);}

            var SwitchUser = new ProcessStartInfo()
            {
                UserName = username,
                Password = secure,                
                Domain = domainname,
                WorkingDirectory = workingdirectory,                
                FileName = EdgeDriverPath,
                UseShellExecute = false,
                LoadUserProfile = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            Process.Start(SwitchUser);
        }




      
    }
}
