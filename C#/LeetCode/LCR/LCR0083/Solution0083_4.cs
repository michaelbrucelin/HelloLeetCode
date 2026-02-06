using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0083
{
    public class Solution0083_4 : Interface0083
    {
        /// <summary>
        /// 原地交换
        /// 参考LeetCode.Interview.Interview0807.Solution0807_oth.md
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> result = [];
            result.Add(nums);
            int n = nums.Length, t;
            for (int i = 0; i < n - 1; i++) for (int k = result.Count - 1; k >= 0; k--) for (int j = i + 1; j < n; j++)
                    {
                        int[] next = [.. result[k]];
                        t = next[i]; next[i] = next[j]; next[j] = t;
                        result.Add(next);
                    }

            return result;
        }
    }
}
