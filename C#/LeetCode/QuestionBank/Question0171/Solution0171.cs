using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0171
{
    public class Solution0171 : Interface0171
    {
        private Dictionary<char, int> map = new Dictionary<char, int>() { { 'A', 1 }, { 'B', 2 }, { 'C', 3 }, { 'D', 4 }, { 'E', 5 }, { 'F', 6 }, { 'G', 7 }
                                                                         ,{ 'H', 8 }, { 'I', 9 }, { 'J',10 }, { 'K',11 }, { 'L',12 }, { 'M',13 }, { 'N',14 }
                                                                         ,{ 'O',15 }, { 'P',16 }, { 'Q',17 }, { 'R',18 }, { 'S',19 }, { 'T',20 }
                                                                         ,{ 'U',21 }, { 'V',22 }, { 'W',23 }, { 'X',24 }, { 'Y',25 }, { 'Z',26 } };
        private const int dim = 26;

        public int TitleToNumber(string columnTitle)
        {
            int result = 0;
            int xs = 1;
            for (int i = columnTitle.Length - 1; i >= 0; i--)
            {
                result += map[columnTitle[i]] * xs;
                xs *= 26;
            }

            return result;
        }

        public int TitleToNumber2(string columnTitle)
        {
            int result = 0;
            int xs = 1;
            for (int i = columnTitle.Length - 1; i >= 0; i--)
            {
                result += (columnTitle[i] - 'A' + 1) * xs;
                xs *= 26;
            }

            return result;
        }
    }
}
