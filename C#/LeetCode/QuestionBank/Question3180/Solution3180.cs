using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3180
{
    public class Solution3180 : Interface3180
    {
        /// <summary>
        /// 排序 + DFS
        /// 大概率会TLE，先写出来，然后再优化
        /// 
        /// 逻辑没问题，意料之中的TLE，参考测试用例01
        /// </summary>
        /// <param name="rewardValues"></param>
        /// <returns></returns>
        public int MaxTotalReward(int[] rewardValues)
        {
            Array.Sort(rewardValues);
            int result = 0, len = rewardValues.Length;
            dfs(0, 0);

            return result;

            void dfs(int idx, int curr)
            {
                if (idx >= len) return;
                if (rewardValues[idx] > curr)
                {
                    result = Math.Max(result, curr + rewardValues[idx]);
                    dfs(idx + 1, curr + rewardValues[idx]);
                }
                dfs(idx + 1, curr);
            }
        }

        /// <summary>
        /// 逻辑与MaxTotalReward()完全相同，有返回值版
        /// </summary>
        /// <param name="rewardValues"></param>
        /// <returns></returns>
        public int MaxTotalReward2(int[] rewardValues)
        {
            Array.Sort(rewardValues);
            int len = rewardValues.Length;
            return dfs(0, 0);

            int dfs(int idx, int curr)
            {
                if (idx >= len) return curr;
                if (rewardValues[idx] <= curr) return dfs(idx + 1, curr);
                return Math.Max(dfs(idx + 1, curr), dfs(idx + 1, curr + rewardValues[idx]));
            }
        }
    }
}
