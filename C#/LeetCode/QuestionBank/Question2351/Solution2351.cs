using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2351
{
    public class Solution2351 : Interface2351
    {
        public char RepeatedCharacter(string s)
        {
            bool[] mask = new bool[26];
            for (int i = 0; i < s.Length; i++)
            {
                int id = s[i] - 'a';
                if (mask[id]) return s[i]; else mask[id] = true;
            }

            throw new Exception($"there is no answer in \"{s}\"");
        }
    }
}
