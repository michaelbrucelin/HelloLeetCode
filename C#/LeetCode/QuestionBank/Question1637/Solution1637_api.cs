using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1637
{
    public class Solution1637_api : Interface1637
    {
        public int MaxWidthOfVerticalArea(int[][] points)
        {
            var order = points.OrderBy(arr => arr[0]).Select(arr => arr[0]).ToArray();
            return order.Skip(1).Zip(order, (i1, i2) => i1 - i2).Max();
        }

        public int MaxWidthOfVerticalArea2(int[][] points)
        {
            var order = points.OrderBy(arr => arr[0]).Select(arr => arr[0]).ToArray();
            return order.Select((i, id) => (i, id)).Skip(1).Max(t => t.i - order[t.id - 1]);
        }

        public int MaxWidthOfVerticalArea3(int[][] points)
        {
            var order = points.OrderBy(arr => arr[0]).Select(arr => arr[0]).ToArray();
            return Enumerable.Range(1, order.Length - 1).Max(i => order[i] - order[i - 1]);
        }
    }
}
