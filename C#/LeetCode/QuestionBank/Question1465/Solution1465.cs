using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1465
{
    public class Solution1465 : Interface1465
    {
        /// <summary>
        /// 排序
        /// 排序，分别找出横纵两个方向的最大间隔
        /// </summary>
        /// <param name="h"></param>
        /// <param name="w"></param>
        /// <param name="horizontalCuts"></param>
        /// <param name="verticalCuts"></param>
        /// <returns></returns>
        public int MaxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts)
        {
            const int MOD = 1000000007;
            long height, width, lenh = horizontalCuts.Length, lenw = verticalCuts.Length;
            Array.Sort(horizontalCuts); Array.Sort(verticalCuts);
            height = Math.Max(horizontalCuts[0], h - horizontalCuts[lenh - 1]);
            width = Math.Max(verticalCuts[0], w - verticalCuts[lenw - 1]);
            for (int i = 1, _h; i < lenh; i++)
            {
                if ((_h = horizontalCuts[i] - horizontalCuts[i - 1]) > height) height = _h;
                if (horizontalCuts[lenh - 1] - horizontalCuts[i] - (lenh - i - 2) <= height) break;
            }
            for (int i = 1, _w; i < lenw; i++)
            {
                if ((_w = verticalCuts[i] - verticalCuts[i - 1]) > width) width = _w;
                if (verticalCuts[lenw - 1] - verticalCuts[i] - (lenw - i - 2) <= width) break;
            }

            return (int)(width * height % MOD);
        }
    }
}
