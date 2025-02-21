using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3250
{
    public class Solution3250 : Interface3250
    {
        /// <summary>
        /// DFS，无返回值
        /// 大概率会TLE，先写出来试试
        /// 逻辑没问题，意料之中的TLE，参考测试用例03
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int CountOfPairs(int[] nums)
        {
            const int MOD = (int)1e9 + 7;
            int result = 0, len = nums.Length;
            dfs(0, 0, nums[0]);
            return result;

            void dfs(int id, int asc, int desc)
            {
                if (id == len) { result = (result + 1) % MOD; return; }

                for (int i = asc, j = 0, sum = nums[id]; i <= sum; i++)
                {
                    j = sum - i;
                    if (j > desc) continue;
                    if (j < 0) break;
                    dfs(id + 1, i, j);
                }
            }
        }
    }
}
