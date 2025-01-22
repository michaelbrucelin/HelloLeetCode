using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2506
{
    public class Solution2506 : Interface2506
    {
        /// <summary>
        /// 整型掩码 + 组合数学
        /// 由于word仅由小写字母组成，所以每个word由哪些字母构成可以用一个整型来表示
        /// 如果某个掩码的字符串有n个，那么可能的配对有n*(n-1)/2个
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public int SimilarPairs(string[] words)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            int mask;
            foreach (string word in words)
            {
                mask = 0;
                foreach (char c in word) mask |= 1 << (c - 'a');
                if (map.ContainsKey(mask)) map[mask]++; else map.Add(mask, 1);
            }

            int result = 0;
            foreach (int cnt in map.Values) result += (cnt * (cnt - 1)) >> 1;
            return result;
        }
    }
}
