using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2731
{
    public class Solution2731 : Interface2731
    {
        /// <summary>
        /// 数学
        /// 1. 由于计算的是两两机器人之间的距离，所以机器人之间无差别，即机器人相撞等于没撞
        /// 2. 那么可以将机器人移动后的位置排序，然后统计两两机器人之间的距离之和
        /// 假定一共有6个机器人，那么从左向右有5段距离
        ///     第1段距离被计算了 1 * 5 = 5 次，左边1个机器人，右边5个机器人
        ///     第2段距离被计算了 2 * 4 = 8 次，左边2个机器人，右边4个机器人
        ///     第3段距离被计算了 3 * 3 = 9 次，左边3个机器人，右边3个机器人
        ///     第4段距离被计算了 4 * 2 = 8 次，左边4个机器人，右边2个机器人
        ///     第5段距离被计算了 5 * 1 = 5 次，左边5个机器人，右边1个机器人
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="s"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public int SumDistance(int[] nums, string s, int d)
        {
            int len = nums.Length;
            long[] pos = new long[len];
            for (int i = 0; i < len; i++)
                pos[i] = nums[i] + ((long)d) * ((((s[i] >> 1) & 1) << 1) - 1);  // L 01001100  R 01010010
            Array.Sort(pos);

            const int MOD = 1000000007;
            long result = 0;
            for (long i = 1; i < len; i++)
            {
                result += ((pos[i] - pos[i - 1]) % MOD) * (i * (len - i) % MOD) % MOD;
            }
            result %= MOD;

            return (int)result;
        }
    }
}
