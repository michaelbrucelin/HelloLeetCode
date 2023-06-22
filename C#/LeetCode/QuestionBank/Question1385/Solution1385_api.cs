using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1385
{
    public class Solution1385_api : Interface1385
    {
        public int FindTheDistanceValue(int[] arr1, int[] arr2, int d)
        {
            return arr1.Count(i => arr2.All(j => Math.Abs(j - i) > d));
        }
    }
}
