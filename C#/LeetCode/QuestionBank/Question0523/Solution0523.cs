using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0523
{
    public class Solution0523 : Interface0523
    {
        /// <summary>
        /// 遍历
        /// 遍历的同时记录下“前缀对K的模”即可
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool CheckSubarraySum(int[] nums, int k)
        {
            long sum = 0, mod; int len = nums.Length;
            Dictionary<long, int> map = new Dictionary<long, int> { { 0, -1 } };
            for (int i = 0; i < len; i++)
            {
                mod = (sum += nums[i]) % k;
                if (map.TryGetValue(mod, out int idx))
                {
                    if (i - idx > 1) return true;
                }
                else
                {
                    map.Add(mod, i);
                }
            }

            return false;
        }
    }
}
