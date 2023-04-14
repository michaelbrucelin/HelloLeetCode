using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2000
{
    public class Solution2000_api : Interface2000
    {
        public string ReversePrefix(string word, char ch)
        {
            int id = word.IndexOf(ch) + 1;

            return id == -1 ? word : $"{new string(word[0..id].Reverse().ToArray())}{word[id..]}";
        }
    }
}
