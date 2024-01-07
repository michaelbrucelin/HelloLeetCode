using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1646
{
    public class Utils1646
    {
        public void Dial()
        {
            int[] result = new int[101];
            for (int i = 0; i <= 100; i++) result[i] = GetMaximumGenerated(i);
            Utils.Dump(result);
        }

        private int GetMaximumGenerated(int n)
        {
            if (n < 2) return n;

            int[] nums = new int[n + 1];
            nums[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                nums[i] = nums[i >> 1] + (i & 1) * nums[(i >> 1) + 1];
            }

            int max = nums[1];
            for (int i = 3; i <= n; i += 2) max = Math.Max(max, nums[i]);
            return max;
        }
    }
}
