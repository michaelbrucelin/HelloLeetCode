using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2391
{
    public class Solution2391 : Interface2391
    {
        /// <summary>
        /// 遍历，位运算
        /// </summary>
        /// <param name="garbage"></param>
        /// <param name="travel"></param>
        /// <returns></returns>
        public int GarbageCollection(string[] garbage, int[] travel)
        {
            int len = garbage.Length;
            int[] sums = new int[len];    // travel前缀和
            for (int i = 1; i < len; i++) sums[i] = sums[i - 1] + travel[i - 1];

            int[,] info = new int[2, 4];  // M 01001101, P 01010000, G 01000111, info[0]记录垃圾的数量，info[1]记录垃圾的最远位置
            for (int i = 0; i < len; i++) foreach (char c in garbage[i])
                {
                    info[0, c & 3]++; info[1, c & 3] = i;
                }

            int result = 0;
            for (int i = 0; i < 4; i++) result += info[0, i] + sums[info[1, i]];
            return result;
        }
    }
}
