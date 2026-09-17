using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1943
{
    public class Solution1943_err : Interface1943
    {
        /// <summary>
        /// 差分
        /// 题意没理解对，即使和相同，但是 1+4 与 2+3 是不同的，参考测试用例03
        /// </summary>
        /// <param name="segments"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IList<IList<long>> SplitPainting(int[][] segments)
        {
            int min = int.MaxValue, max = int.MinValue, len = segments.Length;
            for (int i = 0; i < len; i++) { min = Math.Min(min, segments[i][0]); max = Math.Max(max, segments[i][1]); }
            int offset = min;
            long[] diff = new long[max - offset + 1];
            for (int i = 0; i < len; i++)
            {
                diff[segments[i][0] - offset] += segments[i][2]; diff[segments[i][1] - offset] -= segments[i][2];
            }
            len = max - offset;
            for (int i = 1; i < len; i++) diff[i] += diff[i - 1];

            IList<IList<long>> result = new List<IList<long>>();
            int left = 0;
            for (int i = 1; i < len; i++) if (diff[i] != diff[left])
                {
                    result.Add([left + offset, i + offset, diff[left]]);
                    left = i;
                }
            result.Add([left + offset, len + offset, diff[left]]);

            return result;
        }
    }
}
