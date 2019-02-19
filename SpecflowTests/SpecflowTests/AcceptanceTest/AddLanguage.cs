using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest
{
    [Binding]
    public class SpecFlowFeature1Steps : Utils.Start
    {
        [Given(@"I clicked on the Language tab under Profile page")]
        public void GivenIClickedOnTheLanguageTabUnderProfilePage()
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Profile tab
            Driver.driver.FindElement(By.LinkText("Profile")).Click();

            //Click on Languages tab
            Driver.driver.FindElement(By.XPath("//a[contains(text(),'Languages')]")).Click();

        }

        [When(@"I add a new language")]
        public void WhenIAddANewLanguage()
        {
            //Wait
            Thread.Sleep(500);

            //Click on Add New button
            Driver.driver.FindElement(By.XPath("(//div[contains(text(),'Add New')])[1]")).Click();

            //Add Language
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Language']")).SendKeys("English");

            //Choose the language level
            SelectElement chooseLanguageLevel = new SelectElement(driver.FindElement(By.Name("level")));
            chooseLanguageLevel.SelectByText("Fluent");

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();

        }

        [Then(@"that language should be displayed on my listings")]
        public void ThenThatLanguageShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Language");

                Thread.Sleep(1000);
                string ExpectedValue = "English";
                string ActualValue = Driver.driver.FindElement(By.XPath("//td[contains(text(),'English')]")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageAdded");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }


        }


        [When(@"I delete a language")]
        public void WhenIDeleteALanguage()
        {
            //string beforeXpath = "//tbody[";
            //string afterXpath = "]/tr/td[1]";

            //for (int i = 1; i <= 4; i++)
            //{
            //    string language = Driver.driver.FindElement(By.XPath(beforeXpath + i + afterXpath)).Text;
            //    if (language.Contains("Malayalam"))
            //    {
            //        //Delete a language
            //        Driver.driver.FindElement(By.XPath("//tbody[" + i + "]/tr/td[3]/span[2]/i")).Click();
            //    }
            //}
           
            Driver.driver.FindElement(By.XPath("//tbody/tr/td[contains(text(),'English')]//../following-sibling::td[2]/span[2]/i[@class='remove icon']")).Click();
        }

        [Then(@"that language should be removed from the listings")]
        public void ThenThatLanguageShouldBeRemovedFromTheListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Delete a Language");

                Thread.Sleep(1000);
                string beforeXpath = "//tbody[";
                string afterXpath = "]/tr/td[1]";
                string ExpectedValue = "Telugu";
                IList<IWebElement> languageList = driver.FindElements(By.XPath("//table[@class='ui fixed table']/tbody/tr/td[1]"));
                int languageCount = languageList.Count;
                for (int i = 1; i <= languageCount; i++)
                {
                    // string ActualValue = Driver.driver.FindElement(By.XPath("//tbody[1]/tr/td[1]")).Text;
                    string ActualValue = Driver.driver.FindElement(By.XPath(beforeXpath + i + afterXpath)).Text;
                    Thread.Sleep(500);
                    if (ActualValue.Contains("Telugu"))
                    {
                        if (ExpectedValue == ActualValue)
                        {
                            CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Deleted a Language Successfully");
                            SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageDeletedAndNotFound");
                        }
                        else
                            CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                    }

                }

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }


        }
        [When(@"I update a language")]
        public void WhenIUpdateALanguage()
        {
            //Update a language,click the level
            //Driver.driver.FindElement(By.XPath("//tbody[1]/tr/td[3]/span[1]/i")).Click();
            Driver.driver.FindElement(By.XPath("//tbody/tr/td[contains(text(),'Malayalam')]//..//following-sibling::td[2]/span[1]/i[@class='outline write icon']")).Click();

            //Select the new language level
            SelectElement chooseLanguageLevel = new SelectElement(driver.FindElement(By.Name("level")));
            chooseLanguageLevel.SelectByText("Fluent");

            //Click on update
            Driver.driver.FindElement(By.XPath("//input[@value='Update']")).Click();
        }

        [Then(@"that language should be updated in the listings")]
        public void ThenThatLanguageShouldBeUpdatedInTheListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Update a Language");

                Thread.Sleep(1000);
                string ExpectedValue = "Fluent";
                string ActualValue = Driver.driver.FindElement(By.XPath("//tbody/tr/td[contains(text(),'Malayalam')]//..//following-sibling::td[1] ")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Updated a Language Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageLevelUpdated");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }


        [When(@"I add a four new language with (.*) and (.*)")]
        public void WhenIAddAFourNewLanguageWithAnd(string language, string level)
        {
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("(//div[contains(text(),'Add New')])[1]")).Click();

            //Add Language
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Language']")).SendKeys(language);

            //Choose the language level
            SelectElement chooseLanguageLevel = new SelectElement(driver.FindElement(By.Name("level")));
            chooseLanguageLevel.SelectByText(level);

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();

            //Wait
            Thread.Sleep(500);
        }
        [Then(@"those (.*) should be displayed on my listings")]
        public void ThenThoseEnglishShouldBeDisplayedOnMyListings(string language)
        {

            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Language");

                Thread.Sleep(1000);
                IList<IWebElement> rows = driver.FindElements(By.XPath("//table[@class='ui fixed table']/tbody/tr"));
                int rowCount = rows.Count;
                string beforeXpath = "//tbody[";
                string afterXpath = "]/tr/td[1]";
                string ExpectedValue = language;
                // foreach(IWebElement row in rows)
                for (int i = 1; i <= rowCount; i++)
                {
                    // string ActualValue = Driver.driver.FindElement(By.XPath("//tbody[1]/tr/td[1]")).Text;
                    string ActualValue = Driver.driver.FindElement(By.XPath(beforeXpath + i + afterXpath)).Text;
                    Thread.Sleep(500);
                    if (ActualValue.Contains(language))
                    {
                        if (ExpectedValue == ActualValue)
                        {
                            CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");
                            SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageAdded");
                        }
                        else
                            CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                    }

                }
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }

        }

        [When(@"I add a language that already exists with different level")]
        public void WhenIAddALanguageThatAlreadyExistsWithDifferentLevel()
        {
            //Click on Add New button
            Driver.driver.FindElement(By.XPath("(//div[contains(text(),'Add New')])[1]")).Click();

            //Add Language
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Language']")).SendKeys("Tamil");

            //Choose the language level
            SelectElement chooseLanguageLevel = new SelectElement(driver.FindElement(By.Name("level")));
            chooseLanguageLevel.SelectByText("Fluent");

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();
        }

        [Then(@"it should throw an error message")]
        public void ThenItShouldThrowAnErrorMessage()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Language");

                Thread.Sleep(1000);
                string ExpectedValue = "Tamil";
                string ActualValue = Driver.driver.FindElement(By.XPath("//td[contains(text(),'Tamil')]")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Error message pops up");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageNotAdded");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }


        }

        [When(@"I add a language that already exists with same level")]
        public void WhenIAddALanguageThatAlreadyExistsWithSameLevel()
        {
            //Wait
            Thread.Sleep(500);

            //Click on Add New button
            Driver.driver.FindElement(By.XPath("(//div[contains(text(),'Add New')])[1]")).Click();

            //Add Language
            Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Language']")).SendKeys("Tamil");

            //Choose the language level
            SelectElement chooseLanguageLevel = new SelectElement(driver.FindElement(By.Name("level")));
            chooseLanguageLevel.SelectByText("Conversational");

            //Click on Add button
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();
        }

    }
}
