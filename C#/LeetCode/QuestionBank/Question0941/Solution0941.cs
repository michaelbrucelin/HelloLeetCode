using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0941
{
    public class Solution0941 : Interface0941
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public bool ValidMountainArray(int[] arr)
        {
            if (arr.Length < 3) return false;

            int i = 1, len = arr.Length;
            while (i < len && arr[i] > arr[i - 1]) i++;
            if (i == 1 || i == len || arr[i] == arr[i - 1]) return false;
            while (i < len && arr[i] < arr[i - 1]) i++;
            if (i == len) return true;

            return false;
        }
    }
}
