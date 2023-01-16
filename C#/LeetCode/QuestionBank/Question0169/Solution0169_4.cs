using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0169
{
    public class Solution0169_4 : Interface0169
    {
        public int MajorityElement(int[] nums)
        {
            Random random = new Random();
            int len = nums.Length, half = len >> 1;
            while (true)
            {
                int val = nums[random.Next(0, len)];
                int cnt = 0;
                for (int i = 0; i < len; i++) if (nums[i] == val) cnt++;
                if (cnt > half) return val;
            }
        }
    }
}
