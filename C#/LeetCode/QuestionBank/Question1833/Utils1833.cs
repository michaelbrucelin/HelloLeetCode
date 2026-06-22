using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1833
{
    public class Utils1833
    {
        /// <summary>
        /// 找出使用堆排与计数排序的临界点，即数组数量小于等于N时，使用小顶堆，大于N时使用计数排序
        /// </summary>
        /// <returns></returns>
        public void Dial()
        {
            int result = -1, N = (int)1e5, low = 1, high = (int)1e5, mid;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                if (mid * Math.Log2(mid) <= N)
                {
                    result = mid; low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            Console.WriteLine(result);
        }
    }
}
