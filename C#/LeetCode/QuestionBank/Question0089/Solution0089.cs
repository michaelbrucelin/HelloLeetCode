using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0089
{
    public class Solution0089 : Interface0089
    {
        /// <summary>
        /// dp
        /// n = 1，结果显然是 [0, 1]
        /// 假设 n = k 的结果已知，那么 n = k+1 可以有 n = k 的结果构造出来
        ///     前 2^k 项与 n = k 的结果一致
        ///     后 2^k 项是 n = k 的反序，同时每一项 += 2^k 即可
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<int> GrayCode(int n)
        {
            if (n == 1) return [0, 1];

            int len = 1 << n;
            IList<int> result = new int[len];
            result[1] = 1;
            for (int _n = 1, add = 2; _n < n; _n++, add <<= 1)
            {
                for (int i = add - 1, j = add; i >= 0; i--, j++) result[j] = result[i] + add;
            }

            return result;
        }
    }
}
