using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0494
{
    public class Solution0494 : Interface0494
    {
        /// <summary>
        /// BFS，组合
        /// 最多20个数字，最多有2^20 = 1048576种选择，暴力解应该可以过
        /// 由于题目限定0 <= sum(nums[i]) <= 1000，所以最多有2000 * 20种选择
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int FindTargetSumWays(int[] nums, int target)
        {
            int len = nums.Length;
            Dictionary<int, int> map = new Dictionary<int, int>() { { 0, 1 } }, _map = new Dictionary<int, int>();
            foreach (int num in nums)
            {
                foreach (int key in map.Keys)
                {
                    _map.TryAdd(key + num, 0); _map[key + num] += map[key];
                    _map.TryAdd(key - num, 0); _map[key - num] += map[key];
                }
                map.Clear();
                foreach (int key in _map.Keys)
                {
                    map.Add(key, _map[key]); _map.Remove(key);
                }
            }

            return map.ContainsKey(target) ? map[target] : 0;
        }
    }
}
