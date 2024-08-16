using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3117
{
    public class Solution3117 : Interface3117
    {
        /// <summary>
        /// DFS
        /// 注意，“与”运算只能把一个数字变小，而不能变大
        /// 
        /// 逻辑没问题，意料之中的TLE，参考测试用例04
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="andValues"></param>
        /// <returns></returns>
        public int MinimumValueSum(int[] nums, int[] andValues)
        {
            const int meta = int.MaxValue;
            int result = meta, n = nums.Length, m = andValues.Length;
            dfs(0, meta, 0, 0);

            return result == int.MaxValue ? -1 : result;

            void dfs(int add, int curr, int num_id, int and_id)
            {
                if (num_id >= n || and_id >= m) return;
                if (n - num_id < m - and_id) return;

                curr &= nums[num_id];
                if (curr < andValues[and_id]) return;
                if (curr > andValues[and_id])
                {
                    dfs(add, curr, num_id + 1, and_id);
                }
                else  // if (curr == andValues[and_id])
                {
                    if (num_id == n - 1 && and_id == m - 1)
                    {
                        result = Math.Min(result, add + nums[num_id]);
                    }
                    else
                    {
                        dfs(add, curr, num_id + 1, and_id);                     // 继续这个子数组
                        dfs(add + nums[num_id], meta, num_id + 1, and_id + 1);  // 结束这个子数组
                    }
                }
            }
        }
    }
}
