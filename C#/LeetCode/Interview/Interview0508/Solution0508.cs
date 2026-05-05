using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0508
{
    public class Solution0508 : Interface0508
    {
        /// <summary>
        /// 模拟
        /// 二维与一维的映射
        /// 
        /// 可以更快的解决，x1与x2与两端，所以可以先让这区间的整数为 -1，然后第一个整数前面一个前缀区间为0，最后一个整数一个后缀区间为0
        /// </summary>
        /// <param name="length"></param>
        /// <param name="w"></param>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int[] DrawLine(int length, int w, int x1, int x2, int y)
        {
            int[] result = new int[length];
            int ccnt = w >> 5;                                   // w/32;
            int idx = ccnt * y;
            for (int x = x1; x <= x2; x++)
            {
                result[idx + (x >> 5)] |= 1 << (31 - (x & 31));  // x%32
            }

            return result;
        }
    }
}
