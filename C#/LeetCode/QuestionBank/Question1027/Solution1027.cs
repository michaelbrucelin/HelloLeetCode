using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1027
{
    public class Solution1027 : Interface1027
    {
        /// <summary>
        /// 暴力枚举
        /// 1. 既然是等差子序列，那么只要前两个元素定了（公差定了），后面的元素就定了
        ///     - 确定前两个元素可以暴力枚举，O(n^2)
        ///     - 确定后面的元素，可以提前预处理为Dictionary<int, List<int>>，记录指定元素的位置
        ///         由于题目限制 0 <= nums[i] <= 500，所以可以使用数组代替字典
        ///     - 确定后面的元素，可以贪心的取索引尽可能小的哪个元素，使用二分法寻找
        /// 
        /// 逻辑没错，提交会超时，参考测试用例06
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LongestArithSeqLength(int[] nums)
        {
            int result = 2, len = nums.Length;
            Dictionary<int, List<int>> pos = new Dictionary<int, List<int>>();  // 预处理每个元素所在的位置
            for (int i = 0; i < len; i++)
                if (pos.ContainsKey(nums[i])) pos[nums[i]].Add(i); else pos.Add(nums[i], new List<int>() { i });

            for (int i = 0; i < len - 1; i++) for (int j = i + 1; j < len; j++)
                {
                    int d = nums[j] - nums[i], pre = nums[j], nextid = j, cnt = 2;
                    while (pos.ContainsKey(pre + d))
                    {
                        if ((nextid = BinarySearch(pos[pre + d], nextid)) == -1) break;
                        pre = nums[nextid]; cnt++;
                    }
                    result = Math.Max(result, cnt);
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
