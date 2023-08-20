using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0575
{
    public class Solution0575_api : Interface0575
    {
        public int DistributeCandies(int[] candyType)
        {
            return Math.Min(candyType.Distinct().Count(), candyType.Length >> 1);
        }
    }
}
