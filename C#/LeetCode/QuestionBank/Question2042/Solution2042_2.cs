using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2042
{
    public class Solution2042_2 : Interface2042
    {
        public bool AreNumbersAscending(string s)
        {
            int[] nums = s.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                            .Where(s => Regex.IsMatch(s, @"^\d+$"))
                            .Select(s => int.Parse(s))
                            .ToArray();

            for (int i = 1; i < nums.Length; i++)
                if (nums[i - 1] >= nums[i]) return false;

            return true;
        }
    }
}
