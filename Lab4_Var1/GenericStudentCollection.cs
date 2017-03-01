using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Var1
{
    public class GenericStudentCollection<TKey>
    {
        private Dictionary<TKey, Student> students;

        private KeySelector<TKey> key_selector_method;

        public GenericStudentCollection(KeySelector<TKey> input_key_selector)
        {
            this.key_selector_method = input_key_selector;
        }

        // TODO: everything should be changed below according to Extra Task requirements.

        /* Get maximum AGP from `students` collection.
         * It was required by the task to use IEnumerable<T>.Max method
         */
        public double MaxAGP
        {
            get
            {
                double max_agp = 0.0;
                if (students != null)
                {
                    // Assigning a lambda expression to a delegate instance
                    Func<KeyValuePair<TKey, Student>, double> convertKeyValuePairToAGP = x => x.Value.AGP;
                    // Passing delegate instance to Max method
                    max_agp = students.Max(convertKeyValuePairToAGP);
                }
                return max_agp;
            }
        }

        /* Method returns a subset of students collection of all Students
         * with given Education value.
         */
        public IEnumerable<KeyValuePair<TKey, Student>> EducationForm(Education value)
        {
            if (students != null)
            {
                Func<KeyValuePair<TKey, Student>, bool> hasEducationValue = x => x.Value.Degree == value;
                return students.Where(hasEducationValue);
            }
            else
                throw new ArgumentNullException("students");
        }

        /* Returns collection of Students who have specialist degree. */
        /* public IEnumerable<Student> Specialists
        {
            get
            {
                if (students != null)
                {
                    // Implement delegate instance with lambda expression.
                    // Lambda expression checks if student's degree equals Education.Specialist.
                    Func<Student, bool> checkIfSpecialist = x => x.Degree == Education.Specialist;
                    // It was required by the task to use IEnumerable<T>.Where method.
                    return students.Where<Student>(checkIfSpecialist);
                }
                else
                    throw new ArgumentNullException("students");
            }
        } */

        /* Public property that groups Students in students collection based on
         * Student.AGP values.
         */
        public IEnumerable<IGrouping<Education, KeyValuePair<TKey, Student>>> AGP_Grouping
        {
            get
            {
                if (students != null)
                {
                    return students.GroupBy(kvp => kvp.Value.Degree);
                }
                else
                    throw new ArgumentNullException("students");
            }
        }

        /* Returns list of Students each of which has given AGP value.
         * AGP value is given by method parameter. Must use IEnumerable<T>.Group
         * and IEnumerable<T>.ToList
         */
        /*public List<Student> AverageMarkGroup(double value)
        {
            List<Student> list = new List<Student>();
            if (students != null)
            {
                IEnumerable<IGrouping<double, Student>> agp_grouping = students.GroupBy<Student, double>(st => st.AGP);
                foreach (IGrouping<double, Student> group in agp_grouping)
                {
                    if (group.Key == value)
                    {
                        list = group.ToList<Student>();
                    }
                    //else
                    //    throw new ArgumentException("AGP provided does not match any of students' AGPs.", "value");
                }
            }
            //else
            //    throw new ArgumentNullException("students");
            return list;
        }*/

        /* Adds 5 default Student objects to students collection */
        public void AddDefaults() // test!
        {
            if (this.students == null)
                this.students = new Dictionary<TKey, Student>();
            for (int i = 0; i < 5; i++)
            {
                Student stud = new Student(new Person("Polyekt " + i, "Polyektovich " + i, new DateTime()), Education.Bachelor, 123+i);
                TKey key = key_selector_method(stud);
                students.Add(key, stud);
            }
        }

        public void AddStudents(params Student[] student_array) // test!
        {
            if (student_array != null)
            {
                if (this.students == null)
                    this.students = new Dictionary<TKey, Student>();

                for (int i = 0; i < student_array.Length; i++)
                {
                    TKey key = key_selector_method(student_array[i]);
                    this.students.Add(key, student_array[i]);
                }
            }
        }

        public override string ToString()
        {
            string s = "";
            foreach (Student stud in students.Values) // test!
            {
                s += stud.ToString() + "\n";
            }
            return s;
        }

        public string ToShortString()
        {
            string s = "";
            foreach (Student stud in students.Values) // test!
            {
                s += stud.ToShortString() + "\n" +
                    "Number of credits: " + stud.Credit_List.Count + "\n" +
                    "Number of exams: " + stud.Exam_List.Count + "\n\n";
            }
            return s;
        }

        
        ///* Sorts Student objects in student collection based on
        // * their last names. It uses IComparable interface implementation
        // * from Person class.
        // */
        
        //public void SortByLastName()
        //{
        //    if (this.students != null)
        //    {
        //        /* List<T>.Sort(Comparison<T> comparison) requires a method as
        //         * a parameter. Parameter should conform with 
        //         * `int Compare(T, T)` delegate.
        //         */
        //        this.students.Sort(CompareStudentsByLastName);
        //    }
        //}

        ///* Method to compare to Student objects. Because in this case the
        // * task requires to use IComparable implementation from Person class
        // * I had to use IComparable as parameter's type. Person is the base class
        // * for Student. CompareStudentsByLastName satiafies requiremets of
        // * `int Compare(T, T)` delegate.
        // */
        //private int CompareStudentsByLastName(IComparable x, IComparable y)
        //{
        //    // make use of Person.IComparable.CompareTo method :
        //    return x.CompareTo(y);
        //}

        ///* Sort `students` collection by birth dates using
        // * IComparer<Person> interface implemetation from Person
        // * class.
        // */
        //public void SortByBirthDate()
        //{
        //    if (this.students != null)
        //    {
        //        CompareStudentsByBirthDate compare = new CompareStudentsByBirthDate();
        //        // List<T>.Sort overload that requires IComparer<T>. Because T is Student
        //        // we have to provide IComparer<Student> object to the Sort() method.
        //        // See helper class below.
        //        this.students.Sort(compare);
        //    }
        //}

        ///* Helper class implementing IComparer<Student> interface */
        //private class CompareStudentsByBirthDate : IComparer<Student>
        //{
        //    int IComparer<Student>.Compare(Student x, Student y)
        //    {
        //        /* Some crappy casting */
        //        return ((IComparer<Person>)x).Compare(x, y);
        //    }
        //}

        ///* Sort Students in `students` collection by their AGP.
        // * We use List<T>.Sort method that requires IComparer<Student>.
        // * We prtovide an object of Student.StudentAGPComparer class as 
        // * a parameter for Sort() method.
        // */
        //public void SortByAGP()
        //{
        //    Student.StudentAGPComparer agp_comparer = new Student.StudentAGPComparer();
        //    this.students.Sort(agp_comparer);
        //}
    }
}
