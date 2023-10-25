using Microsoft.VisualStudio.TestTools.UnitTesting;
using static csvimport.Program;
using System.Collections.Generic;
using System.Linq;

namespace ProjectTests
{
    [TestClass]
    public class UnitTest1
    {

        public const string FILE_PATH = @"C:\Users\User\Desktop\TAFE 2023\Wednesdays-Programming\OOP_Workshops\Week 12\Week12_2023\CSV_Week12_Test\CSV_Helper_Example_Code\CSV_Helper_Example_Code\some-data.csv";
        public List<CsvMap> importedRecords = CsvImporter.ImportSomeRecords(FILE_PATH).ToList();


        /// <summary>
        /// Check no empty records
        /// </summary>
        [TestMethod]
        public void TestRecordsAreNotEmpty()
        {
            Assert.IsNotNull(importedRecords);//This is now part of our control data becuase of the the green check
        }

        [TestMethod]
        public void SaveTestCheck()
        {
            //Act
            //Set my saved record

            //Arrange
            //Grab the record I just saved

            //Assert
            //If the record save -> if nullt or empty

        }
    }
}
