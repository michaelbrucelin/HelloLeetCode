using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1658
{
    public class Solution1658_2_2 : Interface1658
    {
        public int MinOperations(int[] nums, int x)
        {
            int len = nums.Length, sum = nums.Sum();
            if (sum == x) return len;
            if (sum < x) return -1;

            int result = len + 1;
            int lsum = 0, rsum = sum, left = -1, right = 0;  // 左端操作了left+1步，右端操作了len-right步
            while (left < len && right < len)
            {
                int _x = lsum + rsum;
                if (_x == x)
                {
                    result = Math.Min(result, left + 1 + len - right);
                    lsum += nums[++left];
                    rsum -= nums[right++];
                }
                else if (_x > x)
                    rsum -= nums[right++];
                else  // _x < x
                    lsum += nums[++left];
            }
            while (left < len)
            {
                if (lsum > x) break;
                if (lsum == x)
                {
                    if (left + 1 < result) result = left + 1;
                    break;
                }
                else  // lsum < x
                    lsum += nums[++left];
            }

            return result == len + 1 ? -1 : result;
        }
    }
}
