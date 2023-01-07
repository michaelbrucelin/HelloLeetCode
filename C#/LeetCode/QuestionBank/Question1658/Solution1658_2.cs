using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1658
{
    public class Solution1658_2 : Interface1658
    {
        public int MinOperations(int[] nums, int x)
        {
            int len = nums.Length;
            int[] lsum = new int[len + 1], rsum = new int[len + 1];
            for (int i = 0; i < len; i++) lsum[i + 1] = lsum[i] + nums[i];
            if (lsum[len] == x) return len;
            if (lsum[len] < x) return -1;
            for (int i = len - 1; i >= 0; i--) rsum[i] = rsum[i + 1] + nums[i];

            int result = len + 1;
            int left = 0, right = 0;  // 左端操作了left步，右端操作了len-right步
            while (left <= len && right <= len)
            {
                int _x = lsum[left] + rsum[right];
                if (_x == x)
                {
                    result = Math.Min(result, left + len - right);
                    left++; right++;
                }
                else if (_x > x)
                    right++;
                else  // _x < x
                    left++;
            }

            return result == len + 1 ? -1 : result;
        }
    }
}
