### [二叉树的右侧视图](https://leetcode.cn/problems/WNC0Lk/solutions/1398945/er-cha-shu-de-you-ce-shi-tu-by-leetcode-ucmya/?envType=problem-list-v2&envId=ySsxoJfz)

#### 前言

由于树的形状无法提前知晓，不可能设计出优于 $O(n)$ 的算法。因此，我们应该试着寻找线性时间解。带着这个想法，我们来考虑一些同等有效的方案。

#### 方法一：深度优先搜索

**思路**

我们对树进行深度优先搜索，在搜索过程中，我们总是先访问右子树。那么对于每一层来说，我们在这层见到的第一个结点一定是最右边的结点。

**算法**

这样一来，我们可以存储在每个深度访问的第一个结点，一旦我们知道了树的层数，就可以得到最终的结果数组。

![](./assets/img/Solution0046_off_1.png)

上图表示了问题的一个实例。红色结点自上而下组成答案，边缘以访问顺序标号。

```Python
class Solution:
    def rightSideView(self, root: TreeNode) -> List[int]:
        rightmost_value_at_depth = dict() # 深度为索引，存放节点的值
        max_depth = -1

        stack = [(root, 0)]
        while stack:
            node, depth = stack.pop()

            if node is not None:
                # 维护二叉树的最大深度
                max_depth = max(max_depth, depth)

                # 如果不存在对应深度的节点我们才插入
                rightmost_value_at_depth.setdefault(depth, node.val)

                stack.append((node.left, depth + 1))
                stack.append((node.right, depth + 1))

        return [rightmost_value_at_depth[depth] for depth in range(max_depth + 1)]
```

```Java
class Solution {
    public List<Integer> rightSideView(TreeNode root) {
        Map<Integer, Integer> rightmostValueAtDepth = new HashMap<Integer, Integer>();
        int max_depth = -1;

        Deque<TreeNode> nodeStack = new LinkedList<TreeNode>();
        Deque<Integer> depthStack = new LinkedList<Integer>();
        nodeStack.push(root);
        depthStack.push(0);

        while (!nodeStack.isEmpty()) {
            TreeNode node = nodeStack.pop();
            int depth = depthStack.pop();

            if (node != null) {
                // 维护二叉树的最大深度
                max_depth = Math.max(max_depth, depth);

                // 如果不存在对应深度的节点我们才插入
                if (!rightmostValueAtDepth.containsKey(depth)) {
                    rightmostValueAtDepth.put(depth, node.val);
                }

                nodeStack.push(node.left);
                nodeStack.push(node.right);
                depthStack.push(depth + 1);
                depthStack.push(depth + 1);
            }
        }

        List<Integer> rightView = new ArrayList<Integer>();
        for (int depth = 0; depth <= max_depth; depth++) {
            rightView.add(rightmostValueAtDepth.get(depth));
        }

        return rightView;
    }
}
```

```C++
class Solution {
public:
    vector<int> rightSideView(TreeNode* root) {
        unordered_map<int, int> rightmostValueAtDepth;
        int max_depth = -1;

        stack<TreeNode*> nodeStack;
        stack<int> depthStack;
        nodeStack.push(root);
        depthStack.push(0);

        while (!nodeStack.empty()) {
            TreeNode* node = nodeStack.top();nodeStack.pop();
            int depth = depthStack.top();depthStack.pop();

            if (node != NULL) {
                // 维护二叉树的最大深度
                max_depth = max(max_depth, depth);

                // 如果不存在对应深度的节点我们才插入
                if (rightmostValueAtDepth.find(depth) == rightmostValueAtDepth.end()) {
                    rightmostValueAtDepth[depth] =  node -> val;
                }

                nodeStack.push(node -> left);
                nodeStack.push(node -> right);
                depthStack.push(depth + 1);
                depthStack.push(depth + 1);
            }
        }

        vector<int> rightView;
        for (int depth = 0; depth <= max_depth; ++depth) {
            rightView.push_back(rightmostValueAtDepth[depth]);
        }

        return rightView;
    }
};
```

**复杂度分析**

- 时间复杂度 $: O(n)$。深度优先搜索最多访问每个结点一次，因此是线性复杂度。
- 空间复杂度 $: O(n)$。最坏情况下，栈内会包含接近树高度的结点数量，占用 $O(n)$ 的空间。

#### 方法二：广度优先搜索

**思路**

我们可以对二叉树进行层次遍历，那么对于每层来说，最右边的结点一定是最后被遍历到的。二叉树的层次遍历可以用广度优先搜索实现。

