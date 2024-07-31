using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0055
{
    public class Solution0055 : Interface0055
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CanJump(int[] nums)
        {
            if (nums.Length == 1) return true;

            int len = nums.Length;
            bool[] visited = new bool[len];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0); visited[0] = true;
            int id; while (queue.Count > 0)
            {
                id = queue.Dequeue();
                if (id + nums[id] >= len - 1) return true;
                for (int _id = id + 1; _id <= id + nums[id]; _id++) if (!visited[_id])
                    {
                        queue.Enqueue(_id); visited[_id] = true;
                    }
            }

            return false;
        }
    }
}
