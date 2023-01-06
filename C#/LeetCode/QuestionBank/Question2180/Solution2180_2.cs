using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2180
{
    public class Solution2180_2 : Interface2180
    {
        /// <summary>
        /// 找规律
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int CountEven(int num)
        {
            if (num == 1000) return 499;

            return (((num / 100) & 1) == ((num / 10) & 1)) ? (num >> 1) : ((num - 1) >> 1);
        }
    }
}
