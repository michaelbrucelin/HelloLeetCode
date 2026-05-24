using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2522
{
    public class Solution2522 : Interface2522
    {
        /// <summary>
        /// 贪心
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MinimumPartition(string s, int k)
        {
            if (k < 10)
            {
                if (k == 9) return s.Length;
                foreach (char c in s) if ((c & 15) > k) return -1;
                return s.Length;
            }

            int result = 1, len = s.Length; long _k = 0;
            for (int i = 0, x; i < len; i++)
            {
                x = s[i] & 15;
                _k = _k * 10 + x;
                if (_k > k) { result++; _k = x; }
            }

            return result;
        }
    }
}
