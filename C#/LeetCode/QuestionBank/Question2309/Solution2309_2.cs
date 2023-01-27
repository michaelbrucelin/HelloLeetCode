using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2309
{
    public class Solution2309_2 : Interface2309
    {
        public string GreatestLetter(string s)
        {
            HashSet<char> set = new HashSet<char>();
            for (int i = 0; i < s.Length; i++) set.Add(s[i]);

            for (int i = 25; i >= 0; i--)
                if (set.Contains((char)(65 + i)) && set.Contains((char)(97 + i))) return ((char)(65 + i)).ToString();

            return string.Empty;
        }
    }
}
