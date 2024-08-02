using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0189
{
    public class Solution0189 : Interface0189
    {
        /// <summary>
        /// 使用辅助空间
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        public void Rotate(int[] nums, int k)
        {
            int len = nums.Length;
            k %= len;
            if (k == 0) return;

            int[] buffer = new int[len];
            Array.Copy(nums, 0, buffer, k, len - k);
            Array.Copy(nums, len - k, buffer, 0, k);
            Array.Copy(buffer, nums, len);
        }
    }
}
