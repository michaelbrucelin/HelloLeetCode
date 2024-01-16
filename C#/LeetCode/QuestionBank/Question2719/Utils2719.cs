using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2719
{
    public class Utils2719
    {
        private const int MOD = 1000000007;  // 10^9 + 7

        public void Dial()
        {
            Utils.Dump(GetDistribution(22), true);
        }

        private long[][] GetDistribution(int len)
        {
            if (len <= 0) return null;

            long[][] dist = new long[len + 1][];
            dist[0] = new long[] { 1 };
            for (int k = 1, cnt; k <= len; k++)  // 计算长度为k的数字的分布情况
            {
                cnt = (k - 1) * 9 + 1;
                dist[k] = new long[k * 9 + 1];
                for (int i = 0; i < 10; i++) for (int j = 0; j < cnt; j++)
                    {
                        dist[k][j + i] += dist[k - 1][j] % MOD;
                        dist[k][j + i] %= MOD;
                    }
            }

            // 将分布数组转为前缀和的形式
            for (int i = 0; i <= len; i++) for (int j = 1; j < dist[i].Length; j++)
                {
                    dist[i][j] += dist[i][j - 1];
                    dist[i][j] %= MOD;
                }

            return dist;
        }
    }
}
