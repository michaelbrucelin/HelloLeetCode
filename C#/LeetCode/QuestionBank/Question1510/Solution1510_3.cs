using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1510
{
    public class Solution1510_3 : Interface1510
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool WinnerSquareGame(int n)
        {
            HashSet<int> square = new HashSet<int>();
            for (int i = 1, j; (j = i * i) < 100000; i++) square.Add(j);
            Dictionary<(int, bool), bool> memory = new Dictionary<(int, bool), bool>();

            return dfs(n, true, square, memory);

            static bool dfs(int n, bool isAlice, HashSet<int> square, Dictionary<(int, bool), bool> memory)
            {
                if (square.Contains(n)) return isAlice;
                if (memory.ContainsKey((n, isAlice))) return memory[(n, isAlice)];

                if (isAlice)
                {
                    for (int i = 1, j; (j = i * i) < n; i++) if (dfs(n - j, false, square, memory))
                        {
                            memory.Add((n, isAlice), true);
                            return true;
                        }
                    memory.Add((n, isAlice), false);
                    return false;
                }
                else
                {
                    for (int i = 1, j; (j = i * i) < n; i++) if (!dfs(n - j, true, square, memory))
                        {
                            memory.Add((n, isAlice), false);
                            return false;
                        }
                    memory.Add((n, isAlice), true);
                    return true;
                }
            }
        }
    }
}
