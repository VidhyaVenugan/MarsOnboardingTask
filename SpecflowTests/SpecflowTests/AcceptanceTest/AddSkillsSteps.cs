using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class AddSkillsSteps
    {
        [Given(@"I clicked on the skills tab under Profile page")]
        public void GivenIClickedOnTheSkillsTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Profile tab
            Driver.driver.FindElement(By.LinkText("Profile")).Click();

            //Click on Skills tab
            Driver.driver.FindElement(By.XPath("//a[contains(text(),'Skills')]")).Click();

        }
        
        [When(@"I add a new skill")]
        public void WhenIAddANewSkill()
        {
            //Wait
            Thread.Sleep(1500);

            //Click on Add New button
            Driver.driver.FindElement(By.XPath("(//div[contains(text(),'Add New')])[2]")).Click();

            //Add Skill
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Skill']")).SendKeys("Testing");

            //Select the skill level
            SelectElement chooseSkillLevel = new SelectElement(Driver.driver.FindElement(By.Name("level")));
            chooseSkillLevel.SelectByText("Beginner");

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();

        }

        [Then(@"that skill should be displayed on my listings")]
        public void ThenThatSkillShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Skill");

                Thread.Sleep(1000);
                string ExpectedValue = "Testing";
                string ActualValue = Driver.driver.FindElement(By.XPath("//td[contains(text(),'Testing')]")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Skill Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "SkillAdded");
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
