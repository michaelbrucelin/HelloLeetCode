using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0229
{
    public class Solution0229_err : Interface0229
    {
        /// <summary>
        /// 摩尔投票
        /// 每找到3个互不相同的元素，就将这3个元素“抵消”，余下的元素就是结果
        /// 
        /// 写错了，参考测试用例04，有时间再改
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<int> MajorityElement(int[] nums)
        {
            Dictionary<int, int> freq = new Dictionary<int, int>();
            foreach (int num in nums) if (freq.TryGetValue(num, out int cnt)) freq[num] = ++cnt; else freq.Add(num, 1);
            int[] keys = new int[3]; int idx, min;
            while (freq.Count > 2)
            {
                idx = 0;
                foreach (int key in freq.Keys)
                {
                    keys[idx++] = key;
                    if (idx == 3) break;
                }
                min = Math.Min(freq[keys[0]], Math.Min(freq[keys[1]], freq[keys[2]]));
                for (int i = 0; i < 3; i++) if (freq[keys[i]] == min) freq.Remove(keys[i]); else freq[keys[i]] -= min;
            }

            if (freq.Count < 2) return [.. freq.Keys];
            int x = freq.First().Key, y = freq.Last().Key;
            if (freq[x] * 2 <= freq[y]) return [y];
            if (freq[y] * 2 <= freq[x]) return [x];
            return [x, y];
        }
    }
}
