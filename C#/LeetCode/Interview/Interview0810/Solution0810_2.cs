using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0810
{
    public class Solution0810_2 : Interface0810
    {
        private static readonly int[] dirs = new int[] { 0, 1, 0, -1, 0 };

        /// <summary>
        /// DFS
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
            dfs(image, sr, sc, rcnt, ccnt, image[sr][sc], newColor);

            return image;
        }

        private void dfs(int[][] image, int sr, int sc, int rcnt, int ccnt, int curr, int newColor)
        {
            image[sr][sc] = newColor;
            for (int i = 0, _r, _c; i < 4; i++)
            {
                _r = sr + dirs[i]; _c = sc + dirs[i + 1];
                if (_r < 0 || _r >= rcnt || _c < 0 || _c >= ccnt) continue;
                if (image[_r][_c] == curr) dfs(image, _r, _c, rcnt, ccnt, curr, newColor);
            }
        }

        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="image"></param>
        /// <param name="sr"></param>
        /// <param name="sc"></param>
        /// <param name="newColor"></param>
        /// <returns></returns>
        public int[][] FloodFill2(int[][] image, int sr, int sc, int newColor)
        {
            if (image[sr][sc] == newColor) return image;

            int rcnt = image.Length, ccnt = image[0].Length, curr = image[sr][sc];
            image[sr][sc] = newColor;
            for (int i = 0, _r, _c; i < 4; i++)
            {
                _r = sr + dirs[i]; _c = sc + dirs[i + 1];
                if (_r < 0 || _r >= rcnt || _c < 0 || _c >= ccnt) continue;
                if (image[_r][_c] == curr) FloodFill2(image, _r, _c, newColor);
            }

            return image;
        }
    }
}
