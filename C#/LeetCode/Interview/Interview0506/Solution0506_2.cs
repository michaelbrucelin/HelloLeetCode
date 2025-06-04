using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0506
{
    public class Solution0506_2 : Interface0506
    {
        /// <summary>
        /// 异或
        /// 先异或，再统计1的数量
        /// 注意，XOR的结果不能为负数
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public int ConvertInteger(int A, int B)
        {
            if (A == B) return 0;
            int result = 0, XOR = A ^ B;
            if (XOR < 0)
            {
                result = 1;
                XOR = A < 0 ? (A & (~(1 << 31))) ^ B : A ^ (B & (~(1 << 31)));
            }

            while (XOR > 0) { result++; XOR &= XOR - 1; }

            return result;
        }
    }
}
