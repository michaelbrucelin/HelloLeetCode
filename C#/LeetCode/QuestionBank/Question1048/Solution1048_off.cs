using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1048
{
    public class Solution1048_off : Interface1048
    {
        public int LongestStrChain(string[] words)
        {
            int result = 1, len = words.Length;
            Dictionary<string, int> helper = new Dictionary<string, int>();
            Array.Sort(words, (s1, s2) => s1.Length - s2.Length);
            int ptr = 0, _len = words[0].Length;
            while (ptr < len && words[ptr].Length == _len)
            {
                helper.TryAdd(words[ptr], 1); ptr++;
            }
            for (int i = ptr; i < len; i++)
            {
                if (helper.ContainsKey(words[i])) continue;
                helper.Add(words[i], 1);
                for (int j = 0; j < words[i].Length; j++)
                {
                    string str = $"{words[i].Substring(0, j)}{words[i].Substring(j + 1)}";
                    if (helper.ContainsKey(str)) helper[words[i]] = Math.Max(helper[words[i]], helper[str] + 1);
                    result = Math.Max(result, helper[words[i]]);
                }
            }

            return result;
        }
    }
}
