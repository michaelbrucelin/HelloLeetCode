using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2411
{
    public class Solution2411 : Interface2411
    {
        /// <summary>
        /// 双指针，滑动窗口
        /// 1. 或运算的结果随着数组变长，结果只会增不会减
        ///     所以，从后向前遍历数组，可以得到每个起点的子数组的或的最大值
        /// 2. 使用双指针（滑动窗口）找出每个起点达到最大值的最小长度
        ///     由于 或 运算没有逆运算，所以需要使用一个数组来记录子数组每一位上 1 的数量
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
                    cnts[BitOperations.Log2(x - (x & (x - 1)))] += val;
                    x &= x - 1;
                }
            }

            int getorvalue()
            {
                int _orval = 0;
                for (int i = 0; i < 31; i++) if (cnts[i] > 0) _orval |= 1 << i;
                return _orval;
            }
        }
    }
}
