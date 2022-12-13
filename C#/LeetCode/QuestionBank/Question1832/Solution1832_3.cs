using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1832
{
    public class Solution1832_3 : Interface1832
    {
        public bool CheckIfPangram(string sentence)
        {
            int mask = 0;
            for (int i = 0; i < sentence.Length; i++)
                mask |= 1 << (sentence[i] - 'a');

            return mask == (1 << 26) - 1;
        }

        public bool CheckIfPangram2(string sentence)
        {
            int mask = 0, full = (1 << 26) - 1;
            for (int i = 0; i < sentence.Length; i++)
            {
                mask |= 1 << (sentence[i] - 'a');
                if (mask == full) return true;
            }

            return false;
        }
    }
}
