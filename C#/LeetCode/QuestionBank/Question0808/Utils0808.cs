using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0808
{
    public class Utils0808
    {
        /// <summary>
        /// 直觉上有数学上的O(1)解，但是没想出来，所以打印一些结果观察一下规律
        /// </summary>
        public void Dial(int n)
        {
            Solution0808 solution = new Solution0808();
            double[] result = new double[n + 1];
            for (int i = 0; i <= n; i++) result[i] = solution.SoupServings2(i);
            Utils.Dump(result);
        }
    }
}
