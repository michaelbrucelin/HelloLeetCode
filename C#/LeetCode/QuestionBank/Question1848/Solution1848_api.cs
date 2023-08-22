using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1848
{
    public class Solution1848_api : Interface1848
    {
        public int GetMinDistance(int[] nums, int target, int start)
        {
            return nums.Select((num, id) => (num, id)).Where(t => t.num == target).Min(t => Math.Abs(t.id - start));
        }
    }
}
