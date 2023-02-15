using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1250
{
    public class Solution1250_2 : Interface1250
    {
        public bool IsGoodArray(int[] nums)
        {
            int gcd = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                gcd = GetGCD(gcd, nums[i]);
                if (gcd == 1) return true;
            }

            return gcd == 1;
        }

        public bool IsGoodArray2(int[] nums)
        {
            return nums.Aggregate(nums[0], (i1, i2) => GetGCD(i1, i2)) == 1;
        }

        private int GetGCD(int x, int y)
        {
            if (x == y) return x;

            int move = 0;
            while (x != y)
            {
                if ((x & 1) == 0 && (y & 1) == 0)
                {
                    x >>= 1; y >>= 1; move++;
                }
                else if ((x & 1) == 0 && (y & 1) == 1) x >>= 1;
                else if ((x & 1) == 1 && (y & 1) == 0) y >>= 1;
                else
                {
                    if (x > y) x = (x - y) >> 1; else y = (y - x) >> 1;
                }
            }

            return x << move;
        }
    }
}
