using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0045
{
    public class Solution0045 : Interface0045
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Jump(int[] nums)
        {
            if (nums.Length == 1) return 0;

            int result = 0, cnt, len = nums.Length;
            bool[] visited = new bool[len];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0); visited[0] = true;
            while ((cnt = queue.Count) > 0)
            {
                result++;
                for (int i = 0, id; i < cnt; i++)
                {
                    id = queue.Dequeue();
                    if (id + nums[id] >= len - 1) return result;
                    for (int _id = id + 1; _id <= id + nums[id]; _id++) if (!visited[_id])
                        {
                            queue.Enqueue(_id); visited[_id] = true;
                        }
                }
            }

            return result;
        }
    }
}
