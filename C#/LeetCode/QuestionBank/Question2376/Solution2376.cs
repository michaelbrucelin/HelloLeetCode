using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2376
{
    public class Solution2376 : Interface2376
    {
        private static readonly int[] dstb = [0, 9, 90, 738, 5274, 32490, 168570, 712890, 2345850, 5611770];

        /// <summary>
        /// 排列组合
        /// 位数  全部                首位为0           数量     累计
        /// 1     10                  1                 9        9
        /// 2     90      = 10*9      9                 81       90
        /// 3     720     = 10*9*8    72     = 9*8      648      738
        /// 4     5040    = 10*...*7  504    = 9*...*7  4536     5274
        /// 5     30240   = 10*...*6  3024   = 9*...*6  27216    32490
        /// 6     151200  = 10*...*5  15120  = 9*...*5  136080   168570
        /// 7     604800  = 10*...*4  60480  = 9*...*4  544320   712890
        /// 8     1814400 = 10*...*3  181440 = 9*...*3  1632960  2345850
        /// 9     3628800 = 10*...*2  362880 = 9*...*2  3265920  5611770
        /// 
        /// 例如：n = 12306
        /// 4位：                5274
        ///                已选  数量
        /// 5位：第1位选1  1
        ///      第2位
        ///          选0         336 = 8*7*6
        ///          选2   12
        ///      第3位
        ///          选0         42 = 7*6
        ///          选3   123
        ///      第4位
        ///          选0   1230
        ///      第5位
        ///          选4         1
        ///          选5         1
        ///          选6         1
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CountSpecialNumbers(int n)
        {
            List<int> digits = new List<int>();
            while (n > 0) { digits.Add(n % 10); n /= 10; }

            int result = 0, len = digits.Count;
            bool[] mask = new bool[10];
            result += dstb[len - 1];
            for (int i = len - 1, cnt, start = 11 - len; i >= 0; i--)
            {
                cnt = 1; for (int j = 0; j < i; j++) cnt *= start + j;
                for (int j = (i == len - 1 ? 1 : 0); j < digits[i]; j++) if (!mask[j]) result += cnt;
                if (mask[digits[i]]) goto End;
                mask[digits[i]] = true;
            }
            result++;  // 加上自身
            End:;

            return result;
        }
    }
}
