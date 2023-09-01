using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0557
{
    public class Solution0557_2 : Interface0557
    {
        /// <summary>
        /// 遍历空格
        /// Solution0557更通用，这里充分利用题目中的这三个条件：
        ///     1. s 不包含任何开头或结尾空格
        ///     2. s 里 至少 有一个词
        ///     3. s 中的所有单词都用一个空格隔开
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ReverseWords(string s)
        {
            char[] chars = s.ToCharArray();
            int left = 0, right, len = s.Length;
            for (int i = 1; i < len; i++)
            {
                if (chars[i] != ' ') continue;
                right = i - 1;
                Reverse(chars, left, right);
                left = i++ + 1;
            }
            Reverse(chars, left, len - 1);

            return new string(chars);
        }

        private void Reverse(char[] chars, int left, int right)
        {
            while (left < right)
            {
                chars[left] = (char)(chars[left] ^ chars[right]);
                chars[right] = (char)(chars[left] ^ chars[right]);
                chars[left] = (char)(chars[left] ^ chars[right]);
                left++; right--;
            }
        }
    }
}
