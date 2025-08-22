using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2507
{
    public class Solution2507_2 : Interface2507
    {
        /// <summary>
        /// 线性筛 + 迭代
        /// 逻辑与Solution2507完全一样，只是将递归改为了迭代
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int SmallestValue(int n)
        {
            List<int> list = GetPrimes(n + 1);
            HashSet<int> set = new HashSet<int>(list);

            int _n, sqrt;
            while (n != 4 && !set.Contains(n))  // 很容易证明4是唯一需要单独处理的，其余的值都单调递减
            {
                _n = 0; sqrt = (int)Math.Sqrt(n);
                foreach (int x in list)
                {
                    if (x <= sqrt) while (n % x == 0) { _n += x; n /= x; } else break;
                }
                if (n > 1) _n += n;
                n = _n;
            }

            return n;
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
