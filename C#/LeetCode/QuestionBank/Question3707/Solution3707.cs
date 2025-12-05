using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3707
{
    public class Solution3707 : Interface3707
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool ScoreBalance(string s)
        {
            int total = 0, len = s.Length;
            for (int i = 0; i < len; i++) total += s[i] - '`';
            if ((total & 1) != 0) return false;
            total >>= 1;
            for (int i = 0, score = 0; i < len; i++)
            {
                score += s[i] - '`';
                if (score == total) return true;
                if (score > total) return false;
            }

            return false;
        }
    }
}
