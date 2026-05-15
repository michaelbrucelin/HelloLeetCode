using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3884
{
    public class Solution3884 : Interface3884
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int FirstMatchingIndex(string s)
        {
            for (int i = 0, j = s.Length - 1; i <= j; i++, j--) if (s[i] == s[j]) return i;

            return -1;
        }
    }
}
