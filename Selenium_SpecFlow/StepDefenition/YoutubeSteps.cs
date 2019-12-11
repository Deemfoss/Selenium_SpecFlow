using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlow_Selenium.StepDefenition
{
    [Binding]
    public class YoutubeSteps
    {
        private string searchKeyWords;
        private ChromeDriver chromeDriver;
        public YoutubeSteps()
        {
            chromeDriver = new ChromeDriver();
        }

        [Given(@"I have navigated to YouTube website")]
        public void GivenIHaveNavigatedToYouTubeWebsite()
        {
            chromeDriver.Navigate().GoToUrl("https://www.youtube.com/");
            Assert.IsTrue(chromeDriver.Title.ToLower().Contains("youtube"));
        }

        [Given(@"I have entered (.*) as search keywords")]
        public void GivenIHaveEnteredNBAAsSearchKeywords(string searchString)
        {
            this.searchKeyWords = searchString.ToLower();
            var searchInput = chromeDriver.FindElementById("search");
            var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(3));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("search")));
            searchInput.SendKeys(searchKeyWords);
        }

        [When(@"I press the search button")]
        public void WhenIPressTheSearchButton()
        {
            var searchButton = chromeDriver.FindElementById("search-icon-legacy");
            searchButton.Click();
        }

        [Then(@"I should be navigate to search result page")]
        public void ThenIShouldBeNavigateToSearchResultPage()
        {
            Thread.Sleep(2000);
            Assert.IsTrue(chromeDriver.Url.ToLower().Contains(searchKeyWords));
            Assert.IsTrue(chromeDriver.Title.ToLower().Contains(searchKeyWords));
        }

        public void Dispose()
        {
            if (chromeDriver != null)
            {
                chromeDriver.Dispose();
                chromeDriver = null;
            }
        }
    }
}
