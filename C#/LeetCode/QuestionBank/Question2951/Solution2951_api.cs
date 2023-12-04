using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2951
{
    public class Solution2951_api : Interface2951
    {
        public IList<int> FindPeaks(int[] mountain)
        {
            return mountain.Select((val, id) => (val, id))
                           .Skip(1)
                           .Take(mountain.Length - 2)
                           .Where(t => t.val > mountain[t.id - 1] && t.val > mountain[t.id + 1])
                           .Select(t => t.id)
                           .ToArray();
        }
    }
}
