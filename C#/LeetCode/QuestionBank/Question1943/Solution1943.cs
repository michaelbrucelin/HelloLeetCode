using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1943
{
    public class Solution1943 : Interface1943
    {
        /// <summary>
        /// 差分
        /// 注意Solution1943_err与题目描述“每种颜色 colori 互不相同”，相对于Solution1943_err做了下面更改
        /// </summary>
        /// <param name="segments"></param>
        /// <returns></returns>
        public IList<IList<long>> SplitPainting(int[][] segments)
        {
            int min = int.MaxValue, max = int.MinValue, len = segments.Length;
            for (int i = 0; i < len; i++) { min = Math.Min(min, segments[i][0]); max = Math.Max(max, segments[i][1]); }
            int offset = min;
            long[] diff = new long[max - offset + 1];
            HashSet<int> set = [];                     // 题目限定每个颜色都不相同，所以每个边界都会产生新的颜色
            for (int i = 0; i < len; i++)
            {
                diff[segments[i][0] - offset] += segments[i][2]; set.Add(segments[i][0] - offset);
                diff[segments[i][1] - offset] -= segments[i][2]; set.Add(segments[i][1] - offset);
            }
            len = max - offset;
            for (int i = 1; i < len; i++) diff[i] += diff[i - 1];
            int[] border = new int[set.Count];
            int id = 0;
            foreach (int x in set) border[id++] = x;
            Array.Sort(border);

            len = border.Length;
            IList<IList<long>> result = new List<IList<long>>();
            for (int i = 1; i < len; i++) if (diff[border[i - 1]] > 0)
                {
                    result.Add([border[i - 1] + offset, border[i] + offset, diff[border[i - 1]]]);
                }

            return result;
        }
    }
}
