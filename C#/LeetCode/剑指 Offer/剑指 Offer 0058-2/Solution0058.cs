using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.剑指_Offer.剑指_Offer_0058_2
{
    public class Solution0058 : Interface0058
    {
        /// <summary>
        /// 模拟C进行原地更改
        /// </summary>
        /// <param name="s"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public string ReverseLeftWords(string s, int n)
        {
            int len = s.Length; char[] chars = s.ToCharArray();
            for (int i = 0; i < n; i++)
            {
                char c = chars[0];
                for (int j = 0; j < len - 1; j++) chars[j] = chars[j + 1];
                chars[len - 1] = c;
            }

            return new string(chars);
        }

        public string ReverseLeftWords2(string s, int n)
        {
            int len = s.Length; char[] chars = new char[len];
            for (int i = 0; i < len - n; i++) chars[i] = s[i + n];
            for (int i = 0; i < n; i++) chars[i + len - n] = s[i];

            return new string(chars);
        }

        public string ReverseLeftWords3(string s, int n)
        {
            return $"{s.Substring(n)}{s.Substring(0, n)}";
        }
    }
}
