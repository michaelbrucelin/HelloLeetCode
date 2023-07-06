using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1880
{
    public class Solution1880_api : Interface1880
    {
        public bool IsSumEqual(string firstWord, string secondWord, string targetWord)
        {
            int first = int.Parse(new string(firstWord.Select(c => (char)(c - 49)).ToArray()));
            int second = int.Parse(new string(secondWord.Select(c => (char)(c - 49)).ToArray()));
            int target = int.Parse(new string(targetWord.Select(c => (char)(c - 49)).ToArray()));

            return target == first + second;
        }
    }
}
