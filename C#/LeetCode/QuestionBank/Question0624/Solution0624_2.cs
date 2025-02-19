using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0624
{
    public class Solution0624_2 : Interface0624
    {
        /// <summary>
        /// 逻辑同Solution0624，精简代码
        /// </summary>
        /// <param name="arrays"></param>
        /// <returns></returns>
        public int MaxDistance(IList<IList<int>> arrays)
        {
            int n = arrays.Count;
            if (n == 2) return Math.Max(arrays[1][^1] - arrays[0][0], arrays[0][^1] - arrays[1][0]);

            int id1 = 0, id2 = 0, id3 = 0, id4 = 0;  // 1 最小值，2 次小值，3 次大值，4 最大值  的id

            for (int i = 0, min = 0, max = 0; i < n; i++)
            {
                min = arrays[i][0];
                if (min < arrays[id1][0]) { id2 = id1; id1 = i; } else if (min < arrays[id2][0]) id2 = i;
                max = arrays[i][^1];
                if (max > arrays[id4][^1]) { id3 = id4; id4 = i; } else if (max > arrays[id3][^1]) id3 = i;

            }

            if (id1 != id4) return arrays[id4][^1] - arrays[id1][0];
            return Math.Max(arrays[id4][^1] - arrays[id2][0], arrays[id3][^1] - arrays[id1][0]);
        }
    }
}
