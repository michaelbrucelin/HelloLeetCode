using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3200
{
    public class Solution3200 : Interface3200
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="red"></param>
        /// <param name="blue"></param>
        /// <returns></returns>
        public int MaxHeightOfTriangle(int red, int blue)
        {
            int[,] cnts = { { red, blue, 0 }, { blue, red, 0 } };

            for (int i = 0; i < 2; i++) while (cnts[i, cnts[i, 2] & 1] > cnts[i, 2])
                {
                    cnts[i, cnts[i, 2] & 1] -= cnts[i, 2] + 1;
                    cnts[i, 2]++;
                }

            return Math.Max(cnts[0, 2], cnts[1, 2]);
        }

        /*
         * 下面的代码是错误的，默认将数量少的球放第一层，这是错误的
         * 上面的代码就是下面代码将两种情况都模拟一遍的结果，利用数组精简了代码，但是不易读了
         * public int MaxHeightOfTriangle(int red, int blue)
         * {
         *     int[] cnts = new int[2];
         *     if (red <= blue) { cnts[0] = red; cnts[1] = blue; } else { cnts[0] = blue; cnts[1] = red; }
         * 
         *     int result = 0;
         *     while (cnts[result & 1] > result)
         *     {
         *         cnts[result & 1] -= result + 1;
         *         result++;
         *     }
         * 
         *     return result;
         * }
         */
    }
}
