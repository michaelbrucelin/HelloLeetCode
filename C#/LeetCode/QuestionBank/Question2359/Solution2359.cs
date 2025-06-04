using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2359
{
    public class Solution2359 : Interface2359
    {
        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="edges"></param>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        /// <returns></returns>
        public int ClosestMeetingNode(int[] edges, int node1, int node2)
        {
            if (node1 == node2) return node1;

            int p1 = node1, p2 = node2, n = edges.Length;
            bool[] visited1 = new bool[n], visited2 = new bool[n];
            while ((p1 != -1 && !visited1[p1]) || (p2 != -1 && !visited2[p2]))
            {
                if (p1 != -1 && !visited1[p1]) visited1[p1] = true;
                if (p2 != -1 && !visited2[p2]) visited2[p2] = true;
                if (p1 != -1 && visited2[p1] && p2 != -1 && visited1[p2]) return Math.Min(p1, p2);
                if (p1 != -1) { if (visited2[p1]) return p1; else p1 = edges[p1]; }
                if (p2 != -1) { if (visited1[p2]) return p2; else p2 = edges[p2]; }
            }

            return -1;
        }
    }
}
