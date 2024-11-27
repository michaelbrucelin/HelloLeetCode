using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1309
{
    public class Solution1309_2 : Interface1309
    {
        private static readonly Dictionary<char, char> map1 = new Dictionary<char, char>() {
            {'1','a'},{'2','b'},{'3','c'},{'4','d'},{'5','e'},{'6','f'},{'7','g'},{'8','h'},{'9','i'}
        };
        private static readonly Dictionary<char, Dictionary<char, char>> map2 = new Dictionary<char, Dictionary<char, char>>()
        {
            { '1', new Dictionary<char, char>(){ {'0','j'},{'1','k'},{'2','l'},{'3','m'},{'4','n'},{'5','o'},{'6','p'},{'7','q'},{'8','r'},{'9','s'} } },
            { '2', new Dictionary<char, char>(){ {'0','t'},{'1','u'},{'2','v'},{'3','w'},{'4','x'},{'5','y'},{'6','z'} } }
        };

        public string FreqAlphabets(string s)
        {
            StringBuilder builder = new StringBuilder();
            int ptr = 0, len = s.Length; char c;
            while (ptr < len)
            {
                if (ptr + 2 < len && s[ptr + 2] == '#')
                {
                    builder.Append(map2[s[ptr]][s[ptr + 1]]); ptr += 3;
                }
                else
                {
                    builder.Append(map1[s[ptr]]); ptr += 1;
                }
            }

            return builder.ToString();
        }
    }
}
