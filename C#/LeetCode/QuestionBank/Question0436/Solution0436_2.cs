using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0436
{
    public class Solution0436_2 : Interface0436
    {
        /// <summary>
        /// 排序 + 双指针
        /// 先按照start排序，再按照end排序，按照end排序逐个寻找结果
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public int[] FindRightInterval(int[][] intervals)
        {
            int len = intervals.Length;
            int[] idxs = new int[len], idxe = new int[len];
            for (int i = 0; i < len; i++) idxs[i] = idxe[i] = i;
            Array.Sort(idxs, (x, y) => intervals[x][0] - intervals[y][0]);
            Array.Sort(idxe, (x, y) => intervals[x][1] - intervals[y][1]);

            int[] result = new int[len];
            Array.Fill(result, -1);
            for (int i = 0, j = 0; i < len; i++)
            {
                while (j < len && intervals[idxs[j]][0] < intervals[idxe[i]][1]) j++;
                if (j == len) break;
                result[idxe[i]] = idxs[j];
            }

            return result;
        }
    }
}
