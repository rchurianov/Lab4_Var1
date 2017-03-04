using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Var1
{
    public class JournalEntry
    {
        /* Default constructor. Initializes fields with empty strings. */
        public JournalEntry()
        {
            this.ChangedCollectionName = "";
            this.ChangeType = "";
            this.StudentObjectString = "";
        }

        /* First argument - name of the collection which was changed.
         * Second argument - a string that states what was changed.
         * Third argument - a string with data from the element of collection that was changed.
         */
        public JournalEntry(string collection_name, string change_type, string student)
        {
            this.ChangedCollectionName = collection_name;
            this.ChangeType = change_type;
            this.StudentObjectString = student;
        }

        public string ChangedCollectionName { get; set; }

        public string ChangeType { get; set; }

        public string StudentObjectString { get; set; }

        public override string ToString()
        {
            return ChangedCollectionName + "\n" +
                ChangeType + "\n" +
                StudentObjectString;
        }
    }
}
