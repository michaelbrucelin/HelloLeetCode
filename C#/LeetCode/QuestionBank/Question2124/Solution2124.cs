using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2124
{
    public class Solution2124 : Interface2124
    {
        public bool CheckString(string s)
        {
            bool has_b = false; char c;
            for (int i = 0; i < s.Length; i++)
            {
                c = s[i];
                switch (c)
                {
                    case 'a':
                        if (has_b) return false;
                        break;
                    case 'b':
                        has_b = true;
                        break;
                    default:
                        throw new Exception("logic error.");
                }
            }

            return true;
        }
    }
}
