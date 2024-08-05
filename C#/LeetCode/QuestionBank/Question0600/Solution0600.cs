using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0600
{
    public class Solution0600 : Interface0600
    {
        /// <summary>
        /// 递归
        /// 1. 如果n的二进制全部是1，共N位，则显然F(N) = F(N-1) + F(N-2)，F(N-1): 第1位取0，F(N-2): 第1位取1
        ///     预处理出来F(1) .. F(32)
        /// 2. 如果n的二进制中含有0，显然，第1位一定为1
        ///     第1位取0，结果为F(N-1)
        ///     第1位取1，则第二位必取0
        ///         如果第2位的原值是1，结果为F(N-2)
        ///         如果第2位的原值是0，递归处理n的二进制去掉前2位的结果
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int FindIntegers(int n)
        {
            if (n < 3) return n + 1;

            int[] dial = new int[32];
            dial[0] = 2; dial[1] = 3;
            for (int i = 2; i < 32; i++) dial[i] = dial[i - 1] + dial[i - 2];

            List<int> bits = new List<int>();
            while (n > 0) { bits.Add(n & 1); n >>= 1; }

            return _FindIntegers(bits.Count - 1);

            int _FindIntegers(int right)
            {
                while (right >= 0 && bits[right] == 0) right--;
                if (right < 0) return 1;
                if (right == 0) return 2;

                if (bits[right - 1] == 1)
                {
                    return dial[right - 1] + (right >= 2 ? dial[right - 2] : 1);
                }
                else
                {
                    return dial[right - 1] + _FindIntegers(right - 2);
                }
            }
        }
    }
}
