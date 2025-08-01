### [括号表示法 + 字典树（Python/Java/C++/Go）](https://leetcode.cn/problems/delete-duplicate-folders-in-system/solutions/895148/zi-dian-shu-ha-xi-biao-by-endlesscheng-115r/)

**核心思路**：把**相同的子树映射为相同的字符串**，就能用哈希表去重了。

如何把子树转化成字符串？为了准确判断两棵子树的结构是否相同，需要做到两点：

1. 字符串需要包含子树所有节点的**文件夹名**。
2. 字符串要能够表达节点的**父子关系**。

考察树的递归过程，把向下「递」的动作用一个非字母字符表示，向上「归」的动作用另一个非字母字符表示，就可以描述一棵树的形状了（用非字母字符是为了与文件夹名区分开）。比如说，**用左括号表示递，用右括号表示归**。从节点 $x$ 向下递到节点 $y$，再归回 $x$，就可以表示为 $x(y)$。如果 $x$ 有两个儿子 $y$ 和 $z$（并且这两个儿子都是叶子），那么子树 $x$ 就可以表示为 $x(y)(z)$。

一般地，定义如下括号表达式：

- 对于叶子节点，设其文件夹名为 $S$，则其括号表达式就是 $S$。
- 对于任意子树 $x$，设 $x$ 的儿子为 $y_1,y_2,\dots ,y_k$，则子树 $x$ 的括号表达式为
    $$x的文件夹名+(子树y_1的表达式)+(子树y_2的表达式)+\cdots +(子树y_k的表达式)$$

![](./assets/img/Solution1948_oth.png)

看示例 4，子树 $x$ 的括号表达式为 $x(y)$，子树 $a$ 的括号表达式为 $a(x(y))(z)$，子树 $b$ 的括号表达式为 $b(x(y))(z)$。

根据题意，我们不关心子树根节点的文件夹名，在去掉子树根节点后，子树 $a$ 和子树 $b$ 的括号表达式都是 $(x(y))(z)$，所以这两个文件夹「包含非空且相同的子文件夹集合，并具有相同的子文件夹结构」。

括号表达式既包含了文件夹名，又通过**括号的嵌套关系**表达了父子关系，因此可用于判断两个文件夹是否为相同文件夹。

你可能会问：如果子树 $b$ 的两棵子树是 $z$ 在左，$x(y)$ 在右呢？得到的表达式为 $(z)(x(y))$，这样没法判断两棵子树相同呀？

解决办法：在构造括号表达式时，先把子树 $y_1,y_2,\dots ,y_k$ 的表达式按照字典序**排序**，再把表达式依次拼接，就可以避免出现上述情况了。

