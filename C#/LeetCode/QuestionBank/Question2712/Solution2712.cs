using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2712
{
    public class Solution2712 : Interface2712
    {
        /// <summary>
        /// DP
        /// F(i, 0)  表示只进行 [0..j] 翻转将 [0..i] 全部翻转为 0 的最小成本
        /// F(i, 1)  表示只进行 [0..j] 翻转将 [0..i] 全部翻转为 1 的最小成本
        /// F'(i, 0) 表示只进行 [j..]  翻转将 [i..]  全部翻转为 0 的最小成本
        /// F'(i, 1) 表示只进行 [j..]  翻转将 [i..]  全部翻转为 1 的最小成本
        /// 则 F(i, 0) = s[i] == 0 --> F(i-1, 0)
        ///              s[i] == 1 --> (i+1) + F(i-1, 1)
        ///    F(i, 1), F'(i, 0), F'(i, 1) 同理
        /// DP结束后，遍历任意位置i，结果就是Min(F(i,0)+F'(i+1,0), F(i,1)+F'(i+1,1))
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public long MinimumCost(string s)
        {
            int len = s.Length;
            long[,] dpl = new long[len, 2], dpr = new long[len, 2];
            dpl[0, 0] = s[0] - '0'; dpl[0, 1] = '1' - s[0];
            for (int i = 1; i < len; i++)
            {
                if (s[i] == '0')
                {
                    dpl[i, 0] = dpl[i - 1, 0]; dpl[i, 1] = i + 1 + dpl[i - 1, 0];
                }
                else
                {
                    dpl[i, 1] = dpl[i - 1, 1]; dpl[i, 0] = i + 1 + dpl[i - 1, 1];
                }
            }
            dpr[len - 1, 0] = s[len - 1] - '0'; dpr[len - 1, 1] = '1' - s[len - 1];
            for (int i = len - 2; i >= 0; i--)
            {
                if (s[i] == '0')
                {
                    dpr[i, 0] = dpr[i + 1, 0]; dpr[i, 1] = len - i + dpr[i + 1, 0];
                }
                else
                {
                    dpr[i, 1] = dpr[i + 1, 1]; dpr[i, 0] = len - i + dpr[i + 1, 1];
                }
            }

            long result = long.MaxValue;
            result = Math.Min(result, Math.Min(dpr[0, 0], dpr[0, 1]));
            result = Math.Min(result, Math.Min(dpl[len - 1, 0], dpl[len - 1, 1]));
            for (int i = 1; i < len; i++)
            {
                result = Math.Min(result, Math.Min(dpl[i - 1, 0] + dpr[i, 0], dpl[i - 1, 1] + dpr[i, 1]));
            }

            return result;
        }
    }
}
