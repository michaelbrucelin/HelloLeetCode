using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2582
{
    public class Solution2582 : Interface2582
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="n"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public int PassThePillow(int n, int time)
        {
            int ptr = 1, dir = 1;
            while (--time >= 0)
            {
                ptr += dir;
                if (ptr == n) dir = -1; else if (ptr == 1) dir = 1;
            }

            return ptr;
        }
    }
}
