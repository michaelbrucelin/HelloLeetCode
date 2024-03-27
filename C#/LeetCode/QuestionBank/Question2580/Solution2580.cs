using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2580
{
    public class Solution2580 : Interface2580
    {
        /// <summary>
        /// 排序 + 排列组合
        /// 1. 排序，合并区间
        ///     准确说都不需要分组，直接计数（共多少个组）即可
        /// 2. 排列组合，Cn0 + Cn1 + ... + Cnn
        ///     这一步是二项式，结果是2^n，这里先不优化，手写一个计算组合数玩玩
        /// 
        /// 逻辑没问题，TLE，参考测试用例03
        /// </summary>
        /// <param name="ranges"></param>
        /// <returns></returns>
        public int CountWays(int[][] ranges)
        {
            const int MOD = (int)1e9 + 7;
            Comparer<int[]> comparer = Comparer<int[]>.Create((arr1, arr2) => (arr1[0] - arr2[0]) switch { > 0 => 1, < 0 => -1, _ => (arr1[1] - arr2[1]) switch { > 0 => 1, < 0 => -1, _ => 0 } });
            Array.Sort(ranges, comparer);
            List<int[]> _ranges = new List<int[]>() { ranges[0].ToArray() };
            for (int i = 1; i < ranges.Length; i++)
            {
                if (ranges[i][0] <= _ranges[^1][1])
                    _ranges[^1][1] = Math.Max(_ranges[^1][1], ranges[i][1]);
                else
                    _ranges.Add(ranges[i].ToArray());
            }

            int result = 0, cnt = _ranges.Count;
            for (int i = 0; i <= cnt; i++) result = (result + nCr(cnt, i, MOD)) % MOD;

            return result;
        }

        private int nCr(int n, int r, int MOD)
        {
            if (r == 0 || r == n) return 1;
            if (r == 1 || r == n - 1) return n;

            int[] multip = new int[r];
            for (int i = 0; i < r; i++) multip[i] = n - i;
            Queue<int> divide = new Queue<int>();
            for (int i = 1; i <= r; i++) divide.Enqueue(i);

            while (divide.Count > 0)
            {
                int div = divide.Dequeue();
                for (int i = 0; i < multip.Length; i++)
                {
                    if (multip[i] > 1)
                    {
                        int gcd = GetGCD(multip[i], div);
                        multip[i] /= gcd; div /= gcd;
                        if (div == 1) goto Continue;
                    }
                }
                divide.Enqueue(div);
                Continue:;
            }

            long result = multip[0];
            for (int i = 1; i < r; i++) result = result * multip[i] % MOD;

            return (int)result;
        }

        private int GetGCD(int x, int y)
        {
            if (x == y) return x;

            int move = 0;
            while (x != y) switch ((x & 1, y & 1))
                {
                    case (0, 0): x >>= 1; y >>= 1; move++; break;
                    case (0, 1): x >>= 1; break;
                    case (1, 0): y >>= 1; break;
                    default:  // (1, 1)
                        if (x > y) x = (x - y) >> 1; else y = (y - x) >> 1;
                        break;
                }

            return x << move;
        }
    }
}
