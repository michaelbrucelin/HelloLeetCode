using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2507
{
    public class Solution2507 : Interface2507
    {
        /// <summary>
        /// 线性筛 + 递归
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int SmallestValue(int n)
        {
            List<int> list = GetPrimes(n + 1);
            HashSet<int> set = new HashSet<int>(list);

            return _SmallestValue(n);

            int _SmallestValue(int x)
            {
                if (set.Contains(x)) return x;
                int _x = 0, sqrt = (int)Math.Sqrt(x);
                foreach (int y in list)
                {
                    if (y <= sqrt) while (x % y == 0) { _x += y; x /= y; } else break;
                }
                if (x > 1) _x += x;
                if (_x == 4) return 4;  // 很容易证明4是唯一需要单独处理的，其余的值都单调递减
                return _SmallestValue(_x);
            }
        }

        private List<int> GetPrimes(int n)
        {
            List<int> result = new List<int>();
            bool[] mask = new bool[n]; Array.Fill(mask, true);
            for (int i = 2; i < n; i++)
            {
                if (mask[i]) result.Add(i);
                for (int j = 0; j < result.Count && i * result[j] < n; j++)
                {
                    mask[i * result[j]] = false;
                    if (i % result[j] == 0) break;
                }
            }

            return result;
        }
    }
}
