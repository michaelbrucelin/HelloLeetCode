using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0329
{
    public class Solution0329_2 : Interface0329
    {
        /// <summary>
        /// DP
        /// 逻辑同Solution0329，改为DP
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public int LongestIncreasingPath(int[][] matrix)
        {
            int rcnt = matrix.Length, ccnt = matrix[0].Length;
            List<(int, int, int)> list = [];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) list.Add((matrix[r][c], r, c));
            list.Sort((x, y) => y.Item1 - x.Item1);

            int result = 1;
            int[,] dp = new int[rcnt, ccnt];
            int[] dirs = [-1, 0, 1, 0, -1];
            for (int i = 0, r, c, _r, _c, _result, cnt = list.Count; i < cnt; i++)
            {
                r = list[i].Item2; c = list[i].Item3; _result = 0;
                for (int j = 0; j < 4; j++)
                {
                    _r = r + dirs[j]; _c = c + dirs[j + 1];
                    if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt && matrix[_r][_c] > matrix[r][c]) _result = Math.Max(_result, dp[_r, _c]);
                }
                dp[r, c] = ++_result;
                result = Math.Max(result, _result);
            }

            return result;
        }
    }
}
