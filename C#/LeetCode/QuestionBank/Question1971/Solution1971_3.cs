using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1971
{
    public class Solution1971_3 : Interface1971
    {
        public bool ValidPath(int n, int[][] edges, int source, int destination)
        {
            if (source == destination) return true;

            int[] disjoint = new int[n];
            for (int i = 0; i < disjoint.Length; i++) disjoint[i] = i;
            for (int i = 0; i < edges.Length; i++)
            {
                Union(disjoint, edges[i][0], edges[i][1]);
                if (Find(disjoint, source) == Find(disjoint, destination)) return true;
            }

            return false;
        }

        private void Union(int[] disjoint, int v1, int v2)
        {
            int _v1 = Find(disjoint, v1), _v2 = Find(disjoint, v2);
            int _v = Math.Min(_v1, _v2);
            disjoint[_v1] = disjoint[_v2] = disjoint[v1] = disjoint[v2] = _v;
        }

        private int Find(int[] disjoint, int v)
        {
            while (disjoint[v] != v) v = disjoint[v];
            return v;
        }
    }
}
