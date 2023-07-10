using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace LeetCode.QuestionBank.Question1351
{
    public class Solution1351_api : Interface1351
    {
        public int CountNegatives(int[][] grid)
        {
            return grid.Select(arr => arr.Count(i => i < 0)).Sum();
        }
    }
}
