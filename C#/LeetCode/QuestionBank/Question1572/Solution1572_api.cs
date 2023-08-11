using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1572
{
    public class Solution1572_api : Interface1572
    {
        public int DiagonalSum(int[][] mat)
        {
            int len = mat.Length;
            return mat.Select((row, rid) => row.Where((num, cid) => cid == rid || cid == len - rid - 1).Sum()).Sum();
        }
    }
}
