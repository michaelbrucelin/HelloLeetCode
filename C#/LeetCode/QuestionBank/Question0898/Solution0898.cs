using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0898
{
    public class Solution0898 : Interface0898
    {
        /// <summary>
        /// LogTrick
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int SubarrayBitwiseORs(int[] arr)
        {
            if (arr.Length == 0) return 0;

            int len = arr.Length;
            HashSet<int> set = [arr[0]];
            for (int i = 1; i < len; i++)
            {
                set.Add(arr[i]);
                for (int j = i - 1; j >= 0 && (arr[j] | arr[i]) != arr[j]; j--)
                {
                    set.Add(arr[j] |= arr[i]);
                }
            }

            return set.Count;
        }
    }
}
