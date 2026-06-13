using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1524
{
    public class Solution1524_2 : Interface1524
    {
        /// <summary>
        /// 维护左，枚举右
        /// 底层逻辑与Solution1524相同
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int NumOfSubarrays(int[] arr)
        {
            int result = 0, sum = 0, len = arr.Length;
            int[] cnts = [1, 0];                        // cnts[0] 偶数数量 cnts[1] 奇数数量
            const int MOD = (int)1e9 + 7;
            for (int i = 0; i < len; i++)
            {
                sum = (sum + arr[i]) & 1;
                result = (result + cnts[1 - sum]) % MOD;
                cnts[sum]++;
            }

            return result;
        }
    }
}
