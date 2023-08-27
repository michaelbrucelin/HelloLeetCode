using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0056
{
    public class Solution0056 : Interface0056
    {
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="intervals"></param>
        /// <returns></returns>
        public int[][] Merge(int[][] intervals)
        {
            Array.Sort(intervals, (arr1, arr2) => arr1[0] - arr2[0]);
            List<int[]> result = new List<int[]>() { intervals[0] };
            for (int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i][0] > result[^1][1])
                    result.Add(intervals[i]);
                else
                    result[^1][1] = Math.Max(result[^1][1], intervals[i][1]);
            }

            return result.ToArray();
        }
    }
}
