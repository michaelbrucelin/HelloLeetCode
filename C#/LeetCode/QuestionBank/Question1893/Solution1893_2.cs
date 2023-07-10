using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1893
{
    public class Solution1893_2 : Interface1893
    {
        /// <summary>
        /// 排序 + 合并区间
        /// 1. 将ranges按照区间左端点排序
        /// 2. 将ranges中的重合区间合并为一个区间
        /// 3. [left, right]必须完整的属于合并后的ranges中的某一个区间结果才为true
        /// </summary>
        /// <param name="ranges"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public bool IsCovered(int[][] ranges, int left, int right)
        {
            Array.Sort(ranges, (arr1, arr2) => arr1[0] - arr2[0]);
            List<int[]> _ranges = new List<int[]>() { ranges[0] };
            for (int i = 1; i < ranges.Length; i++)
            {
                if (ranges[i][0] <= _ranges[^1][1] + 1)
                    _ranges[^1][1] = Math.Max(_ranges[^1][1], ranges[i][1]);
                else
                    _ranges.Add(ranges[i]);
            }

            for (int i = 0; i < _ranges.Count; i++)
            {
                if (_ranges[i][0] <= left && right <= _ranges[i][1]) return true;
                if (right < _ranges[i][0]) break;
            }

            return false;
        }
    }
}
