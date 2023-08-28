using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0057
{
    public class Solution0057 : Interface0057
    {
        /// <summary>
        /// 遍历，逐项合并
        /// </summary>
        /// <param name="intervals"></param>
        /// <param name="newInterval"></param>
        /// <returns></returns>
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            if (intervals.Length == 0) return new int[][] { newInterval };

            List<int[]> result = new List<int[]>();
            if (newInterval[1] < intervals[0][0])
            {
                result.Add(newInterval); result.AddRange(intervals);
            }
            else if (newInterval[0] > intervals[^1][1])
            {
                result.AddRange(intervals); result.Add(newInterval);
            }
            else
            {
                int i = 0, len = intervals.Length;
                for (; i < len; i++)
                {
                    if (newInterval[0] > intervals[i][1])
                    {
                        result.Add(intervals[i]);
                    }
                    else
                    {
                        if (newInterval[1] < intervals[i][0])
                        {
                            result.Add(newInterval); result.Add(intervals[i]);
                        }
                        else
                        {
                            result.Add(new int[] { Math.Min(intervals[i][0], newInterval[0]), Math.Max(intervals[i][1], newInterval[1]) });
                            for (i++; i < len; i++)
                            {
                                if (intervals[i][0] > result[^1][1])
                                {
                                    result.Add(intervals[i]); break;
                                }
                                else
                                {
                                    result[^1][1] = Math.Max(result[^1][1], intervals[i][1]);
                                }
                            }
                        }
                        break;
                    }
                }
                for (i++; i < len; i++) result.Add(intervals[i]);
            }

            return result.ToArray();
        }
    }
}
