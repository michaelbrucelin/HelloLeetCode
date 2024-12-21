using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2545
{
    public class Solution2545_api : Interface2545
    {
        public int[][] SortTheStudents(int[][] score, int k)
        {
            Array.Sort(score, (arr1, arr2) => arr2[k] - arr1[k]);
            return score;
        }
    }
}
