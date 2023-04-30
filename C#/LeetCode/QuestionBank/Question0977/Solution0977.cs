using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0977
{
    public class Solution0977 : Interface0977
    {
        /// <summary>
        /// 双指针
        /// 从中间向两边
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] SortedSquares(int[] nums)
        {
            int len = nums.Length;
            int ptr_l = 0, ptr_r;
            for (; ptr_l + 1 < len; ptr_l++) if (Math.Abs(nums[ptr_l + 1]) > Math.Abs(nums[ptr_l])) break;
            ptr_r = ptr_l + 1;

            int[] result = new int[len];
            int ptr = 0, _diff; while (ptr_l >= 0 && ptr_r < len)
            {
                _diff = Math.Abs(nums[ptr_l]) - Math.Abs(nums[ptr_r]);
                if (_diff < 0)
                {
                    result[ptr++] = nums[ptr_l] * nums[ptr_l]; ptr_l--;
                }
                else if (_diff > 0)
                {
                    result[ptr++] = nums[ptr_r] * nums[ptr_r]; ptr_r++;
                }
                else  //  if (_diff == 0)
                {
                    result[ptr++] = nums[ptr_l] * nums[ptr_l]; ptr_l--;
                    result[ptr++] = nums[ptr_r] * nums[ptr_r]; ptr_r++;
                }
            }
            while (ptr_l >= 0) { result[ptr++] = nums[ptr_l] * nums[ptr_l]; ptr_l--; }
            while (ptr_r < len) { result[ptr++] = nums[ptr_r] * nums[ptr_r]; ptr_r++; }

            return result;
        }

        /// <summary>
        /// 双指针
        /// 从两边向中间
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] SortedSquares2(int[] nums)
        {
            int len = nums.Length;
            int[] result = new int[len];
            int ptr = len - 1, ptr_l = 0, ptr_r = len - 1;
            int _diff; while (ptr_l < ptr_r)
            {
                _diff = Math.Abs(nums[ptr_l]) - Math.Abs(nums[ptr_r]);
                if (_diff > 0)
                {
                    result[ptr--] = nums[ptr_l] * nums[ptr_l]; ptr_l++;
                }
                else if (_diff < 0)
                {
                    result[ptr--] = nums[ptr_r] * nums[ptr_r]; ptr_r--;
                }
                else  //  if (_diff == 0)
                {
                    result[ptr--] = nums[ptr_l] * nums[ptr_l]; ptr_l++;
                    result[ptr--] = nums[ptr_r] * nums[ptr_r]; ptr_r--;
                }
            }
            if (ptr_l == ptr_r) result[ptr] = nums[ptr_l] * nums[ptr_r];

            return result;
        }
    }
}
