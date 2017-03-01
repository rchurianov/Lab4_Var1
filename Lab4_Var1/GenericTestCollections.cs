using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_Var1
{
    public class GenericTestCollections<TKey, TValue>
    {
        private List<TKey> list_of_keys;
        private List<string> list_of_strings;
        private Dictionary<TKey, TValue> key_value_dict;
        private Dictionary<string, TValue> value_dict;

        private GenerateElement<TKey, TValue> generate_element_method;

        /* Constuctor to create collections with specified number of items */
        public GenericTestCollections(int length, GenerateElement<TKey, TValue> kvp_generator)
        {
            list_of_keys = new List<TKey>();
            list_of_strings = new List<string>();
            key_value_dict = new Dictionary<TKey, TValue>();
            value_dict = new Dictionary<string, TValue>();

            this.generate_element_method = kvp_generator;

            for (int i = 0; i < length; i++)
            {
                /* Gnerating equal but different KVP objects */
                KeyValuePair<TKey, TValue> kvp1 = generate_element_method(i);
                KeyValuePair<TKey, TValue> kvp2 = generate_element_method(i);

                list_of_keys.Add(kvp1.Key);
                list_of_strings.Add(kvp1.Key.ToString());

                key_value_dict.Add(kvp2.Key, kvp2.Value);
                value_dict.Add(kvp1.Key.ToString(), kvp1.Value);
            }
        }

        /* Method to get search times for collections.
         * Method returns an array of integers. Each element in the array is
         * search time in ticks for a specific element in one of collections.
         * [output_array_index] - description
         * [0] - search time for the first element in List<TKey>
         * [1] - search time for the central element in List<TKey>
         * [2] - search time for the last element in List<TKey>
         * [3] - search time for a non-existent element in List<TKey>
         * [4] - search time for the first element in List<string>
         * [5] - search time for the central element in List<string>
         * [6] - search time for the last element in List<string>
         * [7] - search time for the non-existent element in List<string>
         * [8] - search time by key for the first element in Dictionary<TKey, TValue>
         * [9] - search time by key for the central element in Dictionary<TKey, TValue>
         * [10] - search time by key for the last element in Dictionary<TKey, TValue>
         * [11] - search time by key for a non-existent element in Dictionary<TKey, TValue>
         * [12] - search time by key for the first element in Dictionary<string, TValue>
         * [13] - search time by key for the central element in Dictionary<string, TValue>
         * [14] - search time by key for the last element in Dictionary<string, TValue>
         * [15] - search time by key for a non-existent element in Dictionary<string, TValue>
         * [16] - search time by value for the first element in Dictionary<TKey, TValue>
         * [17] - search time by value for the central element in Dictionary<TKey, TValue>
         * [18] - search time by value for the last element in Dictionary<TKey, TValue>
         * [19] - search time by value for a non-existent element in Dictionary<TKey, TValue>
         */

        public int[] TimeComparison()
        {
            int[] results = new int[20];
            int collections_length =  list_of_keys.Count;
            int[] indexes = {0, collections_length / 2, collections_length-1, collections_length + 100};
            int result_index = 0;

            /* Searching for elements in list_of_keys */
            foreach(int index in indexes)
            {
                KeyValuePair<TKey, TValue> kvp = generate_element_method(index);
                int start_time = Environment.TickCount;
                bool b = this.list_of_keys.Contains(kvp.Key);
                results[result_index] = Environment.TickCount - start_time;
                if (!b & index < collections_length + 100)
                    Console.WriteLine("Could not find {0} element in list_of_keys.", index);
                else if (b & index == collections_length + 100)
                    Console.WriteLine("Found non-existent element in list_of_keys.");
                result_index += 1;
            }

            /* Searching for elements in list_of_strings */
            foreach (int index in indexes)
            {
                KeyValuePair<TKey, TValue> kvp = generate_element_method(index);
                int start_time = Environment.TickCount;
                bool b = this.list_of_strings.Contains(kvp.Key.ToString());
                results[result_index] = Environment.TickCount - start_time;
                if (!b & index < collections_length + 100)
                    Console.WriteLine("Could not find {0} element in list_of_stings.", index);
                else if (b & index == collections_length + 100)
                    Console.WriteLine("Found non-existent element in list_of_strings.");
                result_index += 1;
            }

            /* Searching for elements by Key in key_value_list */
            foreach (int index in indexes)
            {
                KeyValuePair<TKey, TValue> kvp = generate_element_method(index);
                int start_time = Environment.TickCount;
                bool b = this.key_value_dict.ContainsKey(kvp.Key);
                results[result_index] = Environment.TickCount - start_time;
                if (!b & index < collections_length + 100)
                    Console.WriteLine("Could not find {0} element in key_value_dict.", index);
                else if (b & index == collections_length + 100)
                    Console.WriteLine("Found non-existent element in key_value_dict.");
                result_index += 1;
            }

            /* Searching for elements by Key in value_list */
            foreach (int index in indexes)
            {
                KeyValuePair<TKey, TValue> kvp = generate_element_method(index);
                int start_time = Environment.TickCount;
                bool b = this.value_dict.ContainsKey(kvp.Key.ToString());
                results[result_index] = Environment.TickCount - start_time;
                if (!b & index < collections_length + 100)
                    Console.WriteLine("Could not find {0} element in value_dict.", index);
                else if (b & index == collections_length + 100)
                    Console.WriteLine("Found non-existent element in value_dict.");
                result_index += 1;
            }

            /* Searching for elements by Value in value_list */
            foreach (int index in indexes)
            {
                KeyValuePair<TKey, TValue> kvp = generate_element_method(index);
                int start_time = Environment.TickCount;
                bool b = this.key_value_dict.ContainsValue(kvp.Value);
                results[result_index] = Environment.TickCount - start_time;
                if (!b & index < collections_length + 100)
                    Console.WriteLine("Could not find {0} element in key_value_dict.", index);
                else if (b & index == collections_length + 100)
                    Console.WriteLine("Found non-existent element in key_value_dict.");
                result_index += 1;
            }

            return results;
        }

        public override string ToString()
        {
            string s = "";
            foreach (TKey tk in list_of_keys)
            {
                s += tk.ToString();
            }
            s += "\n";

            foreach (string tk in list_of_strings)
            {
                s += tk;
            }
            s += "\n";
            foreach (KeyValuePair<TKey, TValue> kvp in key_value_dict)
            {
                s += kvp.ToString();
            }
            s += "\n";
            foreach(KeyValuePair<string, TValue> kvp in value_dict)
            {
                s += kvp.ToString();
            }
            return s;
        }
    }
}
