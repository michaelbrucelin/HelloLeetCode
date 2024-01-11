using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1725
{
    public class Solution1725 : Interface1725
    {
        public int CountGoodRectangles(int[][] rectangles)
        {
            int max_edge = 0, edge, cnt = 0;
            foreach (var arr in rectangles)
            {
                edge = Math.Min(arr[0], arr[1]);
                if (edge > max_edge)
                {
                    max_edge = edge; cnt = 1;
                }
                else if (edge == max_edge)
                {
                    cnt++;
                }
            }

            return cnt;
        }
    }
}
