using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3760
{
    public class Solution3760 : Interface3760
    {
        /// <summary>
        /// 脑筋急转弯
        /// 就是字符串中不同字母的数量
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MaxDistinct(string s)
        {
            int result = 0, idx;
            bool[] set = new bool[26];
            foreach (char c in s)
            {
                idx = c - 'a';
                if (!set[idx])
                {
                    set[idx] = true;
                    if (++result == 26) return 26;
                }
            }

            return result;
        }

        /// <summary>
        /// 逻辑完全同MaxDistinct().将数组换成整型
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MaxDistinct2(string s)
        {
            int mask = 0, MASK = (1 << 26) - 1;
            foreach (char c in s) if ((mask |= 1 << (c - 'a')) == MASK) return 26;

            int result = 0;
            while (mask > 0) { result++; mask &= (mask - 1); }

            return result;
        }
    }
}
