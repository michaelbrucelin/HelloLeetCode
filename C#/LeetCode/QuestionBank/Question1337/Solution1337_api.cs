using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1337
{
    public class Solution1337_api : Interface1337
    {
        public int[] KWeakestRows(int[][] mat, int k)
        {
            return mat.Select((arr, rid) => (arr.Sum(), rid))
                      .OrderBy(t => t.Item1)
                      .ThenBy(t => t.rid)
                      .Take(k)
                      .Select(t => t.rid)
                      .ToArray();
        }

        public int[] KWeakestRows2(int[][] mat, int k)
        {
            return mat.Select((arr, rid) => (arr.Select((i, id) => (i, id)).FirstOrDefault(t => t.Item1 == 0, (-1, arr.Length)).Item2, rid))
                      .OrderBy(t => t.Item1)
                      .ThenBy(t => t.rid)
                      .Take(k)
                      .Select(t => t.rid)
                      .ToArray();
        }
    }
}
