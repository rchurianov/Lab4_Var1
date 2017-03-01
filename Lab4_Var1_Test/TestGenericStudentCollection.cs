using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab3_Var1;

namespace UnitTestProject
{
    [TestClass]
    public class TestGenericStudentCollection
    {
        [TestMethod]
        public void Test_Constructor()
        {
            GenericStudentCollection<Person> gsc_p = new GenericStudentCollection<Person>(make_person_key);
            gsc_p.AddDefaults();
            Console.WriteLine(gsc_p.ToString());
            Console.WriteLine("\n**********\n");
            Console.WriteLine(gsc_p.ToShortString());
        }

        /* Instance of GenericKeySelector delegate.
         * Returns key of type Person. */
        private Person make_person_key(Student stud)
        {
            return stud.Passport_Data;
        }

        /* Instance of GenericKeySelector delegate.
         * Returns key of type string.
         */
        private string make_string_key(Student stud)
        {
            return stud.Passport_Data.ToString();
        }
    }
}
