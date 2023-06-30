using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0717
{
    public class Solution0717 : Interface0717
    {
        /// <summary>
        /// 分析
        /// 1. 在不考虑是否无解的情况下，只有下面3种可能最后一个字符一定是1比特字符
        ///     1. 数组只有一个字符
        ///     2. 倒数第二个字符是0
        ///     3. 倒数第二个字符是1，且向前连续偶数个1
        /// 2. 这里不考虑无解的情况了
        /// </summary>
        /// <param name="bits"></param>
        /// <returns></returns>
        public bool IsOneBitCharacter(int[] bits)
        {
            int len = bits.Length;
            if (len == 1 || bits[len - 2] == 0) return true;
            int cnt = 0;
            for (int i = len - 2; i >= 0; i--)
            {
                if (bits[i] == 1) cnt++; else break;
            }

            return (cnt & 1) != 1;
        }
    }
}
