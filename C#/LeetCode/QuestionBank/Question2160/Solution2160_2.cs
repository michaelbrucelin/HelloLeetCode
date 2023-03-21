using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2160
{
    public class Solution2160_2 : Interface2160
    {
        /// <summary>
        /// 数学 + 排列
        /// 最小的组合一定是两个最小的数字是“十位”，两个最大的数字是“个位”
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int MinimumSum(int num)
        {
            int[] buffer = new int[4];
            for (int i = 0; i < 4; i++)
            {
                buffer[i] = num % 10; num /= 10;
            }
            Array.Sort(buffer);

            return buffer[0] * 10 + buffer[1] * 10 + buffer[2] + buffer[3];
        }
    }
}
