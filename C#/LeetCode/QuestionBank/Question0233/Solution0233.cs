using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0233
{
    public class Solution0233 : Interface0233
    {
        /// <summary>
        /// 找规律
        /// 1位数，有1个
        /// 2位数，首位是1，有11=1+10个，否则有1个，一共20个
        /// 3位数，首位是1，有120=20+100个，否则有20个，一共有300个
        /// ...
        /// k位数，一共有k*10^(k-1)个，k<=9
        /// 
        /// 没写完，先不写了
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CountDigitOne(int n)
        {
            if (n == 0) return 0;

            int len = 0; for (int _n = n; _n > 0; _n /= 10) len++;
            int[] cnts = new int[len];
            for (int i = 0, j = 1; i < len; i++, j *= 10) cnts[i] = i * j;

            throw new NotImplementedException();
        }
    }
}
