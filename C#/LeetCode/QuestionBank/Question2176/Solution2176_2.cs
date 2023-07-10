using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2176
{
    public class Solution2176_2 : Interface2176
    {
        /// <summary>
        /// 先分组，再暴力枚举
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int CountPairs(int[] nums, int k)
        {
            Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();
            for (int i = 0; i < nums.Length; i++)
                if (dic.ContainsKey(nums[i])) dic[nums[i]].Add(i); else dic.Add(nums[i], new List<int>() { i });

            int result = 0;
            foreach (var list in dic.Values) for (int i = 0; i < list.Count - 1; i++) for (int j = i + 1; j < list.Count; j++)
                    {
                        if (list[i] * list[j] % k == 0) result++;
                    }

            return result;
        }
    }
}
