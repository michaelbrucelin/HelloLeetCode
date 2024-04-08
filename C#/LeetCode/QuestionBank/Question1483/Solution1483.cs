using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1483
{
    public class Solution1483
    {
    }

    /// <summary>
    /// 暴力解（递归） + 记忆化
    /// 逻辑没问题，提交会超时，参考测试用例03
    /// </summary>
    public class TreeAncestor : Interface1483
    {
        public TreeAncestor(int n, int[] parent)
        {
            this.parent = parent;
            cache = new Dictionary<(int node, int k), int>();
        }

        private int[] parent;
        private Dictionary<(int node, int k), int> cache;

        public int GetKthAncestor(int node, int k)
        {
            if (!cache.ContainsKey((node, k)))
            {
                int _node = node, _k = k;
                while (_k-- > 0 && _node != -1) _node = parent[_node];
                cache.Add((node, k), _node);
            }

            return cache[(node, k)];
        }
    }
}
