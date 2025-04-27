using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2845
{
    public class Solution2845 : Interface2845
    {
        /// <summary>
        /// 贡献法
        /// 1. 先统计出所有 nums[i] % modulo == k 的位置
        /// 2. 然后遍历长度是k,k+modulo,k+2*modulo,...的子数组的“贡献值”是多少
        /// 感觉还是会TLE
        /// 
        /// 逻辑没问题，意料之中的TLE，参考测试用例03
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="modulo"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public long CountInterestingSubarrays(IList<int> nums, int modulo, int k)
        {
            int cnt = nums.Count;
            List<int> ids = new() { -1 };
            for (int i = 0; i < cnt; i++) if (nums[i] % modulo == k) ids.Add(i);
            ids.Add(cnt);
            cnt = ids.Count;

            long result = 0;
            if (k == 0) for (int i = 1, _cnt; i < cnt; i++)
                {
                    _cnt = ids[i] - ids[i - 1] - 1;
                    result += (long)(_cnt + 1) * _cnt >> 1;
                }

            int span = k != 0 ? k : modulo;
            while (span < cnt - 1)
            {
                for (int l = 1, r = span; r < cnt - 1; l++, r++)
                {
                    result += (long)(ids[l] - ids[l - 1]) * (ids[r + 1] - ids[r]);
                }
                span += modulo;
            }

            return result;
        }
    }
}
