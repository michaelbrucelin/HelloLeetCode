using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2707
{
    public class Solution2707 : Interface2707
    {
        /// <summary>
        /// DP
        /// 1. 找出s中可以被覆盖的区间，把这些区间按照末端的位置排序
        ///     这个查找过程可以使用KMP算法，因为只需要做一次预处理(next数组)，然后就可以快速的查找每一个dictionary中的单词了
        /// 2. 依据这些区间DP
        ///     对于每个区间，“不选”，可覆盖的长度是上一个区间“选”与“不选”的最大值
        ///                   “选”，  当前区间覆盖值 + 最后一个与当前区间不重叠区间的“选”与“不选”的最大值
        ///                             二分法找到最后一个不重叠区间
        /// </summary>
        /// <param name="s"></param>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public int MinExtraChar(string s, string[] dictionary)
        {
            List<(int l, int r)> ranges = new List<(int l, int r)>() { (-1, -1) };
            foreach (string sub in dictionary) foreach (int id in AllIndexesOf(s, sub, true))
                {
                    ranges.Add((id, id + sub.Length - 1));
                }
            ranges.Sort((t1, t2) => t1.r != t2.r ? t1.r - t2.r : t1.l - t2.l);

            int cnt = ranges.Count;
            int[,] dp = new int[cnt, 2];  // dp[i,0]：不选，dp[i,1]：选
            for (int i = 1, j; i < cnt; i++)
            {
                dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1]);
                j = BinarySearch(ranges, i - 1, ranges[i].l);
                dp[i, 1] = Math.Max(dp[j, 0], dp[j, 1]) + ranges[i].r - ranges[i].l + 1;
            }

            return s.Length - Math.Max(dp[cnt - 1, 0], dp[cnt - 1, 1]);
        }

        private List<int> AllIndexesOf(string str, string value, bool overlap = false)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("the string to find may not be empty", "value");

            List<int> indexes = new List<int>();
            int step = (overlap ? 1 : value.Length);
            for (int index = 0; ; index += step)
            {
                index = str.IndexOf(value, index);
                if (index == -1) return indexes;
                indexes.Add(index);
            }
        }

        private int BinarySearch(List<(int l, int r)> ranges, int limit, int target)
        {
            int result = 0, left = 0, right = limit, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (ranges[mid].r < target)
                {
                    result = mid; left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return result;
        }
    }
}
