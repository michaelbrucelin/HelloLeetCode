using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1461
{
    public class Solution1461 : Interface1461
    {
        /// <summary>
        /// 滚动哈希
        /// 滚动计算所有s的长度为k的子串的十进制值，放集合中，然后检验集合中值的数量是否是2^k个即可
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool HasAllCodes(string s, int k)
        {
            if (s.Length <= k) return false;

            int dec = 0, mask = (1 << k) - 1, total = 1 << k, len = s.Length;
            HashSet<int> set = [];
            for (int i = 0; i < k; i++) dec = (dec << 1) | (s[i] & 15);
            set.Add(dec);
            for (int i = k; i < len; i++)
            {
                dec = (dec << 1) | (s[i] & 15);
                dec &= mask;
                set.Add(dec);
            }

            return set.Count == total;
        }
    }
}
