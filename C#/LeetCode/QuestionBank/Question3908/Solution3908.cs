using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3908
{
    public class Solution3908 : Interface3908
    {
        /// <summary>
        /// 状态机模拟
        /// </summary>
        /// <param name="n"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool ValidDigit(int n, int x)
        {
            bool has = false, pre = false;
            int d;
            while (n > 0)
            {
                d = n % 10;
                if (d == x) has = true;
                pre = d == x;
                n /= 10;
            }

            return has && (!pre);
        }
    }
}
