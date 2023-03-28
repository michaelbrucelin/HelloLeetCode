using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1092
{
    public class Utils1092
    {
        public static bool IsSubSequence(string sub, string super)
        {
            int len1 = sub.Length, len2 = super.Length;
            if (len1 > len2) return false;

            int ptr1 = 0, ptr2 = 0;
            while (ptr1 < len1 && ptr2 < len2)
            {
                if (sub[ptr1] == super[ptr2++]) ptr1++;
            }

            return ptr1 == len1;
        }
    }
}
