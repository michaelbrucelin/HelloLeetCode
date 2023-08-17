using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2154
{
    public class Solution2154 : Interface2154
    {
        /// <summary>
        /// 哈希
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="original"></param>
        /// <returns></returns>
        public int FindFinalValue(int[] nums, int original)
        {
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++) set.Add(nums[i]);

            while (set.Contains(original)) original <<= 1;

            return original;
        }
    }
}
