using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1539
{
    public class Solution1539_3 : Interface1539
    {
        /// <summary>
        /// 遍历“空隙”
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindKthPositive(int[] arr, int k)
        {
            if (k < arr[0]) return k;
            int cnt = arr[0] - 1, len = arr.Length;
            for (int i = 1; i < len; i++)
            {
                if (cnt + arr[i] - arr[i - 1] - 1 >= k)
                {
                    return arr[i - 1] + k - cnt;
                }
                else
                {
                    cnt += arr[i] - arr[i - 1] - 1;
                }
            }

            return arr[^1] + k - cnt;
        }
    }
}
