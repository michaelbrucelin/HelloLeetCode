using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0969
{
    public class Solution0969 : Interface0969
    {
        /// <summary>
        /// 贪心 + 模拟
        /// 1. 将n移到最前
        /// 2. 将n移到最后
        /// 3. 将n-1移到最前
        /// 4. 将n-1移到最后第2位
        /// 5. ... ...
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public IList<int> PancakeSort(int[] arr)
        {
            List<int> result = [];
            for (int x = arr.Length, i; x > 0; x--)
            {
                i = -1;
                while (arr[++i] != x) ;
                if (i == x - 1) continue;
                reverse(0, i);
                reverse(0, x - 1);
                result.Add(i + 1);
                result.Add(x);
            }

            return result;

            void reverse(int l, int r)
            {
                l--; r++;
                while (++l < --r) (arr[l], arr[r]) = (arr[r], arr[l]);
            }
        }
    }
}
