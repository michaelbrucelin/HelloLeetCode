using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0929
{
    public class Solution0929_2 : Interface0929
    {
        public int NumUniqueEmails(string[] emails)
        {
            HashSet<string> set = new HashSet<string>();
            List<char> list = new List<char>();
            int p;
            string s1, s2;
            foreach (string s in emails)
            {
                list.Clear();
                s1 = s2 = "";
                for (p = 0; ; p++)
                {
                    if (s[p] == '+')
                    {
                        if (s1.Length == 0) s1 = new string(list.ToArray());
                    }
                    else if (s[p] == '@')
                    {
                        if (s1.Length == 0) s1 = new string(list.ToArray());
                        break;
                    }
                    else if (s[p] != '.')
                    {
                        list.Add(s[p]);
                    }
                }
                s2 = new string(s[p..].ToCharArray());
                set.Add($"{s1}{s2}");
            }

            return set.Count;
        }
    }
}
