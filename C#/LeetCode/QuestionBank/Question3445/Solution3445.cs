using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3445
{
    public class Solution3445 : Interface3445
    {
        /// <summary>
        /// 前缀和 + 暴力查找
        /// 
        /// 逻辑没问题，TLE，参考测试用例05
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaxDifference(string s, int k)
        {
            int len = s.Length;
            int[,] presum = new int[5, len + 1];
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < 5; j++) presum[j, i + 1] = presum[j, i];
                presum[s[i] & 15, i + 1]++;
            }

            int result = int.MinValue, odd, even, cnt;
            for (int l = 0; l < len; l++) for (int r = l + k - 1; r < len; r++)
                {
                    odd = int.MinValue; even = int.MaxValue;
                    for (int i = 0; i < 5; i++) if ((cnt = presum[i, r + 1] - presum[i, l]) != 0)
                        {
                            if ((cnt & 1) == 1) odd = Math.Max(odd, cnt); else even = Math.Min(even, cnt);
                        }
                    if (odd != int.MinValue && even != int.MaxValue) result = Math.Max(result, odd - even);
                }

            return result;
        }
    }
}
