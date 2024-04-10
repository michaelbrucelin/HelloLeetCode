using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1483
{
    public class Solution1483_2
    {
    }

    /// <summary>
    /// 暴力解（递归） + 记忆化
    /// 逻辑与Solution1483一样，做了下面的优化：
    /// 如果(node, k)的结果已知，那么(node, y):
    ///     如果 y <= k，那么(node, y)的结果已知
    ///     如果 y >  k，从(node, k)继续查找(node, y)，而不是从头开始
    /// 
    /// 逻辑没问题，提交会内存溢出，参考测试用例05
    ///     本想继续优化，例如当得到了(3,1) (3,2) (3,3)的结果后，其实((3,1),1) ((3,1),2) ((3,2),1)这3个值也已经知道了
    ///     但是当前已经内存溢出，就没必要做这部分优化了
    /// </summary>
    public class TreeAncestor_2 : Interface1483
    {
        public TreeAncestor_2(int n, int[] parent)
        {
            this.parent = parent;
            cache = new Dictionary<int, List<int>>();
        }

        private int[] parent;
        private Dictionary<int, List<int>> cache;

        public int GetKthAncestor(int node, int k)
        {
            if (!cache.ContainsKey(node)) cache.Add(node, new List<int>());
            if (k > cache[node].Count)
            {
                int _node = cache[node].Count == 0 ? node : cache[node][^1], _k = k - cache[node].Count;
                while (_k-- > 0 && _node != -1)
                {
                    _node = parent[_node]; cache[node].Add(_node);
                }
            }

            return k > cache[node].Count ? -1 : cache[node][k - 1];
        }
    }
}
