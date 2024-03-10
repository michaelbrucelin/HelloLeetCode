using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0806
{
    public class Solution0806_2 : Interface0806
    {
        /// <summary>
        /// 迭代
        /// 逻辑同Solution0806，1:1将递归翻译为迭代，写着玩的
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        public void Hanota(IList<int> A, IList<int> B, IList<int> C)
        {
            Stack<(IList<int> A, int cnt, IList<int> B, IList<int> C)> stack = new Stack<(IList<int> A, int cnt, IList<int> B, IList<int> C)>();
            stack.Push((A, A.Count, B, C));
            (IList<int> A, int cnt, IList<int> B, IList<int> C) item;
            while (stack.Count > 0)
            {
                item = stack.Pop();
                switch (item.cnt)
                {
                    case 1:
                        item.C.Add(item.A[^1]); item.A.RemoveAt(item.A.Count - 1);
                        break;
                    case > 1:
                        stack.Push((item.B, item.cnt - 1, item.A, item.C));
                        stack.Push((item.A, 1, item.B, item.C));
                        stack.Push((item.A, item.cnt - 1, item.C, item.B));
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
