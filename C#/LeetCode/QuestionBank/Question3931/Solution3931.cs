using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3931
{
    public class Solution3931 : Interface3931
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsAdjacentDiffAtMostTwo(string s)
        {
            for (int i = 1, len = s.Length; i < len; i++) if (Math.Abs(s[i] - s[i - 1]) > 2) return false;
            return true;
        }
    }
}
