using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3640
{
    public class Solution3640 : Interface3640
    {
        /// <summary>
        /// 多轮遍历
        /// 如果找出一个最长的三段式子数组，那么
        ///     第1段，取和最大的后缀子数组
        ///     第2段，和不变
        ///     第3段，取和最大的前缀子数组
        /// 基于上面思路，制定下面解题过程，有些轮的遍历可以合并为1轮，那都是编码技巧了，这里只描述思路过程
        /// 1. 遍历，预处理出前缀和
        /// 2. 遍历，找出所有的严格递增区间与严格递减区间
        /// 3. 遍历，找出递增区间的和最大的前缀，只记录位置就可以（有前缀和）
        /// 4. 遍历，找出递增区间的和最大的后缀，只记录位置就可以（有前缀和）
        /// 5. 遍历，找最终结果
        /// 
        /// 下面编码时，1 3 4 这3个步骤合并在第 5 步中，因为不会重复计算，所以没必要预处理
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public long MaxSumTrionic(int[] nums)
        {
            if (nums.Length < 4) return 0;
            if (nums.Length == 4 && nums[1] > nums[0] && nums[2] < nums[1] && nums[3] > nums[2]) return 0L + nums[0] + nums[1] + nums[2] + nums[3];

            List<(int, int, int)> ranges = new List<(int, int, int)>();  // (left_id, right_id, asc or desc)
            int pl = 0, pr = 1, len = nums.Length;
            int flag = ((nums[1] - nums[0]) >> 31) - ((nums[0] - nums[1]) >> 31), _flag;
            while (true)
            {
                if (pr + 1 == len) break;
                _flag = ((nums[pr + 1] - nums[pr]) >> 31) - ((nums[pr] - nums[pr + 1]) >> 31);
                if (_flag == flag) { pr++; continue; }
                ranges.Add((pl, pr, flag));
                pl = pr; pr++; flag = _flag;
            }
            ranges.Add((pl, pr, flag));

            long result = long.MinValue, sum1, sum2, sum3, _sum; len = ranges.Count;
            for (int i = 0, j = 1, k = 2, p; k < len; i++, j++, k++) if (ranges[i].Item3 == 1 && ranges[j].Item3 == -1 && ranges[k].Item3 == 1)
                {
                    (pl, pr, _) = ranges[j];
                    sum1 = nums[pl - 1]; sum2 = 0; sum3 = nums[pr + 1];
                    for (p = pl; p <= pr; p++) sum2 += nums[p];                             // 第2段全部保留
                    (pl, pr, _) = ranges[i]; _sum = sum1;
                    for (p = pr - 2; p >= pl; p--) sum1 = Math.Max(sum1, _sum += nums[p]);  // 第1段找最大后缀
                    (pl, pr, _) = ranges[k]; _sum = sum2;
                    for (p = pl + 2; p <= pr; p++) sum2 = Math.Max(sum2, _sum += nums[p]);  // 第3段找最大前缀

                    result = Math.Max(result, sum1 + sum2 + sum3);
                }

            return result;
        }
    }
}
