using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0466
{
    public class Solution0466 : Interface0466
    {
        /// <summary>
        /// 暴力枚举，双指针
        /// 目测必然TLE，只是写着玩的，提交竟然通过了... ...
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="n1"></param>
        /// <param name="s2"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        public int GetMaxRepetitions(string s1, int n1, string s2, int n2)
        {
            if (s1.Length * n1 < s2.Length * n2) return 0;
            if (s1 == s2) return n1 / n2;

            int result = 0;
            int len1 = s1.Length, len2 = s2.Length, c2 = 0, p2 = 0;
            for (int c1 = 0; c1 < n1; c1++) for (int p1 = 0; p1 < len1; p1++)  // 遍历[s1, n1]中的每一个字符
                {
                    if (s1[p1] == s2[p2])
                    {
                        if (++p2 == len2)
                        {
                            p2 = 0;
                            if (++c2 == n2)
                            {
                                result++; c2 = 0;
                            }
                        }
                    }
                }

            return result;
        }
    }
}
