using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3780
{
    public class Solution3780 : Interface3780
    {
        /// <summary>
        /// 分类讨论
        /// 3个整数和能被3整除，这三个整数对3的模有4种可能(0,0,0), (1,1,1), (2,2,2), (0,1,2)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaximumSum(int[] nums)
        {
            int result = 0, len = nums.Length;
            int[][] mods = [new int[3], new int[3], new int[3]];
            for (int i = 0; i < len; i++) insert(mods[nums[i] % 3], nums[i]);

            for (int i = 0; i < 3; i++) if (mods[i][2] > 0) result = Math.Max(result, mods[i][0] + mods[i][1] + mods[i][2]);
            if (mods[0][0] > 0 && mods[1][0] > 0 && mods[2][0] > 0) result = Math.Max(result, mods[0][0] + mods[1][0] + mods[2][0]);

            return result;

            static void insert(int[] arr, int x)
            {
                if (x > arr[0])
                {
                    arr[2] = arr[1]; arr[1] = arr[0]; arr[0] = x;
                }
                else if (x > arr[1])
                {
                    arr[2] = arr[1]; arr[1] = x;
                }
                else if (x > arr[2])
                {
                    arr[2] = x;
                }
            }
        }
    }
}
