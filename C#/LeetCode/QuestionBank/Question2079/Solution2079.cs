using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2079
{
    public class Solution2079 : Interface2079
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="plants"></param>
        /// <param name="capacity"></param>
        /// <returns></returns>
        public int WateringPlants(int[] plants, int capacity)
        {
            int result = 0, len = plants.Length;
            for (int i = 0, water = capacity; i < len; i++)
            {
                if (water >= plants[i])
                {
                    water -= plants[i]; result++;
                }
                else
                {
                    water = capacity - plants[i]; result += (i << 1) + 1;
                }
            }

            return result;
        }
    }
}
