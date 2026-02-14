using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0799
{
    public class Solution0799_3 : Interface0799
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="poured"></param>
        /// <param name="query_row"></param>
        /// <param name="query_glass"></param>
        /// <returns></returns>
        public double ChampagneTower(int poured, int query_row, int query_glass)
        {
            double[,] glasses = new double[query_row + 1, query_row / 2 + 2];
            glasses[0, 0] = poured;
            for (int r = 1, C; r <= query_row; r++)
            {
                C = (r >> 1) + 1;
                glasses[r, 0] = overflow(glasses[r - 1, 0]);
                for (int c = 1; c < C; c++) glasses[r, c] = overflow(glasses[r - 1, c - 1]) + overflow(glasses[r - 1, c]);
                if (glasses[r, C - 1] <= 1) break;
                // for (int c = C; c <= r; c++) glasses[r, C] = glasses[r, r - C]; 
                glasses[r, C] = glasses[r, r - C];  // 只需要计算出前面一半就可以了 
            }
            query_glass = Math.Min(query_glass, query_row - query_glass);
            return glasses[query_row, query_glass] > 1 ? 1 : glasses[query_row, query_glass];

            static double overflow(double x) { return x > 1 ? (x - 1) / 2 : 0; }
        }
    }
}
