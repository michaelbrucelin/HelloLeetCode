using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2248
{
    public class Solution2248_2 : Interface2248
    {
        /// <summary>
        /// 统计每个数字出现的次数
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> Intersection(int[][] nums)
        {
            Dictionary<int, int> freq = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++) for (int j = 0; j < nums[i].Length; j++)
                {
                    int val = nums[i][j];
                    if (freq.ContainsKey(val)) freq[val]++; else freq.Add(val, 1);
                }

            List<int> result = new List<int>();
            int len = nums.Length;
            foreach (var kv in freq) if (kv.Value == len) result.Add(kv.Key);
            result.Sort();

            return result;
        }

        /// <summary>
        /// 逻辑同Intersection()，将字典改为数组
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> Intersection2(int[][] nums)
        {
            int[] freq = new int[1001];
            for (int i = 0; i < nums.Length; i++) for (int j = 0; j < nums[i].Length; j++) freq[nums[i][j]]++;

            List<int> result = new List<int>();
            for (int i = 1, len = nums.Length; i < 1001; i++) if (freq[i] == len) result.Add(i);
            result.Sort();

            return result;
        }
    }
}
