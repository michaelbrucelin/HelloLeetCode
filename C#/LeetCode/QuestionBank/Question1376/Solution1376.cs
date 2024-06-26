﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1376
{
    public class Solution1376 : Interface1376
    {
        /// <summary>
        /// DFS
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

            return dfs(headID, arc, informTime);
        }

        private int dfs(int headID, List<int>[] arc, int[] informTime)
        {
            if (arc[headID] == null) return 0;

            int time = 0;
            for (int i = 0; i < arc[headID].Count; i++)
                time = Math.Max(time, dfs(arc[headID][i], arc, informTime));

            return informTime[headID] + time;
        }

        /// <summary>
        /// DFS
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

            return dfs2(n, headID, arc, informTime);
        }

        private int dfs2(int n, int headID, int[,] arc, int[] informTime)
        {
            int time = 0;
            for (int i = 0; i < n; i++)
                if (arc[headID, i] == 1) time = Math.Max(time, dfs2(n, i, arc, informTime));

            return informTime[headID] + time;
        }
    }
}
