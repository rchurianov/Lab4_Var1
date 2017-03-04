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
            StudentCollection computer_vision_group = new StudentCollection();
            StudentCollection bayes_methods_group = new StudentCollection();
            Journal vision_journal = new Journal();
            Journal references_journal = new Journal();

            computer_vision_group.StudentsCountChanged += vision_journal.handle_StudentsCountChanged;
            computer_vision_group.StudentReferenceChanged += vision_journal.handle_StudentReferenceChanged;

            computer_vision_group.StudentReferenceChanged += references_journal.handle_StudentReferenceChanged;
            bayes_methods_group.StudentReferenceChanged += references_journal.handle_StudentReferenceChanged;

            computer_vision_group.AddDefaults();
            bayes_methods_group.AddDefaults();

            computer_vision_group.Remove(2);

            bayes_methods_group[1] = new Student(new Person("Name", "LAST NAME", new DateTime(1233, 1, 1)), Education.SecondEducation, 333);

            Console.WriteLine(vision_journal.ToString());
            Console.WriteLine("____________\n");
            Console.WriteLine(references_journal.ToString());
            Console.ReadKey();
        }
    }
}
