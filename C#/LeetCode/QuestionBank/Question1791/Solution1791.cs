using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1791
{
    public class Solution1791 : Interface1791
    {
        public int FindCenter(int[][] edges)
        {
            int p00 = edges[0][0], p01 = edges[0][1], p10 = edges[1][0], p11 = edges[1][1];
            if (p00 == p10 || p00 == p11) return p00;
            if (p01 == p10 || p01 == p11) return p01;

            throw new Exception("logic error.");
        }

        public int FindCenter2(int[][] edges)
        {
            int p00 = edges[0][0], p01 = edges[0][1], p10 = edges[1][0], p11 = edges[1][1];
            if (p00 == p10 || p00 == p11) return p00;
            return p01;
        }
    }
}
