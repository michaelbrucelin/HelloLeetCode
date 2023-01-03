using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2042
{
    public class Solution2042_3 : Interface2042
    {
        public bool AreNumbersAscending(string s)
        {
            List<int> nums = new List<int>();

            int ptr = -1, len = s.Length, buffer = 0;
            bool flag = false;
            while (++ptr < len)
            {
                if (char.IsDigit(s[ptr]))
                {
                    flag = true;
                    buffer = buffer * 10 + (s[ptr] - '0');
                }
                else
                {
                    if (flag)
                    {
                        if (nums.Count > 0 && buffer <= nums[nums.Count - 1]) return false;
                        nums.Add(buffer);
                    }
                    buffer = 0;
                    flag = false;
                }
            }
            if (flag && buffer <= nums[nums.Count - 1]) return false;

            return true;
        }
    }
}
