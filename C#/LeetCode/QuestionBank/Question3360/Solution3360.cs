using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3360
{
    public class Solution3360 : Interface3360
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool CanAliceWin(int n)
        {
            bool result = false;
            for (int i = 10; i <= n; i--)
            {
                n -= i; result = !result;
            }

            return result;
        }
    }
}
