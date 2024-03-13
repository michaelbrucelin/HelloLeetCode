using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0803
{
    public class Solution0803_api : Interface0803
    {
        public int FindMagicIndex(int[] nums)
        {
            return nums.Select((num, id) => (num, id)).Where(t => t.num == t.id).Select(t => t.id).FirstOrDefault(-1);
        }
    }
}
