# AbsaTechnicalAssessmentTwoWeb

Project Overview
The primary goal of this project is to automate the user addition process within a web application. It uses the following technologies and libraries:

Selenium WebDriver for browser automation.
SpecFlow for behavior-driven development.
Extent Report for generating detailed test reports.
ExcelDataReader for reading data from Excel files (optional).
Prerequisites
Before you start, ensure you have the following software and tools installed:

Visual Studio (or another C# development environment).
NuGet Package Manager for managing dependencies.
WebDrivers (e.g., ChromeDriver) for the web browser you intend to automate.
Project Structure
The project structure is organized as follows:

SeleniumCSharpUserManagement/
│
├── Features/
│   └── Users.feature
│
├── Pages/
│   ├── UsersPage.cs
│
├── StepDefinitions/
│   └── UsersStepDefinitions.cs
│
├── ReusableMethods/
│   ├── Base.cs
│   └── PageActions.cs
│   └── Validations.cs
│ 
│   ├── TestData/
│   └── ExcelReader.cs
│
├── App.config
├── Hooks.cs
├── AbsaTechAssessmentTwo.sln
│
└── README.md
