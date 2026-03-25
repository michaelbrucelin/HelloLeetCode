using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0986
{
    public class Solution0986 : Interface0986
    {
        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="firstList"></param>
        /// <param name="secondList"></param>
        /// <returns></returns>
        public int[][] IntervalIntersection(int[][] firstList, int[][] secondList)
        {
            List<int[]> result = new List<int[]>();
            int s, e, p1 = 0, p2 = 0, len1 = firstList.Length, len2 = secondList.Length;
            while (p1 < len1 && p2 < len2)
            {
                s = Math.Max(firstList[p1][0], secondList[p2][0]);
                e = Math.Min(firstList[p1][1], secondList[p2][1]);
                if (s <= e) result.Add([s, e]);
                switch (firstList[p1][1] - secondList[p2][1])
                {
                    case < 0: p1++; break;
                    case > 0: p2++; break;
                    default: p1++; p2++; break;
                }
            }

            return [.. result];
        }
    }
}
