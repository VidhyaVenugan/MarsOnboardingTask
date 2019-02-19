using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class AddDescriptionSteps
    {
        [Given(@"I clicked on description under Profile page")]
        public void GivenIClickedOnDescriptionUnderProfilePage()
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Profile tab
            Driver.driver.FindElement(By.LinkText("Profile")).Click();

            //Click on Write icon

            Driver.driver.FindElement(By.XPath("//h3/span/i")).Click();
        }
        
        [When(@"I enter a brief decription about myself")]
        public void WhenIEnterABriefDecriptionAboutMyself()
        {
            //Wait
            Thread.Sleep(500);

            //Clear the description box
            Driver.driver.FindElement(By.XPath("//textarea[@name='value']")).Clear();

            //Enter the description
            Driver.driver.FindElement(By.Name("value")).SendKeys("I have 5 years of work experience working with TCS India.I worked in Oracle Financials and later moved into Recruitment.");

            //Click Save
            Driver.driver.FindElement(By.XPath("(//button[contains(text(),'Save')])[2]")).Click();
        }
        
        [Then(@"the description should be displayed")]
        public void ThenTheDescriptionShouldBeDisplayed()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add Description");

                Thread.Sleep(1000);
                string ExpectedValue = "I have 5 years of work experience working with TCS India.I worked in Oracle Financials and later moved into Recruitment.";
                string ActualValue = Driver.driver.FindElement(By.XPath("//span[contains(text(),'TCS')]")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added Description Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "DescriptionAdded");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }
    }
}
