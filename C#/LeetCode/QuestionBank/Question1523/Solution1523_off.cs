using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1523
{
    public class Solution1523_off : Interface1523
    {
        public int CountOdds(int low, int high)
        {
            return ((high + 1) >> 1) - (low >> 1);
        }
    }
}
