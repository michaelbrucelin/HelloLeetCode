using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1310
{
    public class Solution1310 : Interface1310
    {
        /// <summary>
        /// 前缀和
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public int[] XorQueries(int[] arr, int[][] queries)
        {
            int len = arr.Length;
            int[] prexor = new int[len + 1];
            for (int i = 0; i < len; i++) prexor[i + 1] = prexor[i] ^ arr[i];

            len = queries.Length;
            int[] result = new int[len];
            for (int i = 0; i < len; i++) result[i] = prexor[queries[i][1] + 1] ^ prexor[queries[i][0]];
            return result;
        }
    }
}
