using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsaTechAssessment.ReusableMethods
{
    public class Validations: PageActions
    {
        public void ValidateTableHeader(string[] expectedValues)
        {
            try
            {
                // Find the table or element that contains the header.
                IWebElement table = driver.FindElement(By.XPath("//table[@class='smart-table table table-striped']"));

                // Iterate through the rows of the table.
                foreach (IWebElement row in table.FindElements(By.XPath("//tr[@class='smart-table-header-row']")))
                {
                    // Locate the cells in the current row.
                    IList<IWebElement> cells = row.FindElements(By.TagName("th"));

                    // Check if the row has at least as many cells as expectedValues.
                    if (cells.Count >= expectedValues.Length)
                    {
                        // Extract the values from the cells and compare with expected values.
                        bool allValuesMatch = true;
                        for (int i = 0; i < expectedValues.Length; i++)
                        {
                            string cellValue = cells[i].Text;
                            if (cellValue != expectedValues[i])
                            {
                                allValuesMatch = false;
                                break;
                            }
                        }

                        if (allValuesMatch)
                        {
                            Console.WriteLine("Table Validated");
                            return; // Table Validated, exit the method.
                        }
                    }
                }

                Console.WriteLine("Table not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ValidateTableRecord(string[] expectedValues)
        {
            try
            {
                // Find the table or element that contains the records.
                IWebElement table = driver.FindElement(By.XPath("//table[@class='smart-table table table-striped']"));

                // Iterate through the rows of the table.
                foreach (IWebElement row in table.FindElements(By.XPath("//tr[@class='smart-table-data-row ng-scope']")))
                {
                    // Locate the cells in the current row.
                    IList<IWebElement> cells = row.FindElements(By.TagName("td"));

                    // Check if the row has at least as many cells as expectedValues.
                    if (cells.Count >= expectedValues.Length)
                    {
                        // Extract the values from the cells and compare with expected values.
                        bool allValuesMatch = true;
                        for (int i = 0; i < expectedValues.Length; i++)
                        {
                            string cellValue = cells[i].Text;
                            if (cellValue != expectedValues[i])
                            {
                                allValuesMatch = false;
                                break;
                            }
                        }

                        if (allValuesMatch)
                        {
                            Console.WriteLine("Record added successfully.");
                            return; // Record found, exit the method.
                        }
                    }
                }

                Console.WriteLine("Record not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
