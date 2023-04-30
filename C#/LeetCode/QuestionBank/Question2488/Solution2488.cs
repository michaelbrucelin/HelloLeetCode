using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2488
{
    public class Solution2488 : Interface2488
    {
        /// <summary>
        /// 分析
        /// 从中间向两边扩散即可，具体见Solution2488.md
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int CountSubarrays(int[] nums, int k)
        {
            int kid, len = nums.Length;
            for (kid = 0; kid < len; kid++) if (nums[kid] == k) break;

            Dictionary<int, int> left = new Dictionary<int, int>() { { 0, 1 } };
            for (int i = kid - 1, key = 0; i >= 0; i--)
            {
                if (nums[i] < k) key++; else key--;  // 题目保证数组元素不同，此处非小即大
                left.TryAdd(key, 0); left[key]++;
            }

            int result = 0;
            for (int i = kid, key = 1; i < len; i++)
            {
                if (nums[i] > k) key++; else key--;  // 题目保证数组元素不同，此处非小即大
                result += left.ContainsKey(key) ? left[key] : 0;
                result += left.ContainsKey(key - 1) ? left[key - 1] : 0;
            }

            return result;
        }

        /// <summary>
        /// 与CountSubarrays()一样，对1与n两个极值做特殊处理
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int CountSubarrays2(int[] nums, int k)
        {
            int len = nums.Length;
            if (k == 1)
            {
                if (len <= 2) return len;
                if (nums[0] == k || nums[len - 1] == k) return 2;
                return 3;
            }
            if (k == len) return 1;

            int kid; for (kid = 0; kid < len; kid++) if (nums[kid] == k) break;
            Dictionary<int, int> left = new Dictionary<int, int>() { { 0, 1 } };
            for (int i = kid - 1, key = 0; i >= 0; i--)
            {
                if (nums[i] < k) key++; else key--;  // 题目保证数组元素不同，此处非小即大
                left.TryAdd(key, 0); left[key]++;
            }

            int result = 0;
            for (int i = kid, key = 1; i < len; i++)
            {
                if (nums[i] > k) key++; else key--;  // 题目保证数组元素不同，此处非小即大
                result += left.ContainsKey(key) ? left[key] : 0;
                result += left.ContainsKey(key - 1) ? left[key - 1] : 0;
            }

            return result;
        }

        /// <summary>
        /// 与CountSubarrays2()一样，将符号处理改为库函数Math.Sigh()
        /// 不确认库函数内部是不是直接调用的位运算，取符号位的值，如果是的话，理论上会更快
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int CountSubarrays3(int[] nums, int k)
        {
            int len = nums.Length;
            if (k == 1)
            {
                if (len <= 2) return len;
                if (nums[0] == k || nums[len - 1] == k) return 2;
                return 3;
            }
            if (k == len) return 1;

            int kid; for (kid = 0; kid < len; kid++) if (nums[kid] == k) break;
            Dictionary<int, int> left = new Dictionary<int, int>() { { 0, 1 } };
            for (int i = kid - 1, key = 0; i >= 0; i--)
            {
                key += Math.Sign(k - nums[i]);
                left.TryAdd(key, 0); left[key]++;
            }

            int result = 0;
            result += left.ContainsKey(0) ? left[0] : 0;
            result += left.ContainsKey(-1) ? left[-1] : 0;
            for (int i = kid + 1, key = 0; i < len; i++)
            {
                key += Math.Sign(nums[i] - k);
                result += left.ContainsKey(key) ? left[key] : 0;
                result += left.ContainsKey(key - 1) ? left[key - 1] : 0;
            }

            return result;
        }
    }
}
