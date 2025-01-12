using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2275
{
    public class Solution2275 : Interface2275
    {
        /// <summary>
        /// 遍历，逐位分析
        /// 按位与结果大于0，即至少有一位全部为1，所以枚举每一位即可
        /// 题目限定的数据范围是1e7，所以枚举24位即可
        /// </summary>
        /// <param name="candidates"></param>
        /// <returns></returns>
        public int LargestCombination(int[] candidates)
        {
            int result = 0, cnt, len = candidates.Length;
            for (int i = 0; i < 24; i++)
            {
                cnt = 0;
                for (int j = 0; j < len; j++) cnt += (candidates[j] >> i) & 1;
                result = Math.Max(result, cnt);
            }

            return result;
        }
    }
}
