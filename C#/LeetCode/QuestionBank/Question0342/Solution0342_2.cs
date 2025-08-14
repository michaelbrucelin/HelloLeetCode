using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0342
{
    public class Solution0342_2 : Interface0342
    {
        private static readonly HashSet<int> pow4 = [1, 4, 16, 64, 256, 1024, 4096, 16384, 65536, 262144, 1048576, 4194304, 16777216, 67108864, 268435456, 1073741824];

        public bool IsPowerOfFour(int n)
        {
            return pow4.Contains(n);
        }
    }
}
