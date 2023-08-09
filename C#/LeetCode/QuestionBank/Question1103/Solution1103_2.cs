using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1103
{
    public class Solution1103_2 : Interface1103
    {
        /// <summary>
        /// 找规律
        /// 具体见Solution1103_2.md
        /// </summary>
        /// <param name="candies"></param>
        /// <param name="num_people"></param>
        /// <returns></returns>
        public int[] DistributeCandies(int candies, int num_people)
        {
            int[] result = new int[num_people];
            int k = (int)Math.Floor((Math.Sqrt(2D * candies + 0.25D) - 0.5D) / num_people);
            if (k > 0) for (int i = 0; i < num_people; i++)
                    result[i] = k * (i + 1) + (((k * (k - 1)) >> 1) * num_people);
            if ((candies -= result.Sum()) > 0)
            {
                int start = 1 + k * num_people;
                for (int i = 0; candies > 0; i++)
                {
                    result[i] += Math.Min(start, candies);
                    candies -= start++;
                }
            }

            return result;
        }
    }
}
