using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1556
{
    public class Solution1556 : Interface1556
    {
        public string ThousandSeparator(int n)
        {
            if (n == 0) return "0";

            List<char> list = new List<char>();
            int cnt = -1;
            while (n > 0)
            {
                if (++cnt == 3)
                {
                    list.Add('.'); cnt = 0;
                }
                list.Add((char)((n % 10) + '0'));
                n /= 10;
            }

            return new string(list.Reverse<char>().ToArray());
        }
    }
}
