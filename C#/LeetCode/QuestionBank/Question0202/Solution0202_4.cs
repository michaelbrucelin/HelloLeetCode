using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0202
{
    public class Solution0202_4 : Interface0202
    {
        public bool IsHappy(int n)
        {
            HashSet<int> happy = new HashSet<int>() { 1, 7, 10, 13, 19, 23, 28, 31, 32, 44, 49, 68, 70, 79, 82, 86, 91, 94, 97, 100, 103, 109, 129, 130, 133, 139, 167, 176, 188, 190, 192, 193, 203, 208, 219, 226, 230, 236, 239 };

            while (n > 243) n = GetNext(n);

            return happy.Contains(n);
        }

        private int GetNext(int n)
        {
            int t = 0;
            while (n > 0)
            {
                var info = Math.DivRem(n, 10);
                t += info.Remainder * info.Remainder;
                n = info.Quotient;
            }

            return t;
        }

        /// <summary>
        /// 243是999的Next值，打表的大小可以自定义，这里选择在这个范围打表
        /// [ 1, 7, 10, 13, 19, 23, 28, 31, 32, 44, 49, 68, 70, 79, 82, 86, 91, 94, 97, 100, 103, 109, 129, 130, 133, 139, 167, 176, 188, 190, 192, 193, 203, 208, 219, 226, 230, 236, 239 ]
        /// </summary>
        /// <returns></returns>
        private List<int> GetHappy()
        {
            List<int> list = new List<int>();

            for (int i = 1; i <= 243; i++)
            {
                int slow = i, fast = GetNext(i);
                while (fast != 1 && fast != slow)
                {
                    slow = GetNext(slow);
                    fast = GetNext(GetNext(fast));
                }
                if (fast == 1) list.Add(i);
            }

            return list;
        }
    }
}
