using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2076
{
    public class Solution2076 : Interface2076
    {
        /// <summary>
        /// 暴力搜索图
        /// 每次申请，相当于将两个点连接起来，然后从其中一个点开始，DFS/BFS找出全部的相连的点，放入集合，然后再逐个判断restrictions
        /// 
        /// 大概率会TLE，先写出来试试，如果用可回退（忽略路径压缩）的并查集，感觉也不快
        /// 提交竟然通过了... ...
        /// </summary>
        /// <param name="n"></param>
        /// <param name="restrictions"></param>
        /// <param name="requests"></param>
        /// <returns></returns>
        public bool[] FriendRequests(int n, int[][] restrictions, int[][] requests)
        {
            int len = requests.Length;
            HashSet<int>[] graph = new HashSet<int>[n];
            for (int i = 0; i < n; i++) graph[i] = [];

            bool[] result = new bool[len];
            HashSet<int> group = new HashSet<int>();
            Queue<int> queue = new Queue<int>();
            for (int i = 0, x, y, node; i < len; i++)
            {
                x = requests[i][0]; y = requests[i][1];
                graph[x].Add(y); graph[y].Add(x);
                group.Clear();
                queue.Enqueue(x);
                while (queue.Count > 0)
                {
                    node = queue.Dequeue();
                    if (group.Add(node))
                    {
                        foreach (int _node in graph[node]) queue.Enqueue(_node);
                    }
                }

                result[i] = true;
                foreach (int[] split in restrictions) if (group.Contains(split[0]) && group.Contains(split[1]))
                    {
                        result[i] = false;
                        graph[x].Remove(y); graph[y].Remove(x);
                        break;
                    }
            }

            return result;
        }
    }
}
