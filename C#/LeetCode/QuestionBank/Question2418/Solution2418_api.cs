using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2418
{
    public class Solution2418_api : Interface2418
    {
        public string[] SortPeople(string[] names, int[] heights)
        {
            return heights.Select((i, id) => (id, i))
                          .OrderByDescending(t => t.i)
                          .Select(t => names[t.id])
                          .ToArray();
        }

        public string[] SortPeople2(string[] names, int[] heights)
        {
            return names.Zip(heights, (name, height) => (name, height))
                        .OrderByDescending(t => t.height)
                        .Select(t => t.name)
                        .ToArray();
        }
    }
}
