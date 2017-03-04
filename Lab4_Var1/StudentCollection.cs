﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Var1
{
    public class StudentCollection
    {
        private List<Student> students;

        public StudentCollection()
        {
            this.students = new List<Student>();
            this.CollectionName = "";
        }

        public string CollectionName { get; set; }

        #region Events for notifying when List<Student> changes

        /* Event raises when number of elements in this.studetns changes */
        public event StudentListHandler StudentsCountChanged;

        /* Event raises when reference to one of the "students"
         * collection changes. */
        public event StudentListHandler StudentReferenceChanged;

        /* Abstraction method to separate event handler call */
        protected virtual void OnStudentsCountChanged(StudentListEventHandlerEventArgs args)
        {
            StudentListHandler handler = StudentsCountChanged;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        /* Abstraction method to separate event handler call */
        protected virtual void OnStudentReferenceChanged(StudentListEventHandlerEventArgs args)
        {
            StudentListHandler handler = StudentReferenceChanged;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        #endregion


        /* Removes an element from collection.
         * Returns "false" if there is no element with 
         * specified index.
         */
        public bool Remove(int j) 
        {
            Student stud = new Student();
            try
            {
                stud = students.ElementAt<Student>(j);
                students.RemoveAt(j);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return false;
            }
            
            StudentListEventHandlerEventArgs args = new StudentListEventHandlerEventArgs();
            args.ChangedObject = stud;
            args.ChangeType = "A Student at index " + j + " was  removed from collection.";
            args.CollectionName = this.CollectionName;
            OnStudentsCountChanged(args);
            return true;
        }

        /* Indexator which gets and sets an element
         * at a specified index.
         */
        public Student this[int index]
        {
            get
            {
                try
                {
                    return students.ElementAt(index);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    return null;
                }
            }

            set
            {
                if (index >= 0 & index < students.Count)
                {
                    students[index] = value;

                    StudentListEventHandlerEventArgs args = new StudentListEventHandlerEventArgs();
                    args.ChangedObject = students[index];
                    args.ChangeType = "An element was changed.";
                    args.CollectionName = this.CollectionName;
                    OnStudentReferenceChanged(args);
                }
            }
        }

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
                    Func<Student, double> convertStudentToAGP = x => x.AGP;
                    // Passing delegate instance to Max method
                    max_agp = students.Max<Student>(convertStudentToAGP);
                }
                return max_agp;
            }
        }

        /* Returns collection of Students who have specialist degree. */
        public IEnumerable<Student> Specialists
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
        }

        /* Returns list of Students each of which has given AGP value.
         * AGP value is given by method parameter. Must use IEnumerable<T>.Group
         * and IEnumerable<T>.ToList
         */
        public List<Student> AverageMarkGroup(double value)
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
        }

        /* Adds 5 default Student objects to students collection */
        public void AddDefaults()
        {
            if (students == null)
                students = new List<Student>();
            for (int i = 0; i < 5; i++)
            {
                Student stud = new Student();
                students.Add(stud);

                StudentListEventHandlerEventArgs args = new StudentListEventHandlerEventArgs();
                args.ChangedObject = stud;
                args.ChangeType = "A new default Student object was added to collection.";
                args.CollectionName = this.CollectionName;
                OnStudentsCountChanged(args);
            }
        }

        public void AddStudents(params Student[] student_array)
        {
            if (student_array != null)
            {
                if (this.students == null)
                    this.students = new List<Student>();

                for (int i = 0; i < student_array.Length; i++)
                {
                    this.students.Add(student_array[i]);

                    StudentListEventHandlerEventArgs args = new StudentListEventHandlerEventArgs();
                    args.ChangedObject = student_array[i];
                    args.ChangeType = "A new Student object from a source was added to collection.";
                    args.CollectionName = this.CollectionName;
                    OnStudentsCountChanged(args);
                }
            }
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < students.Count; i++)
            {
                s += students[i].ToString() + "\n";
            }
            return s;
        }

        public string ToShortString()
        {
            string s = "";
            for (int i = 0; i < students.Count; i++)
            {
                s += students[i].ToShortString() + "\n" +
                    "Number of credits: " + students[i].Credit_List.Count + "\n" +
                    "Number of exams: " + students[i].Exam_List.Count + "\n";
            }
            return s;
        }

        /* Sorts Student objects in student collection based on
         * their last names. It uses IComparable interface implementation
         * from Person class.
         */
        public void SortByLastName()
        {
            if (this.students != null)
            {
                /* List<T>.Sort(Comparison<T> comparison) requires a method as
                 * a parameter. Parameter should conform with 
                 * `int Compare(T, T)` delegate.
                 */
                this.students.Sort(CompareStudentsByLastName);
            }
        }

        /* Method to compare to Student objects. Because in this case the
         * task requires to use IComparable implementation from Person class
         * I had to use IComparable as parameter's type. Person is the base class
         * for Student. CompareStudentsByLastName satisfies requiremets of
         * `int Compare(T, T)` delegate.
         */
        private int CompareStudentsByLastName(IComparable x, IComparable y)
        {
            // make use of Person.IComparable.CompareTo method :
            return x.CompareTo(y);
        }

        /* Sort `students` collection by birth dates using
         * IComparer<Person> interface implemetation from Person
         * class.
         */
        public void SortByBirthDate()
        {
            if (this.students != null)
            {
                CompareStudentsByBirthDate compare = new CompareStudentsByBirthDate();
                // List<T>.Sort overload that requires IComparer<T>. Because T is Student
                // we have to provide IComparer<Student> object to the Sort() method.
                // See helper class below.
                this.students.Sort(compare);
            }
        }

        /* Helper class implementing IComparer<Student> interface */
        private class CompareStudentsByBirthDate : IComparer<Student>
        {
            int IComparer<Student>.Compare(Student x, Student y)
            {
                /* Some crappy casting */
                return ((IComparer<Person>)x).Compare(x, y);
            }
        }

        /* Sort Students in `students` collection by their AGP.
         * We use List<T>.Sort method that requires IComparer<Student>.
         * We prtovide an object of Student.StudentAGPComparer class as 
         * a parameter for Sort() method.
         */
        public void SortByAGP()
        {
            Student.StudentAGPComparer agp_comparer = new Student.StudentAGPComparer();
            this.students.Sort(agp_comparer);
        }
    }
}
