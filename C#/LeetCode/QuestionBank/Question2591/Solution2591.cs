using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2591
{
    public class Solution2591 : Interface2591
    {
        /// <summary>
        /// 贪心
        /// </summary>
        /// <param name="money"></param>
        /// <param name="children"></param>
        /// <returns></returns>
        public int DistMoney(int money, int children)
        {
            if (money < children) return -1;

            money -= children;
            int x = money / 7, y = money % 7;
            if (x > children) return children - 1;
            if (x == children) return y != 0 ? children - 1 : children;

            return (y != 3 || x != children - 1) ? x : x - 1;
        }
    }
}
