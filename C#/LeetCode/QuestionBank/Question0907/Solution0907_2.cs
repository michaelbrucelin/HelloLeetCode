using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0907
{
    public class Solution0907_2 : Interface0907
    {
        /// <summary>
        /// 贡献法
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int SumSubarrayMins(int[] arr)
        {
            long result = 0;
            int len = arr.Length; const int MOD = 1000000007;
            for (int i = 0, lcnt, rcnt; i < len; i++)
            {
                lcnt = rcnt = 0;
                for (int j = i - 1; j >= 0 && arr[j] >= arr[i]; j--, lcnt++) ;
                for (int j = i + 1; j < len && arr[j] > arr[i]; j++, rcnt++) ;
                result += ((long)arr[i]) * (lcnt + 1) * (rcnt + 1) % MOD;
                result %= MOD;
            }

            return (int)result;
        }
    }
}
