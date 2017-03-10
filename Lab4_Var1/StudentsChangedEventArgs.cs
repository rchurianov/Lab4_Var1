using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Var1
{
    public class StudentsChangedEventArgs<TKey>
    {
        public string CollectionName { get; set; }

        public Action ChangeType { get; set; }

        public string StudentProperty { get; set; }

        public TKey ChangedElementKey { get; set; }

        public StudentsChangedEventArgs(string collection_name, Action change_type, string student_property, TKey key)
        {
            this.CollectionName = collection_name;
            this.ChangeType = change_type;
            this.StudentProperty = student_property;
            this.ChangedElementKey = key;
        }

        public override string ToString()
        {
            return CollectionName + "\n" +
                ChangeType.ToString() + "\n" +
                StudentProperty + "\n" +
                ChangedElementKey.ToString();
        }
    }
}
