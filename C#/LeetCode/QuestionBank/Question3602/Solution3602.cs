using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3602
{
    public class Solution3602 : Interface3602
    {
        private static readonly string map = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public string ConcatHex36(int n)
        {
            StringBuilder result = new StringBuilder();
            int x = n * n * n;
            while (x > 0) { result.Insert(0, map[x % 36]); x /= 36; }
            x = n * n;
            while (x > 0) { result.Insert(0, map[x % 16]); x /= 16; }

            return result.ToString();
        }
    }
}
