using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2610
{
    public class Solution2610 : Interface2610
    {
        /// <summary>
        /// 贪心
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> FindMatrix(int[] nums)
        {
            Dictionary<int, int> freq = new Dictionary<int, int>();
            foreach (int num in nums) if (freq.ContainsKey(num)) freq[num]++; else freq.Add(num, 1);

            List<IList<int>> result = new List<IList<int>>();
            foreach (var kv in freq)
            {
                if (result.Count < kv.Value) for (int i = result.Count; i < kv.Value; i++) result.Add(new List<int>());
                for (int i = 0; i < kv.Value; i++) result[i].Add(kv.Key);
            }

            return result;
        }
    }
}
