using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3537
{
    public class Solution3537 : Interface3537
    {
        /// <summary>
        /// 构造 + 递归
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int[][] SpecialGrid(int n)
        {
            int N = 1 << n;
            int[][] result = new int[N][];
            for (int i = 0; i < N; i++) result[i] = new int[N];
            rec(0, N - 1, 0, N - 1, 0, (1 << (n << 1)) - 1);

            return result;

            void rec(int r1, int r2, int c1, int c2, int x1, int x2)
            {
                if (r1 == r2) { result[r1][c1] = x1; return; }

                int rm = r1 + ((r2 - r1) >> 1), cm = c1 + ((c2 - c1) >> 1), span = (x2 - x1 + 1) >> 2, x = x1;
                rec(r1, rm, cm + 1, c2, x + span * 0, x + span * 1 - 1);
                rec(rm + 1, r2, cm + 1, c2, x + span * 1, x + span * 2 - 1);
                rec(rm + 1, r2, c1, cm, x + span * 2, x + span * 3 - 1);
                rec(r1, rm, c1, cm, x + span * 3, x + span * 4 - 1);
            }
        }
    }
}
