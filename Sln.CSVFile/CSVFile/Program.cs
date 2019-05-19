using CsvHelper;
using System;
using System.IO;

namespace CSVFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = @"E:\Data_\UserInfo.csv";
            //Writing into CSV
            var result = StaticData.GetAllUserInfo();
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteRecords(result);
                writer.Flush();
            }

            Console.WriteLine("List data write into csv successfully!");

            //Reading a CSV File
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader))
            {
                var records = csv.GetRecords<UserInfo>();
                foreach (var item in records)
                {
                    Console.WriteLine(item.ID + "--" + item.FirstName + "--" + item.LastName);
                }
            }

            Console.ReadLine();
        }
    }
}
