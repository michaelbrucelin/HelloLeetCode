using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3536
{
    public class Solution3536_api : Interface3536
    {
        public int MaxProduct(int n)
        {
            return n.ToString().Select(x => x - '0')
                               .OrderByDescending(x => x)
                               .Take(2)
                               .Aggregate(1, (x, y) => x * y);
        }
    }
}
