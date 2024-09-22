using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3289
{
    public class Solution3289_2 : Interface3289
    {
        /// <summary>
        /// 位运算
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] GetSneakyNumbers(int[] nums)
        {
            int n = nums.Length;
            int xor = 0;
            for (int i = 0; i < n; i++) xor ^= nums[i];
            for (int i = 0; i < n - 2; i++) xor ^= i;

            int x = 0, mask = xor & (-xor);
            for (int i = 0; i < n; i++) if ((nums[i] & mask) == 0) x ^= nums[i];
            for (int i = 0; i < n - 2; i++) if ((i & mask) == 0) x ^= i;

            return [x, x ^ xor];
        }
    }
}
