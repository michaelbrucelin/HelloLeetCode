using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2105
{
    public class Solution2105 : Interface2105
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="plants"></param>
        /// <param name="capacityA"></param>
        /// <param name="capacityB"></param>
        /// <returns></returns>
        public int MinimumRefill(int[] plants, int capacityA, int capacityB)
        {
            int result = 0, i = 0, j = plants.Length - 1, waterA = capacityA, waterB = capacityB;
            for (; i < j; i++, j--)
            {
                if (waterA >= plants[i]) waterA -= plants[i]; else { waterA = capacityA - plants[i]; result++; }
                if (waterB >= plants[j]) waterB -= plants[j]; else { waterB = capacityB - plants[j]; result++; }
            }
            if (i == j && waterA < plants[i] && waterB < plants[j]) result++;

            return result;
        }
    }
}
