using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0806
{
    public class Solution0806 : Interface0806
    {
        /// <summary>
        /// 递归
        /// 将A全部移到C，相当于
        /// 1. A除了最后一个元素的其余元素全部移到B
        /// 2. A最后一个元素移到C
        /// 3. B的全部元素移到C
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        public void Hanota(IList<int> A, IList<int> B, IList<int> C)
        {
            Hanota(A, A.Count, B, C);
        }

        private void Hanota(IList<int> A, int cnt, IList<int> B, IList<int> C)
        {
            switch (cnt)
            {
                case 1:
                    C.Add(A[^1]); A.RemoveAt(A.Count - 1);
                    break;
                case > 1:
                    Hanota(A, cnt - 1, C, B);
                    C.Add(A[^1]); A.RemoveAt(A.Count - 1);
                    Hanota(B, cnt - 1, A, C);
                    break;
                default:
                    break;
            }
        }
    }
}
