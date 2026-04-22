using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3819
{
    public class Solution3819 : Interface3819
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] RotateElements(int[] nums, int k)
        {
            if (k == 0) return nums;

            int len = nums.Length;
            List<int> ids = [];
            for (int i = 0; i < len; i++) if (nums[i] >= 0) ids.Add(i);
            int cnt = ids.Count;
            if (cnt < 2 || k % cnt == 0) return nums;

            k %= cnt;
            Dictionary<int, int> temp = new Dictionary<int, int>();
            for (int i = 0, j = k; i < cnt; i++, j++)
            {
                if (i < k) temp.Add(ids[i], nums[ids[i]]);
                j %= cnt;
                nums[ids[i]] = j > i ? nums[ids[j]] : temp[ids[j]];
            }

            return nums;
        }
    }
}
