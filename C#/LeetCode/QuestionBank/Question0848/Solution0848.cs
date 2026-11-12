using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0848
{
    public class Solution0848 : Interface0848
    {
        /// <summary>
        /// 前缀和
        /// </summary>
        /// <param name="s"></param>
        /// <param name="shifts"></param>
        /// <returns></returns>
        public string ShiftingLetters(string s, int[] shifts)
        {
            char[] chars = [.. s];
            shifts[^1] %= 26;
            for (int i = shifts.Length - 2; i >= 0; i--) shifts[i] = (shifts[i] + shifts[i + 1]) % 26;
            for (int i = 0, len = chars.Length; i < len; i++) chars[i] = (char)('a' + (chars[i] - 'a' + shifts[i]) % 26);

            return new string(chars);
        }
    }
}
