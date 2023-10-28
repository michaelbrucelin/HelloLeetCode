using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1128
{
    public class Solution1128 : Interface1128
    {
        /// <summary>
        /// 排列组合
        /// 每一个多米诺骨牌按从小到大排列，然后[a,b]可以对等转为a*10+b或者a<<4|b，放入Hash表计数
        /// </summary>
        /// <param name="dominoes"></param>
        /// <returns></returns>
        public int NumEquivDominoPairs(int[][] dominoes)
        {
            int[] freq = new int[100];
            foreach (var arr in dominoes)
                if (arr[0] <= arr[1]) freq[arr[0] * 10 + arr[1]]++; else freq[arr[1] * 10 + arr[0]]++;

            int result = 0;
            foreach (int cnt in freq) result += (cnt * (cnt - 1)) >> 1;
            return result;
        }
    }
}
