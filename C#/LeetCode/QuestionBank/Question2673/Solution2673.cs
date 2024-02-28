using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2673
{
    public class Solution2673 : Interface2673
    {
        /// <summary>
        /// 贪心
        /// 遍历一次可以计算出最大路径值，只要让所有路径值是最大路径值即可，如果增加，尽可能在更高（离根更近）的层改，这样影响的比较大
        /// 1. 计算根到每个叶子节点的路径值，放到数组中，并记录最大的路径值max，总层数lcnt = (int)Math.Log2(n + 1)
        /// 2. 逐层遍历每一个节点
        ///     遍历时就已经知道当前节点的层数 lid，当然也可以通过 (int)Math.Log2(i + 1) + 1 来计算节点的层数
        ///     计算以当前节点为根的子树的叶子节点范围
        ///         根据当前节点的id可以计算出第一个叶子节点的id，2^{lcnt-lid}*id + 2^{lcnt-lid} - 1
        ///             也可以这样计算：当前节点的 id*2+1 是左孩子，递归查找左孩子即可
        ///         根据当前节点的层数可以计算出叶子节点的数量，2^{lcnt-lid} 个
        ///         范围：[2^{lcnt-lid}*id + 2^{lcnt-lid} - 1, 2^{lcnt-lid}*id + 2^{lcnt-lid+1} - 2]
        ///               [2^{lcnt-lid}*(id+1) - 1, 2^{lcnt-lid}*(id+2) - 2]
        ///     找出叶子节点路径值的最大值 _max
        ///         result += (max - _max)
        ///         每个叶子节点的路径值 += (max - _max)
        /// </summary>
        /// <param name="n"></param>
        /// <param name="cost"></param>
        /// <returns></returns>
        public int MinIncrements(int n, int[] cost)
        {
            int[] sums = new int[n]; sums[0] = cost[0];
            for (int i = 1; i < n; i++) sums[i] += cost[i] + sums[(i - 1) >> 1];
            int max = sums[n >> 1];
            for (int i = (n >> 1) + 1; i < n; i++) max = Math.Max(max, sums[i]);

            int result = 0, lcnt = (int)Math.Log2(n + 1), left, right, lmax, add;
            for (int lid = 1; lid <= lcnt; lid++)
            {
                for (int i = (1 << (lid - 1)) - 1, _cnt = 0; _cnt < (1 << (lid - 1)); _cnt++, i++)
                {
                    left = (1 << (lcnt - lid)) * (i + 1) - 1; right = (1 << (lcnt - lid)) * (i + 2) - 2;
                    lmax = sums[left];
                    for (int j = left + 1; j <= right; j++) lmax = Math.Max(lmax, sums[j]);
                    if ((add = max - lmax) > 0)
                    {
                        result += add;
                        for (int j = left; j <= right; j++) sums[j] += add;
                    }
                }
            }

            return result;
        }
    }
}
