using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1854
{
    public class Solution1854_2 : Interface1854
    {
        /// <summary>
        /// 差分数组
        /// </summary>
        /// <param name="logs"></param>
        /// <returns></returns>
        public int MaximumPopulation(int[][] logs)
        {
            int[] diff = new int[101];
            for (int i = 0; i < logs.Length; i++)
            {
                diff[logs[i][0] - 1950]++; diff[logs[i][1] - 1950]--;
            }

            int offset = 0;
            for (int i = 1; i < 101; i++)
            {
                diff[i] += diff[i - 1];
                if (diff[i] > diff[offset]) offset = i;
            }
            return offset + 1950;
        }

        public int MaximumPopulation2(int[][] logs)
        {
            int[] diff = new int[101];
            foreach (int[] log in logs)
            {
                diff[log[0] - 1950]++;
                diff[log[1] - 1950]--;
            }
            for (int i = 1; i < 101; i++) diff[i] += diff[i - 1];

            int year = 0;
            for (int i = 1; i < 101; i++) if (diff[i] > diff[year]) year = i;
            return year + 1950;
        }
    }
}
