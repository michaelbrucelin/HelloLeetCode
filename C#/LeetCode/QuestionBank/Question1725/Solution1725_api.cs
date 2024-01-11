using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1725
{
    public class Solution1725_api : Interface1725
    {
        public int CountGoodRectangles(int[][] rectangles)
        {
            return rectangles.Select(arr => Math.Min(arr[0], arr[1]))
                             .GroupBy(edge => edge)
                             .OrderByDescending(g => g.Key)
                             .First()
                             .Count();
        }
    }
}
