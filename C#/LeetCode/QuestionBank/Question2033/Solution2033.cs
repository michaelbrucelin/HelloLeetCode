using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2033
{
    public class Solution2033 : Interface2033
    {
        /// <summary>
        /// hash + 枚举
        /// 1. 遍历grid，预处理出：1. Dictionary<int, int> 每个值的频次，最小值 min，最大值 max，和 sum
        ///     顺便剪枝，如果两个值的差不是x的倍数，结果为-1
        /// 2. 枚举，维护左，枚举右
        ///     枚举所有的目标值：[min, min+x, min+2x, ... max]
        ///     假定枚举到 min+kx，维护 小于min+kx 的和，可以直接算出 大于 min+kx 的和
        ///     这时可以直接算出目标为 min+kx 的操作数：diff/x
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public int MinOperations(int[][] grid, int x)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length, min = int.MaxValue, max = int.MinValue, sum = 0;
            Dictionary<int, int> freq = new Dictionary<int, int>();
            for (int r = 0, last = grid[0][0], val; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    if (((val = grid[r][c]) - last) % x != 0) return -1;
                    last = val;
                    freq.TryAdd(val, 0); freq[val]++;
                    min = Math.Min(min, val); max = Math.Max(max, val); sum += val;
                }

            int result = int.MaxValue, lsum = 0, lfreq = 0, rsum = sum, rfreq = rcnt * ccnt;
            for (int target = min, tfreq; target <= max; target += x)
            {
                if (freq.TryGetValue(target, out int value)) tfreq = value; else tfreq = 0;
                rsum -= target * tfreq; rfreq -= tfreq;
                result = Math.Min(result, (target * lfreq - lsum + rsum - target * rfreq) / x);
                lsum += target * tfreq; lfreq += tfreq;
            }

            return result;
        }
    }
}
