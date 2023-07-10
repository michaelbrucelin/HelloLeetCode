using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1893
{
    public class Solution1893_3 : Interface1893
    {
        /// <summary>
        /// 排序 + “剥离”区间
        /// 1. 将ranges按照区间左端点排序
        /// 2. 从[left, right]中一个区间一个区间的“剥离”
        /// 3. 最后[left, right]为空结果为true
        /// </summary>
        /// <param name="ranges"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public bool IsCovered(int[][] ranges, int left, int right)
        {
            Array.Sort(ranges, (arr1, arr2) => arr1[0] - arr2[0]);
            for (int i = 0; i < ranges.Length && left <= right; i++)
            {
                if (ranges[i][0] > left) return false; else left = Math.Max(left, ranges[i][1] + 1);
            }

            return left > right;
        }
    }
}
