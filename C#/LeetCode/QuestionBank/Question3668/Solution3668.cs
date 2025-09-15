using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3668
{
    public class Solution3668 : Interface3668
    {
        /// <summary>
        /// 自定义排序
        /// </summary>
        /// <param name="order"></param>
        /// <param name="friends"></param>
        /// <returns></returns>
        public int[] RecoverOrder(int[] order, int[] friends)
        {
            int n = order.Length;
            int[] map = new int[n + 1];
            for (int i = 0; i < n; i++) map[order[i]] = i;
            // IComparer<int> comparer = Comparer<int>.Create((x, y) => map[x] - map[y]);
            Array.Sort(friends, (x, y) => map[x] - map[y]);

            return friends;
        }
    }
}
