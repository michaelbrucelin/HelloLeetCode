using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0744
{
    public class Solution0744 : Interface0744
    {
        /// <summary>
        /// 二分法
        /// </summary>
        /// <param name="letters"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public char NextGreatestLetter(char[] letters, char target)
        {
            char result = letters[0];
            int left = 0, right = letters.Length - 1, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (letters[mid] > target)
                {
                    result = letters[mid]; right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return result;
        }
    }
}
