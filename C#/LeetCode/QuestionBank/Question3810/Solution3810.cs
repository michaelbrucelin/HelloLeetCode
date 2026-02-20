using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3810
{
    public class Solution3810 : Interface3810
    {
        /// <summary>
        /// 脑筋急转弯
        /// 结果就是 nums[i] != target[i] 的不同值的数量
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int MinOperations(int[] nums, int[] target)
        {
            int len = nums.Length;
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < len; i++) if (nums[i] != target[i]) set.Add(nums[i]);

            return set.Count;
        }
    }
}
