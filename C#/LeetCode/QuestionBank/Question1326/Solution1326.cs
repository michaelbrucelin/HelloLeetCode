using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1326
{
    public class Solution1326 : Interface1326
    {
        /// <summary>
        /// 贪心法
        /// 1. 从头开始计算，计算出以当前点为起点的最远喷洒范围，例如
        ///     ranges = [  3,   4,  1,  1,  0,  0]
        ///               -3~3 -3~5 1~3 2~4 4~4 5~5
        ///                0~3  0~5 1~3 2~4 4~4 5~5
        ///     farest = [  5,   3,  4,  0,  4,  5]
        /// 2. 有了farest数组，那么取起点为0的最远距离d0，然后取起点为1~d0中最远距离d1，再取d0+1~d1之间最远距离d2... ...
        /// 证明，画个图，反证法可以证明。
        /// </summary>
        /// <param name="n"></param>
        /// <param name="ranges"></param>
        /// <returns></returns>
        public int MinTaps(int n, int[] ranges)
        {
            int[] farest = new int[n + 1];  // n = ranges.Length - 1
            for (int i = 0, start; i <= n; i++)
            {
                start = Math.Max(i - ranges[i], 0);
                farest[start] = Math.Max(start, i + ranges[i]);
            }
            if (farest[0] == 0) return -1;

            int step = 1, prev = 0, curr = farest[0], post = farest[0];
            while (curr < n)
            {
                for (int i = prev + 1; i <= curr; i++) post = Math.Max(post, farest[i]);
                if (post == curr) return -1;

                step++; prev = curr; curr = post;
            }

            return step;
        }
    }
}
