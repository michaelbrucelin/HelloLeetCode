using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0974
{
    public class Solution0974 : Interface0974
    {
        /// <summary>
        /// 前缀和，前缀取余
        /// 维护左，枚举右，如果非空子数组[x..y]对k整除，则[0..x-1]与[0..y]对k同余
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int SubarraysDivByK(int[] nums, int k)
        {
            int result = 0;
            int[] mods = new int[k];
            mods[0] = 1;
            for (int i = 0, mod = 0, len = nums.Length; i < len; i++)
            {
                mod = ((mod + nums[i]) % k + k) % k;
                result += mods[mod];
                mods[mod]++;
            }

            return result;
        }
    }
}
