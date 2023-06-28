using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1681
{
    public class Solution1681 : Interface1681
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// 1. 特殊情况处理
        ///     如果有数量大于k的元素存在，返回-1
        ///     如果有数量等于k的元素存在，直接每一组分配一个该元素
        ///     如果每个元素都只有一个 且 k == nums.length，返回0
        /// 2. DFS + 记忆化搜索
        /// 
        /// 未完成，以后再写
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinimumIncompatibility(int[] nums, int k)
        {
            Dictionary<int, int> freq = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (freq.ContainsKey(nums[i])) freq[nums[i]]++; else freq.Add(nums[i], 1);
            }
            int maxFreq = freq.Values.Max();
            if (maxFreq > k) return -1;
            if (maxFreq == 1 && k == nums.Length) return 0;

            int gcnt = nums.Length / k;  // gcnt是每组的元素数量，题目保证必然整除
            List<int> every = new List<int>();
            if (maxFreq == k) foreach (var kv in freq) if (kv.Value == k)
                    {
                        every.Add(kv.Key); freq.Remove(kv.Key); gcnt--;
                    }
            if (gcnt == 0) return (every.Max() - every.Min()) * k;

            Dictionary<string, int> cache = new Dictionary<string, int>();
            List<group1681> groups = new List<group1681>();




            int result = 256;  // 题目的数据范围不会产生更大的结果

            return result;
        }

        public int dfs(Dictionary<int, int> freq, List<group1681> groups, List<int> every, int k, int gcnt, Dictionary<string, int> cache)
        {
            string gstr = string.Join(',', freq.OrderBy(kv => kv.Key).Select(kv => $"{{{kv.Key},{kv.Value}}}"));
            if(cache.ContainsKey(gstr)) return cache[gstr];

            int result = 256;  // 题目的数据范围不会产生更大的结果


            cache.Add(gstr, result);
            return result;
        }

        public class group1681
        {
            public group1681()
            {
                Set = new HashSet<int>();
                Max = 0;
                Min = 17;
            }

            public HashSet<int> Set;

            public int Cnt { get { return Set.Count; } }

            public int Max { get; set; }

            public int Min { get; set; }

            public int Incompatibility { get { return Max - Min; } }

            public bool Add(int i)
            {
                Max = Math.Max(Max, i);
                Min = Math.Min(Min, i);
                return Set.Add(i);
            }

            public bool Contains(int i) { return Set.Contains(i); }
        }
    }
}
