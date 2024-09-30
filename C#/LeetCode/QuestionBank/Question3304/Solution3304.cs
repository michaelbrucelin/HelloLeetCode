using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3304
{
    public class Solution3304 : Interface3304
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public char KthCharacter(int k)
        {
            int[] chars = new int[k];
            int n = 1, _n;
            while (n < k)
            {
                _n = n;
                for (int i = 0; i < _n && n < k; i++) chars[n++] = chars[i] + 1;
            }

            return (char)(chars[k - 1] % 26 + 'a');
        }
    }
}
