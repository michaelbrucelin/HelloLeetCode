using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1376
{
    public class Solution1376_2 : Interface1376
    {
        /// <summary>
        /// BFS
        /// 1. 将manager数组转为树，然后BFS解决
        /// 2. 树是特殊的图，转为图更为简单，这里使用邻接表表示图
        /// </summary>
        /// <param name="n"></param>
        /// <param name="headID"></param>
        /// <param name="manager"></param>
        /// <param name="informTime"></param>
        /// <returns></returns>
        public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime)
        {
            List<int>[] arc = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                if (manager[i] != -1)
                {
                    if (arc[manager[i]] == null) arc[manager[i]] = new List<int>();
                    arc[manager[i]].Add(i);
                }
            }

            int result = 0;
            Queue<(int id, int time)> queue = new Queue<(int id, int time)>(); queue.Enqueue((headID, informTime[headID]));
            int cnt; while ((cnt = queue.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    var info = queue.Dequeue();
                    if (arc[info.id] == null)
                    {
                        result = Math.Max(result, info.time);
                    }
                    else
                    {
                        for (int j = 0; j < arc[info.id].Count; j++)
                        {
                            queue.Enqueue((arc[info.id][j], info.time + informTime[arc[info.id][j]]));
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// BFS
        /// 与NumOfMinutes()一样，这里使用邻接矩阵
        /// 逻辑没问题，但是提交会内存溢出，参考测试用例05，这里也体现了用邻接矩阵表示图的弊端，没有使用稀疏矩阵继续尝试
        /// </summary>
        /// <param name="n"></param>
        /// <param name="headID"></param>
        /// <param name="manager"></param>
        /// <param name="informTime"></param>
        /// <returns></returns>
        public int NumOfMinutes2(int n, int headID, int[] manager, int[] informTime)
        {
            int[,] arc = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                if (manager[i] != -1) arc[manager[i], i] = 1;
            }

            int result = 0;
            Queue<(int id, int time)> queue = new Queue<(int id, int time)>(); queue.Enqueue((headID, informTime[headID]));
            int cnt; while ((cnt = queue.Count) > 0)
            {
                for (int i = 0; i < cnt; i++)
                {
                    var info = queue.Dequeue(); bool flag = true;
                    for (int j = 0; j < n; j++)
                    {
                        if (arc[info.id, j] == 1)
                        {
                            queue.Enqueue((j, info.time + informTime[j]));
                            flag = false;
                        }
                    }
                    if (flag) result = Math.Max(result, info.time);
                }
            }

            return result;
        }
    }
}
