using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1606
{
    public class Solution1606 : Interface1606
    {
        /// <summary>
        /// 排序 + 双指针
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int SmallestDifference(int[] a, int[] b)
        {
            Array.Sort(a);
            Array.Sort(b);

            long result = Math.Abs(0L + a[0] - b[0]), diff;
            int pa = 0, pb = 0, lena = a.Length, lenb = b.Length;
            while (pa < lena && pb < lenb)
            {
                switch (diff = 0L + a[pa] - b[pb])
                {
                    case > 0: result = Math.Min(result, +diff); pb++; break;
                    case < 0: result = Math.Min(result, -diff); pa++; break;
                    default: return 0;
                }
            }

            return (int)result;
        }
    }
}
