using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsaTechAssessment.TestData
{
    public class ExcelReader
    {
        public static IDictionary<string, IExcelDataReader> _cache;
        private static FileStream stream;
        private static IExcelDataReader reader;

        static ExcelReader()
        {
            _cache = new Dictionary<string, IExcelDataReader>();
        }

        public static string GetCellData(string sheetName, int row, int column)
        {
            if(_cache.ContainsKey(sheetName))
            {
                reader = _cache[sheetName];
            }
            else
            {
                stream = new FileStream(@"../../TestData/TestDataFile.xlsx", FileMode.Open, FileAccess.Read);
                reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                _cache.Add(sheetName, reader);
            }

            DataTable table = reader.AsDataSet().Tables[sheetName];
            return table.Rows[row][column].ToString();
        }
    }
}
