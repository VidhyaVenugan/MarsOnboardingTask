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
    public class AddEducationSteps
    {
        [Given(@"I clicked on the education tab under Profile page")]
        public void GivenIClickedOnTheEducationTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Profile tab
            Driver.driver.FindElement(By.LinkText("Profile")).Click();

            //Click on Skills tab
            Driver.driver.FindElement(By.XPath("//a[contains(text(),'Education')]")).Click();

        }

        [When(@"I add educational background details")]
        public void WhenIAddEducationalBackgroundDetails()
        {
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("(//div[contains(text(),'Add New')])[3]")).Click();

            //Add Educational Bacground Details
            //Add University Name
            Driver.driver.FindElement(By.Name("instituteName")).SendKeys("Amrita School Of Engineering");

            //Select Country of College
            SelectElement selectCountry = new SelectElement(Driver.driver.FindElement(By.Name("country")));
            selectCountry.SelectByText("India");

            //Select the Degree Title
            SelectElement selectDegreeTitle = new SelectElement(Driver.driver.FindElement(By.Name("title")));
            selectDegreeTitle.SelectByText("B.Tech");

            //Add the Degree Name
            Driver.driver.FindElement(By.Name("degree")).SendKeys("Computer Science Engineering");

            //Select the year of Graduation
            SelectElement selectYear = new SelectElement(Driver.driver.FindElement(By.Name("yearOfGraduation")));
            selectYear.SelectByText("2008");

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();
        }

        [Then(@"that educational details should be displayed on my listings")]
        public void ThenThatEducationalDetailsShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add Education Details");

                Thread.Sleep(1000);
                string ExpectedValue = "Amrita School Of Engineering";
                string ActualValue = Driver.driver.FindElement(By.XPath("//td[contains(text(),'Amrita')]")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added Educational Details Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "EducationAdded");
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
