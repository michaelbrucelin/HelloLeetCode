using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1037
{
    public class Solution1037 : Interface1037
    {
        public bool IsBoomerang(int[][] points)
        {
            if ((points[1][0] == points[0][0] && points[1][1] == points[0][1]) ||
                (points[2][0] == points[0][0] && points[2][1] == points[0][1]) ||
                (points[2][0] == points[1][0] && points[2][1] == points[1][1]))
                return false;

            if ((points[1][1] - points[0][1]) * (points[2][0] - points[0][0]) ==
                (points[2][1] - points[0][1]) * (points[1][0] - points[0][0]))
                return false;

            return true;
        }

        public bool IsBoomerang2(int[][] points)
        {
            int p0 = points[0][1] * 101 + points[0][0];
            int p1 = points[1][1] * 101 + points[1][0];
            int p2 = points[2][1] * 101 + points[2][0];
            if ((p1 == p0) || (p2 == p0) || (p2 == p1)) return false;

            if ((points[1][1] - points[0][1]) * (points[2][0] - points[0][0]) ==
                (points[2][1] - points[0][1]) * (points[1][0] - points[0][0]))
                return false;

            return true;
        }
    }
}
