using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1738
{
    public class Solution1738 : Interface1738
    {
        /// <summary>
        /// 类二维前缀和 + 小顶堆
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int KthLargestValue(int[][] matrix, int k)
        {
            int rcnt = matrix.Length, ccnt = matrix[0].Length;
            int[,] prexor = new int[rcnt + 1, ccnt + 1];
            PriorityQueue<int, int> maxpq = new PriorityQueue<int, int>();
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    prexor[r + 1, c + 1] = matrix[r][c] ^ prexor[r + 1, c] ^ prexor[r, c + 1] ^ prexor[r, c];
                    maxpq.Enqueue(prexor[r + 1, c + 1], -prexor[r + 1, c + 1]);
                }

            while (--k > 0) maxpq.Dequeue();
            return maxpq.Dequeue();
        }
    }
}
