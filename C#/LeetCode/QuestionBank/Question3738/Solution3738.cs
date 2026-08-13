using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3738
{
    public class Solution3738 : Interface3738
    {
        /// <summary>
        /// 贪心
        /// 先预处理出所有的非递减区间，然后逐个判断两个相邻的能不能合并即可
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int LongestSubarray(int[] nums)
        {
            if (nums.Length < 3) return nums.Length;

            List<(int, int)> list = [];
            int pl = 0, pr, len = nums.Length;
            while (pl < len)
            {
                pr = pl;
                while (pr + 1 < len && nums[pr + 1] >= nums[pr]) pr++;
                list.Add((pl, pr));
                pl = pr + 1;
            }
            if (list.Count == 1) return len;

            int result = list[0].Item2 - list[0].Item1 + 2, cnt = list.Count;
            for (int i = 1, len1, len2; i < cnt; i++)
            {
                len1 = list[i - 1].Item2 - list[i - 1].Item1 + 1;
                len2 = list[i].Item2 - list[i].Item1 + 1;
                // result = Math.Max(result, Math.Max(len1 + 1, len2 + 1));
                result = Math.Max(result, len2 + 1);
                if (len2 > 1 && nums[list[i].Item1 + 1] >= nums[list[i - 1].Item2]) result = Math.Max(result, len1 + len2);
                if (len1 > 1 && nums[list[i - 1].Item2 - 1] <= nums[list[i].Item1]) result = Math.Max(result, len1 + len2);
            }

            return result;
        }
    }
}
