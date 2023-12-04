using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2951
{
    public class Solution2951 : Interface2951
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="mountain"></param>
        /// <returns></returns>
        public IList<int> FindPeaks(int[] mountain)
        {
            List<int> result = new List<int>();
            for (int i = 1; i < mountain.Length - 1; i++)
                if (mountain[i] > mountain[i - 1] && mountain[i] > mountain[i + 1]) result.Add(i);

            return result;
        }
    }
}
