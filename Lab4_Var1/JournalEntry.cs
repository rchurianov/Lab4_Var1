using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Var1
{
    public class JournalEntry
    {
        public JournalEntry()
        {
            this.ChangedCollectionName = "";
            this.ChangeType = "";
            this.StudentObjectString = "";
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
