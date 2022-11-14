using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace CSV_Helper_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteClassObj();
            Console.ReadKey();
        }

        static void WriteClassObj()
        {
            var records = new List<Foo>
            {
                new Foo { Id = 1, Name = "one" },
                new Foo { Id = 2, Name = "one" },
                new Foo { Id = 3, Name = "one" },
                new Foo { Id = 4, Name = "one" },
            };
            records.WriteCSV("D:\\CSV\\file.csv");
        }
    }

    internal class Foo
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public static class MyExtensions
    {
        public static void WriteCSV<T>(this IList<T> list,string filePath) where T : class
        {
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(list);
            }
        }
    }
}
