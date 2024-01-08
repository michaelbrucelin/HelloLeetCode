using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2194
{
    public class Solution2194 : Interface2194
    {
        public IList<string> CellsInRange(string s)
        {
            List<string> result = new List<string>();
            char C1 = s[0], C2 = s[3], R1 = s[1], R2 = s[4];
            for (int c = 0; c <= C2 - C1; c++) for (int r = 0; r <= R2 - R1; r++)
                {
                    result.Add($"{(char)(C1 + c)}{(char)(R1 + r)}");
                }

            return result;
        }
    }
}
