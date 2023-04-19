using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2553
{
    public class Solution2553_api : Interface2553
    {
        public int[] SeparateDigits(int[] nums)
        {
            return string.Join("", nums.Select(i => i.ToString()))
                         .ToCharArray()
                         .Select(c => c & 15)
                         .ToArray();
        }

        public int[] SeparateDigits2(int[] nums)
        {
            return nums.Select(i => i.ToString().ToCharArray())
                       .SelectMany(c => c)
                       .Select(c => c & 15)
                       .ToArray();
        }
    }
}
