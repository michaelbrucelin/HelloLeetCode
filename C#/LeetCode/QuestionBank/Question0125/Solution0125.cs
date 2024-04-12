using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0125
{
    public class Solution0125 : Interface0125
    {
        /// <summary>
        /// 双指针遍历
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsPalindrome(string s)
        {
            if (s.Length <= 1) return true;

            int left = 0, right = s.Length - 1;
            while (left < right)
            {
                while (left < right && !char.IsLetterOrDigit(s[left])) left++;
                while (right > left && !char.IsLetterOrDigit(s[right])) right--;
                if (left == right) return true;
                if (s[left] != s[right] && ((s[left] ^ 32) != s[right])) return false;  // 观察一下数字与字母的ASCII值，这个判断是对的
                left++; right--;
            }

            return true;
        }
    }
}
