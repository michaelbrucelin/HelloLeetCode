using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3372
{
    public class Solution3372_2 : Interface3372
    {
        /// <summary>
        /// 换根DP
        /// 逻辑同Solution3372，将BFS改为换根DP
        /// 
        /// 不写了，思路是维护左侧第1层，第2层..第k层的节点，与总节点数
        ///               维护右侧第1层，第2层..第k层的节点，与总节点数
        /// 然后将根换成每一个child
        /// </summary>
        /// <param name="edges1"></param>
        /// <param name="edges2"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] MaxTargetNodes(int[][] edges1, int[][] edges2, int k)
        {
            int n1 = edges1.Length + 1, n2 = edges2.Length + 1;
            List<int>[] tree1 = new List<int>[n1], tree2 = new List<int>[n2];
            for (int i = 0; i < n1; i++) tree1[i] = new List<int>();
            foreach (int[] edge in edges1) { tree1[edge[0]].Add(edge[1]); tree1[edge[1]].Add(edge[0]); }
            for (int i = 0; i < n2; i++) tree2[i] = new List<int>();
            foreach (int[] edge in edges2) { tree2[edge[0]].Add(edge[1]); tree2[edge[1]].Add(edge[0]); }

            int[] result = new int[n1];

            return result;

            int[] dp(List<int>[] tree, int step)
            {
                int n = tree.Length;
                int[] cnts = new int[n];
                if (step < 0) return cnts;
                if (step == 0) { Array.Fill(cnts, 1); return cnts; }

                // 以0为根
                List<int>[] lchild = new List<int>[step + 1]; int lcnt = 1;
                List<int>[] rchild = new List<int>[step + 1]; int rcnt = 1;
                Queue<int> queue = new Queue<int>();
                bool[] visited = new bool[n];

                return cnts;
            }
        }
    }
}
