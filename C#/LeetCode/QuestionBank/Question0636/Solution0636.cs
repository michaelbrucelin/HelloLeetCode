using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0636
{
    public class Solution0636 : Interface0636
    {
        /// <summary>
        /// 栈
        /// </summary>
        /// <param name="n"></param>
        /// <param name="logs"></param>
        /// <returns></returns>
        public int[] ExclusiveTime(int n, IList<string> logs)
        {
            int[] result = new int[n];
            Stack<(int, int)> stack = new Stack<(int, int)>();
            (int id, int time) item;
            foreach (string log in logs)
            {
                string[] info = log.Split(':');
                int id = int.Parse(info[0]), time = int.Parse(info[2]);
                if (info[1][0] == 's')
                {
                    if (stack.Count > 0)
                    {
                        item = stack.Peek();
                        result[item.id] += time - item.time;
                    }
                    stack.Push((id, time));
                }
                else
                {
                    item = stack.Pop();
                    result[id] += time - item.time + 1;
                    if (stack.Count > 0)
                    {
                        item = stack.Pop();
                        stack.Push((item.id, time + 1));
                    }
                }
            }

            return result;
        }
    }
}
