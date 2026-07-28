using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3518
{
    public class Solution3518 : Interface3518
    {
        /// <summary>
        /// 下一个更大的字符串
        /// 
        /// 逻辑没问题，TLE，参考测试用例04，可以通过组合数学优化来快速定位
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string SmallestPalindrome(string s, int k)
        {
            int len = s.Length >> 1;
            int[] cnts = new int[26];
            for (int i = 0; i < len; i++) cnts[s[i] - 'a']++;
            char[] chars = new char[len];
            for (int i = 0, x = 0; i < len; i++)
            {
                while (cnts[x] == 0) x++;
                chars[i] = (char)('a' + x);
                cnts[x]--;
            }

            while (--k > 0) if (!NextBigger(chars)) return "";
            char[] result = new char[len = s.Length];
            if ((len & 1) != 0) result[len >> 1] = s[len >> 1];
            for (int i = 0, j = len - 1; i < j; i++, j--) result[i] = result[j] = chars[i];
            return new string(result);

            static bool NextBigger(char[] chars)
            {
                int p1 = chars.Length - 2, len = chars.Length;
                while (p1 >= 0 && chars[p1] >= chars[p1 + 1]) p1--;
                if (p1 == -1) return false;
                int p2 = len - 1;
                while (chars[p2] <= chars[p1]) p2--;
                (chars[p1], chars[p2]) = (chars[p2], chars[p1]);
                for (p1 = p1 + 1, p2 = len - 1; p1 < p2; p1++, p2--) (chars[p1], chars[p2]) = (chars[p2], chars[p1]);

                return true;
            }
        }
    }
}
