using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0060
{
    public class Solution0060 : Interface0060
    {
        /// <summary>
        /// 下一个排列
        /// 可以优化缩小规模。例如n=9，k > 8! && k < 2*8!，那么，直接从213456789开始向后找就行，还可以比较与 7! 的大小，继续缩小规模
        /// 
        /// 以为会TLE，竟然过了。。。
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public string GetPermutation(int n, int k)
        {
            char[] chars = new char[n];
            for (int i = 0; i < n; i++) chars[i] = (char)('1' + i);
            while (--k > 0) next(chars);

            return new string(chars);

            static void next(char[] list)
            {
                int p1, p2, n = list.Length;
                for (p1 = n - 2; p1 >= 0 && list[p1] > list[p1 + 1]; p1--) ;
                if (p1 < 0) return;
                for (p2 = n - 1; p2 > p1 && list[p2] < list[p1]; p2--) ;
                (list[p1], list[p2]) = (list[p2], list[p1]);
                for (int i = p1 + 1, j = n - 1; i < j; i++, j--) (list[i], list[j]) = (list[j], list[i]);
            }
        }
    }
}
