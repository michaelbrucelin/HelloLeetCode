using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1539
{
    public class Solution1539 : Interface1539
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int FindKthPositive(int[] arr, int k)
        {
            int len = arr.Length;
            if (arr[^1] - len < k) return len + k;

            int num = 0, i = 0;
            while (k > 0)
            {
                num++;
                if (num != arr[i]) k--; else i++;
            }

            return num;
        }
    }
}
