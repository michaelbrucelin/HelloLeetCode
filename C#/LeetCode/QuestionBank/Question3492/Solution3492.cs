using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3492
{
    public class Solution3492 : Interface3492
    {
        public int MaxContainers(int n, int w, int maxWeight)
        {
            return Math.Min(n * n, maxWeight / w);
        }
    }
}
