using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0151
{
    public class Solution0151_2 : Interface0151
    {
        /// <summary>
        /// 原地更改
        /// 这里使用char[]模拟C中的字符串进行原地更改
        /// 1. 移除额外的空格（首尾空格，中间连续的多个空格）
        /// 2. 翻转整个字符串
        /// 3. 翻转每一个单词
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ReverseWords(string s)
        {
            char[] chars = s.ToCharArray();
            int left = 0, right = chars.Length - 1;
            while (left <= right && chars[left] == ' ') left++;    // 移除前缀空格
            while (right >= left && chars[right] == ' ') right--;  // 移除尾缀空格
            if (left > right) return string.Empty;

            for (int i = left + 1; i <= right; i++)                // 移除中间空格
            {
                if (chars[i] == ' ' && chars[i - 1] == ' ')
                {
                    for (int j = i; j < right; j++) chars[j] = chars[j + 1];
                    i--; right--;
                }
            }

            SubReverse(chars, left, right);
            int _left = left, _right;
            while (_left <= right)
            {
                _right = _left; while (_right <= right && chars[_right] != ' ') _right++;
                SubReverse(chars, _left, _right - 1);
                _left = _right + 1;
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
