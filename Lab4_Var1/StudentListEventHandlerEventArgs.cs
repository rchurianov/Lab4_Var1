using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab4_Var1
{
    public class StudentListEventHandlerEventArgs : EventArgs
    {
        public string CollectionName
        { get; set; }

        public string ChangeType
        { get; set; }

        public Student ChangedObject
        { get; set; }

        public override string ToString()
        {
            return CollectionName + "\n" +
                ChangeType + "\n" +
                ChangedObject + "\n";
        }
    }
}
