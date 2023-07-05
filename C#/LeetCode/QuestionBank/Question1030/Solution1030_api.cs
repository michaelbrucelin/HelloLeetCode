using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1030
{
    public class Solution1030_api : Interface1030
    {
        public int[][] AllCellsDistOrder(int rows, int cols, int rCenter, int cCenter)
        {
            var rs = Enumerable.Range(0, rows);
            var cs = Enumerable.Range(0, cols);
            var query = rs.SelectMany(r => cs.Select(c => new int[] { r, c }));

            return query.OrderBy(arr => Math.Abs(arr[0] - rCenter) + Math.Abs(arr[1] - cCenter))
                        .ToArray();
        }
    }
}
