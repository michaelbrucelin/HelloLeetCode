using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0598
{
    public class Solution0598_api : Interface0598
    {
        public int MaxCount(int m, int n, int[][] ops)
        {
            if (ops.Length == 0) return m * n;
            return ops.Select(arr => arr[0]).Min() * ops.Select(arr => arr[1]).Min();
        }
    }
}
