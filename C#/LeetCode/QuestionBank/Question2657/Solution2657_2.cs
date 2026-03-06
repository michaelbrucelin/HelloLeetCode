using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2657
{
    public class Solution2657_2 : Interface2657
    {
        /// <summary>
        /// Hash
        /// 逻辑同Solution2657，注意到题目限定的数据量范围，可以将集合运算优化为位运算
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public int[] FindThePrefixCommonArray(int[] A, int[] B)
        {
            const long M01 = 0B0101010101010101010101010101010101010101010101010101010101010101;
            const long M02 = 0B0011001100110011001100110011001100110011001100110011001100110011;
            const long M04 = 0B0000111100001111000011110000111100001111000011110000111100001111;
            const long M08 = 0B0000000011111111000000001111111100000000111111110000000011111111;
            const long M16 = 0B0000000000000000111111111111111100000000000000001111111111111111;
            const long M32 = 0B0000000000000000000000000000000011111111111111111111111111111111;

            int n = A.Length;
            int[] result = new int[n];
            long m1 = 0, m2 = 0;
            for (int i = 0; i < n; i++)
            {
                m1 |= 1L << A[i]; m2 |= 1L << B[i];
                result[i] = weight(m1 & m2);
            }

            return result;

            static int weight(long x)
            {
                x = (x & M01) + ((x >> 01) & M01);
                x = (x & M02) + ((x >> 02) & M02);
                x = (x & M04) + ((x >> 04) & M04);
                x = (x & M08) + ((x >> 08) & M08);
                x = (x & M16) + ((x >> 16) & M16);
                x = (x & M32) + ((x >> 32) & M32);

                return (int)x;
            }
        }

        /// <summary>
        /// 逻辑同FindThePrefixCommonArray()，使用API
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public int[] FindThePrefixCommonArray2(int[] A, int[] B)
        {
            int n = A.Length;
            int[] result = new int[n];
            long m1 = 0, m2 = 0;
            for (int i = 0; i < n; i++)
            {
                m1 |= 1L << A[i]; m2 |= 1L << B[i];
                result[i] = BitOperations.PopCount((ulong)(m1 & m2));
            }

            return result;
        }
    }
}
