using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3684
{
    public class Solution3684 : Interface3684
    {
        /// <summary>
        /// 排序 + 遍历
        /// 数组长度不超过100，所以直接排序再遍历就是很好，没必要搞 去重 + TopK 这些优化
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MaxKDistinct(int[] nums, int k)
        {
            Array.Sort(nums);
            List<int> result = [nums[^1]];
            k--;
            for (int i = nums.Length - 2; i >= 0 && k > 0; i--) if (nums[i] != nums[i + 1])
                {
                    result.Add(nums[i]);
                    k--;
                }

            return result.ToArray();
        }
    }
}
