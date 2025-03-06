using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2588
{
    public class Solution2588 : Interface2588
    {
        /// <summary>
        /// 类前缀和
        /// 1. 如果一个数组是美丽的，那么每一位上的1的数量一定是偶数
        ///     翻译成代码的话就是数组的 异或 结果是0
        /// 2. 类似于前缀和的思想，预处理每一个前缀数组的异或结果
        /// 3. 然后枚举每一个子数组，O(n^2)，大概率会TLE，先写出来再想办法优化
        /// 
        /// 逻辑没问题，意料之中的TLE，参考测试用例03
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long BeautifulSubarrays(int[] nums)
        {
            long result = 0;
            int len = nums.Length;
            int[] xors = new int[len + 1];
            for (int i = 0; i < len; i++) xors[i + 1] = xors[i] ^ nums[i];
            for (int i = 0; i < len; i++) for (int j = i; j < len; j++) if ((xors[j + 1] ^ xors[i]) == 0) result++;

            return result;
        }
    }
}
