using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2683
{
    public class Solution2683_2 : Interface2683
    {
        /// <summary>
        /// 数学
        /// 逻辑见官解
        /// </summary>
        /// <param name="derived"></param>
        /// <returns></returns>
        public bool DoesValidArrayExist(int[] derived)
        {
            int xor = 0;
            foreach (int x in derived) xor ^= x;

            return xor == 0;
        }
    }
}
