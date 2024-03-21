using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3079
{
    public class Solution3079_2 : Interface3079
    {
        private readonly static int[] map = new int[] { 0, 1, 11, 111, 1111 };

        public int SumOfEncryptedInt(int[] nums)
        {
            int result = 0;
            for (int i = 0; i < nums.Length; i++) result += encrypt(nums[i]);

            return result;
        }

        private int encrypt(int num)
        {
            int result = 0, max = 0, len = 0;
            while (num > 0)
            {
                len++;
                max = Math.Max(max, num % 10);
                num /= 10;
            }

            return max * map[len];
        }
    }
}
