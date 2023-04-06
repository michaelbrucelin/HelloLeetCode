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
        /// 用List实现
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string BaseNeg2(int n)
        {
            if (n == 0) return "0";

            List<int> bin = new List<int>();
            while (n > 0) { bin.Add(n & 1); n >>= 1; }

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < bin.Count; i++)
            {
                switch (bin[i])
                {
                    case 0:
                        result.Insert(0, 0); break;
                    case 1:
                        if ((i & 1) != 0)
                        {
                            if (bin.Count != i + 1) bin[i + 1]++; else bin.Add(1);
                        }
                        result.Insert(0, 1);
                        break;
                    case 2:
                        if (bin.Count != i + 1) bin[i + 1]++; else bin.Add(1);
                        result.Insert(0, 0);
                        break;
                    default:
                        throw new Exception("logic error!");
                }
            }

            return result.ToString();
        }

        /// <summary>
        /// 与BaseNeg2()一样，用栈实现
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string BaseNeg22(int n)
        {
            if (n == 0) return "0";

            Stack<int> buffer = new Stack<int>();
            int pos = 0;
            while (n > 0) { if ((n & 1) != 0) buffer.Push(pos); n >>= 1; pos++; }
            Stack<int> bin = new Stack<int>(buffer);

            StringBuilder result = new StringBuilder();
            int id = 0;
            while (bin.Count > 0)
            {
                pos = bin.Pop();
                if (bin.Count > 0 && pos == bin.Peek())
                {
                    bin.Pop(); bin.Push(pos + 1);
                }
                else
                {
                    while (id < pos) { result.Insert(0, 0); id++; }
                    if ((pos & 1) != 0) bin.Push(pos + 1);
                    result.Insert(0, 1); id++;
                }
            }

            return result.ToString();
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
