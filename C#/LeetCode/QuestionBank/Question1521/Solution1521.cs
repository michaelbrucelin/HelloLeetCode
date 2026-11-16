using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1521
{
    public class Solution1521 : Interface1521
    {
        /// <summary>
        /// LogTrick
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int ClosestToTarget(int[] arr, int target)
        {
            int result = int.MaxValue, len = arr.Length;
            for (int i = 0; i < len; i++)
            {
                result = Math.Min(result, Math.Abs(arr[i] - target));
                if (result == 0) return 0;
                for (int j = i - 1; j >= 0 && (arr[j] & arr[i]) != arr[j]; j--)
                {
                    result = Math.Min(result, Math.Abs((arr[j] &= arr[i]) - target));
                    if (result == 0) return 0;
                }
            }

            return result;
        }
    }
}
