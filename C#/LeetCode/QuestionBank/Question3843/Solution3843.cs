using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3843
{
    public class Solution3843 : Interface3843
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FirstUniqueFreq(int[] nums)
        {
            Dictionary<int, int> map1 = new Dictionary<int, int>();
            foreach (int num in nums) { map1.TryAdd(num, 0); map1[num]++; }
            Dictionary<int, int> map2 = new Dictionary<int, int>();
            foreach (int key in map1.Keys) { map2.TryAdd(map1[key], 0); map2[map1[key]]++; }

            foreach (int num in nums) if (map2[map1[num]] == 1) return num;
            return -1;
        }
    }
}
