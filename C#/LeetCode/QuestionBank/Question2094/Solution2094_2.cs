using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2094
{
    public class Solution2094_2 : Interface2094
    {
        /// <summary>
        /// 分类讨论 + 排列组合
        /// 
        /// 没时间，先暴力写了
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public int[] FindEvenNumbers(int[] digits)
        {
            int[] cnts = new int[10];
            foreach (int digit in digits) cnts[digit]++;

            List<int> result = new List<int>();
            for (int i = 0; i < 10; i += 2) if (cnts[i] > 0)  // 枚举个位
                {
                    
                }

            result.Sort();
            return result.ToArray();
        }
    }
}
