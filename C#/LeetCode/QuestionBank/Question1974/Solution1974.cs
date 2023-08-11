using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1974
{
    public class Solution1974 : Interface1974
    {
        public int MinTimeToType(string word)
        {
            int sum = 0;
            for (int i = 0, prev = 0, curr; i < word.Length; i++)
            {
                curr = word[i] - 'a';
                sum += Math.Min(Math.Abs(curr - prev), Math.Min(prev - curr + 26, curr - prev + 26)) + 1;
                prev = curr;
            }

            return sum;
        }
    }
}
