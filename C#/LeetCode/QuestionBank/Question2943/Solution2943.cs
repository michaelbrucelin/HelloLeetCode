using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2943
{
    public class Solution2943 : Interface2943
    {
        /// <summary>
        /// 贪心
        /// 删除连续的才有意义，横向和竖向比有交集，所以找出横向与竖向各自最大值的较小值即可
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <param name="hBars"></param>
        /// <param name="vBars"></param>
        /// <returns></returns>
        public int MaximizeSquareHoleArea(int n, int m, int[] hBars, int[] vBars)
        {
            if (hBars.Length == 0 || vBars.Length == 0) return 1;
            if (hBars.Length == 1 || vBars.Length == 1) return 4;

            Array.Sort(hBars);
            Array.Sort(vBars);
            int h = 1, _h = 1, v = 1, _v = 1, len;
            len = hBars.Length;
            for (int i = 1; i < len; i++)
            {
                if (hBars[i] == hBars[i - 1] + 1) _h++; else { h = Math.Max(h, _h); _h = 1; }
            }
            h = Math.Max(h, _h);
            len = vBars.Length;
            for (int i = 1; i < len; i++)
            {
                if (vBars[i] == vBars[i - 1] + 1) _v++; else { v = Math.Max(v, _v); _v = 1; }
            }
            v = Math.Max(v, _v);

            int l = Math.Min(h, v) + 1;
            return l * l;
        }
    }
}
