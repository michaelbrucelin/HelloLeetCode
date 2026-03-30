using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1306
{
    public class Solution1306 : Interface1306
    {
        /// <summary>
        /// DFS
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public bool CanReach(int[] arr, int start)
        {
            int len = arr.Length;
            bool[] visited = new bool[len];

            return dfs(start);

            bool dfs(int pos)
            {
                if (visited[pos]) return false;
                if (arr[pos] == 0) return true;
                visited[pos] = true;

                if (pos - arr[pos] >= 0 && dfs(pos - arr[pos])) return true;
                if (pos + arr[pos] < len && dfs(pos + arr[pos])) return true;
                return false;
            }
        }
    }
}
