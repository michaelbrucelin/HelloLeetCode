using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2681
{
    public class Solution2681_2 : Interface2681
    {
        /// <summary>
        /// 排序 + 排列组合
        /// 具体见Solution2681_2.md
        /// 
        /// 逻辑没问题，提交依然超时，慢就慢在初始化N上面
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SumOfPower2(int[] nums)
        {
            const int MOD = 1000000007;
            Array.Sort(nums);
            long result = 0; int len = nums.Length;
            for (int i = 0, num; i < len; i++)
            {
                num = nums[i]; result = (result + ((long)num) * num % MOD * num % MOD) % MOD;
            }

            int N = 0;
            for (int i = 0, num; i < len; i++)
            {
                num = nums[i]; for (int j = 0; j < len - i - 1; j++) num = (num << 1) % MOD;
                N = (N + num) % MOD;
            }
            for (int i = len - 1, num; i > 0; i--)
            {
                num = nums[i]; N -= num; while (N < 0 || (N & 1) != 0) N += MOD; N >>= 1;
                result = (result + ((long)num) * num % MOD * N % MOD) % MOD;
            }

            return (int)result;
        }

        /// <summary>
        /// 与SumOfPower()逻辑一样，优化初始化N
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

            long N = 0, _num; int W = 32;
            for (int i = 0, j; i < len; i++)
            {
                _num = nums[i]; for (j = len - i - 1; j > W; j -= W) _num = (_num << W) % MOD; _num = (_num << j) % MOD;
                N = (N + _num) % MOD;
            }
            for (int i = len - 1, num; i > 0; i--)
            {
                num = nums[i]; N -= num; while (N < 0 || (N & 1) != 0) N += MOD; N >>= 1;
                result = (result + ((long)num) * num % MOD * N % MOD) % MOD;
            }

            return (int)result;
        }
    }
}
