using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1524
{
    public class Solution1524 : Interface1524
    {
        /// <summary>
        /// 枚举前缀和
        /// 假定数组sums是arr的前缀和数组，那么arr[i..j]的和为sums[j]-sums[i]
        /// 如果sums[j]-sums[i]是奇数，则sums[i]与sums[j]必须一奇一偶
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int NumOfSubarrays(int[] arr)
        {
            int result = 0, even = 0, odd = 0, len = arr.Length;
            const int MOD = (int)1e9 + 7;
            int[] sums = new int[len + 1];
            for (int i = 0; i < len; i++) sums[i + 1] = sums[i] + arr[i];
            for (int i = 0; i <= len; i++) if ((sums[i] & 1) == 0) even++; else odd++;
            for (int i = 0; i < len; i++)
            {
                if ((sums[i] & 1) == 0) result += odd; else result += even;
                result %= MOD;
                if ((sums[i] & 1) == 0) even--; else odd--;
            }

            return result;
        }
    }
}
