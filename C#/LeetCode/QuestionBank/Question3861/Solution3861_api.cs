using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3861
{
    public class Solution3861_api : Interface3861
    {
        public int MinimumIndex(int[] capacity, int itemSize)
        {
            return capacity.Select((val, idx) => (val, idx))
                           .Where(x => x.val >= itemSize)
                           .OrderBy(x => x.val)
                           .ThenBy(x => x.idx)
                           .FirstOrDefault((-1, -1))
                           .Item2;
        }
    }
}
