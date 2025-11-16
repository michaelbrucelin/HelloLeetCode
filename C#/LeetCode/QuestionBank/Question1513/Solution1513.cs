using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1513
{
    public class Solution1513 : Interface1513
    {
        /// <summary>
        /// 遍历 + 排列组合
        /// 数学思想解决问题
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int NumSub(string s)
        {
            int result = 0, p = -1, len = s.Length;
            const int MOD = (int)1e9 + 7;
            long cnt = 0;
            while (++p < len)
            {
                if (s[p] == '0')
                {
                    result = (int)(result + ((cnt * (cnt + 1) >> 1) % MOD)) % MOD;
                    cnt = 0;
                }
                else
                {
                    cnt++;
                }
            }
            result = (int)(result + ((cnt * (cnt + 1) >> 1) % MOD)) % MOD;

            return result;
        }

        /// <summary>
        /// 逻辑与NumSub()一样，编程思想解决问题
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int NumSub2(string s)
        {
            int result = 0, p = -1, len = s.Length;
            const int MOD = (int)1e9 + 7;
            int cnt = 0;
            while (++p < len)
            {
                if (s[p] == '0')
                {
                    cnt = 0;
                }
                else
                {
                    result = (result + (++cnt)) % MOD;
                }
            }

            return result;
        }
    }
}
