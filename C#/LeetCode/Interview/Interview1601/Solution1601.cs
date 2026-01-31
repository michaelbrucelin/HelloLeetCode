
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1601
{
    public class Solution1601 : Interface1601
    {
        /// <summary>
        /// 位运算
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public int[] SwapNumbers(int[] numbers)
        {
            numbers[0] ^= numbers[1];
            numbers[1] ^= numbers[0];
            numbers[0] ^= numbers[1];

            return numbers;
        }
    }
}
