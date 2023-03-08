using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1252
{
    public class Solution1252_2 : Interface1252
    {
        /// <summary>
        /// 位运算优化
        /// 题目限定n，m均小于64，所以可以用一个long来表示一行或者一列，由于每次操作是+1，即奇偶切换，所以直接位运算取反即可
        /// 
        /// 代码是错误的，当更改一行时，这一行取反并没有错，但是更改这一行时，每一列也都发生了改变，但是代码中没有体现出来这一部分
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="indices"></param>
        /// <returns></returns>
        public int OddCells(int m, int n, int[][] indices)
        {
            long[] rows = new long[m], cols = new long[n];
            for (int i = 0; i < indices.Length; i++)
            {
                rows[indices[i][0]] = ~rows[indices[i][0]]; cols[indices[i][1]] = ~cols[indices[i][1]];
            }

            int result = 0; long _m = (1 << n) - 1, _n = (1 << m) - 1;
            for (int i = 0; i < m; i++) result += HammingWeight(rows[i] & _m);
            for (int i = 0; i < n; i++) result += HammingWeight(cols[i] & _n);

            return result;
        }

        private int HammingWeight(long n)
        {
            long result;
            result = n - ((n >> 1) & 3681400539) - ((n >> 2) & 1227133513);
            return (int)(((result + (result >> 3)) & 3340530119) % 63);
        }
    }
}
