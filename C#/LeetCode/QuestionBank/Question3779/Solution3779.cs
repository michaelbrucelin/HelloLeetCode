using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3779
{
    public class Solution3779 : Interface3779
    {
        /// <summary>
        /// 遍历 + Hash
        /// 倒序遍历预处理出后缀数组中不同元素的个数即可
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MinOperations(int[] nums)
        {
            int len = nums.Length;
            HashSet<int> set = [];
            for (int i = len - 1; i >= 0; i--)
            {
                if (!set.Add(nums[i])) return (i + 3) / 3;
            }

            return 0;
        }
    }
}
