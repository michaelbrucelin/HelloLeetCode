using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1871
{
    public class Solution1871 : Interface1871
    {
        /// <summary>
        /// DFS
        /// 
        /// 栈溢出 + TLE，参考测试用例03
        /// </summary>
        /// <param name="s"></param>
        /// <param name="minJump"></param>
        /// <param name="maxJump"></param>
        /// <returns></returns>
        public bool CanReach(string s, int minJump, int maxJump)
        {
            if (s[^1] == '1') return false;

            int len = s.Length;
            bool[] visited = new bool[len];
            return dfs(0);

            bool dfs(int idx)
            {
                if (idx == len - 1) return true;
                if (visited[idx]) return false;
                visited[idx] = true;
                for (int x = minJump; x <= maxJump && idx + x < len; x++)
                {
                    if (s[idx + x] == '0' && dfs(idx + x)) return true;
                }
                return false;
            }
        }
    }
}
