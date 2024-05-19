using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1535
{
    public class Solution1535 : Interface1535
    {
        /// <summary>
        /// 分析
        /// 1. 如果最大值到了arr[0]的位置，那么arr[0]就不再变化
        /// 2. 如果游戏再进行到最大值之前产生了赢家，返回这个赢家，否则，最大值就是赢家
        /// 3. 如果不考虑“循环”，每个值的得分
        ///     1. 如果前面的最大值比其小，得1分
        ///     2. 后面有N个连续比其小的值，得N分
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int GetWinner(int[] arr, int k)
        {
            if (k == 1) return Math.Max(arr[0], arr[1]);

            int score = 0, max = arr[0], len = arr.Length;
            for (int i = 1, val; i < len; i++)
            {
                val = arr[i];
                if (val < max)
                {
                    if (++score >= k) return max;
                }
                else  // if (val > max) 题目限定没有重复值
                {
                    max = val; score = 1;
                }
            }

            return max;
        }
    }
}
