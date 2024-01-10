using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2129
{
    public class Solution2129_api : Interface2129
    {
        public string CapitalizeTitle(string title)
        {
            return string.Join(' ', title.Split(' ').Select(str => str.Length < 3 ? str.ToLower() : $"{str[..1].ToUpper()}{str[1..].ToLower()}"));
        }
    }
}
