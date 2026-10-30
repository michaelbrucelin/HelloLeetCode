using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1400
{
    public class Solution1400 : Interface1400
    {
        /// <summary>
        /// 构造
        /// 计数即可，奇数个必然产生一个新的，偶数个(2n)可以产生0,1,2,...2n个，注意0个需要一个其他的回文串，独立是不可以的
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool CanConstruct(string s, int k)
        {
            if (k > s.Length) return false;
            if (k == s.Length) return true;

            int[] cnts = new int[26];
            for (int i = 0, len = s.Length; i < len; i++) cnts[s[i] - 'a']++;
            int odd = 0;
            for (int i = 0; i < 26; i++) odd += cnts[i] & 1;
            if (odd > k) return false;

            return true;
        }
    }
}
