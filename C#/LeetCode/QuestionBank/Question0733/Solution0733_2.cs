using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0733
{
    public class Solution0733_2 : Interface0733
    {
        private static readonly int[] dr = new int[] { -1, 0, 1, 0 };  // 上 右 下 左
        private static readonly int[] dc = new int[] { 0, 1, 0, -1 };  // 上 右 下 左

        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="image"></param>
        /// <param name="sr"></param>
        /// <param name="sc"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public int[][] FloodFill(int[][] image, int sr, int sc, int color)
        {
            if (image[sr][sc] == color) return image;

            dfs(image, sr, sc, image.Length, image[0].Length, image[sr][sc], color);

            return image;
        }

        private void dfs(int[][] image, int r, int c, int rcnt, int ccnt, int _color, int color)
        {
            if (image[r][c] != _color) return;
            image[r][c] = color;
            for (int j = 0; j < 4; j++)
            {
                int _r = r + dr[j], _c = c + dc[j];
                if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt && image[_r][_c] == _color)
                    dfs(image, _r, _c, rcnt, ccnt, _color, color);
            }
        }
    }
}
