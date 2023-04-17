using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0810
{
    public class Solution0810 : Interface0810
    {
        private static readonly int[] dirs = new int[] { 0, 1, 0, -1, 0 };

        /// <summary>
        /// BFS
        /// “逐层”BFS
        /// </summary>
        /// <param name="image"></param>
        /// <param name="sr"></param>
        /// <param name="sc"></param>
        /// <param name="newColor"></param>
        /// <returns></returns>
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            if (image[sr][sc] == newColor) return image;

            int rcnt = image.Length, ccnt = image[0].Length;
            int curr = image[sr][sc];
            Queue<(int r, int c)> queue = new Queue<(int r, int c)>();
            queue.Enqueue((sr, sc));
            int cnt; while ((cnt = queue.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    var p = queue.Dequeue();
                    image[p.r][p.c] = newColor;
                    for (int j = 0, _r, _c; j < 4; j++)
                    {
                        _r = p.r + dirs[j]; _c = p.c + dirs[j + 1];
                        if (_r < 0 || _r >= rcnt || _c < 0 || _c >= ccnt) continue;
                        if (image[_r][_c] == curr) queue.Enqueue((_r, _c));
                    }
                }
            }

            return image;
        }

        /// <summary>
        /// BFS
        /// “逐个”BFS
        /// </summary>
        /// <param name="image"></param>
        /// <param name="sr"></param>
        /// <param name="sc"></param>
        /// <param name="newColor"></param>
        /// <returns></returns>
        public int[][] FloodFill2(int[][] image, int sr, int sc, int newColor)
        {
            if (image[sr][sc] == newColor) return image;

            int rcnt = image.Length, ccnt = image[0].Length;
            int curr = image[sr][sc];
            Queue<(int r, int c)> queue = new Queue<(int r, int c)>();
            queue.Enqueue((sr, sc));
            while (queue.Count > 0)
            {
                var p = queue.Dequeue();
                image[p.r][p.c] = newColor;
                for (int j = 0, _r, _c; j < 4; j++)
                {
                    _r = p.r + dirs[j]; _c = p.c + dirs[j + 1];
                    if (_r < 0 || _r >= rcnt || _c < 0 || _c >= ccnt) continue;
                    if (image[_r][_c] == curr) queue.Enqueue((_r, _c));
                }
            }

            return image;
        }
    }
}
