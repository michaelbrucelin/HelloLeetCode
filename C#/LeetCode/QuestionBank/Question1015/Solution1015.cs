using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1015
{
    public class Solution1015 : Interface1015
    {
        private static readonly int[] map1 = [1, 0, 9, 8, 7, 6, 5, 4, 3, 2];
        private static readonly int[][] map2 = [                              // map2[i][j]表示 j * map2[i][j] % 10 = i
            [ 0, -1, -1, -1, -1, -1, -1, -1, -1, -1],
            [-1,  1, -1,  7, -1, -1, -1,  3, -1,  9],
            [-1,  2, 16, -1, 38, -1, 27, -1, 49, -1],                         // 目标为2，有多个解
            [-1,],
            [-1,],
            [-1,],
            [-1,],
            [-1,],
            [-1,],
            [-1,]];

        /// <summary>
        /// 模拟乘法
        /// 具体分析见Solution1015.md
        /// </summary>
        /// <param name="k"></param>
        /// <returns></returns>
        public int SmallestRepunitDivByK(int k)
        {
            if ((k & 1) != 1 || k % 10 == 5) return -1;

            List<int> result = [0], digits = [];
            while (k > 0) { digits.Add(k % 10); k /= 10; }
            for (int i = 0, target; i < result.Count; i++)
            {
                if (result[i] == 1) continue;
                target = map1[result[i]];
            }

            return result.Count;
        }
    }
}
