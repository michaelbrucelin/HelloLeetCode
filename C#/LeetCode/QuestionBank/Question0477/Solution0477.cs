using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0477
{
    public class Solution0477 : Interface0477
    {
        /// <summary>
        /// “竖式”计算
        /// 计算每个位有多少个1，多少个0即可
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int TotalHammingDistance(int[] nums)
        {
            int result = 0, len = nums.Length;
            int[] cnts = new int[2];
            for (int i = 0; i < 31; i++)
            {
                cnts[0] = cnts[1] = 0;
                for (int j = 0; j < len; j++) cnts[(nums[j] >> i) & 1]++;
                result += cnts[0] * cnts[1];
            }

            return result;
        }

        /// <summary>
        /// 逻辑同TotalHammingDistance()，更改原数组中的值，提前剪枝
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int TotalHammingDistance2(int[] nums)
        {
            int result = 0, cnt, len = nums.Length;  // cnt表示数组中大于0的值的数量
            int[] cnts = new int[2];
            for (int i = 0; i < 31; i++)
            {
                cnt = 0;
                cnts[0] = cnts[1] = 0;
                for (int j = 0; j < len; j++)
                {
                    cnts[nums[j] & 1]++;
                    nums[j] >>= 1;
                    cnt -= (nums[j] | -nums[j]) >> 31;
                }
                result += cnts[0] * cnts[1];
                if (cnt == 0) break;
            }

            return result;
        }
    }
}
