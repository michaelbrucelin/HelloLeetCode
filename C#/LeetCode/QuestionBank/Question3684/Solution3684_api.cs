using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3684
{
    public class Solution3684_api : Interface3684
    {
        public int[] MaxKDistinct(int[] nums, int k)
        {
            return nums.Distinct().OrderBy(x => -x).Take(k).ToArray();
        }
    }
}
