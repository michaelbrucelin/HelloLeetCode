using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0598
{
    public class Solution0598 : Interface0598
    {
        /// <summary>
        /// 求ops的交集
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="ops"></param>
        /// <returns></returns>
        public int MaxCount(int m, int n, int[][] ops)
        {
            int rmax = m, cmax = n;
            for (int i = 0; i < ops.Length; i++)
            {
                rmax = Math.Min(rmax, ops[i][0]);
                cmax = Math.Min(cmax, ops[i][1]);
            }

            return rmax * cmax;
        }
    }
}
