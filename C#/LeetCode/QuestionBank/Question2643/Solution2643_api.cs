using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2643
{
    public class Solution2643_api : Interface2643
    {
        public int[] RowAndMaximumOnes(int[][] mat)
        {
            return mat.Select((row, rid) => new int[] { rid, row.Sum() })
                      .OrderByDescending(arr => arr[1])
                      .ThenBy(arr => arr[0])
                      .First();
        }
    }
}
