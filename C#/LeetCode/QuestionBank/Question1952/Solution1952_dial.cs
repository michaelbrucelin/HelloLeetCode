using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1952
{
    public class Solution1952_dial : Interface1952
    {
        private static readonly HashSet<int> set = new HashSet<int>() {
            4, 9, 25, 49, 121, 169, 289, 361, 529, 841, 961, 1369, 1681, 1849,
            2209, 2809, 3481, 3721, 4489, 5041, 5329, 6241, 6889, 7921, 9409
        };

        public bool IsThree(int n)
        {
            return set.Contains(n);
        }
    }
}
