using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1306
{
    public class Solution1306_2 : Interface1306
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public bool CanReach(int[] arr, int start)
        {
            int len = arr.Length;
            bool[] visited = new bool[len];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            int pos;
            while (queue.Count > 0)
            {
                pos = queue.Dequeue();
                if (visited[pos]) continue;
                if (arr[pos] == 0) return true;
                visited[pos] = true;
                if (pos - arr[pos] >= 0) queue.Enqueue(pos - arr[pos]);
                if (pos + arr[pos] < len) queue.Enqueue(pos + arr[pos]);
            }

            return false;
        }
    }
}
