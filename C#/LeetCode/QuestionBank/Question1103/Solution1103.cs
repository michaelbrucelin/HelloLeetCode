using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1103
{
    public class Solution1103 : Interface1103
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="candies"></param>
        /// <param name="num_people"></param>
        /// <returns></returns>
        public int[] DistributeCandies(int candies, int num_people)
        {
            int[] result = new int[num_people];
            for (int i = 1, j = 0; ; i++, j++)
            {
                if (j == num_people) j = 0;
                if (i < candies)
                {
                    result[j] += i; candies -= i;
                }
                else
                {
                    result[j] += candies; break;
                }
            }

            return result;
        }
    }
}
