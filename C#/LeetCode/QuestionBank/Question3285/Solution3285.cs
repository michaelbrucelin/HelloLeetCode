using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3285
{
    public class Solution3285 : Interface3285
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="height"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public IList<int> StableMountains(int[] height, int threshold)
        {
            List<int> result = new List<int>();
            for (int i = 1; i < height.Length; i++) if (height[i - 1] > threshold) result.Add(i);

            return result;
        }
    }
}
