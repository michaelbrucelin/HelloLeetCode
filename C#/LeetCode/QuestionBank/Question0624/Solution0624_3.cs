using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0624
{
    public class Solution0624_3 : Interface0624
    {
        /// <summary>
        /// 排序
        /// 逻辑同Solution0624_2
        /// </summary>
        /// <param name="arrays"></param>
        /// <returns></returns>
        public int MaxDistance(IList<IList<int>> arrays)
        {
            int n = arrays.Count;
            if (n == 2) return Math.Max(arrays[1][^1] - arrays[0][0], arrays[0][^1] - arrays[1][0]);

            int[] asc = new int[n], desc = new int[n];
            for (int i = 0; i < n; i++) asc[i] = desc[i] = i;
            Array.Sort(asc, (x, y) => arrays[x][0] - arrays[y][0]);
            Array.Sort(desc, (x, y) => arrays[y][^1] - arrays[x][^1]);

            if (asc[0] != desc[0]) return arrays[desc[0]][^1] - arrays[asc[0]][0];
            return Math.Max(arrays[desc[1]][^1] - arrays[asc[0]][0], arrays[desc[0]][^1] - arrays[asc[1]][0]);
        }
    }
}
