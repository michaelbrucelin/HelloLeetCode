using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1217
{
    public class Solution1217_api : Interface1217
    {
        public int MinCostToMoveChips(int[] position)
        {
            var query = position.Select(i => i & 1).GroupBy(i => i).Select(g => g.Count());
            return query.Count() == 1 ? 0 : query.Min();
        }
    }
}
