using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3668
{
    public class Solution3668_2 : Interface3668
    {
        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="order"></param>
        /// <param name="friends"></param>
        /// <returns></returns>
        public int[] RecoverOrder(int[] order, int[] friends)
        {
            int n = order.Length;
            bool[] set = new bool[n + 1];
            foreach (int x in friends) set[x] = true;

            n = 0;
            foreach (int x in order) if (set[x]) friends[n++] = x;

            return friends;
        }
    }
}
