using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1524
{
    public class Solution1524_3 : Interface1524
    {
        /// <summary>
        /// 维护左，枚举右
        /// 本质上就是前缀和，记录前缀和前面有多少个偶数，多少个奇数即可
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int NumOfSubarrays(int[] arr)
        {
            const int MOD = (int)1e9 + 7;
            int result = 0, sum = 0, even = 1, odd = 0, len = arr.Length;
            for (int i = 0; i < len; i++)
            {
                if (((sum += arr[i]) & 1) == 0)
                {
                    even++; result += odd; result %= MOD;
                }
                else
                {
                    odd++; result += even; result %= MOD;
                }
            }

            return result;
        }
    }
}
