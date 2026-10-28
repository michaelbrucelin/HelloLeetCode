using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3030
{
    public class Solution3030 : Interface3030
    {
        /// <summary>
        /// 模拟
        /// 暴力解法
        /// </summary>
        /// <param name="image"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public int[][] ResultGrid(int[][] image, int threshold)
        {
            int rcnt = image.Length, ccnt = image[0].Length;
            int[][] point = new int[rcnt][], count = new int[rcnt][];
            for (int r = 0; r < rcnt; r++) { point[r] = new int[ccnt]; count[r] = new int[ccnt]; }
            for (int r = 2, sum; r < rcnt; r++) for (int c = 2; c < ccnt; c++) if (check(image, r, c, threshold))
                    {
                        sum = 0;
                        for (int _r = r - 2; _r <= r; _r++) for (int _c = c - 2; _c <= c; _c++) sum += image[_r][_c];
                        sum /= 9;
                        for (int _r = r - 2; _r <= r; _r++) for (int _c = c - 2; _c <= c; _c++) { point[_r][_c] += sum; count[_r][_c]++; }
                    }

            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) point[r][c] = count[r][c] != 0 ? point[r][c] / count[r][c] : image[r][c];
            return point;

            static bool check(int[][] image, int r, int c, int threshold)
            {
                for (int _r = r - 2; _r <= r; _r++) for (int _c = c - 2; _c < c; _c++) if (Math.Abs(image[_r][_c] - image[_r][_c + 1]) > threshold) return false;
                for (int _c = c - 2; _c <= c; _c++) for (int _r = r - 2; _r < r; _r++) if (Math.Abs(image[_r][_c] - image[_r + 1][_c]) > threshold) return false;
                return true;
            }
        }
    }
}
