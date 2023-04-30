using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2053
{
    public class Solution2053 : Interface2053
    {
        /// <summary>
        /// 哈希表
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string KthDistinct(string[] arr, int k)
        {
            Dictionary<string, int> freq = new Dictionary<string, int>();
            for (int i = 0; i < arr.Length; i++) { freq.TryAdd(arr[i], 0); freq[arr[i]]++; }

            for (int i = 0; i < arr.Length; i++)
            {
                if (freq[arr[i]] == 1) k--;
                if (k == 0) return arr[i];
            }

            return string.Empty;
        }

        public string KthDistinct2(string[] arr, int k)
        {
            return arr.Select((str, id) => (str, id))
                      .GroupBy(item => item.str)
                      .Select(g => new { Str = g.Key, Cnt = g.Count(), Id = g.Min(gg => gg.id) })
                      .Where(item => item.Cnt == 1)
                      .OrderBy(item => item.Id)
                      .Skip(k - 1)
                      .DefaultIfEmpty(new { Str = "", Cnt = -1, Id = -1 })
                      .First().Str;
        }
    }
}
