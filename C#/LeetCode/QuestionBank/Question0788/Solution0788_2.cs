using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0788
{
    public class Solution0788_2 : Interface0788
    {
        private static List<int> memory = [0];
        private static readonly int[] state = [0, 0, 1, -1, -1, 1, 1, -1, 0, 1];

        /// <summary>
        /// 缓存 + 懒更新
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int RotatedDigits(int n)
        {
            for (int i = memory.Count; i <= n; i++) memory.Add(memory[i - 1] + check(i));
            return memory[n];

            static int check(int x)
            {
                int cnt = 0;
                while (x > 0)
                {
                    if (state[x % 10] == -1) return 0;
                    cnt += state[x % 10];
                    x /= 10;
                }
                return Math.Sign(cnt);
            }
        }
    }
}
