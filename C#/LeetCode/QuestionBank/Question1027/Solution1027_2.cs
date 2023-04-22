using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1027
{
    public class Solution1027_2 : Interface1027
    {
        /// <summary>
        /// 暴力枚举
        /// 与Solution1027逻辑一样，进行了下面的剪枝优化
        /// 剪枝优化
        /// 1. 如果余下的项不能产生比已知结果更大的结果，不需要继续处理
        /// 
        /// 逻辑没错，提交会超时，参考测试用例07
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LongestArithSeqLength(int[] nums)
        {
            int result = 2, len = nums.Length;
            Dictionary<int, List<int>> pos = new Dictionary<int, List<int>>();  // 预处理每个元素所在的位置
            for (int i = 0; i < len; i++)
                if (pos.ContainsKey(nums[i])) pos[nums[i]].Add(i); else pos.Add(nums[i], new List<int>() { i });
            for (int i = 0; i < len - 1; i++)
            {
                if (len - i <= result) break;                                   // 剪枝
                for (int j = i + 1; j < len; j++)
                {
                    if (len - j + 1 <= result) break;                           // 剪枝
                    int d = nums[j] - nums[i], pre = nums[j], nextid = j, cnt = 2;
                    while (pos.ContainsKey(pre + d))
                    {
                        if ((nextid = BinarySearch(pos[pre + d], nextid)) == -1) break;
                        pre = nums[nextid]; cnt++;
                        if (len - nextid - 1 + cnt <= result) break;            // 剪枝
                    }
                    result = Math.Max(result, cnt);
                }
            }

            return result;
        }

        /// <summary>
        /// 暴力枚举
        /// 与LongestArithSeqLength()一样，增加了下面的剪枝优化
        /// 剪枝优化
        /// 1. 记录下处理过的等差子序列的索引的组合，如果新的枚举的索引对是其中的项，那么不需要再处理了
        ///     例如等差子序列的id是0,10,15,49的话，那么需要记录(0,10) (0,15) (10,15) (0,49) (10,49) (15,49)
        ///                                         其实(0,10),(0,15),(0,49)，即与第一个元素的配对不需要记录，因为后面不可能匹配得到，没有意义
        /// 逻辑没错，提交会超时，优化变成了负优化，参考测试用例07
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LongestArithSeqLength2(int[] nums)
        {
            int result = 2, len = nums.Length;
            Dictionary<int, List<int>> pos = new Dictionary<int, List<int>>();  // 预处理每个元素所在的位置
            for (int i = 0; i < len; i++)
                if (pos.ContainsKey(nums[i])) pos[nums[i]].Add(i); else pos.Add(nums[i], new List<int>() { i });
            HashSet<(int, int)> set = new HashSet<(int, int)>();                // 记忆化
            List<int> list = new List<int>();                                   // 辅助记忆化
            for (int i = 0; i < len - 1; i++)
            {
                if (len - i <= result) break;                                   // 剪枝
                for (int j = i + 1; j < len; j++)
                {
                    if (len - j + 1 <= result) break;                           // 剪枝
                    if (set.Contains((i, j))) continue;                         // 剪枝
                    list.Clear(); list.Add(j);
                    int d = nums[j] - nums[i], pre = nums[j], nextid = j, cnt = 2;
                    while (pos.ContainsKey(pre + d))
                    {
                        if ((nextid = BinarySearch(pos[pre + d], nextid)) == -1) break;
                        pre = nums[nextid]; cnt++;
                        if (len - nextid - 1 + cnt <= result) break;            // 剪枝
                        foreach (int id in list) set.Add((id, nextid));
                        list.Add(nextid);
                    }
                    result = Math.Max(result, cnt);
                }
            }

            return result;
        }

        /// <summary>
        /// 寻找第一个大于target的索引
        /// </summary>
        /// <param name="list"></param>
        /// <param name="start"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private int BinarySearch(List<int> list, int target)
        {
            int result = -1, low = 0, high = list.Count - 1, mid;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                if (list[mid] > target)
                {
                    result = list[mid]; high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return result;
        }
    }
}
