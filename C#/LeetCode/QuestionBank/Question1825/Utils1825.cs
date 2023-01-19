using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1825
{
    public static class Utils1825
    {
        public static void ShowInfo(this Interface1825 obj)
        {
            if (obj is MKAverage_2)
            {
                MKAverage_2 _obj = (MKAverage_2)obj;
                BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
                Type type = _obj.GetType();
                FieldInfo field = type.GetField("dic", flags);
                SortedDictionary<int, int> dic = (SortedDictionary<int, int>)field.GetValue(_obj);
                Console.WriteLine("MKAverage_2's dic:");
                if (dic.Count == 0)
                    Console.WriteLine("dic is a empty dictionary.");
                else
                    Console.WriteLine(dic.Select(kv => $"{kv.Key}:\t{kv.Value}").Aggregate((s1, s2) => $"{s1}{Environment.NewLine}{s2}"));
            }
            else if (obj is MKAverage_3)
            {
                MKAverage_3 _obj = (MKAverage_3)obj;
                BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
                Type type = _obj.GetType();

                FieldInfo field1 = type.GetField("s1", flags);
                SortedDictionary<int, int> dic1 = (SortedDictionary<int, int>)field1.GetValue(_obj);
                Console.WriteLine("MKAverage_3's s1:");
                if (dic1.Count == 0)
                    Console.WriteLine("s1 is a empty dictionary.");
                else
                    Console.WriteLine(dic1.Select(kv => $"{kv.Key}:\t{kv.Value}").Aggregate((s1, s2) => $"{s1}{Environment.NewLine}{s2}"));

                FieldInfo field2 = type.GetField("s2", flags);
                SortedDictionary<int, int> dic2 = (SortedDictionary<int, int>)field2.GetValue(_obj);
                Console.WriteLine("MKAverage_3's s2:");
                if (dic2.Count == 0)
                    Console.WriteLine("s2 is a empty dictionary.");
                else
                    Console.WriteLine(dic2.Select(kv => $"{kv.Key}:\t{kv.Value}").Aggregate((s1, s2) => $"{s1}{Environment.NewLine}{s2}"));

                FieldInfo field3 = type.GetField("s3", flags);
                SortedDictionary<int, int> dic3 = (SortedDictionary<int, int>)field3.GetValue(_obj);
                Console.WriteLine("MKAverage_3's s3:");
                if (dic3.Count == 0)
                    Console.WriteLine("s3 is a empty dictionary.");
                else
                    Console.WriteLine(dic3.Select(kv => $"{kv.Key}:\t{kv.Value}").Aggregate((s1, s2) => $"{s1}{Environment.NewLine}{s2}"));
            }
        }
    }
}
