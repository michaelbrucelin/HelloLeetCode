using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1017
{
    public class Solution1017 : Interface1017
    {
        /// <summary>
        /// 数学
        /// 具体分析见Solution1017.md
        /// 
        /// 用栈实现
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string BaseNeg2(int n)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 与BaseNeg2()一样，用List实现
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string BaseNeg22(int n)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 与BaseNeg2()一样，用双向链表实现
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string BaseNeg23(int n)
        {
            if (n == 0) return "0";

            LinkedList<int> bin = new LinkedList<int>();
            int pos = 0;
            while (n > 0) { if ((n & 1) != 0) bin.AddLast(pos); n >>= 1; pos++; }

            StringBuilder result = new StringBuilder();
            int id = 0;
            while (bin.Count > 0)
            {
                pos = bin.First(); bin.RemoveFirst();
                if (bin.Count > 0 && pos == bin.First())
                {
                    bin.RemoveFirst(); bin.AddFirst(pos + 1);
                }
                else
                {
                    while (id < pos) { result.Insert(0, 0); id++; }
                    if ((pos & 1) != 0) bin.AddFirst(pos + 1);
                    result.Insert(0, 1); id++;
                }
            }

            return result.ToString();
        }
    }
}
