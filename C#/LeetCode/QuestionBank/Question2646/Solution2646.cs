using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2646
{
    public class Solution2646 : Interface2646
    {
        /// <summary>
        /// DFS + 记忆化搜索（类DP）
        /// 首先，定义几个数据结构
        ///     1. price[]，题目提供了
        ///     2. cnt[]，记录所有“旅行”，途径各个节点的次数，初始值为0
        ///     3. totalPrice，已知了cnt[]，就可以计算出所有节点都不折扣的总价格
        ///     3. discnt[]，如果这个节点折扣，以这个节点为根的子树的总折扣价格，即需要从总价格中减掉的价格，初始值为0
        ///     4. undiscnt[]，如果这个节点不折扣，以这个节点为根的子树的总折扣价格，即需要从总价格中减掉的价格，初始值为0
        /// 1. 将图处理为树，固定0节点为根，每个节点记录：父节点, 父节点集合（含自身）, 子节点集合
        /// 2. 既然是树，而且每个节点的成本都是正值，那么任意两个节点之间的“旅行”路径是唯一的
        ///     从start向上找父节点，一直找到根，如果某一级的父节点在end的父节点集合中，那么start到end就是通过这一级的父节点连接的
        ///     有了start到end的路径，那么就知道途径哪些节点了，更新cnt[]，当所有的路径都找完了，更新discnt与undiscnt数组
        /// 3. DFS，自底向上，对于每个节点
        ///     1. 如果没有途径，折不折扣都不影响总价格，discnt[] = undiscnt[] = SUM(MAX(discnt_i, undiscnt_i))
        ///     2. 如果途径，discnt[] = SUM(undiscnt_i), undiscnt[] = SUM(MAX(discnt_i, undiscnt_i))
        /// 4. 最后的结果就是totalPrice - MAX(discnt[0], undiscnt[0])，节点0是根
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <param name="price"></param>
        /// <param name="trips"></param>
        /// <returns></returns>
        public int MinimumTotalPrice(int n, int[][] edges, int[] price, int[][] trips)
        {
            // 处理为树
            (int parent, HashSet<int> parents, HashSet<int> children)[] tree = new (int parent, HashSet<int> parents, HashSet<int> children)[n];
            for (int i = 0; i < n; i++) tree[i] = (-1, null, new HashSet<int>());
            foreach (int[] arr in edges) { tree[arr[0]].children.Add(arr[1]); tree[arr[1]].children.Add(arr[0]); }
            tree[0].parents = new HashSet<int>() { 0 };
            DoTree(tree, 0);  // 将图处理为树（有向图），并更新树的节点的细节，选择节点0为根

            // 找出所有的途径节点及其途径次数
            int[] cnt = new int[n]; int start, end, ptrA, ptrZ;
            foreach (int[] arr in trips)
            {
                //if (arr[0] == arr[1])
                //{
                //    cnt[arr[0]]++;
                //}
                //else
                //{
                ptrA = start = arr[0]; ptrZ = end = arr[1];
                while (!tree[end].parents.Contains(ptrA)) { cnt[ptrA]++; ptrA = tree[ptrA].parent; }
                cnt[ptrA]++;
                while (ptrZ != ptrA) { cnt[ptrZ]++; ptrZ = tree[ptrZ].parent; }
                //}
            }

            // DFS
            int[] discnt = new int[n], undiscnt = new int[n];
            dfs(tree, 0, price, cnt, discnt, undiscnt);

            // 计算结果
            int totalPrice = 0;
            for (int i = 0; i < n; i++) totalPrice += price[i] * cnt[i];
            return totalPrice - Math.Max(discnt[0], undiscnt[0]);
        }

        private void dfs((int parent, HashSet<int> parents, HashSet<int> children)[] tree, int id, int[] price, int[] cnt, int[] discnt, int[] undiscnt)
        {
            int _discnt;

            if (tree[id].children.Count == 0)  // 叶子节点
            {
                if (cnt[id] > 0) discnt[id] = (price[id] >> 1) * cnt[id];
            }
            else                               // 非叶子节点
            {
                foreach (int child in tree[id].children) dfs(tree, child, price, cnt, discnt, undiscnt);

                _discnt = 0; foreach (int child in tree[id].children) _discnt += Math.Max(discnt[child], undiscnt[child]);
                if (cnt[id] > 0)  // 途径
                {
                    undiscnt[id] = _discnt;                                                  // 不折扣
                    foreach (int child in tree[id].children) discnt[id] += undiscnt[child];  // 折扣
                    discnt[id] += (price[id] >> 1) * cnt[id];                                // 折扣
                }
                else              // 不途径
                {
                    discnt[id] = undiscnt[id] = _discnt;                                     // 不折扣，折扣
                }
            }
        }

        private void DoTree((int parent, HashSet<int> parents, HashSet<int> children)[] tree, int id)
        {
            foreach (int child in tree[id].children)
            {
                tree[child].parent = id;
                tree[child].parents = new HashSet<int>(tree[id].parents) { child };
                tree[child].children.Remove(id);
                DoTree(tree, child);
            }
        }
    }
}
