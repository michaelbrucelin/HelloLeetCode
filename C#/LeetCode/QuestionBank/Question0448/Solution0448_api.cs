using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0448
{
    public class Solution0448_api : Interface0448
    {
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            return Enumerable.Range(1, nums.Length).Except(nums).ToList();
        }
    }
}
