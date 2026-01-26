using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0097
{
    public class Solution0097 : Interface0097
    {
        /// <summary>
        /// DFS + 记忆化搜索
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <param name="s3"></param>
        /// <returns></returns>
        public bool IsInterleave(string s1, string s2, string s3)
        {
            if (s1.Length + s2.Length != s3.Length) return false;

            int len1 = s1.Length, len2 = s2.Length, len3 = s3.Length;
            Dictionary<(int, int, int), bool> memory = new Dictionary<(int, int, int), bool>();
            if (dfs(0, 0, 1)) return true;
            if (dfs(0, 0, 2)) return true;
            return false;

            bool dfs(int p1, int p2, int type)  // type: 1:s1先, 2:s2先
            {
                if (memory.ContainsKey((p1, p2, type))) return memory[(p1, p2, type)];

                int p3 = p1 + p2;
                if (p3 == len3) return true;

                if (type == 1)
                {
                    for (int i = 0; p1 + i < len1 && s1[p1 + i] == s3[p3 + i]; i++) if (dfs(p1 + i + 1, p2, 2))
                        {
                            memory.Add((p1, p2, type), true);
                            return true;
                        }
                }
                else
                {
                    for (int i = 0; p2 + i < len2 && s2[p2 + i] == s3[p3 + i]; i++) if (dfs(p1, p2 + i + 1, 1))
                        {
                            memory.Add((p1, p2, type), true);
                            return true;
                        }
                }

                memory.Add((p1, p2, type), false);
                return false;
            }
        }
    }
}
