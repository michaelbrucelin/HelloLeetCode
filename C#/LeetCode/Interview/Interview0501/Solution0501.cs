using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0501
{
    public class Solution0501 : Interface0501
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="N"></param>
        /// <param name="M"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public int InsertBits(int N, int M, int i, int j)
        {
            int result = N;
            for (int n = i, m = 0, mask; n <= j; n++, m++)
            {
                mask = ~(1 << n);            // 置零
                result &= mask;
                mask = ((M >> m) & 1) << n;  // 插入
                result |= mask;
            }

            return result;
        }

        /// <summary>
        /// 逻辑同InsertBits()，一次性全部置零，一次性全部插入
        /// </summary>
        /// <param name="N"></param>
        /// <param name="M"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public int InsertBits2(int N, int M, int i, int j)
        {
            int result = N, mask, width = j - i + 1;
            mask = ~(((1 << width) - 1) << i);  // 一次性全部置零
            result &= mask;
            mask = M << i;                      // 一次性全部插入
            result |= mask;

            return result;
        }
    }
}
