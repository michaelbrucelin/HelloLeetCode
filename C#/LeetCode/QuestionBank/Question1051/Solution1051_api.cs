using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1051
{
    public class Solution1051_api : Interface1051
    {
        public int HeightChecker(int[] heights)
        {
            return heights.OrderBy(i => i).Zip(heights).Count(t => t.First != t.Second);
        }
    }
}
