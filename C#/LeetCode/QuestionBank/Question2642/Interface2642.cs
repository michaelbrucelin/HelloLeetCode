using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2642
{
    /// <summary>
    /// Your Graph object will be instantiated and called as such:
    /// Graph obj = new Graph(n, edges);
    /// obj.AddEdge(edge);
    /// int param_2 = obj.ShortestPath(node1,node2);
    /// </summary>
    public interface Interface2642
    {
        // public Graph(int n, int[][] edges);

        public void AddEdge(int[] edge);

        public int ShortestPath(int node1, int node2);
    }
}
