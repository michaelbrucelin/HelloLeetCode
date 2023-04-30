using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0982
{
    public class Solution0982 : Interface0982
    {
        /// <summary>
        /// 暴力解
        /// 先暴力解试探一下，在英文区提交能过，在中文区提交超时
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountTriplets(int[] nums)
        {
            int result = 0, len = nums.Length, len2 = nums.Length * nums.Length;
            for (int i = 0; i < len; i++)
            {
                if (nums[i] == 0) result += len2;
                else for (int j = 0; j < len; j++)
                    {
                        if ((nums[i] & nums[j]) == 0) result += len;
                        else for (int k = 0; k < len; k++)
                                if ((nums[i] & nums[j] & nums[k]) == 0) result++;
                    }
            }

            return result;
        }

        /// <summary>
        /// 在CountTriplets()基础上略加优化
        /// 先暴力计算出所有两个元素“与”的结果，然后再用这个结果与第三个元素与运算
        /// 
        /// 效果出奇的好，远远没想到，测试用例3的用时从5.99s 7.07s 6.03s降为0.05s左右
        /// 应该是“计算二元组”时，由大量的重复结果，从而导致下一次循环次数骤减导致的，猜测的，没有去验证
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountTriplets2(int[] nums)
        {
            int result = 0, len = nums.Length;
            Dictionary<int, int> buffer = new Dictionary<int, int> { { 0, 0 } };
            int _key; for (int i = 0; i < len; i++)
            {
                if (nums[i] == 0) buffer[0] += len;
                else for (int j = 0; j < len; j++)
                    {
                        if (nums[j] == 0) buffer[0]++;
                        else
                        {
                            _key = nums[i] & nums[j]; buffer.TryAdd(_key, 0); buffer[_key]++;
                        }
                    }
            }
            foreach (var kv in buffer)
            {
                if (kv.Key == 0) result += kv.Value * len;
                else for (int k = 0; k < len; k++)
                    {
                        if (nums[k] == 0 || (kv.Key & nums[k]) == 0) result += kv.Value;
                    }
            }

            return result;
        }
    }
}
