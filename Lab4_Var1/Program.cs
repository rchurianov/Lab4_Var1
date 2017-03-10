using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Var1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region basic task
            //StudentCollection computer_vision_group = new StudentCollection();
            //StudentCollection bayes_methods_group = new StudentCollection();
            //Journal vision_journal = new Journal();
            //Journal references_journal = new Journal();

            //computer_vision_group.StudentsCountChanged += vision_journal.handle_StudentsCountChanged;
            //computer_vision_group.StudentReferenceChanged += vision_journal.handle_StudentReferenceChanged;

            //computer_vision_group.StudentReferenceChanged += references_journal.handle_StudentReferenceChanged;
            //bayes_methods_group.StudentReferenceChanged += references_journal.handle_StudentReferenceChanged;

            //computer_vision_group.AddDefaults();
            //bayes_methods_group.AddDefaults();

            //computer_vision_group.Remove(2);

            //bayes_methods_group[1] = new Student(new Person("Name", "LAST NAME", new DateTime(1233, 1, 1)), Education.SecondEducation, 333);

            //Console.WriteLine(vision_journal.ToString());
            //Console.WriteLine("____________\n");
            //Console.WriteLine(references_journal.ToString());
            #endregion

            GenericStudentCollection<string> msu = new GenericStudentCollection<string>(key_selector);
            GenericStudentCollection<string> mipt = new GenericStudentCollection<string>(key_selector);
            Journal competition_data = new Journal();
            msu.StudentsChanged += competition_data.handle_StudentsChanged;
            mipt.StudentsChanged += competition_data.handle_StudentsChanged;

            // Add elements to collections
            Student[] st_add = new Student[5];
            //Random rand = new Random();
            Student tmp_student = new Student(new Person("John 0", "Smith 0", new DateTime()), Education.Bachelor, 121);
            st_add[0] = tmp_student;

            Student tmp_student1 = new Student(new Person("John 1", "Smith 1", new DateTime()), Education.Specialist, 121);
            st_add[1] = tmp_student1;

            Student tmp_student2 = new Student(new Person("John 2", "Smith 2", new DateTime()), Education.Specialist, 121);
            st_add[2] = tmp_student2;

            Student tmp_student3 = new Student(new Person("John 3", "Smith 3", new DateTime()), Education.Bachelor, 121);
            st_add[3] = tmp_student3;

            Student tmp_student4 = new Student(new Person("John 4", "Smith 4", new DateTime()), Education.Bachelor, 121);
            st_add[4] = tmp_student4;
            msu.AddStudents(st_add);
            Student[] st_add_2 = new Student[5];
            //Random rand = new Random();

            for (int i = 0; i < 5; i++)
            {
                //int grade = rand.Next(1, 6); // 1 is inclusive, 6 is exclusive - grade [1,5]
                Student tmp_stud = new Student(new Person("Walley " + i, "Mystic " + i, new DateTime()), Education.Bachelor, 121);
                tmp_stud.AddExams(new Exam("Some Exam", i, new DateTime()));
                st_add_2[i] = tmp_stud;
                //st_add[i] = new Student(new Person("John", "Smith", new DateTime()), Education.Bachelor, 112);
            }
            mipt.AddStudents(st_add_2);

            // Change Degree or Group_Number for some elements of both collections
            st_add[0].Degree = Education.SecondEducation;
            st_add[1].Degree = Education.SecondEducation;

            st_add_2[2].Group_Number = 333;
            st_add_2[3].Group_Number = 333;

            // Delete an element from a collection
            msu.Remove(st_add[4]);

            // Edit a property in the deleted element
            st_add[4].Degree = Education.SecondEducation;

            Console.WriteLine(competition_data.ToString());

            Console.ReadKey();
        }

        private static string key_selector(Student stud)
        {
            return stud.Passport_Data.ToString();
        }
    }
}
