using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0383
{
    public class Solution0383_api : Interface0383
    {
        public bool CanConstruct(string ransomNote, string magazine)
        {
            if (ransomNote.Length > magazine.Length) return false;

            Dictionary<char, int> dic1 = ransomNote.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
            Dictionary<char, int> dic2 = magazine.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());

            foreach (var kv in dic1)
            {
                if (!dic2.ContainsKey(kv.Key) || dic2[kv.Key] < kv.Value) return false;
            }

            return true;
        }

        public bool CanConstruct2(string ransomNote, string magazine)
        {
            if (ransomNote.Length > magazine.Length) return false;

            Dictionary<char, int> dic1 = ransomNote.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
            Dictionary<char, int> dic2 = magazine.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());

            return dic1.All(kv => dic2.ContainsKey(kv.Key) && kv.Value <= dic2[kv.Key]);
        }
    }
}
