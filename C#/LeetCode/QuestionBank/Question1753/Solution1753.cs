using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1753
{
    public class Solution1753 : Interface1753
    {
        /// <summary>
        /// 贪心法
        /// 始终从最大的两堆石子中取石块
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public int MaximumScore(int a, int b, int c)
        {
            int result = 0;
            while ((a > 0 && (b > 0 || c > 0)) || (b > 0 && c > 0))
            {
                result++;
                if (a >= b)
                {
                    a--;
                    if (b >= c) b--; else c--;
                }
                else
                {
                    b--;
                    if (a >= c) a--; else c--;
                }
            }

            return result;
        }
    }
}
