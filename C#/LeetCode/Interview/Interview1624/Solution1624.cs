using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1624
{
    public class Solution1624 : Interface1624
    {
        /// <summary>
        /// Hash
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> PairSums(int[] nums, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();
            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach (int num in nums) if (map.TryGetValue(num, out int val)) map[num] = ++val; else map.Add(num, 1);
            int cnt, num2;
            foreach (int num1 in map.Keys) if (map.ContainsKey(num2 = target - num1))
                {
                    cnt = num1 != num2 ? Math.Min(map[num1], map[num2]) : map[num1] >> 1;
                    for (int i = 0; i < cnt; i++) result.Add([num1, num2]);
                    map[num1] -= cnt;
                    map[num2] -= cnt;
                }

            return result;
        }
    }
}
