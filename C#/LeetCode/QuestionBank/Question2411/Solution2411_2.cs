using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2411
{
    public class Solution2411_2 : Interface2411
    {
        private static readonly int[] DeBruijnIdx = [0, 1, 28, 2, 29, 14, 24, 3, 30, 22, 20, 15, 25, 17, 4, 8,
                                                     31, 27, 13, 23, 21, 19, 16, 7, 26, 12, 18, 6, 11, 5, 10, 9];

        /// <summary>
        /// 逻辑完全同Solution2411，使用 De Bruijn 位运算技巧快速查找二进制中 1 的位置
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] SmallestSubarrays(int[] nums)
        {
            int len = nums.Length;
            int[] result = new int[len], suffix = new int[len];
            suffix[^1] = nums[^1];
            for (int i = len - 2; i >= 0; i--) suffix[i] = suffix[i + 1] | nums[i];  // 计算后缀or值，即目标值
            if (suffix[0] == 0)
            {
                Array.Fill(result, 1);
                return result;
            }

            int[] cnts = new int[31];
            int orval = 0, pl = 0, pr = -1;
            for (; pl < len && pr + 1 < len; pl++)
            {
                while (orval < suffix[pl]) { maskupdate(pr + 1, 1); orval |= nums[++pr]; }
                result[pl] = pr < pl ? 1 : pr - pl + 1;
                maskupdate(pl, -1);
                orval = getorvalue();
            }
            while (pl < len) { result[pl] = len - pl; pl++; }

            return result;

            void maskupdate(int idx, int val)
            {
                uint x = (uint)nums[idx];
                while (x > 0)
                {
                    cnts[log2(x - (x & (x - 1)))] += val;
                    x &= x - 1;
                }
            }

            int getorvalue()
            {
                int _orval = 0;
                for (int i = 0; i < 31; i++) if (cnts[i] > 0) _orval |= 1 << i;
                return _orval;
            }

            int log2(uint n)
            {
                return DeBruijnIdx[(n * 0x077CB531U) >> 27];
            }
        }
    }
}
