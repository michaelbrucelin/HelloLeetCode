using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0167
{
    public class Solution0167 : Interface0167
    {
        /// <summary>
        /// 二分法
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] numbers, int target)
        {
            int len = numbers.Length, _target;
            for (int i = 0; i < len; i++)
            {
                if (i > 0 && numbers[i] == numbers[i - 1]) continue;
                _target = target - numbers[i];
                int low = i + 1, high = len - 1, mid;
                while (low <= high)
                {
                    mid = low + ((high - low) >> 1);
                    if (numbers[mid] < _target) low = mid + 1;
                    else if (numbers[mid] > _target) high = mid - 1;
                    else return new int[] { i + 1, mid + 1 };
                }
            }

            throw new Exception("logic error.");
        }

        /// <summary>
        /// 二分法
        /// 对TwoSum()略加优化，下一轮的二分法，右边界从上一轮的右边界开始即可
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum2(int[] numbers, int target)
        {
            int len = numbers.Length, _target, low, high = len - 1, mid;
            for (int i = 0; i < len; i++)
            {
                if (i > 0 && numbers[i] == numbers[i - 1]) continue;
                _target = target - numbers[i];
                low = i + 1;
                while (low <= high)
                {
                    mid = low + ((high - low) >> 1);
                    if (numbers[mid] < _target) low = mid + 1;
                    else if (numbers[mid] > _target) high = mid - 1;
                    else return new int[] { i + 1, mid + 1 };
                }
            }

            throw new Exception("logic error.");
        }
    }
}
