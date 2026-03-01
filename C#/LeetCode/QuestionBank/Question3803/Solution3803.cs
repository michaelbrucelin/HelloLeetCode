using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3803
{
    public class Solution3803 : Interface3803
    {
        /// <summary>
        /// 遍历 + 哈希
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int ResiduePrefixes(string s)
        {
            int result = 0, len = s.Length;
            HashSet<char> set = new HashSet<char>();
            for (int i = 0; i < len && set.Count < 3; i++)
            {
                set.Add(s[i]);
                if (set.Count == (i + 1) % 3) result++;
            }

            return result;
        }
    }
}
