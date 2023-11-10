using AbsaTechAssessment.PageObjects;
using ExcelDataReader;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;
using AbsaTechAssessment.TestData;

namespace AbsaTechAssessment.StepDefinitions
{
    [Binding]
    public class UsersStepDefinitions
    {
        UsersPage up = new UsersPage();
        string sheetName = "Users";

        [Given(@"that you are on the users page on the (.*) browser")]
        public void GivenThatYouAreOnTheUsersPageOnThe(string browser)
        {
            up.NavigateToTestSite(browser);
        }

        [When(@"you add new users and verify that the users has been successfully added to the list")]
        public void WhenYouAddNewUsersAndVerifyThatTheUsersHasBeenSuccessfullyAddedToTheList()
        {
            int currentRow = 1;

            while (true)
            {
                string firstname = ExcelReader.GetCellData(sheetName, currentRow, 0);
                string lastname = ExcelReader.GetCellData(sheetName, currentRow, 1);
                string username = ExcelReader.GetCellData(sheetName, currentRow, 2);
                string password = ExcelReader.GetCellData(sheetName, currentRow, 3);
                string customer = ExcelReader.GetCellData(sheetName, currentRow, 4);
                string role = ExcelReader.GetCellData(sheetName, currentRow, 5);
                string email = ExcelReader.GetCellData(sheetName, currentRow, 6);
                string cell = ExcelReader.GetCellData(sheetName, currentRow, 7);

                if (string.IsNullOrEmpty(firstname))
                {
                    // Exit the loop when there are no more records
                    break;
                }

                up.AddUser(firstname, lastname, username, password, customer, role, email, cell);

                up.ValidateUserInTable(firstname, lastname, username, customer, role, email, cell);

                // Increment the row counter
                currentRow++;
            }

            // Close the ExcelDataReader and any open files when done
            foreach (var kvp in ExcelReader._cache)
            {
                kvp.Value.Close();
            }
        }
    }
}
