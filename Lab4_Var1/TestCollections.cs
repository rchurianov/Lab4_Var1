using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Var1
{
    public class TestCollections
    {
        private List<Person> person_list;
        private List<string> list_of_strings;
        private Dictionary<Person, Student> person_student_dict;
        private Dictionary<string, Student> student_dict;

        /* Constuctor to create collections with specified number of items */
        public TestCollections(int length)
        {
            person_list = new List<Person>();
            list_of_strings = new List<string>();
            person_student_dict = new Dictionary<Person, Student>();
            student_dict = new Dictionary<string, Student>();

            for (int i = 0; i < length; i++ )
            {
                Person tmp_person_1 = new Person("Doug " + i, "Spaulding " + i, new DateTime((long)i));
                Person tmp_person_2 = new Person("Doug " + i, "Spaulding " + i, new DateTime((long)i));
                Student tmp_student_1 = new Student(tmp_person_1, Education.Bachelor, 333);
                Student tmp_student_2 = new Student(tmp_person_2, Education.Bachelor, 333);

                /* adding equal but different objects to different collections */
                person_list.Add(tmp_person_1);
                list_of_strings.Add(tmp_person_1.ToString());
                person_student_dict.Add(tmp_person_2, tmp_student_2);
                student_dict.Add(tmp_person_1.ToString(), tmp_student_1);
            }
        }

        /* Static method that returns a Student object (reference?)
         * and is used to populate collections.
         */
        public static Student MakeStudent(int number)
        {
            return new Student(new Person("Doug " + number, "Spaulding " + number, new DateTime((long)number)), Education.Bachelor, 333);
        }

        /* Method to get search times for collections.
         * Method returns an array of integers. Each element in the array is
         * search time in ticks for a specific element in one of collections.
         * [output_array_index] - description
         * [0] - search time for the first element in List<Person>
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
        public int[] TimeComparison()
        {
            int[] results = new int[20];

            /* Searching for the first element in List<Person> person_list.
             * Measuring search time. */
            Person person_to_look_for = new Person("Doug " + 0, "Spaulding " + 0, new DateTime((long)0));
            int start_time = Environment.TickCount;
            bool b = this.person_list.Contains(person_to_look_for);
            results[0] = Environment.TickCount - start_time;
            if (!b)
                Console.WriteLine("Could not find first element in person_list.");
            
            /* Searching for the central element in List<Person> person_list.
             * Measuring search time. */
            person_to_look_for.Name = "Doug " + (person_list.Count / 2);
            person_to_look_for.Last_Name = "Spaulding " + (person_list.Count / 2);
            person_to_look_for.Birth_Date = new DateTime((long)(person_list.Count / 2));
            start_time = Environment.TickCount;
            b = this.person_list.Contains(person_to_look_for);
            results[1] = Environment.TickCount - start_time;
            if (!b)
                Console.WriteLine("Could not find central element in person_list.");

            /* Searching for the last element in List<Person> collection.
             * Measuring search time.
             */
            person_to_look_for.Name = "Doug " + (person_list.Count - 1);
            person_to_look_for.Last_Name = "Spaulding " + (person_list.Count - 1);
            person_to_look_for.Birth_Date = new DateTime((long)(person_list.Count - 1));
            start_time = Environment.TickCount;
            b = this.person_list.Contains(person_to_look_for);
            results[2] = Environment.TickCount - start_time;
            if (!b)
                Console.WriteLine("Could not find last element in person_list.");

            /* Searching for a nonexistent element in List<Person> collection.
             * Measuring search time.
             */
            person_to_look_for.Name = "Doug " + (person_list.Count + 100);
            person_to_look_for.Last_Name = "Spaulding " + (person_list.Count + 100);
            person_to_look_for.Birth_Date = new DateTime((long)(person_list.Count + 100));
            start_time = Environment.TickCount;
            b = this.person_list.Contains(person_to_look_for);
            results[3] = Environment.TickCount - start_time;
            if (b)
                Console.WriteLine("Found a non-existent element in person_list. Error.");

            /* Searching for the first element in List<string> collection.
             * Measuring search time.
             */
            person_to_look_for.Name = "Doug " + 0;
            person_to_look_for.Last_Name = "Spaulding " + 0;
            person_to_look_for.Birth_Date = new DateTime((long)0);
            string string_to_look_for = person_to_look_for.ToString();
            start_time = Environment.TickCount;
            b = this.list_of_strings.Contains(string_to_look_for);
            results[4] = Environment.TickCount - start_time;
            if (!b)
                Console.WriteLine("Could not find first element in List<string>.");

            /* Searching for the central element in List<string> collection 
             * Measuring search time.
             */
            person_to_look_for.Name = "Doug " + (list_of_strings.Count / 2);
            person_to_look_for.Last_Name = "Spaulding " + (list_of_strings.Count / 2);
            person_to_look_for.Birth_Date = new DateTime((long)(list_of_strings.Count / 2));
            string_to_look_for = person_to_look_for.ToString();
            start_time = Environment.TickCount;
            b = this.list_of_strings.Contains(string_to_look_for);
            results[5] = Environment.TickCount - start_time;
            if (!b)
                Console.WriteLine("Could not find central element in list_of_strings.");

            /* Searching for the last element in List<string> collection 
             * Measuring search time.
             */
            person_to_look_for.Name = "Doug " + (person_list.Count - 1);
            person_to_look_for.Last_Name = "Spaulding " + (person_list.Count - 1);
            person_to_look_for.Birth_Date = new DateTime((long)(person_list.Count - 1));
            string_to_look_for = person_to_look_for.ToString();
            start_time = Environment.TickCount;
            b = this.list_of_strings.Contains(string_to_look_for);
            results[6] = Environment.TickCount - start_time;
            if (!b)
                Console.WriteLine("Could not find the last element in list_of_strings.");

            /* Searching for non-existent element in List<string> collection 
             * Measuring search time.
             */
            person_to_look_for.Name = "Doug " + (person_list.Count + 100);
            person_to_look_for.Last_Name = "Spaulding " + (person_list.Count + 100);
            person_to_look_for.Birth_Date = new DateTime((long)(person_list.Count + 100));
            string_to_look_for = person_to_look_for.ToString();
            start_time = Environment.TickCount;
            b = this.list_of_strings.Contains(string_to_look_for);
            results[7] = Environment.TickCount - start_time;
            if (b)
                Console.WriteLine("Found a non-existent element in list_of_strings. Something wrong here.");

            /* Searching by key for the first element in Dictionary<Person, Student>.
             * Measuring search time.
             */
            person_to_look_for.Name = "Doug " + 0;
            person_to_look_for.Last_Name = "Spaulding " + 0;
            person_to_look_for.Birth_Date = new DateTime((long)0);
            start_time = Environment.TickCount;
            b = this.person_student_dict.ContainsKey(person_to_look_for);
            results[8] = Environment.TickCount - start_time;
            if (!b)
                Console.WriteLine("Could not find the first element in person_student_dict.");

            /* Searching by key for the central element in Dictionary<Person, Student>.
             * Measuring search time.
             */
            person_to_look_for.Name = "Doug " + (person_student_dict.Count / 2);
            person_to_look_for.Last_Name = "Spaulding " + (person_student_dict.Count / 2);
            person_to_look_for.Birth_Date = new DateTime((long)(person_student_dict.Count / 2));
            start_time = Environment.TickCount;
            b = this.person_student_dict.ContainsKey(person_to_look_for);
            results[9] = Environment.TickCount - start_time;
            if (!b)
                Console.WriteLine("Could not find the central element in person_student_dict.");

            /* Searching by key for the last element in Dictionary<Person, Student>.
             * Measuring search time.
             */
            person_to_look_for.Name = "Doug " + (person_student_dict.Count - 1);
            person_to_look_for.Last_Name = "Spaulding " + (person_student_dict.Count - 1);
            person_to_look_for.Birth_Date = new DateTime((long)(person_student_dict.Count - 1));
            start_time = Environment.TickCount;
            b = this.person_student_dict.ContainsKey(person_to_look_for);
            results[10] = Environment.TickCount - start_time;
            if (!b)
                Console.WriteLine("Could not find the last element in person_student_dict.");

            /* Searching by key for a non-existent element in Dictionary<Person, Student>.
             * Measuring search time.
             */
            person_to_look_for.Name = "Doug " + (person_student_dict.Count + 100);
            person_to_look_for.Last_Name = "Spaulding " + (person_student_dict.Count + 100);
            person_to_look_for.Birth_Date = new DateTime((long)(person_student_dict.Count + 100));
            start_time = Environment.TickCount;
            b = this.person_student_dict.ContainsKey(person_to_look_for);
            results[11] = Environment.TickCount - start_time;
            if (b)
                Console.WriteLine("Found a non-existent element in person_student_dict.");

            /* Searching by key for the first element in Dictionary<string, Student>.
             * Measuring search time.
             */
            person_to_look_for.Name = "Doug " + 0;
            person_to_look_for.Last_Name = "Spaulding " + 0;
            person_to_look_for.Birth_Date = new DateTime((long)0);
            string_to_look_for = person_to_look_for.ToString();
            start_time = Environment.TickCount;
            b = this.student_dict.ContainsKey(string_to_look_for);
            results[12] = Environment.TickCount - start_time;
            if (!b)
                Console.WriteLine("Could not find the first element in student_dict.");

            /* Searching by key for the central element in Dictionary<string, Student>.
             * Measuring search time.
             */
            person_to_look_for.Name = "Doug " + (student_dict.Count / 2);
            person_to_look_for.Last_Name = "Spaulding " + (student_dict.Count / 2);
            person_to_look_for.Birth_Date = new DateTime((long)(student_dict.Count / 2));
            string_to_look_for = person_to_look_for.ToString();
            start_time = Environment.TickCount;
            b = this.student_dict.ContainsKey(string_to_look_for);
            results[13] = Environment.TickCount - start_time;
            if (!b)
                Console.WriteLine("Could not find the central element in student_dict.");

            /* Searching by key for the last element in Dictionary<string, Student>.
             * Measuring search time.
             */
            person_to_look_for.Name = "Doug " + (student_dict.Count - 1);
            person_to_look_for.Last_Name = "Spaulding " + (student_dict.Count - 1);
            person_to_look_for.Birth_Date = new DateTime((long)(student_dict.Count - 1));
            string_to_look_for = person_to_look_for.ToString();
            start_time = Environment.TickCount;
            b = this.student_dict.ContainsKey(string_to_look_for);
            results[14] = Environment.TickCount - start_time;
            if (!b)
                Console.WriteLine("Could not find the central element in student_dict.");

            /* Searching by key for a non-existent element in Dictionary<string, Student>.
             * Measuring search time.
             */
            person_to_look_for.Name = "Doug " + (student_dict.Count + 100);
            person_to_look_for.Last_Name = "Spaulding " + (student_dict.Count + 100);
            person_to_look_for.Birth_Date = new DateTime((long)(student_dict.Count + 100));
            string_to_look_for = person_to_look_for.ToString();
            start_time = Environment.TickCount;
            b = this.student_dict.ContainsKey(string_to_look_for);
            results[15] = Environment.TickCount - start_time;
            if (b)
                Console.WriteLine("Found a non-existing element in student_dict.");

            /* Searching by value for the first element in Dictionary<Person, Student>.
             * Measuring search time.
             */
            person_to_look_for.Name = "Doug " + 0;
            person_to_look_for.Last_Name = "Spaulding " + 0;
            person_to_look_for.Birth_Date = new DateTime((long)0);
            Student student_to_look_for = new Student(person_to_look_for, Education.Bachelor, 333);
            start_time = Environment.TickCount;
            b = this.student_dict.ContainsValue(student_to_look_for);
            results[16] = Environment.TickCount - start_time;
            if (!b)
                Console.WriteLine("Could not find the first element by value in person_student_dict.");

            /* Searching by value for the central element in Dictionary<Person, Student>.
             * Measuring search time.
             */
            student_to_look_for.Name = "Doug " + (person_student_dict.Count / 2);
            student_to_look_for.Last_Name = "Spaulding " + (person_student_dict.Count / 2);
            student_to_look_for.Birth_Date = new DateTime((long)((person_student_dict.Count / 2)));
            //string_to_look_for = person_to_look_for.ToString();
            start_time = Environment.TickCount;
            b = this.student_dict.ContainsValue(student_to_look_for);
            results[17] = Environment.TickCount - start_time;
            if (!b)
                Console.WriteLine("Could not find the central element by value in person_student_dict.");

            /* Searching by value for the last element in Dictionary<Person, Student>.
             * Measuring search time.
             */
            student_to_look_for.Name = "Doug " + (person_student_dict.Count - 1);
            student_to_look_for.Last_Name = "Spaulding " + (person_student_dict.Count - 1);
            student_to_look_for.Birth_Date = new DateTime((long)((person_student_dict.Count - 1)));
            //string_to_look_for = person_to_look_for.ToString();
            start_time = Environment.TickCount;
            b = this.student_dict.ContainsValue(student_to_look_for);
            results[18] = Environment.TickCount - start_time;
            if (!b)
                Console.WriteLine("Could not find the last element by value in person_student_dict.");

            /* Searching by value for a non-existent element in Dictionary<Person, Student>.
             * Measuring search time.
             */
            student_to_look_for.Name = "Doug " + (person_student_dict.Count + 100);
            student_to_look_for.Last_Name = "Spaulding " + (person_student_dict.Count + 100);
            student_to_look_for.Birth_Date = new DateTime((long)((person_student_dict.Count + 100)));
            //string_to_look_for = person_to_look_for.ToString();
            start_time = Environment.TickCount;
            b = this.student_dict.ContainsValue(student_to_look_for);
            results[19] = Environment.TickCount - start_time;
            if (b)
                Console.WriteLine("Found a non-existent element by value in person_student_dict.");

            return results;
        }
    }
}
