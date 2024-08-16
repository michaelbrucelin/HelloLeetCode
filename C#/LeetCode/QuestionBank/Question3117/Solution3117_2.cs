using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3117
{
    public class Solution3117_2 : Interface3117
    {
        /// <summary>
        /// 逻辑同Solution3117，添加了记忆化搜索
        /// 
        /// 比Solution3117快乐很多，但是依然TLE，参考测试用例05
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="andValues"></param>
        /// <returns></returns>
        public int MinimumValueSum(int[] nums, int[] andValues)
        {
            const int meta = int.MaxValue;
            int n = nums.Length, m = andValues.Length;
            Dictionary<(int s1, int s2), int> memory = new Dictionary<(int s1, int s2), int>();  // s1, s2分别是nums与andValues的起点
            int result = dfs(0, 0);

            return result == meta ? -1 : result;

            int dfs(int s1, int s2)
            {
                if (memory.ContainsKey((s1, s2))) return memory[(s1, s2)];
                if (s1 >= n || s2 >= m) return meta;
                if (n - s1 < m - s2) return meta;

                int add = meta, and = meta, _s1 = s1;
                while (and >= andValues[s2] && _s1 < n)
                {
                    and &= nums[_s1];
                    if (and == andValues[s2])
                    {
                        if (_s1 == n - 1 && s2 == m - 1)
                        {
                            add = Math.Min(add, nums[_s1]);
                        }
                        else if (_s1 < n - 1 && s2 < m - 1)
                        {
                            int _add = dfs(_s1 + 1, s2 + 1);
                            if (_add != meta) add = Math.Min(add, nums[_s1] + _add);
                        }
                    }
                    _s1++;
                }
                memory.Add((s1, s2), add);

                return memory[(s1, s2)];
            }
        }
    }
}
