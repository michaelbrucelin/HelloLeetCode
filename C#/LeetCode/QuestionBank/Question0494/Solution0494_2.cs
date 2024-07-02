using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0494
{
    public class Solution0494_2 : Interface0494
    {
        /// <summary>
        /// BFS，组合
        /// 逻辑同Solution0494，只是将字典换成了数组
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int FindTargetSumWays(int[] nums, int target)
        {
            int len = nums.Length;
            int[] map = new int[2001], _map = new int[2001];  // 0 <= nums[i] <= 1000 && 0 <= sum(nums[i]) <= 1000
            map[1000] = 1;
            for (int i = 0, num; i < len; i++)
            {
                num = nums[i];
                for (int j = 0; j < 2001; j++) if (map[j] > 0)
                    {
                        _map[j + num] += map[j]; _map[j - num] += map[j];
                    }
                Array.Copy(_map, map, 2001);
                Array.Fill(_map, 0);
            }

            return map[target + 1000];
        }
    }
}
