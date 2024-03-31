using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0331
{
    public class Solution0331_2 : Interface0331
    {
        /// <summary>
        /// 分治 + 前缀和 + 记忆化搜索
        /// 逻辑同Solution0331，添加记忆化搜索优化时间复杂度
        /// 
        /// 比Solution0331快了很多，但是依然TLE，参考测试用例07
        /// </summary>
        /// <param name="preorder"></param>
        /// <returns></returns>
        public bool IsValidSerialization(string preorder)
        {
            bool[] order = preorder.Split(',').Select(s => s[0] != '#').ToArray();
            int len = order.Length;
            if ((len & 1) != 1) return false;
            if (!order[0]) return len == 1;

            int[] sums1 = new int[len + 1], sums0 = new int[len + 1];  // sums1，非#的前缀和，sums0，#的前缀和
            for (int i = 0; i < len; i++)
            {
                if (order[i])
                {
                    sums1[i + 1] = sums1[i] + 1; sums0[i + 1] = sums0[i];
                }
                else
                {
                    sums1[i + 1] = sums1[i]; sums0[i + 1] = sums0[i] + 1;
                }
            }
            if (sums0[len] - sums1[len] != 1) return false;

            Dictionary<(int, int), bool> memory = new Dictionary<(int, int), bool>();
            for (int i = 1; i < len; i += 2)
            {
                if (IsValidSerialization(order, 1, i, sums1, sums0, memory) &&
                    IsValidSerialization(order, i + 1, len - 1, sums1, sums0, memory))
                    return true;
            }

            return false;
        }

        private bool IsValidSerialization(bool[] order, int start, int end, int[] sums1, int[] sums0, Dictionary<(int, int), bool> memory)
        {
            if (memory.ContainsKey((start, end))) return memory[(start, end)];
            if ((sums0[end + 1] - sums0[start]) - (sums1[end + 1] - sums1[start]) != 1) memory.Add((start, end), false);
            else if (!order[start]) memory.Add((start, end), end == start);
            else
            {
                memory.Add((start, end), false);
                for (int i = start + 1; i < end; i += 2)
                {
                    if (IsValidSerialization(order, start + 1, i, sums1, sums0, memory) &&
                        IsValidSerialization(order, i + 1, end, sums1, sums0, memory))
                    {
                        memory[(start, end)] = true; break;
                    }
                }
            }

            return memory[(start, end)];
        }
    }
}
