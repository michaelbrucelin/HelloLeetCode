using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3576
{
    public class Solution3576 : Interface3576
    {
        /// <summary>
        /// 分类讨论
        /// 最终结果只能是全部值为1或-1，由于每次使两个元素改变符号，所以
        ///     如果最终结果为1，那么-1的数量一定是偶数，否则，1的数量一定是偶数
        /// 然后由于每次操作的两个数是相邻的，那么就尝试，看看k次是否能可以完成即可
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public bool CanMakeEqual(int[] nums, int k)
        {
            int len = nums.Length;
            List<int>[] idxs = [[], []];
            for (int i = 0; i < len; i++) idxs[(nums[i] + 1) >> 1].Add(i);
            if (idxs[0].Count == 0 || idxs[1].Count == 0) return true;
            if ((idxs[0].Count & 1) == 1 && (idxs[1].Count & 1) == 1) return false;

            int cnt = 0;
            if ((idxs[0].Count & 1) != 1)  // 目标全部为1
            {
                for (int i = 1; i < idxs[0].Count; i += 2) if ((cnt += idxs[0][i] - idxs[0][i - 1]) > k) break;
                if (cnt <= k) return true;
            }
            cnt = 0;
            if ((idxs[1].Count & 1) != 1)  // 目标全部为-1
            {
                for (int i = 1; i < idxs[1].Count; i += 2) if ((cnt += idxs[1][i] - idxs[1][i - 1]) > k) break;
                if (cnt <= k) return true;
            }

            return false;
        }
    }
}
