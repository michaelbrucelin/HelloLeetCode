using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2337
{
    public class Solution2337_2 : Interface2337
    {
        public bool CanChange(string start, string target)
        {
            int len = target.Length, p1 = 0, p2 = 0;
            while (p1 < len && p2 < len)
            {
                while (p1 < len && start[p1] == '_') p1++;
                while (p2 < len && target[p2] == '_') p2++;
                if (p1 == len && p2 == len) return true;
                if (p1 == len || p2 == len) return false;
                if (start[p1] != target[p2]) return false;

                if (start[p1] == 'L')
                {
                    if (p1 < p2) return false; else { p1++; p2++; }
                }
                else  // if (start[p1] == 'R')
                {
                    if (p1 > p2) return false; else { p1++; p2++; }
                }
            }
            while (p1 < len && start[p1] == '_') p1++;
            while (p2 < len && target[p2] == '_') p2++;

            return p1 == p2;
        }
    }
}
