using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2089
{
    public class Solution2089_3 : Interface2089
    {
        /// <summary>
        /// 计数
        /// 不需要排序，直接统计小于target与等于target的元素的数量即可
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<int> TargetIndices(int[] nums, int target)
        {
            int start = 0, cnt = 0;
            foreach (int num in nums)
            {
                if (num < target) start++; else if (num == target) cnt++;
            }

            List<int> result = new List<int>();
            for (int i = 0; i < cnt; i++) result.Add(start + i);
            return result;
        }
    }
}
