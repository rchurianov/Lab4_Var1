using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab3_Var1;

namespace UnitTestProject
{
    [TestClass]
    public class Test_GenericTestCollections
    {
        [TestMethod]
        public void Test_Constructor()
        {
            GenericTestCollections<Person, Student> gtc_ps = new GenericTestCollections<Person, Student>(6, person_student_pair_generator);
            Console.WriteLine(gtc_ps.ToString());
        }

        private KeyValuePair<Person, Student> person_student_pair_generator(int number)
        {
            Person key = new Person("Doug " + number, "Spaulding " + number, new DateTime(1930, 12, 20));
            Student value = new Student(key, Education.Bachelor, 133 + number);
            return new KeyValuePair<Person, Student>(key, value);
        }

        [TestMethod]
        public void Test_TimeComparison()
        {
            GenericTestCollections<Person, Student> gtc_ps = new GenericTestCollections<Person, Student>(1000000, person_student_pair_generator);
            int[] results = gtc_ps.TimeComparison();

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
