using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3227
{
    public class Solution3227 : Interface3227
    {
        /// <summary>
        /// 脑筋急转弯
        /// 1. 如果字符串中没有元音字符，A无法操作，lose
        /// 2. 如果字符串中有奇数个元音字符，A 删除整个字符串，win
        /// 3. 如果字符串中有偶数个元音字符，A 删除其中的奇数个
        ///     然后B无论怎样操作，下一轮到达A操作的时候，字符串中仍有奇数个元音字符
        ///     A 删除整个字符串，win
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool DoesAliceWin(string s)
        {
            HashSet<char> vowels = ['a', 'e', 'i', 'o', 'u'];
            foreach (char c in s) if (vowels.Contains(c)) return true;
            return false;
        }
    }
}
