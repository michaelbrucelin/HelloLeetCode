using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2681
{
    public class Solution2681_3 : Interface2681
    {
        /// <summary>
        /// 与SumOfPower()逻辑一样，递推的计算N
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SumOfPower(int[] nums)
        {
            const int MOD = 1000000007;
            Array.Sort(nums);
            long result = 0; int len = nums.Length;
            for (int i = 0, num; i < len; i++)
            {
                num = nums[i]; result = (result + ((long)num) * num % MOD * num % MOD) % MOD;
            }

            int N = 0;
            for (int i = 0; i < len; i++)
            {
                N = ((N << 1) % MOD + nums[i]) % MOD;
            }
            for (int i = len - 1, num; i > 0; i--)
            {
                num = nums[i]; N -= num; while (N < 0 || (N & 1) != 0) N += MOD; N >>= 1;
                result = (result + ((long)num) * num % MOD * N % MOD) % MOD;
            }

            return (int)result;
        }

        /// <summary>
        /// 与SumOfPower()逻辑一样，既然N可以从前向后遍历递推计算，结果也是一样的
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SumOfPower2(int[] nums)
        {
            const int MOD = 1000000007;
            Array.Sort(nums);
            long result = 0; int N = 0, len = nums.Length;
            for (int i = 0, num; i < len; i++)
            {
                num = nums[i];
                result = (result + ((long)num) * num % MOD * num % MOD) % MOD;
                result = (result + ((long)num) * num % MOD * N % MOD) % MOD;
                N = ((N << 1) % MOD + num) % MOD;
            }

            return (int)result;
        }
    }
}
