using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0520
{
    public class Solution0520 : Interface0520
    {
        /// <summary>
        /// 分类讨论 + 位运算
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool DetectCapitalUse(string word)
        {
            if (word.Length == 1) return true;

            int all0 = 0, all1 = 1;
            for (int i = 1, j; i < word.Length; i++)
            {
                j = (word[i] >> 5) & 1; all0 |= j; all1 &= j;
                if (all0 != 0 && all1 != 1) return false;
            }
            if (all1 == 1) return true;
            if (all0 == 0) return ((word[0] >> 5) & 1) == 0;

            return false;
        }
    }
}
