using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Var1
{
    public class Journal
    {
        private List<JournalEntry> entries;

        public Journal()
        {
            entries = new List<JournalEntry>();
        }

        /* Event handler for StudentsCountChanged event from StudentCollection. */
        public void handle_StudentsCountChanged(object sender, StudentListEventHandlerEventArgs args)
        {
            //JournalEntry je = new JournalEntry(args.CollectionName, args.ChangeType, args.ChangedObject.ToString());
            //entries.Add(je);
        }

        /* Event handler for StudentReferenceChanged event from StudentCollection. */
        public void handle_StudentReferenceChanged(object sender, StudentListEventHandlerEventArgs args)
        {
            //JournalEntry je = new JournalEntry(args.CollectionName, args.ChangeType, args.ChangedObject.ToString());
            //entries.Add(je);
        }

        public void handle_StudentsChanged(object sender, StudentsChangedEventArgs<string> args)
        {
            JournalEntry je = new JournalEntry(args.CollectionName, args.ChangeType, args.StudentProperty, args.ChangedElementKey.ToString());
            entries.Add(je);
        }

        public override string ToString()
        {
            string s = "";
            if (entries != null)
            {
                foreach(JournalEntry entry in entries)
                {
                    s += entry.ToString() + "\n";
                }
            }
            return s;
        }
    }
}
