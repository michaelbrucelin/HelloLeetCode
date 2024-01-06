using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1550
{
    public class Solution1550 : Interface1550
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public bool ThreeConsecutiveOdds(int[] arr)
        {
            int ptr = 0, limit = arr.Length - 2;
            while (ptr < limit)
            {
                if ((arr[ptr] & 1) != 1)
                    ptr++;
                else if ((arr[ptr + 1] & 1) != 1)
                    ptr += 2;
                else if ((arr[ptr + 2] & 1) != 1)
                    ptr += 3;
                else
                    return true;
            }

            return false;
        }
    }
}
