using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1331
{
    public class Solution1331_api : Interface1331
    {
        public int[] ArrayRankTransform(int[] arr)
        {
            var map = arr.Distinct().OrderBy(i => i).Select((val, id) => (val, id)).ToDictionary(t => t.val, t => t.id + 1);
            return arr.Select(i => map[i]).ToArray();
        }
    }
}
