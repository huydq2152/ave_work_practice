using System;
using System.Collections.Generic;
using Contract;
using AlexDataAnalyser;
namespace CSharpBasic
{
    class Program
    {
        static void Main(string[] args)
        {
            var analyzers = new List<IDataAnalyser> { new AlexAnalyser(@"..\..\..\..\Data") };
            foreach (var analyzer in analyzers)
            {
                Console.WriteLine($"Author is {analyzer.Author} ");
                analyzer.GetTopTenStrings(analyzer.Path);
            }

            Console.WriteLine("Press any ken to exit.");
            Console.ReadKey();
        }
    }
}
