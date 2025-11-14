using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2536
{
    public class Solution2536 : Interface2536
    {
        /// <summary>
        /// 二维差分数组
        /// </summary>
        /// <param name="n"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public int[][] RangeAddQueries(int n, int[][] queries)
        {
            int[,] diff = new int[n + 1, n + 1];
            foreach (int[] query in queries)
            {
                diff[query[0], query[1]]++;
                diff[query[0], query[3] + 1]--;
                diff[query[2] + 1, query[1]]--;
                diff[query[2] + 1, query[3] + 1]++;
            }

            int[][] result = new int[n][];
            for (int r = 0; r < n; r++) result[r] = new int[n];
            result[0][0] = diff[0, 0];
            for (int c = 1; c < n; c++) result[0][c] = result[0][c - 1] + diff[0, c];
            for (int r = 1; r < n; r++) result[r][0] = result[r - 1][0] + diff[r, 0];
            for (int r = 1; r < n; r++) for (int c = 1; c < n; c++)
                {
                    result[r][c] = result[r - 1][c] + result[r][c - 1] - result[r - 1][c - 1] + diff[r, c];
                }
            return result;
        }

        /// <summary>
        /// 逻辑与RangeAddQueries()完全相同，将二维数组改为数组的数组试一下
        /// </summary>
        /// <param name="n"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public int[][] RangeAddQueries2(int n, int[][] queries)
        {
            int[][] diff = new int[n + 1][];
            for (int i = 0; i <= n; i++) diff[i] = new int[n + 1];
            foreach (int[] query in queries)
            {
                diff[query[0]][query[1]]++;
                diff[query[0]][query[3] + 1]--;
                diff[query[2] + 1][query[1]]--;
                diff[query[2] + 1][query[3] + 1]++;
            }

            int[][] result = new int[n][];
            for (int r = 0; r < n; r++) result[r] = new int[n];
            result[0][0] = diff[0][0];
            for (int c = 1; c < n; c++) result[0][c] = result[0][c - 1] + diff[0][c];
            for (int r = 1; r < n; r++) result[r][0] = result[r - 1][0] + diff[r][0];
            for (int r = 1; r < n; r++) for (int c = 1; c < n; c++)
                {
                    result[r][c] = result[r - 1][c] + result[r][c - 1] - result[r - 1][c - 1] + diff[r][c];
                }
            return result;
        }
    }
}
