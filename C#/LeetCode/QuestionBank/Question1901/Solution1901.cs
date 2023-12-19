using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1901
{
    public class Solution1901 : Interface1901
    {
        private static readonly int[] dirs = new int[] { -1, 0, 1, 0, -1 };

        /// <summary>
        /// 二分法 + 爬山
        /// 1. 先找出第一行的一个峰值，逻辑同Question0162
        /// 2. 从第一行的峰值开始“爬山”，即移动到该格子4个相邻格子中的最大值位置
        ///     如果有多个最大值位置，那么选择离“边缘”近的那个，随便选一个也可以，选择里边缘近的，有更大的可能会更快的逼近峰值
        /// 3. 最后就会到达一个峰值
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public int[] FindPeakGrid(int[][] mat)
        {
            int[] result = new int[2];
            int rcnt = mat.Length, ccnt = mat[0].Length, low, high, mid;
            switch ((rcnt, ccnt))
            {
                case (1, 1):
                    break;
                case (1, > 1):
                    if (mat[0][0] > mat[0][1]) break;
                    if (mat[0][ccnt - 1] > mat[0][ccnt - 2]) { result[1] = ccnt - 1; break; }
                    low = 1; high = ccnt - 2; mid = -1;
                    while (low <= high)
                    {
                        mid = low + ((high - low) >> 1);
                        if (mat[0][mid] > mat[0][mid - 1] && mat[0][mid] > mat[0][mid + 1]) break;
                        if (mat[0][mid] < mat[0][mid - 1]) high = mid - 1; else low = mid + 1;
                    }
                    result[1] = mid;
                    break;
                case ( > 1, 1):
                    if (mat[0][0] > mat[1][0]) break;
                    if (mat[rcnt - 1][0] > mat[rcnt - 2][0]) { result[0] = rcnt - 1; break; }
                    low = 1; high = rcnt - 2; mid = -1;
                    while (low <= high)
                    {
                        mid = low + ((high - low) >> 1);
                        if (mat[mid][0] > mat[mid - 1][0] && mat[mid][0] > mat[mid + 1][0]) break;
                        if (mat[mid][0] < mat[mid - 1][0]) high = mid - 1; else low = mid + 1;
                    }
                    result[0] = mid;
                    break;
                default:
                    int r = 0, c;
                    if (mat[0][0] > mat[0][1]) c = 0;
                    else if (mat[0][ccnt - 1] > mat[0][ccnt - 2]) c = ccnt - 1;
                    else
                    {
                        low = 1; high = ccnt - 2; mid = -1;
                        while (low <= high)
                        {
                            mid = low + ((high - low) >> 1);
                            if (mat[0][mid] > mat[0][mid - 1] && mat[0][mid] > mat[0][mid + 1]) break;
                            if (mat[0][mid] < mat[0][mid - 1]) high = mid - 1; else low = mid + 1;
                        }
                        c = mid;
                    }

                    // 开始爬山
                    while (true)
                    {
                        for (int i = 0, _r, _c; i < 4; i++)
                        {
                            _r = r + dirs[i]; _c = c + dirs[i + 1];
                            if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt)
                            {
                                if (mat[_r][_c] > mat[r][c]) { r = _r; c = _c; goto CONTINUE; }
                            }
                        }
                        result[0] = r; result[1] = c; break;
                        CONTINUE:;
                    }
                    break;
            }

            return result;
        }
    }
}
