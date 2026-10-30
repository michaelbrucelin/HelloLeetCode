using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3669
{
    public class Solution3669_err : Interface3669
    {
        /// <summary>
        /// 模拟
        /// 
        /// 题目没审对，题目要求因子的最大值与最小值的差最小
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MinDifference(int n, int k)
        {
            int[] result = new int[k];  // 题目保证有解
            int x = 2, id = 0;
            while (id < k)
            {
                while (n % x != 0) x++;
                result[id++] = x;
                n /= x;
                if (id == k - 1) { result[id] = n; break; }
            }

            return result;
        }
    }
}
