using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1935
{
    public class Solution1935_api : Interface1935
    {
        public int CanBeTypedWords(string text, string brokenLetters)
        {
            HashSet<char> set = brokenLetters.ToHashSet();
            return text.Split(' ')
                       .Select(str => str.All(c => !set.Contains(c)))
                       .Count(b => b);
        }
    }
}
