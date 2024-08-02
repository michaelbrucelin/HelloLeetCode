using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0189
{
    public class Solution0189_off_3 : Interface0189
    {
        public void Rotate(int[] nums, int k)
        {
            int len = nums.Length;
            k %= len;
            if (k == 0) return;
            Reverse(0, len - 1);
            Reverse(0, k - 1);
            Reverse(k, len - 1);

            void Reverse(int l, int r)
            {
                int t;
                while (l < r)
                {
                    t = nums[l]; nums[l] = nums[r]; nums[r] = t;
                    l++; r--;
                }
            }
        }
    }
}
