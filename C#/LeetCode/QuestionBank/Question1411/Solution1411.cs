using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1411
{
    public class Solution1411 : Interface1411
    {
        /// <summary>
        /// DP
        /// 如果只有一行，供12种可能，且6种ABA形式的，6种ABC形式的
        /// 对于下一行：ABA -> BAB, BCB, CAC, BAC, CAB
        ///             ABC -> BAB, BCB,      BCA, CAB
        ///             这样，映射关系就出来了
        /// 可以使用矩阵快速幂加速这个计算，这里先不加速，先DP写一下
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumOfWays(int n)
        {
            if (n == 1) return 12;

            const int MOD = (int)1e9 + 7;
            long cnt2 = 6, cnt3 = 6;
            while (--n > 0) (cnt2, cnt3) = ((cnt2 * 3 + cnt3 * 2) % MOD, (cnt2 * 2 + cnt3 * 2) % MOD);

            return (int)((cnt2 + cnt3) % MOD);
        }

        /// <summary>
        /// 逻辑与NumOfWays()完全一样，使用位运算试一下
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumOfWays2(int n)
        {
            if (n == 1) return 12;

            const int MOD = (int)1e9 + 7;
            long cnt2 = 6, cnt3 = 6;
            while (--n > 0) (cnt2, cnt3) = ((cnt2 * 3 + (cnt3 << 1)) % MOD, ((cnt2 << 1) + (cnt3 << 1)) % MOD);

            return (int)((cnt2 + cnt3) % MOD);
        }
    }
}
