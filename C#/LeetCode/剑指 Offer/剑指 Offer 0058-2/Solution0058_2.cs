using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.剑指_Offer.剑指_Offer_0058_2
{
    public class Solution0058_2 : Interface0058
    {
        /// <summary>
        /// 三次翻转
        /// </summary>
        /// <param name="s"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public string ReverseLeftWords(string s, int n)
        {
            char[] chars = s.ToCharArray();
            SubReverse(chars, 0, n - 1);
            SubReverse(chars, n, chars.Length - 1);
            SubReverse(chars, 0, chars.Length - 1);

            return new string(chars);
        }

        private void SubReverse(char[] chars, int left, int right)
        {
            while (left < right)
            {
                char c = chars[left]; chars[left] = chars[right]; chars[right] = c;
                left++; right--;
            }
        }
    }
}
