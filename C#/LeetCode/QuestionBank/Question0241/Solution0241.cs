using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0241
{
    public class Solution0241 : Interface0241
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IList<int> DiffWaysToCompute(string expression)
        {
            int len = expression.Length;
            List<int> exunit = [];        // -1:+ -2:- -3:*
            int num = 0;
            foreach (char c in expression) switch (c)
                {
                    case '+': exunit.Add(num); num = 0; exunit.Add(-1); break;
                    case '-': exunit.Add(num); num = 0; exunit.Add(-2); break;
                    case '*': exunit.Add(num); num = 0; exunit.Add(-3); break;
                    default: num = num * 10 + (c & 15); break;
                }
            exunit.Add(num);
            len = exunit.Count;

            Dictionary<(int, int), List<int>> memory = new Dictionary<(int, int), List<int>>();
            dfs(0, len - 1);

            return memory[(0, len - 1)];

            void dfs(int left, int right)
            {
                if (memory.ContainsKey((left, right))) return;

                if (left == right) { memory.Add((left, right), [exunit[left]]); return; }

                List<int> list = [];
                int x = exunit[left];
                for (int _left = left + 2; _left <= right; _left += 2)
                {
                    if (!memory.ContainsKey((_left, right))) dfs(_left, right);
                    switch (exunit[_left - 1])
                    {
                        case -1: foreach (int y in memory[(_left, right)]) list.Add(x + y); x += exunit[_left]; break;
                        case -2: foreach (int y in memory[(_left, right)]) list.Add(x - y); x -= exunit[_left]; break;
                        case -3: foreach (int y in memory[(_left, right)]) list.Add(x * y); x *= exunit[_left]; break;
                        default: break;
                    }
                }
                // list.Add(x);
                memory.Add((left, right), list);
            }
        }
    }
}
