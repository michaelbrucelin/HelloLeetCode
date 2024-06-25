using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2732
{
    public class Solution2732 : Interface2732
    {
        /// <summary>
        /// 数学题
        /// 如果有解，必然有“只有1行或2行”的解，证明见Solution2732.md
        /// 有了上面的基础，
        ///     如果解只有1行，那必然全是0
        ///     如果解只有2行，那必然两行是不同的
        /// 所以把每一行转为一个整型，然后暴力查找即可。
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public IList<int> GoodSubsetofBinaryMatrix(int[][] grid)
        {
            // if (grid.Length == 1) return [0];  // 画蛇添足了

            int rcnt = grid.Length, ccnt = grid[0].Length;
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int r = 0, val; r < rcnt; r++)
            {
                val = grid[r][0];
                for (int c = 1; c < ccnt; c++) val |= grid[r][c] << c;
                if (val == 0) return [r];
                map.TryAdd(val, r);
            }

            foreach (int k1 in map.Keys) foreach (int k2 in map.Keys)
                {
                    if ((k1 & k2) == 0) return [map[k1], map[k2]];
                }

            return [];
        }
    }
}
