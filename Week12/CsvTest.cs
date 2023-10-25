using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using static csvimport.Program;

namespace Week12
{
    /// <summary>
    /// CSV Unit Test
    /// List of each test
    /// White box testing becuase we know what the app code is/we wrote it -> XML not as important for whitebox
    /// Black box testing is unit testing but we don't know anything about the appliction code -> Essential for black box
    /// </summary>
    [TestClass]
    public class CsvTest
    {
        //IF THIS WAS NUnit I would have setup test.
        public const string FILE_PATH = @"C:\Users\User\Desktop\TAFE 2023\Wednesdays-Programming\OOP_Workshops\Week 12\Week12_2023\CSV_Week12_Test_UPDATED\CSV_Helper_Example_Code\CSV_Helper_Example_Code\some-data.csv";
        
        //TEST DATA
        public List<CsvMap> importedRecords = CsvImporter.ImportSomeRecords(FILE_PATH).ToList();

        #region VALIDATE DATA TEST
        /// <summary>
        /// Check no empty records
        /// </summary>
        [TestMethod]
        public void TestRecordsAreNotEmpty()
        {
            Assert.IsNotNull(importedRecords);//This is now part of our control data becuase of the the green check
        }

        /// <summary>
        /// First Entry Check
        /// </summary>
        [TestMethod]
        public void TestFirstEntry()
        {
            //Control
            //1,James,Male,1990,31
            var controlData = new CsvMap();
            controlData.id = 1;
            controlData.name = "James";
            controlData.gender = "Male";
            controlData.birthdayYear = 1990;
            controlData.age = 31;

            //Actual vs Control - Control vs Actual
            Assert.AreEqual(importedRecords[0].id, controlData.id);
            Assert.AreEqual(importedRecords[0].name, controlData.name);
            Assert.AreEqual(importedRecords[0].gender, controlData.gender);
            Assert.AreEqual(importedRecords[0].birthdayYear, controlData.birthdayYear);
            Assert.AreEqual(importedRecords[0].age, controlData.age);

            //Imported records data is now valid.
            //Last entry = all data valid
            //Sanitisation BUT this should be its own test maybe
            //Is my data actually correct -> answer is the year is out
            //Set up a control of ALL data elements BUT last entry does this more effectively
        }

        /// <summary>
        /// Last Entry check test method
        /// </summary>
        [TestMethod]
        public void TestLastEntry()
        {
            //Control
            //5,Maddie,Female,1999,22
            var controlData = new CsvMap();
            controlData.id = 5;
            controlData.name = "Maddie";
            controlData.gender = "Female";
            controlData.birthdayYear = 1999;
            controlData.age = 22;

            //Actual vs Control - Control vs Actual
            Assert.AreEqual(importedRecords[4].id, controlData.id);
            Assert.AreEqual(importedRecords[4].name, controlData.name);
            Assert.AreEqual(importedRecords[4].gender, controlData.gender);
            Assert.AreEqual(importedRecords[4].birthdayYear, controlData.birthdayYear);
            Assert.AreEqual(importedRecords[4].age, controlData.age);

        }
        #endregion

        /// <summary>
        /// CHECK AGE TEST
        /// Nothing is syntax wrong and I am getting a green check - VERSON 1
        /// BUT i notice the year is out. So what do i do? 
        /// NOTE this so that someone updates BEFORE the next round of testing

        /// VERSION 2 OR UPDATED TEST
        /// Manually change this OR you can do the calculation in code and update the CSV
        /// Data Integrity we could calculate agg off birthday year -> Don't store age
        /// </summary>
        [TestMethod]
        public void TestRecordAge() 
        { 
            //ADD AGE LOGIC TEST HERE
            //ACT

            //VERSION 1
            //LOGIC is correct is the important thing
            //ARRANGE

            //VERSION 2
            //IF OUR DATA is out OR has incorrect values etc -> thats inbetween this test and the next one
            //ASSERT
        }

        //DATA DOES NOT SCALE 
        //THEREFORE AGE should be REMOVED as a RECORD
        //THEREFORE AGE should be DYNAMIC and recorded as the difference of the CURRENT year
        //          vs the BIRTHYEAR
        //NEW VERSION DOES THIS AND UPDATES YOUR CODE WITH THE VALID DATA FOR AGE

        //Scalability tests etc....


        [TestMethod]
        public void TestIfBorn2000s()
        {
            //ACT
            //Control 1
            //2,Alice,Female,2002,19
            var controlData = new CsvMap();
            controlData.id = 2;
            controlData.name = "Alice";
            controlData.gender = "Female";
            controlData.birthdayYear = 2002;
            controlData.age = 19;

            //Control 2
            //4,Bob,Male,2000,21
            var controlData2 = new CsvMap();
            controlData2.id = 4;
            controlData2.name = "Bob";
            controlData2.gender = "Male";
            controlData2.birthdayYear = 2000;
            controlData2.age = 21;

            List<CsvMap> controlRecord = new List<CsvMap>();

            controlRecord.Add(controlData);
            controlRecord.Add(controlData2);


            //ARRANGE
            List<CsvMap> actualRecords = FuncTests.CheckBirthYear(importedRecords); //2 records in this list

            //ASSERT
            //EQUAL SIZE
            Assert.AreEqual(controlRecord.Count, actualRecords.Count);

            int count = 0;
            //SAME OBJECT PROP VALUES
            foreach (var record in actualRecords)
            {
                if(record.id == controlRecord[count].id)
                {
                    Assert.AreEqual(controlRecord[count].id, record.id);
                    Assert.AreEqual(controlRecord[count].name, record.name);
                    Assert.AreEqual(controlRecord[count].birthdayYear, record.birthdayYear);
                    Assert.AreEqual(controlRecord[count].gender, record.gender);
                    Assert.AreEqual(controlRecord[count].age, record.age);
                    count++; 
                }
            }

        }
    }
}
