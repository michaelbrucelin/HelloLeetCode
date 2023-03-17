using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.剑指_Offer.剑指_Offer_0057_2
{
    public class Solution0057_2 : Interface0057
    {
        /// <summary>
        /// 数学
        /// 1. i, i+1, i+2, ... j-1, j 的和是(i+j)(j-i+1)/2
        /// 2. 遍历[1, target-1]，对于遍历的每个i，验证方程有没有正整数解，具体见Solution0057_2.md
        /// 3. 由于子数组长度至少为2，所以不需要遍历[1, target-1]，遍历[1, (target-1)/2]即可
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[][] FindContinuousSequence(int target)
        {
            List<int[]> result = new List<int[]>();
            int target2 = target << 1, border = (target - 1) >> 1;
            for (int i = 1; i <= border; i++)
            {
                int j = (int)Math.Floor(Math.Sqrt(target2 + (i - 0.5D) * (i - 0.5D)) - 0.5D);
                if ((i + j) * (j - i + 1) == target2)                 // 验证解的向下取整
                    result.Add(Enumerable.Range(i, j - i + 1).ToArray());
                //else if ((i + j + 1) * (j + 1 - i + 1) == target2)  // 验证解的向上取整
                //    result.Add(Enumerable.Range(i, j + 1 - i + 1).ToArray());
            }

            return result.ToArray();
        }
    }
}
