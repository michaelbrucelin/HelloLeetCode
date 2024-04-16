using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3110
{
    public class Solution3110 : Interface3110
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int ScoreOfString(string s)
        {
            int result = 0;
            for (int i = 1; i < s.Length; i++) result += Math.Abs(s[i] - s[i - 1]);

            return result;
        }
    }
}
