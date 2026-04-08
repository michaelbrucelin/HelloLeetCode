using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3653
{
    public class Solution3653 : Interface3653
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public int XorAfterQueries(int[] nums, int[][] queries)
        {
            int len = nums.Length;
            const int MOD = (int)1e9 + 7;
            long[] buffer = new long[len];
            Array.Copy(nums, buffer, len);
            foreach (int[] query in queries)
            {
                for (int i = query[0]; i <= query[1]; i += query[2]) buffer[i] = buffer[i] * query[3] % MOD;
            }

            long result = 0;
            for (int i = 0; i < len; i++) result ^= buffer[i];
            return (int)result;
        }
    }
}
