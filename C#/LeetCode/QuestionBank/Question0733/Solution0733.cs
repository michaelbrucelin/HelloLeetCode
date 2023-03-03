using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0733
{
    public class Solution0733 : Interface0733
    {
        private static readonly int[] dr = new int[] { -1, 0, 1, 0 };  // 上 右 下 左
        private static readonly int[] dc = new int[] { 0, 1, 0, -1 };  // 上 右 下 左

        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="image"></param>
        /// <param name="sr"></param>
        /// <param name="sc"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public int[][] FloodFill(int[][] image, int sr, int sc, int color)
        {
            if (image[sr][sc] == color) return image;

            int _color = image[sr][sc], rcnt = image.Length, ccnt = image[0].Length;
            Queue<(int r, int c)> queue = new Queue<(int r, int c)>(); queue.Enqueue((sr, sc));
            int cnt; while ((cnt = queue.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    var point = queue.Dequeue(); image[point.r][point.c] = color;
                    for (int j = 0; j < 4; j++)
                    {
                        int _r = point.r + dr[j], _c = point.c + dc[j];
                        if (_r >= 0 && _r < rcnt && _c >= 0 && _c < ccnt && image[_r][_c] == _color)
                            queue.Enqueue((_r, _c));
                    }
                }
            }

            return image;
        }
    }
}
