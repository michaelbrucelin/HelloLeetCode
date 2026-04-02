using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3537
{
    public class Solution3537_2 : Interface3537
    {
        /// <summary>
        /// 构造 + 迭代
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int[][] SpecialGrid(int n)
        {
            int N = 1 << n;
            int[][] result = new int[N][];
            for (int i = 0; i < N; i++) result[i] = new int[N];
            int x = 0;
            for (int i = 0; i < n; i++) for (int j = 0; j < 4; j++)
                { 
                
                }

            return result;
        }
    }
}
