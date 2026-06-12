using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1833
{
    public class Solution1833 : Interface1833
    {
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="costs"></param>
        /// <param name="coins"></param>
        /// <returns></returns>
        public int MaxIceCream(int[] costs, int coins)
        {
            int result = 0, sum = 0, len = costs.Length;
            Array.Sort(costs);
            for (int i = 0; i < len; i++)
            {
                result++;
                if ((sum += costs[i]) > coins) { result--; break; }
            }

            return result;
        }
    }
}
