using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3360
{
    public class Solution3360_dial : Interface3360
    {
        private static readonly bool[] dial = [false, false, false, false, false, false, false, false, false, false, true, true, true, true, true, true, true, true, true, false, false, false, false, false, false, false, false,
            true, true, true, true, true, true, true, false, false, false, false, false, false, true, true, true, true, true, false, false, false, false, true, true];

        public bool CanAliceWin(int n)
        {
            return dial[n];
        }
    }
}
