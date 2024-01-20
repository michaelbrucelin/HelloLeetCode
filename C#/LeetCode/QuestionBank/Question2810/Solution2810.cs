using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2810
{
    public class Solution2810 : Interface2810
    {
        public string FinalString(string s)
        {
            List<char> list = new List<char>();
            int p = 0, pi, len = s.Length; bool flag;
            while (p < len && s[p] == 'i') p++;
            while (p < len)
            {
                while (p < len && s[p] != 'i') { list.Add(s[p]); p++; }
                if (p == len) break;
                pi = p; flag = true;
                while (pi + 1 < len && s[pi + 1] == 'i') { flag = !flag; pi++; }
                if (flag) Reverse(list);
                p = pi + 1;
            }

            return new string(list.ToArray());
        }

        private void Reverse(List<char> list)
        {
            char c;
            for (int i = 0, j = list.Count - 1; i < j; i++, j--)
            {
                c = list[i]; list[i] = list[j]; list[j] = c;
            }
        }
    }
}
