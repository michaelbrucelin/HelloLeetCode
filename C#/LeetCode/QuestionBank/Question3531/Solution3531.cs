using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3531
{
    public class Solution3531 : Interface3531
    {
        /// <summary>
        /// Hash
        /// 预处理出来每一个横行和每一竖列的最大值与最小值即可
        /// </summary>
        /// <param name="n"></param>
        /// <param name="buildings"></param>
        /// <returns></returns>
        public int CountCoveredBuildings(int n, int[][] buildings)
        {
            int result = 0, x, y;
            Dictionary<int, int[]> xmap = new Dictionary<int, int[]>(), ymap = new Dictionary<int, int[]>();
            foreach (int[] build in buildings)
            {
                x = build[0]; y = build[1];
                if (xmap.TryGetValue(x, out int[] _x)) { _x[0] = Math.Min(_x[0], y); _x[1] = Math.Max(_x[1], y); } else xmap.Add(x, [y, y]);
                if (ymap.TryGetValue(y, out int[] _y)) { _y[0] = Math.Min(_y[0], x); _y[1] = Math.Max(_y[1], x); } else ymap.Add(y, [x, x]);
            }

            foreach (int[] build in buildings)
            {
                x = build[0]; y = build[1];
                if (xmap.TryGetValue(x, out int[] xinfo) && ymap.TryGetValue(y, out int[] yinfo))
                {
                    if (x > yinfo[0] && x < yinfo[1] && y > xinfo[0] && y < xinfo[1]) result++;
                }
            }

            return result;
        }
    }
}
