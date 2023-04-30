using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1716
{
    public class Solution1716 : Interface1716
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int TotalMoney(int n)
        {
            int result = 0;
            for (int i = 0, j = 0, k; i < n; i++)
            {
                if ((k = i % 7) == 0) j++;
                result += j + k;
            }

            return result;
        }
    }
}
