using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0693
{
    public class Solution0693_dial : Interface0693
    {
        private readonly HashSet<int> set = new HashSet<int>() {
            1, 2, 5, 10, 21, 42, 85, 170, 341, 682, 1365, 2730, 5461, 10922, 21845, 43690, 87381,
            174762, 349525, 699050, 1398101, 2796202, 5592405, 11184810, 22369621, 44739242, 89478485,
            178956970, 357913941, 715827882, 1431655765};

        public bool HasAlternatingBits(int n)
        {
            return set.Contains(n);
        }
    }
}
