using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3309
{
    public class Solution3309 : Interface3309
    {
        /// <summary>
        /// 枚举
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxGoodNumber(int[] nums)
        {
            int[] move = new int[3];
            for (int i = 0; i < 3; i++) move[i] = GetHighestBitIndex(nums[i]);

            int result = 0, _result;
            int[][] order = [[0, 1, 2], [0, 2, 1], [1, 0, 2], [1, 2, 0], [2, 0, 1], [2, 1, 0]];
            for (int i = 0; i < 6; i++)
            {
                _result = nums[order[i][2]];
                _result += nums[order[i][1]] << move[order[i][2]];
                _result += nums[order[i][0]] << (move[order[i][1]] + move[order[i][2]]);
                result = Math.Max(result, _result);
            }

            return result;

            static int GetHighestBitIndex(int value)
            {
                int result = 0;
                while (value > 0) { result++; value >>= 1; }
                return result;
            }
        }
    }
}
