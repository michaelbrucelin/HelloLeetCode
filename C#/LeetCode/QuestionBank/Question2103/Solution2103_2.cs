using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2103
{
    public class Solution2103_2 : Interface2103
    {
        public int CountPoints(string rings)
        {
            if (rings.Length < 6) return 0;

            int result = 0;
            for (int i = 0; i < 10; i++)
                if (rings.Contains($"R{i}") && rings.Contains($"G{i}") && rings.Contains($"B{i}"))
                    result++;

            return result;
        }
    }
}
