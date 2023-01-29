using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0231
{
    public class Solution0231 : Interface0231
    {
        public bool IsPowerOfTwo(int n)
        {
            if (n <= 0) return false;
            if (n <= 2) return true;

            while (n > 2)
            {
                if ((n & 1) == 1) return false;
                n >>= 1;
            }

            return true;
        }

        public bool IsPowerOfTwo2(int n)
        {
            if (n <= 0) return false;
            if (n <= 2) return true;

            if ((n & 1) == 1) return false;
            return IsPowerOfTwo2(n >> 1);
        }

        private static readonly HashSet<int> pow2s = new HashSet<int>() { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384, 32768, 65536, 131072, 262144, 524288, 1048576, 2097152, 4194304, 8388608, 16777216, 33554432, 67108864, 134217728, 268435456, 536870912, 1073741824 };
        public bool IsPowerOfTwo3(int n)
        {
            return pow2s.Contains(n);
        }
    }
}
