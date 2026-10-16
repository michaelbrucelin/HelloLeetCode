using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0442
{
    public class Solution0442_2 : Interface0442
    {
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> FindDuplicates(int[] nums)
        {
            List<int> result = [];
            Array.Sort(nums);
            for (int i = 1, len = nums.Length; i < len; i++) if (nums[i] == nums[i - 1]) result.Add(nums[i]);

            return result;
        }
    }
}
