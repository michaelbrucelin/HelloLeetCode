using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2785
{
    public class Solution2785 : Interface2785
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string SortVowels(string s)
        {
            HashSet<char> vowels = ['a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U'];
            List<char> list = [];
            List<int> pos = [];
            int x = s.Length;
            for (int i = 0; i < x; i++) if (vowels.Contains(s[i]))
                {
                    list.Add(s[i]); pos.Add(i);
                }
            list.Sort();

            char[] result = [.. s];
            x = 0;
            foreach (int i in pos) result[i] = list[x++];
            return new string(result);
        }
    }
}
