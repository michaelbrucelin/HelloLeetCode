using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1342
{
    public class Solution1342 : Interface1342
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int NumberOfSteps(int num)
        {
            int result = 0;
            while (num > 0)
            {
                result++;
                if ((num & 1) != 0) num--; else num >>= 1;
            }

            return result;
        }

        public int NumberOfSteps2(int num)
        {
            int result = 0;
            while (num > 1)
            {
                result += (num & 1) + 1;
                num >>= 1;
            }
            if (num > 0) result++;

            return result;
        }
    }
}