代码实现时，用 [字典树](https://leetcode.cn/problems/implement-trie-prefix-tree/solutions/2993894/cong-er-cha-shu-dao-er-shi-liu-cha-shu-p-xsj4/) 表示这个文件系统，节点保存文件夹名称。注意这与一般的字典树不同，不是二十六叉树那种用单个字母对应节点，而是用一整个字符串（文件夹名）对应节点。这棵字典树一个节点（文件夹）最多能有 $20000$ 个儿子（子文件夹）。

用 $paths$ 构建完字典树后，DFS 这棵树，按照前文的规则生成括号表达式 $subTreeExpr$：

- 如果首次遇到 $subTreeExpr$，那么把 $subTreeExpr$ 及其对应的子树根节点保存到哈希表中。
- 否则我们找到了重复的文件夹，把哈希表中 $subTreeExpr$ 对应的节点，以及当前节点，都标记为待删除。

最后，再次 DFS（回溯）这棵字典树，仅访问未被删除的节点，同时用一个列表 $path$ 记录路径上的文件夹名。每次递归到一个节点，就把 $path$ 的一个拷贝加到答案中。做法类似 [257\. 二叉树的所有路径](https://leetcode.cn/problems/binary-tree-paths/)。

```Python
class TrieNode:
    __slots__ = 'son', 'name', 'deleted'

    def __init__(self):
        self.son = {}
        self.name = ''  # 文件夹名称
        self.deleted = False  # 删除标记


class Solution:
    def deleteDuplicateFolder(self, paths: List[List[str]]) -> List[List[str]]:
        root = TrieNode()
        for path in paths:
            # 把 path 插到字典树中，见 208. 实现 Trie
            cur = root
            for s in path:
                if s not in cur.son:
                    cur.son[s] = TrieNode()
                cur = cur.son[s]
                cur.name = s

        expr_to_node = {}  # 子树括号表达式 -> 子树根节点

        def gen_expr(node: TrieNode) -> str:
            if not node.son:  # 叶子
                return node.name  # 表达式就是文件夹名

            # 每个子树的表达式外面套一层括号
            expr = sorted('(' + gen_expr(son) + ')' for son in node.son.values())
            sub_tree_expr = ''.join(expr)  # 按字典序拼接所有子树的表达式
            if sub_tree_expr in expr_to_node:  # 哈希表中有 sub_tree_expr，说明有重复的文件夹
                expr_to_node[sub_tree_expr].deleted = True  # 哈希表中记录的节点标记为删除
                node.deleted = True  # 当前节点标记为删除
            else:
                expr_to_node[sub_tree_expr] = node

            return node.name + sub_tree_expr

        for son in root.son.values():
            gen_expr(son)

        ans = []
        path = []

        # 在字典树上回溯，仅访问未被删除的节点，并将路径记录到答案中
        # 类似 257. 二叉树的所有路径
        def dfs(node: TrieNode) -> None:
            if node.deleted:
                return
            path.append(node.name)
            ans.append(path.copy())  # path[:]
            for child in node.son.values():
                dfs(child)
            path.pop()  # 恢复现场

        for son in root.son.values():
            dfs(son)

        return ans
```

```Java
class Solution {
    private static class TrieNode {
        Map<String, TrieNode> son = new HashMap<>();
        String name; // 文件夹名称
        boolean deleted = false; // 删除标记
    }

    public List<List<String>> deleteDuplicateFolder(List<List<String>> paths) {
        TrieNode root = new TrieNode();
        for (List<String> path : paths) {
            // 把 path 插到字典树中，见 208. 实现 Trie
            TrieNode cur = root;
            for (String s : path) {
                if (!cur.son.containsKey(s)) {
                    cur.son.put(s, new TrieNode());
                }
                cur = cur.son.get(s);
                cur.name = s;
            }
        }

        Map<String, TrieNode> exprToNode = new HashMap<>(); // 子树括号表达式 -> 子树根节点
        for (TrieNode son : root.son.values()) {
            genExpr(son, exprToNode);
        }

        List<List<String>> ans = new ArrayList<>();
        List<String> path = new ArrayList<>();
        for (TrieNode son : root.son.values()) {
            dfs(son, path, ans);
        }
        return ans;
    }

    private String genExpr(TrieNode node, Map<String, TrieNode> exprToNode) {
        if (node.son.isEmpty()) { // 叶子
            return node.name; // 表达式就是文件夹名
        }

        List<String> expr = new ArrayList<>();
        for (TrieNode son : node.son.values()) {
            // 每个子树的表达式外面套一层括号
            expr.add("(" + genExpr(son, exprToNode) + ")");
        }
        Collections.sort(expr);

        String subTreeExpr = String.join("", expr); // 按字典序拼接所有子树的表达式
        TrieNode n = exprToNode.get(subTreeExpr);
        if (n != null) { // 哈希表中有 subTreeExpr，说明有重复的文件夹
            n.deleted = true; // 哈希表中记录的节点标记为删除
            node.deleted = true; // 当前节点标记为删除
        } else {
            exprToNode.put(subTreeExpr, node);
        }

        return node.name + subTreeExpr;
    }

    // 在字典树上回溯，仅访问未被删除的节点，并将路径记录到答案中
    // 类似 257. 二叉树的所有路径
    private void dfs(TrieNode node, List<String> path, List<List<String>> ans) {
        if (node.deleted) {
            return;
        }
        path.add(node.name);
        ans.add(new ArrayList<>(path)); // 记录路径
        for (TrieNode son : node.son.values()) {
            dfs(son, path, ans);
        }
        path.removeLast(); // 恢复现场
    }
}
```

```C++
struct TrieNode {
    unordered_map<string, TrieNode*> son;
    string name; // 文件夹名称
    bool deleted = false; // 删除标记
};

class Solution {
public:
    vector<vector<string>> deleteDuplicateFolder(vector<vector<string>>& paths) {
        TrieNode* root = new TrieNode();
        for (auto& path : paths) {
            // 把 path 插到字典树中，见 208. 实现 Trie
            TrieNode* cur = root;
            for (auto& s : path) {
                if (!cur->son.contains(s)) {
                    cur->son[s] = new TrieNode();
                }
                cur = cur->son[s];
                cur->name = s;
            }
        }

        unordered_map<string, TrieNode*> expr_to_node; // 子树括号表达式 -> 子树根节点

        auto gen_expr = [&](this auto&& gen_expr, TrieNode* node) -> string {
            if (node->son.empty()) { // 叶子
                return node->name; // 表达式就是文件夹名
            }

            vector<string> expr;
            for (auto& [_, son] : node->son) {
                // 每个子树的表达式外面套一层括号
                expr.emplace_back("(" + gen_expr(son) + ")");
            }
            ranges::sort(expr);

            string sub_tree_expr;
            for (auto& e : expr) {
                sub_tree_expr += e; // 按字典序拼接所有子树的表达式
            }

            if (expr_to_node.contains(sub_tree_expr)) { // 哈希表中有 sub_tree_expr，说明有重复的文件夹
                expr_to_node[sub_tree_expr]->deleted = true; // 哈希表中记录的节点标记为删除
                node->deleted = true; // 当前节点标记为删除
            } else {
                expr_to_node[sub_tree_expr] = node;
            }

            return node->name + sub_tree_expr;
        };

        for (auto& [_, son] : root->son) {
            gen_expr(son);
        }

        vector<vector<string>> ans;
        vector<string> path;

        // 在字典树上回溯，仅访问未被删除的节点，并将路径记录到答案中
        // 类似 257. 二叉树的所有路径
        auto dfs = [&](this auto&& dfs, TrieNode* node) -> void {
            if (node->deleted) {
                return;
            }
            path.push_back(node->name);
            ans.push_back(path);
            for (auto& [_, son] : node->son) {
                dfs(son);
            }
            path.pop_back(); // 恢复现场
        };

        for (auto& [_, son] : root->son) {
            dfs(son);
        }

        return ans;
    }
};
```

```Go
type trieNode struct {
    son     map[string]*trieNode
    name    string // 文件夹名称
    deleted bool   // 删除标记
}

func deleteDuplicateFolder(paths [][]string) (ans [][]string) {
    root := &trieNode{}
    for _, path := range paths {
        // 把 path 插到字典树中，见 208. 实现 Trie
        cur := root
        for _, s := range path {
            if cur.son == nil {
                cur.son = map[string]*trieNode{}
            }
            if cur.son[s] == nil {
                cur.son[s] = &trieNode{}
            }
            cur = cur.son[s]
            cur.name = s
        }
    }

    exprToNode := map[string]*trieNode{} // 子树括号表达式 -> 子树根节点
    var genExpr func(*trieNode) string
    genExpr = func(node *trieNode) string {
        if node.son == nil { // 叶子
            return node.name // 表达式就是文件夹名
        }

        expr := make([]string, 0, len(node.son)) // 预分配空间
        for _, son := range node.son {
            // 每个子树的表达式外面套一层括号
            expr = append(expr, "("+genExpr(son)+")")
        }
        slices.Sort(expr)

        subTreeExpr := strings.Join(expr, "") // 按字典序拼接所有子树的表达式
        n := exprToNode[subTreeExpr]
        if n != nil { // 哈希表中有 subTreeExpr，说明有重复的文件夹
            n.deleted = true    // 哈希表中记录的节点标记为删除
            node.deleted = true // 当前节点标记为删除
        } else {
            exprToNode[subTreeExpr] = node
        }

        return node.name + subTreeExpr
    }
    for _, son := range root.son {
        genExpr(son)
    }

    // 在字典树上回溯，仅访问未被删除的节点，并将路径记录到答案中
    // 类似 257. 二叉树的所有路径
    path := []string{}
    var dfs func(*trieNode)
    dfs = func(node *trieNode) {
        if node.deleted {
            return
        }
        path = append(path, node.name)
        ans = append(ans, slices.Clone(path))
        for _, son := range node.son {
            dfs(son)
        }
        path = path[:len(path)-1] // 恢复现场
    }
    for _, son := range root.son {
        dfs(son)
    }
    return
}
```

#### 复杂度分析

- 时间复杂度：$O(ℓ\cdot mlogm)$，其中 $m$ 是字符串的总个数，$ℓ\le 10$ 是单个字符串的长度，题目保证 $ℓ\cdot m\le 2\cdot 10^5$。瓶颈在排序上。字符串拼接的复杂度是 $O(ℓ\cdot m)$。
  - 排序：最坏情况下一个节点有 $O(m)$ 个儿子，我们会对 $O(m)$ 个字符串排序。会发生 $O(mlogm)$ 次字符串比较，每次 $O(ℓ)$ 时间，所以排序的时间复杂度为 $O(ℓ\cdot mlogm)$。
  - 字符串拼接：可能读者会认为当树退化成链时，代码会跑到 $O((ℓ\cdot m)^2)$ 时间，但这是不可能的。注意题目的这句话：「对于不在根层级的任意文件夹，其父文件夹也会包含在输入中。」这意味着如果一棵树的高度是 $d$，那么至少要 $1+2+3+\cdots +d=O(d^2)$ 个字符串才能生成这棵树（可以参考示例 2），所以树的高度只有 $O(\sqrt{m})$。相应地，代码中的 `node.name + subTreeExpr` 会对长为 $O(ℓ\sqrt{m})$ 的字符串复制拼接 $O(\sqrt{m})$ 次，所以时间复杂度为 $O(ℓ(\sqrt{m})^2)=O(ℓ\cdot m)$。
- 空间复杂度：$O(ℓ\cdot m)$。

#### 专题训练

- [297\. 二叉树的序列化与反序列化](https://leetcode.cn/problems/serialize-and-deserialize-binary-tree/)
- 下面数据结构题单的「**六、字典树（trie）**」。

#### 分类题单

[如何科学刷题？](https://leetcode.cn/circle/discuss/RvFUtj/)

1. [滑动窗口与双指针（定长/不定长/单序列/双序列/三指针/分组循环）](https://leetcode.cn/circle/discuss/0viNMK/)
2. [二分算法（二分答案/最小化最大值/最大化最小值/第K小）](https://leetcode.cn/circle/discuss/SqopEo/)
3. [单调栈（基础/矩形面积/贡献法/最小字典序）](https://leetcode.cn/circle/discuss/9oZFK9/)
4. [网格图（DFS/BFS/综合应用）](https://leetcode.cn/circle/discuss/YiXPXW/)
5. [位运算（基础/性质/拆位/试填/恒等式/思维）](https://leetcode.cn/circle/discuss/dHn9Vk/)
6. [图论算法（DFS/BFS/拓扑排序/基环树/最短路/最小生成树/网络流）](https://leetcode.cn/circle/discuss/01LUak/)
7. [动态规划（入门/背包/划分/状态机/区间/状压/数位/数据结构优化/树形/博弈/概率期望）](https://leetcode.cn/circle/discuss/tXLS3i/)
8. [常用数据结构（前缀和/差分/栈/队列/堆/字典树/并查集/树状数组/线段树）](https://leetcode.cn/circle/discuss/mOr1u6/)
9. [数学算法（数论/组合/概率期望/博弈/计算几何/随机算法）](https://leetcode.cn/circle/discuss/IYT3ss/)
10. [贪心与思维（基本贪心策略/反悔/区间/字典序/数学/思维/脑筋急转弯/构造）](https://leetcode.cn/circle/discuss/g6KTKL/)
11. [链表、二叉树与回溯（前后指针/快慢指针/DFS/BFS/直径/LCA/一般树）](https://leetcode.cn/circle/discuss/K0n2gO/)
12. [字符串（KMP/Z函数/Manacher/字符串哈希/AC自动机/后缀数组/子序列自动机）](https://leetcode.cn/circle/discuss/SJFwQI/)
