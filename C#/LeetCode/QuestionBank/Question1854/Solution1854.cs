using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1854
{
    public class Solution1854 : Interface1854
    {
        public int MaximumPopulation(int[][] logs)
        {
            int[] freq = new int[100];
            for (int i = 0; i < logs.Length; i++) for (int j = logs[i][0]; j < logs[i][1]; j++)
                {
                    freq[j - 1950]++;
                }

            int year = 0;
            for (int i = 1; i < 100; i++) if (freq[i] > freq[year]) year = i;

            return year + 1950;
        }
    }
}
