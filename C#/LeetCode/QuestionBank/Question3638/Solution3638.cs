using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3638
{
    public class Solution3638 : Interface3638
    {
        /// <summary>
        /// 贪心
        /// 遍历一次即可
        /// </summary>
        /// <param name="weight"></param>
        /// <returns></returns>
        public int MaxBalancedShipments(int[] weight)
        {
            int result = 0, max = weight[0], id = 0, len = weight.Length;
            while (++id < len)
            {
                if (weight[id] < max)
                {
                    result++;
                    if (++id < len) max = weight[id];
                }
                else
                {
                    max = weight[id];
                }
            }

            return result;
        }
    }
}
