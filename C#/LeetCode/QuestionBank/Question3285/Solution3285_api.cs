using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3285
{
    public class Solution3285_api : Interface3285
    {
        public IList<int> StableMountains(int[] height, int threshold)
        {
            return Enumerable.Range(1, height.Length - 1)
                             .Where(i => height[i - 1] > threshold)
                             .ToArray();
        }
    }
}
