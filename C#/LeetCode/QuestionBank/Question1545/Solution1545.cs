using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1545
{
    public class Solution1545 : Interface1545
    {
        /// <summary>
        /// 暴力
        /// 直觉上有数学解，先暴力解出来再说
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public char FindKthBit(int n, int k)
        {
            List<int> chars = [0];
            int len = 1;
            while (--n > 0)
            {
                chars.Add(1);
                for (int i = len - 1; i >= 0; i--) chars.Add(1 - chars[i]);
                len = (len << 1) + 1;
            }

            return (char)(chars[k - 1] + '0');
        }
    }
}
