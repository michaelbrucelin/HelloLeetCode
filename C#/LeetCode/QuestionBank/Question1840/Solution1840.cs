using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1840
{
    public class Solution1840 : Interface1840
    {
        /// <summary>
        /// 贪心
        /// 1. 将“限制”按位置排序
        /// 2. 修正“限制”，对于相邻的两处限制
        ///     如果两处限制相距为 w，高度分别为 h1 <= h2 且 h2 - h1 > w，则修正 h2 = h1 + w
        /// 3. 计算高度，对于相邻的两处限制
        ///     如果两处限制相距为 w，高度分别为 h1 <= h2 且 h2 - h1 = w，则最高高度为 h2 + (w - h2 + h1) / 2
        /// </summary>
        /// <param name="n"></param>
        /// <param name="restrictions"></param>
        /// <returns></returns>
        public int MaxBuilding(int n, int[][] restrictions)
        {
            if (restrictions.Length == 0) return n - 1;

            List<int[]> limits = [[1, 0], .. restrictions];
            limits.Sort((x, y) => x[0] - y[0]);
            if (limits[^1][0] != n) limits.Add([n, int.MaxValue]);

            int result = 0, cnt = limits.Count;
            for (int i = 1; i < cnt; i++) limits[i][1] = Math.Min(limits[i][1], limits[i - 1][1] + limits[i][0] - limits[i - 1][0]);
            for (int i = cnt - 2; i >= 0; i--) limits[i][1] = Math.Min(limits[i][1], limits[i + 1][1] + limits[i + 1][0] - limits[i][0]);
            for (int i = 1; i < cnt; i++) result = Math.Max(result, Math.Max(limits[i - 1][1], limits[i][1]) + ((limits[i][0] - limits[i - 1][0] - Math.Abs(limits[i][1] - limits[i - 1][1])) >> 1));

            return result;
        }
    }
}
