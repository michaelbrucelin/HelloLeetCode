using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3516
{
    public class Solution3516 : Interface3516
    {
        public int FindClosest(int x, int y, int z)
        {
            int dx = Math.Abs(x - z), dy = Math.Abs(y - z);
            return (dx - dy) switch { < 0 => 1, > 0 => 2, _ => 0 };
        }
    }
}
