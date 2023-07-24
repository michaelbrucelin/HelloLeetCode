using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0771
{
    public class Solution0771_api : Interface0771
    {
        public int NumJewelsInStones(string jewels, string stones)
        {
            HashSet<char> set = jewels.ToHashSet();
            return stones.Count(set.Contains);
        }
    }
}
