using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1601
{
    public class Solution1601_api : Interface1601
    {
        public int[] SwapNumbers(int[] numbers)
        {
            (numbers[0], numbers[1]) = (numbers[1], numbers[0]);
            return numbers;
        }
    }
}
