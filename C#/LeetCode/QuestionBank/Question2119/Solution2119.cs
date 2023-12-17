using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2119
{
    public class Solution2119 : Interface2119
    {
        /// <summary>
        /// 脑筋急转弯
        /// 翻转两次就是把num结尾的0给删除了
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool IsSameAfterReversals(int num)
        {
            if (num == 0) return true;

            return num % 10 != 0;
        }
    }
}
