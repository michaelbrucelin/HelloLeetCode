using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1807
{
    public class Solution1807_4 : Interface1807
    {
        public string Evaluate(string s, IList<IList<string>> knowledge)
        {
            Dictionary<string, string> helper = new Dictionary<string, string>();
            for (int i = 0; i < knowledge.Count; i++) helper.Add(knowledge[i][0], knowledge[i][1]);

            StringBuilder result = new StringBuilder();
            StringBuilder buffer = new StringBuilder();
            int ptr = 0, len = s.Length;
            while (ptr < len)
            {
                if (s[ptr] == '(')
                {
                    while (s[++ptr] != ')') buffer.Append(s[ptr]);
                    string key = buffer.ToString();
                    if (helper.ContainsKey(key)) result.Append(helper[key]); else result.Append('?');
                    buffer.Clear();
                    ptr++;
                }
                else
                {
                    result.Append(s[ptr++]);
                }
            }

            return result.ToString();
        }
    }
}
