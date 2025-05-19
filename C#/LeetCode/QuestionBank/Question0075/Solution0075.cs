using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0075
{
    public class Solution0075 : Interface0075
    {
        /// <summary>
        /// 计数排序
        /// </summary>
        /// <param name="nums"></param>
        public void SortColors(int[] nums)
        {
            int[] count = new int[3];
            foreach (int num in nums) count[num]++;
            int pos = 0;
            for (int i = 0; i < 3; i++) for (int j = 0; j < count[i]; j++) nums[pos++] = i;
        }
    }
}
