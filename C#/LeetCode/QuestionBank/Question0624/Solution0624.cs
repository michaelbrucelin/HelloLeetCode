using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0624
{
    public class Solution0624 : Interface0624
    {
        /// <summary>
        /// 遍历2次
        /// 找数组第一项的最小值以及其余数组最后一项的最大值
        /// 找数组最后一项的最大值以及其余数组最后一项的最小值
        ///     或一次遍历找出数组第一项的最小的两个值以及最大的两个值
        /// 答案就在其中，反证法即可证明
        /// </summary>
        /// <param name="arrays"></param>
        /// <returns></returns>
        public int MaxDistance(IList<IList<int>> arrays)
        {
            int n = arrays.Count;
            if (n == 2) return Math.Max(arrays[1][^1] - arrays[0][0], arrays[0][^1] - arrays[1][0]);

            // (int val, List<int> ids)[] info = new (int val, List<int> ids)[4];  // 0 最小值，1 次小值，2 次大值，3 最大值  的id
            int[] vals = [10001, 10001, -10001, -10001];                           // 元组的值不可更改，也不想用结构，直接用两个数组
            List<int>[] ids = [[-1], [-1], [-1], [-1]];

            for (int i = 0, min = 0, max = 0; i < n; i++)
            {
                min = arrays[i][0];
                if (min < vals[0]) { vals[1] = vals[0]; ids[1] = ids[0]; vals[0] = min; ids[0] = new List<int> { i }; }
                else if (min == vals[0]) { ids[0].Add(i); }
                else if (min < vals[1]) { vals[1] = min; ids[1] = new List<int> { i }; }
                else if (min == vals[1]) { ids[1].Add(i); }

                max = arrays[i][^1];
                if (max > vals[3]) { vals[2] = vals[3]; ids[2] = ids[3]; vals[3] = max; ids[3] = new List<int> { i }; }
                else if (max == vals[3]) { ids[3].Add(i); }
                else if (max > vals[2]) { vals[2] = max; ids[2] = new List<int> { i }; }
                else if (max == vals[2]) { ids[2].Add(i); }
            }

            if (ids[0].Count > 1 || ids[3].Count > 1 || ids[0][0] != ids[3][0]) return vals[3] - vals[0];
            return Math.Max(vals[3] - vals[1], vals[2] - vals[0]);
        }
    }
}
