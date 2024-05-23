using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2831
{
    public class Solution2831 : Interface2831
    {
        /// <summary>
        /// 滑动窗口
        /// 1. 如果一个窗口长度为n，其中众数数量为m，只要满足n-m <= k，这个窗口就满足条件
        /// 2. 左端点从0开始，右端点从0开始向右移动，直到n-m > k，停止
        /// 3. 左端点前进1位
        ///     如果移除窗口的不是众数，那么，n-m变大，右端点向右移动，直到n-m > k，停止
        ///     如果移除窗口的是众数，
        ///         如果窗口的众数没有发生变化，那么n-m没有变化，右端点向右移动，直到n-m > k，停止
        ///         如果窗口的众数发生变化，那么n-m变小，右端点需要向左移动才能找到下一个满足条件的区间，但是区间一定上一个区间小，忽略，
        ///             所以，右端点向右移动，直到n-m > k，停止
        /// 技巧，使用两个字典维护窗口，
        ///     字典1，维护窗口中每个值出现的次数，Dictionary<int, int>
        ///     字典2，有序字典，维护出现不同次数的值，SortedDictionary<int, HashSet<int>>
        /// 
        /// TLE（国际版），参考测试用例04，代码没改，再次提交通过了（国内版）
        /// 之前遇到过几次国际版能过，国内版TLE，反过来这还是第一次遇到
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int LongestEqualSubarray(IList<int> nums, int k)
        {
            Dictionary<int, int> freq = new Dictionary<int, int>();
            SortedDictionary<int, HashSet<int>> maxpq = new SortedDictionary<int, HashSet<int>>(Comparer<int>.Create((i, j) => j - i));
            int result = 1, pl = 0, pr = 0, left, right, len = nums.Count;
            while (pr < len)
            {
                left = nums[pl]; right = nums[pr];
                freq.TryAdd(right, 0); freq[right]++;
                if (maxpq.ContainsKey(freq[right] - 1)) maxpq[freq[right] - 1].Remove(right);
                maxpq.TryAdd(freq[right], new HashSet<int>()); maxpq[freq[right]].Add(right);

                if (pr - pl + 1 - maxpq.First().Key == k)
                {
                    result = Math.Max(result, maxpq.First().Key);
                }
                else if (pr - pl + 1 - maxpq.First().Key > k)
                {
                    maxpq[freq[left]].Remove(left);
                    maxpq.TryAdd(freq[left] - 1, new HashSet<int>()); maxpq[freq[left] - 1].Add(left);
                    freq[left]--;
                    pl++;
                }
                pr++;
            }
            result = Math.Max(result, maxpq.First().Key);

            return result;
        }
    }
}
