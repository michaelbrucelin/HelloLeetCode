using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1287
{
    public class Solution1287 : Interface1287
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int FindSpecialInteger(int[] arr)
        {
            int len = arr.Length;
            if (len < 4) return arr[0];

            int span = len / 4;
            for (int i = 0; i < len; i++) if (arr[i] == arr[i + span]) return arr[i];
            throw new Exception("TestCase Or Code Logic Error.");
        }
    }
}
