using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2808
{
    public class Solution2808 : Interface2808
    {
        /// <summary>
        /// 分组排序
        /// 题意就是一个环形数组，每一次操作，元素可以不变，也可以变为旁边元素的值。
        /// 假定数组的长度为n，数组中有相同的两个元素，距离为x，那么如果最终的目标值是这个元素，则需要
        ///     (Max(x, n-x-2) + 1) / 2 次操作，注意，这里的距离是指二者之间有几个元素
        /// 所以，需要找出数组中每个元素值之间最大距离值的最小值
        /// 
        /// 注意，不需要排序，本来就是从前向后遍历的元素。
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinimumSeconds(IList<int> nums)
        {
            int cnt = nums.Count;
            Dictionary<int, List<int>> dist = new Dictionary<int, List<int>>();
            for (int i = 0, num; i < cnt; i++)
            {
                num = nums[i];
                dist.TryAdd(num, new List<int>());
                dist[num].Add(i);
            }

            int max = cnt, _max, _cnt;
            foreach (int key in dist.Keys)
            {
                if ((_cnt = dist[key].Count) == 1)
                {
                    _max = cnt - 1;
                }
                else
                {
                    // dist[key].Sort();  // 不需要排序，本来就是从前向后遍历的元素
                    _max = cnt - dist[key][^1] + dist[key][0] - 1;
                    for (int i = 1; i < _cnt; i++)
                    {
                        _max = Math.Max(_max, dist[key][i] - dist[key][i - 1] - 1);
                    }
                }
                max = Math.Min(max, _max);
            }

            return (max + 1) >> 1;
        }
    }
}
