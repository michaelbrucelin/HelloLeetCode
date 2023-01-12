using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0168
{
    public class Solution0168 : Interface0168
    {
        private char[] map = new char[] { ' ', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        private const int dim = 26;

        public string ConvertToTitle(int columnNumber)
        {
            StringBuilder result = new StringBuilder();
            while (columnNumber > dim)
            {
                var info = Math.DivRem(columnNumber - 1, dim);
                result.Insert(0, map[info.Remainder + 1]);
                columnNumber = info.Quotient;
            }
            if (columnNumber != 0) result.Insert(0, map[columnNumber]);

            return result.ToString();
        }

        public string ConvertToTitle2(int columnNumber)
        {
            StringBuilder result = new StringBuilder();
            while (columnNumber > 26)
            {
                var info = Math.DivRem(columnNumber - 1, 26);
                result.Insert(0, (char)(info.Remainder + 65));
                columnNumber = info.Quotient;
            }
            if (columnNumber != 0) result.Insert(0, (char)(columnNumber + 64));

            return result.ToString();
        }
    }
}
