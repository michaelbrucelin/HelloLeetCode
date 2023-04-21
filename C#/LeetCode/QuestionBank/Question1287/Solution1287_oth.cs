using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1287
{
    public class Solution1287_oth : Interface1287
    {
        public int FindSpecialInteger(int[] arr)
        {
            int span = arr.Length >> 2;
            for (int i = 0; i < arr.Length - span; i++)
                if (arr[i] == arr[i + span]) return arr[i];

            throw new Exception("TestCase Or Code Logic Error.");  // 题目保证了一定有唯一解
        }
    }
}
