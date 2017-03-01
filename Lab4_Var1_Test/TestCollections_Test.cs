using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab3_Var1;

namespace UnitTestProject
{
    [TestClass]
    public class TestCollections_Test
    {
        [TestMethod]
        public void Console_Test()
        {
            TestCollections tc = new TestCollections(1000000);
            int[] results = tc.TimeComparison();
        /* [0] - search time for the first element in List<Person>
         * [1] - search time for the central element in List<Person>
         * [2] - search time for the last element in List<Person>
         * [3] - search time for a non-existent element in List<Person>
         * [4] - search time for the first element in List<string>
         * [5] - search time for the central element in List<string>
         * [6] - search time for the last element in List<string>
         * [7] - search time for the non-existent element in List<string>
         * [8] - search time by key for the first element in Dictionary<Person, Student>
         * [9] - search time by key for the central element in Dictionary<Person, Student>
         * [10] - search time by key for the last element in Dictionary<Person, Student>
         * [11] - search time by key for a non-existent element in Dictionary<Person, Student>
         * [12] - search time by key for the first element in Dictionary<string, Student>
         * [13] - search time by key for the central element in Dictionary<string, Student>
         * [14] - search time by key for the last element in Dictionary<string, Student>
         * [15] - search time by key for a non-existent element in Dictionary<string, Student>
         * [16] - search time by value for the first element in Dictionary<Person, Student>
         * [17] - search time by value for the central element in Dictionary<Person, Student>
         * [18] - search time by value for the last element in Dictionary<Person, Student>
         * [19] - search time by value for a non-existent element in Dictionary<Person, Student>
         */
            Console.WriteLine("{0} - search time for the first element in List<Person>", results[0]);
            Console.WriteLine("{0} - search time for the central element in List<Person>", results[1]);
            Console.WriteLine("{0} - search time for the last element in List<Person>", results[2]);
            Console.WriteLine("{0} - search time for a non-existent element in List<Person>", results[3]);
            Console.WriteLine("{0} - search time for the first element in List<string>", results[4]);
            Console.WriteLine("{0} - search time for the central element in List<string>", results[5]);
            Console.WriteLine("{0} - search time for the last element in List<string>", results[6]);
            Console.WriteLine("{0} - search time for the non-existent element in List<string>", results[7]);
            Console.WriteLine("{0} - search time by key for the first element in Dictionary<Person, Student>", results[8]);
            Console.WriteLine("{0} - search time by key for the central element in Dictionary<Person, Student>", results[9]);
            Console.WriteLine("{0} - search time by key for the last element in Dictionary<Person, Student>", results[10]);
            Console.WriteLine("{0} - search time by key for a non-existent element in Dictionary<Person, Student>", results[11]);
            Console.WriteLine("{0} - search time by key for the first element in Dictionary<string, Student>", results[12]);
            Console.WriteLine("{0} - search time by key for the central element in Dictionary<string, Student>", results[13]);
            Console.WriteLine("{0} - search time by key for the last element in Dictionary<string, Student>", results[14]);
            Console.WriteLine("{0} - search time by key for a non-existent element in Dictionary<string, Student>", results[15]);
            Console.WriteLine("{0} - search time by value for the first element in Dictionary<Person, Student>", results[16]);
            Console.WriteLine("{0} - search time by value for the central element in Dictionary<Person, Student>", results[17]);
            Console.WriteLine("{0} - search time by value for the last element in Dictionary<Person, Student>", results[18]);
            Console.WriteLine("{0} - search time by value for a non-existent element in Dictionary<Person, Student>", results[19]);
        }
    }
}
