using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0283
{
    public class Solution0283 : Interface0283
    {
        /// <summary>
        /// 逐位移动，暴力解法
        /// </summary>
        /// <param name="nums"></param>
        public void MoveZeroes(int[] nums)
        {
            if (nums.Length == 1) return;

            int len = nums.Length; int left = 0, right = len - 1;
            while (left < right)
            {
                while (left <= right && nums[left] != 0) left++; if (left > right) return;
                while (right >= left && nums[right] == 0) right--; if (right < left) return;
                for (int i = left; i < right; i++) nums[i] = nums[i + 1]; nums[right] = 0;
            }
        }
    }
}
