using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0704
{
    public class Solution0704_api : Interface0704
    {
        public int Search(int[] nums, int target)
        {
            int result;
            return nums.Select((num, id) => (num, id)).ToDictionary(t => t.num, t => t.id).TryGetValue(target, out result) ? result : -1;
        }
    }
}
