using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2099
{
    public class Solution2099 : Interface2099
    {
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MaxSubsequence(int[] nums, int k)
        {
            Dictionary<int, int> topk = new Dictionary<int, int>();
            int[] _nums = nums.ToArray();
            Array.Sort(_nums, (i1, i2) => i2 - i1);
            for (int i = 0, val; i < k; i++)
            {
                val = _nums[i];
                if (topk.ContainsKey(val)) topk[val]++; else topk.Add(val, 1);
            }

            int[] result = new int[k];
            for (int i = 0, j = 0, val; j < k; i++)
            {
                val = nums[i];
                if (topk.ContainsKey(val))
                {
                    result[j++] = val;
                    if (topk[val] > 1) topk[val]--; else topk.Remove(val);
                }
            }

            return result;
        }
    }
}
