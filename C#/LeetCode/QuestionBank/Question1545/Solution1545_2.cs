using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1545
{
    public class Solution1545_2 : Interface1545
    {
        /// <summary>
        /// 递归
        /// Sn的长度为2^n-1，中间位置为2^{n-1}
        /// 如果k是中点，结果为1（S1单独处理），否则递归为Sn-1
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public char FindKthBit(int n, int k)
        {
            if (n == 1) return '0';

            const int SUM = '0' + '1';
            switch (k - (1 << (n - 1)))
            {
                case > 0: return (char)(SUM - FindKthBit(n - 1, (1 << n) - k));
                case < 0: return FindKthBit(n - 1, k);
                default: return '1';
            }
        }
    }
}
