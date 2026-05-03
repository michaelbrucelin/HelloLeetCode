using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0788
{
    public class Solution0788_thread : Interface0788
    {
        private static readonly int[] state = [0, 0, 1, -1, -1, 1, 1, -1, 0, 1];

        /// <summary>
        /// 暴力解的多线程版
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int RotatedDigits(int n)
        {
            int result = 0;
            Parallel.For(1, n + 1, i => { if (check(i)) lock (this) { result++; } });
            return result;

            static bool check(int x)
            {
                int cnt = 0;
                while (x > 0)
                {
                    if (state[x % 10] == -1) return false;
                    cnt += state[x % 10];
                    x /= 10;
                }
                return cnt > 0;
            }
        }

        /// <summary>
        /// 暴力解的多线程版  无锁版
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int RotatedDigits2(int n)
        {
            bool[] result = new bool[n + 1];
            Parallel.For(1, n + 1, i => { if (check(i)) result[i] = true; });
            return result.Count(b => b);

            static bool check(int x)
            {
                int cnt = 0;
                while (x > 0)
                {
                    if (state[x % 10] == -1) return false;
                    cnt += state[x % 10];
                    x /= 10;
                }
                return cnt > 0;
            }
        }
    }
}