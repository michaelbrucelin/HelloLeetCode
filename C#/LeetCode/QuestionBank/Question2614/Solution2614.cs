using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2614
{
    public class Solution2614 : Interface2614
    {
        public int DiagonalPrime(int[][] nums)
        {
            int result = 0, len = nums.Length;
            for (int i = 0; i < len; i++) if (IsPrime(nums[i][i])) result = Math.Max(result, nums[i][i]);
            for (int i = 0; i < len; i++) if (IsPrime(nums[i][len - i - 1])) result = Math.Max(result, nums[i][len - i - 1]);
            return result;
        }

        private bool IsPrime(int num)
        {
            if (num == 1) return false;

            int sqrt = (int)Math.Sqrt(num);
            for (int i = 2; i <= sqrt; i++) if (num % i == 0) return false;

            return true;
        }
    }
}
