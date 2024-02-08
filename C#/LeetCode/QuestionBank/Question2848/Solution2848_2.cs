using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2848
{
    public class Solution2848_2 : Interface2848
    {
        /// <summary>
        /// 排序 + 合并区间
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int NumberOfPoints(IList<IList<int>> nums)
        {
            nums = nums.OrderBy(list => list[1]).ThenBy(list => list[0]).ToList();
            for (int i = nums.Count - 1; i > 0; i--)
            {
                if (nums[i][0] > nums[i - 1][1]) continue;
                nums[i - 1][1] = nums[i][1];
                nums[i - 1][0] = Math.Min(nums[i - 1][0], nums[i][0]);
                nums.RemoveAt(i);
            }

            int result = 0;
            foreach (var arr in nums) result += arr[1] - arr[0] + 1;

            return result;
        }
    }
}
