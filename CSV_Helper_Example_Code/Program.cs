using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;


namespace csvimport
{
    /// <summary>
    /// Simple CSV Helper Example
    /// This console App showcases how to map CSV data using csv helper
    /// We read in our csv data values using this mapped logic
    /// This app checks to see if the person is born in the 2000's or the 90's
    /// </summary>

    public class Program
    {
        public class CsvImporter
        {
            public static List<CsvMap> ImportSomeRecords(string fileName)
            {
                var myRecords = new List<CsvMap>();
                using (var reader = new StreamReader(fileName))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        csv.Context.RegisterClassMap<CsvMapMap>();
                     
                        int currentID;
                        string name;
                        string gender;
                        int birthdayYear;
                        int age;

                        //Start Reading Csv File
                        csv.Read();
                        //Skip Header
                        csv.ReadHeader();

                        while (csv.Read())
                        {
                            currentID = csv.GetField<int>(0);
                            name = csv.GetField<string>(1);
                            gender = csv.GetField<string>(2);
                            birthdayYear = csv.GetField<int>(3);
                            age = csv.GetField<int>(4);
                            myRecords.Add(CreateRecord(currentID, name, gender, birthdayYear, age));

                        }

                    }

                }
                return myRecords;
            }

            public static CsvMap CreateRecord(int id, string name, string gender, int bDayYear, int age)
            {
                CsvMap record = new CsvMap();

                record.id = id;
                record.name = name;
                record.gender = gender;
                record.birthdayYear = bDayYear;
                record.age = age;

                return record;
            }
        }

        public class CsvMap
        {
            public int id { get; set; }
            public string name { get; set; }
            public string gender { get; set; }
            public int birthdayYear { get; set; }
            public int age { get; set; } // IS THIS NEEDED? -> Data Integirty -> Remove later? V1
        }

        public sealed class CsvMapMap : ClassMap<CsvMap>
        {
            public CsvMapMap()
            {
                Map(m => m.id).Index(0);
                Map(m => m.name).Index(1);
                Map(m => m.gender).Index(2);
                Map(m => m.birthdayYear).Index(3);
                Map(m => m.age).Index(4);
            }
        }

        //ADD AGE CALC HERE
        static void Main(string[] args)
        {
            var fileName = @"C:\Users\User\Desktop\TAFE 2023\Wednesdays-Programming\OOP_Workshops\Week 12\Week12_2023\CSV_Week12_Test_UPDATED\CSV_Helper_Example_Code\CSV_Helper_Example_Code\some-data.csv";


            List<CsvMap> importedRecords = CsvImporter.ImportSomeRecords(fileName);


            var result = FuncTests.CheckBirthYear(importedRecords);

            foreach (var record in result) {
                Console.WriteLine("Record ID: " + record.id);
                Console.WriteLine("Name: " + record.name);
                Console.WriteLine("Gender: " + record.gender);
                Console.WriteLine("Born in the 2000's : " + record.birthdayYear);
                Console.WriteLine("Age : " + record.age);
                Console.WriteLine("\n");
            }


            Console.ReadLine();
        }


        //METHOD for returning user age
        //Current year data
        //Compare current to bday year of import records 
        //Return the compare 
        //VERSION 1

        //VERSION 2
        //BASED off my test I updated my CSV file

        //Console.WriteLine("Born in the 2000's : " + record.birthdayYear);

        //foreach (CsvMap record in importedRecords)
        //{
        //    Console.WriteLine("Record ID: " + record.id);
        //    Console.WriteLine("Name: " + record.name);
        //    Console.WriteLine("Gender: " + record.gender);
        //    if(record.birthdayYear >= 2000)
        //    {
        //        Console.WriteLine("Born in the 2000's : " + record.birthdayYear);
        //    }
        //    else
        //    {
        //        Console.WriteLine("Born in the 90's : " + record.birthdayYear);
        //    }
        //    Console.WriteLine("Age : " + record.age);
        //    Console.WriteLine("\n");
        //}

        /// <summary>
        /// Its purpose is the start of a functional series of tests on my csv data
        /// </summary>
        public class FuncTests
        {
            #region FUNCTEST
            public static List<CsvMap> CheckBirthYear(List<CsvMap> passRecords)
            {
                //bool is2000 = false;
                //CsvMap temperson = new CsvMap();
                List<CsvMap> records = new List<CsvMap>();

                foreach (CsvMap recordCheck in passRecords)
                {

                    if (recordCheck.birthdayYear >= 2000)
                    {
                        records.Add(recordCheck);
                    }
                    //else
                    //{
                    //    Console.WriteLine($"{recordCheck.name} was not born in the 2000's");
                    //}

                }

                return records;
            }

            //Check id orders are correct

            //Check null values of names

            //etc..
            #endregion
        }

    }

}
