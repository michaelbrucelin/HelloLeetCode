using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2139
{
    public class Solution2139 : Interface2139
    {
        /// <summary>
        /// 逆序操作
        /// </summary>
        /// <param name="target"></param>
        /// <param name="maxDoubles"></param>
        /// <returns></returns>
        public int MinMoves(int target, int maxDoubles)
        {
            int result = 0;
            while (target > 1 && maxDoubles > 0)
            {
                if ((target & 1) != 0) { target--; } else { target >>= 1; maxDoubles--; }
                result++;
            }
            result += target - 1;

            return result;
        }
    }
}
