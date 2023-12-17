using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2696
{
    public class Solution2696_api : Interface2696
    {
        public int MinLength(string s)
        {
            bool flag = true;
            string[] strs = new string[] { "AB", "CD" };
            while (flag)
            {
                flag = false;
                foreach (string str in strs) if (s.Contains(str))
                    {
                        s = s.Replace(str, ""); flag = true;
                    }
            }

            return s.Length;
        }
    }
}
