using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0808
{
    public class Solution0808_2 : Interface0808
    {
        /// <summary>
        /// 递归
        /// 
        /// 逻辑没问题，意料之中的TLE
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public double SoupServings(int n)
        {
            return rec(n, n);

            double rec(int x, int y)
            {
                switch (x, y)
                {
                    case ( <= 0, <= 0): return 0.5D;
                    case ( <= 0, > 0): return 1D;
                    case ( > 0, <= 0): return 0D;
                    default:
                        return 0.25D * (rec(x - 100, y) + rec(x - 75, y - 25) + rec(x - 50, y - 50) + rec(x - 25, y - 75));
                }
            }
        }

        /// <summary>
        /// 逻辑与SoupServings()一样，添加了记忆化搜索
        /// 
        /// 逻辑没问题，没等到OLE，结果先超出了CLR的递归层数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public double SoupServings2(int n)
        {
            Dictionary<(int, int), double> memory = new Dictionary<(int, int), double>();
            return rec(n, n);

            double rec(int x, int y)
            {
                if (memory.ContainsKey((x, y))) return memory[(x, y)];
                switch (x, y)
                {
                    case ( <= 0, <= 0): memory.Add((x, y), 0.5D); break;
                    case ( <= 0, > 0): memory.Add((x, y), 1D); break;
                    case ( > 0, <= 0): memory.Add((x, y), 0D); break;
                    default:
                        memory.Add((x, y), 0.25D * (rec(x - 100, y) + rec(x - 75, y - 25) + rec(x - 50, y - 50) + rec(x - 25, y - 75)));
                        break;
                }
                return memory[(x, y)];
            }
        }

        /// <summary>
        /// 逻辑与SoupServings2()一样，将递归改为了栈模拟
        /// 
        /// 依然TLE，无所谓，即使不TLE，大概率也会OLE
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public double SoupServings3(int n)
        {
            Dictionary<(int, int), double> memory = new Dictionary<(int, int), double>();
            Stack<(int, int)> stack = new Stack<(int, int)>();
            stack.Push((n, n));
            (int x, int y) item;
            while (stack.Count > 0)
            {
                if (memory.ContainsKey(item = stack.Pop())) continue;
                switch (item)
                {
                    case ( <= 0, <= 0): memory.Add(item, 0.5D); break;
                    case ( <= 0, > 0): memory.Add(item, 1D); break;
                    case ( > 0, <= 0): memory.Add(item, 0D); break;
                    default:
                        (int x, int y) item1 = (item.x - 100, item.y), item2 = (item.x - 75, item.y - 25), item3 = (item.x - 50, item.y - 50), item4 = (item.x - 25, item.y - 75);
                        if (memory.ContainsKey(item1) && memory.ContainsKey(item2) && memory.ContainsKey(item3) && memory.ContainsKey(item4))
                        {
                            memory.Add(item, 0.25D * (memory[item1] + memory[item2] + memory[item3] + memory[item4]));
                        }
                        else
                        {
                            stack.Push(item);
                            if (!memory.ContainsKey(item1)) stack.Push(item1);
                            if (!memory.ContainsKey(item2)) stack.Push(item2);
                            if (!memory.ContainsKey(item3)) stack.Push(item3);
                            if (!memory.ContainsKey(item4)) stack.Push(item4);
                        }
                        break;
                }
            }

            return memory[(n, n)];
        }
    }
}
