using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3222
{
    public class Solution3222 : Interface3222
    {
        /// <summary>
        /// 数学
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public string LosingPlayer(int x, int y)
        {
            int times = Math.Min(x, y / 4);

            return (times & 1) != 0 ? "Alice" : "Bob";
        }
    }
}
