using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3898
{
    public class Solution3898_api : Interface3898
    {
        public int[] FindDegrees(int[][] matrix)
        {
            return matrix.Select(x => x.Sum()).ToArray();
        }
    }
}
