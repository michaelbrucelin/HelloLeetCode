using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1750
{
    public class Solution1750 : Interface1750
    {
        public int MinimumLength(string s)
        {
            if (s.Length == 1) return 1;

            int left = 0, right = s.Length - 1;
            while (left < right && s[left] == s[right])
            {
                while (left + 1 < right && s[left + 1] == s[left]) left++;
                while (right - 1 > left && s[right - 1] == s[right]) right--;
                left++; right--;
            }

            return right - left + 1;
        }
    }
}
