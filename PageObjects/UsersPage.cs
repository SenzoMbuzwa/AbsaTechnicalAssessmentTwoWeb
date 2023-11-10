using AbsaTechAssessment.ReusableMethods;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsaTechAssessment.PageObjects
{
    public class UsersPage : Validations
    {
        #region WebElements
        //users page
        private By AddUserButton = By.XPath("//button[@type='add']");
        private By SearchUserTextbox = By.XPath("//input[@placeholder='Search']");

        //add user
        private By AddUserPopUpTitle = By.XPath("//div[@class='modal-header']/h3");
        private By FirstNameTextbox = By.XPath("//input[@name='FirstName']");
        private By LastNameTextbox = By.XPath("//input[@name='LastName']");
        private By UserNameTextbox = By.XPath("//input[@name='UserName']");
        private By PasswordTextbox = By.XPath("//input[@name='Password']");
        private By CompanyAAARadioButton = By.XPath("(//input[@name='optionsRadios'])[1]");
        private By CompanyBBBRadioButton = By.XPath("(//input[@name='optionsRadios'])[2]");
        private By RoleDropdown = By.XPath("//select[@name='RoleId']");
        private By EmailTextbox = By.XPath("//input[@name='Email']");
        private By CellPhoneTextbox = By.XPath("//input[@name='Mobilephone']");
        private By CloseButton = By.XPath("//button[@class='btn btn-danger' and text()='Close']");
        private By SaveButton = By.XPath("//button[@class='btn btn-success' and text()='Save']");
        #endregion

        #region Actions
        public void NavigateToTestSite(string browser)
        {
            OpenBrowser(browser);
        }
        public void AddUser(string fName, string lName, string username, string password, string customer, string role, string email, string cell)
        {
            Click(AddUserButton);

            WaitUntilElementIsVisible(AddUserPopUpTitle, 2);
            Assert.AreEqual("Add User", GetElementText(AddUserPopUpTitle));

            EnterText(FirstNameTextbox, fName);

            EnterText(LastNameTextbox, lName);

            EnterText(UserNameTextbox, username);

            EnterText(PasswordTextbox, password);

            switch (customer)
            {
                case "Company AAA":
                    Click(CompanyAAARadioButton);
                    break;

                case "Company BBB":
                    Click(CompanyBBBRadioButton);
                    break;
            }

            DropdownSelect(RoleDropdown, role);

            EnterText(EmailTextbox, email);

            EnterText(CellPhoneTextbox, cell);

            Click(SaveButton);
        }

        public void ValidateUsersTableHeader()
        {
            string[] expectedResults = { "First Name", "Last Name", "User Name", "Customer", "Role", "E-mail", "Cell Phone", "Locked" };
            ValidateTableHeader(expectedResults);
        }

        public void ValidateUserInTable(string fName, string lName, string username, string customer, string role, string email, string cell)
        {
            string[] expectedResults = { fName, lName, username, customer, role, email, cell};
            ValidateTableRecord(expectedResults);
        }
        #endregion
    }
}
