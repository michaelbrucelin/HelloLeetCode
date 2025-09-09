using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2327
{
    public class Solution2327 : Interface2327
    {
        /// <summary>
        /// DP
        /// 记录知道秘密1天，2天，...forget-1天的人数
        /// n = 6, delay = 2, forget = 4
        ///    1   2   3   4
        /// 1  1A  0   0   0
        /// 2  0   1A  0   0
        /// 3  1B  0   1A  0
        /// 4  1C  1B  0   1A
        /// 5  1D  1C  1B  0
        /// 6  2EF 1D  1C  1B
        /// </summary>
        /// <param name="n"></param>
        /// <param name="delay"></param>
        /// <param name="forget"></param>
        /// <returns></returns>
        public int PeopleAwareOfSecret(int n, int delay, int forget)
        {
            const int MOD = (int)1e9 + 7;
            int[] dp = new int[forget];
            dp[0] = 1;
            int temp;
            while (--n > 0)
            {
                temp = 0;
                for (int i = forget - 1; i > delay - 1; i--)
                {
                    dp[i] = dp[i - 1];
                    temp = (temp + dp[i - 1]) % MOD;
                }
                for (int i = delay; i > 0; i--) dp[i] = dp[i - 1];
                dp[0] = temp;
            }

            int result = dp[0];
            for (int i = 1; i < forget; i++) result = (result + dp[i]) % MOD;
            return result;
        }

        /// <summary>
        /// 逻辑同PeopleAwareOfSecret，改为使用循环数组来减少计算次数
        /// </summary>
        /// <param name="n"></param>
        /// <param name="delay"></param>
        /// <param name="forget"></param>
        /// <returns></returns>
        public int PeopleAwareOfSecret2(int n, int delay, int forget)
        {
            const int MOD = (int)1e9 + 7;
            int[] dp = new int[forget];
            dp[0] = 1;
            int temp, _n = -1, border = forget * 1000; n--;
            while (++_n < n)
            {
                temp = 0;
                for (int i = forget - 1; i > delay - 1; i--)
                {
                    temp = (temp + dp[(border + i - 1 - _n) % forget]) % MOD;
                }
                dp[(border - _n - 1) % forget] = temp;
            }

            int result = dp[0];
            for (int i = 1; i < forget; i++) result = (result + dp[i]) % MOD;
            return result;
        }

        /// <summary>
        /// 逻辑同PeopleAwareOfSecret2，将计算每一轮新增加的人数的数量改为使用滑动数组的思想解决
        /// </summary>
        /// <param name="n"></param>
        /// <param name="delay"></param>
        /// <param name="forget"></param>
        /// <returns></returns>
        public int PeopleAwareOfSecret3(int n, int delay, int forget)
        {
            throw new NotImplementedException("以后再说，先不做了");
        }
    }
}
