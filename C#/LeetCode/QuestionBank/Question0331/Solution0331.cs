using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0331
{
    public class Solution0331 : Interface0331
    {
        /// <summary>
        /// 分治 + 前缀和
        /// 1. 如果树有 N 个节点，那么前序遍历结果中有 N+1 个 #，前序遍历的总长度是 2N+1
        /// 2. 树的最终组成是：根 - 左 - 右，而 左与右的最终组成是 # 或 X##
        ///     也可以理解为 左与右 的最终组成只有 #，因为 X## 可以理解为 根##
        /// 
        /// 逻辑没问题，TLE，参考测试用例06，可以使用记忆化搜索优化时间复杂度
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

            for (int i = 1; i < len; i += 2)
            {
                if (IsValidSerialization(order, 1, i, sums1, sums0) &&
                    IsValidSerialization(order, i + 1, len - 1, sums1, sums0))
                    return true;
            }

            return false;
        }

        private bool IsValidSerialization(bool[] order, int start, int end, int[] sums1, int[] sums0)
        {
            if ((sums0[end + 1] - sums0[start]) - (sums1[end + 1] - sums1[start]) != 1) return false;
            if (!order[start]) return end == start;
            for (int i = start + 1; i < end; i += 2)
            {
                if (IsValidSerialization(order, start + 1, i, sums1, sums0) &&
                    IsValidSerialization(order, i + 1, end, sums1, sums0))
                    return true;
            }

            return false;
        }
    }
}
