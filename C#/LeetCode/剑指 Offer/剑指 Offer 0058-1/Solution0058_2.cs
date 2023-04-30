using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.剑指_Offer.剑指_Offer_0058_1
{
    public class Solution0058_2 : Interface0058
    {
        /// <summary>
        /// 模拟C中的原地更改字符串
        /// 为了更真实的模拟C，所以这里直接使用char[] chars = s.ToCharArray()，而没有使用List<char>等其它数据结构
        /// 1. 去掉首尾空格，中间的连续多个空格改为一个空格
        /// 2. 整个字符串反转
        /// 3. 字符串中的每个单词反转
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ReverseWords(string s)
        {
            char[] chars = s.ToCharArray();
            int len = chars.Length; int left = 0, right = len - 1;  // left, right表示字符串的真实边界
            while (left <= right && chars[left] == ' ') left++;     // 去掉前缀空格
            while (right >= left && chars[right] == ' ') right--;   // 去掉尾缀空格
            for (int i = left + 1; i <= right; i++)
            {
                if (chars[i] == ' ' && chars[i - 1] == ' ')
                {
                    for (int j = i; j < right; j++) chars[j] = chars[j + 1];
                    right--; i--;
                }
            }

            SubReverse(chars, left, right);
            int start = left, end;
            while (start < right)
            {
                end = start;
                while (end <= right && chars[end] != ' ') end++;
                SubReverse(chars, start, end - 1);
                start = end + 1;
            }

            return new string(chars, left, right - left + 1);
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
