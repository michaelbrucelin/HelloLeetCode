using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1980
{
    public class Solution1980_oth_2 : Interface1980
    {
        public string FindDifferentBinaryString(string[] nums)
        {
            const int SUM = '0' + '1';
            int n = nums.Length;
            char[] buffer = new char[n];
            for (int i = 0; i < n; i++) buffer[i] = (char)(SUM - nums[i][i]);

            return new string(buffer);
        }
    }
}