**算法**

执行广度优先搜索，左结点排在右结点之前，这样，我们对每一层都从左到右访问。因此，只保留每个深度最后访问的结点，我们就可以在遍历完整棵树后得到每个深度最右的结点。除了将栈改成队列，并去除了 `rightmost_value_at_depth` 之前的检查外，算法没有别的改动。

![](./assets/img/Solution0046_off_2.png)

上图表示了同一个示例，红色结点自上而下组成答案，边缘以访问顺序标号。

```Python
class Solution:
    def rightSideView(self, root: TreeNode) -> List[int]:
        rightmost_value_at_depth = dict() # 深度为索引，存放节点的值
        max_depth = -1

        queue = deque([(root, 0)])
        while queue:
            node, depth = queue.popleft()

            if node is not None:
                # 维护二叉树的最大深度
                max_depth = max(max_depth, depth)

                # 由于每一层最后一个访问到的节点才是我们要的答案，因此不断更新对应深度的信息即可
                rightmost_value_at_depth[depth] = node.val

                queue.append((node.left, depth + 1))
                queue.append((node.right, depth + 1))

        return [rightmost_value_at_depth[depth] for depth in range(max_depth + 1)]
```

```Java
class Solution {
    public List<Integer> rightSideView(TreeNode root) {
        Map<Integer, Integer> rightmostValueAtDepth = new HashMap<Integer, Integer>();
        int max_depth = -1;

        Queue<TreeNode> nodeQueue = new LinkedList<TreeNode>();
        Queue<Integer> depthQueue = new LinkedList<Integer>();
        nodeQueue.add(root);
        depthQueue.add(0);

        while (!nodeQueue.isEmpty()) {
            TreeNode node = nodeQueue.remove();
            int depth = depthQueue.remove();

            if (node != null) {
                // 维护二叉树的最大深度
                max_depth = Math.max(max_depth, depth);

                // 由于每一层最后一个访问到的节点才是我们要的答案，因此不断更新对应深度的信息即可
                rightmostValueAtDepth.put(depth, node.val);

                nodeQueue.add(node.left);
                nodeQueue.add(node.right);
                depthQueue.add(depth + 1);
                depthQueue.add(depth + 1);
            }
        }

        List<Integer> rightView = new ArrayList<Integer>();
        for (int depth = 0; depth <= max_depth; depth++) {
            rightView.add(rightmostValueAtDepth.get(depth));
        }

        return rightView;
    }
}
```

```C++
class Solution {
public:
    vector<int> rightSideView(TreeNode* root) {
        unordered_map<int, int> rightmostValueAtDepth;
        int max_depth = -1;

        queue<TreeNode*> nodeQueue;
        queue<int> depthQueue;
        nodeQueue.push(root);
        depthQueue.push(0);

        while (!nodeQueue.empty()) {
            TreeNode* node = nodeQueue.front();nodeQueue.pop();
            int depth = depthQueue.front();depthQueue.pop();

            if (node != NULL) {
                // 维护二叉树的最大深度
                max_depth = max(max_depth, depth);

                // 由于每一层最后一个访问到的节点才是我们要的答案，因此不断更新对应深度的信息即可
                rightmostValueAtDepth[depth] =  node -> val;

                nodeQueue.push(node -> left);
                nodeQueue.push(node -> right);
                depthQueue.push(depth + 1);
                depthQueue.push(depth + 1);
            }
        }

        vector<int> rightView;
        for (int depth = 0; depth <= max_depth; ++depth) {
            rightView.push_back(rightmostValueAtDepth[depth]);
        }

        return rightView;
    }
};
```

**复杂度分析**

- 时间复杂度 $: O(n)$。 每个节点最多进队列一次，出队列一次，因此广度优先搜索的复杂度为线性。
- 空间复杂度 $: O(n)$。每个节点最多进队列一次，所以队列长度最大不不超过 $n$，所以这里的空间代价为 $O(n)$。

---

**注释**

[`deque`](https://leetcode.cn/link/?target=https%3A%2F%2Fdocs.python.org%2F3%2Flibrary%2Fcollections.html%23collections.deque) 数据类型来自于[`collections`](https://leetcode.cn/link/?target=https%3A%2F%2Fdocs.python.org%2F3%2Flibrary%2Fcollections.html) 模块，支持从头和尾部的常数时间 $append/pop$ 操作。若使用 $Python$ 的 `list`，通过 `list.pop(0)` 去除头部会消耗 $O(n)$ 的时间。
