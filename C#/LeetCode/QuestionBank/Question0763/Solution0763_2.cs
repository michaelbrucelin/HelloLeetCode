using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0763
{
    public class Solution0763_2 : Interface0763
    {
        /// <summary>
        /// 区间合并
        /// 26个区间表示26个字母第一次以及最后一次出现的位置，有重叠的区间合并即可
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public IList<int> PartitionLabels(string s)
        {
            int[][] ranges = new int[26][];
            for (int i = 0; i < 26; i++) ranges[i] = [501, -1];
            for (int i = 0, j, len = s.Length; i < len; i++)
            {
                j = s[i] - 'a';
                ranges[j][0] = Math.Min(ranges[j][0], i);
                ranges[j][1] = Math.Max(ranges[j][1], i);
            }
            Array.Sort(ranges, (x, y) => x[0] != y[0] ? x[0] - y[0] : x[1] - y[1]);

            IList<int> result = new List<int>();
            int left = ranges[0][0], right = ranges[0][1];
            for (int i = 1; i < 26 && ranges[i][0] < 501; i++)
            {
                if (ranges[i][0] < right)
                {
                    right = Math.Max(right, ranges[i][1]);
                }
                else
                {
                    result.Add(right - left + 1);
                    left = ranges[i][0]; right = ranges[i][1];
                }
            }
            result.Add(right - left + 1);

            return result;
        }
    }
}
