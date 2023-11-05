### [填充每个节点的下一个右侧节点指针 II](https://leetcode.cn/problems/populating-next-right-pointers-in-each-node-ii/solutions/429828/tian-chong-mei-ge-jie-dian-de-xia-yi-ge-you-ce-15/)

#### 方法一：层次遍历

**思路与算法**

这道题希望我们把二叉树各个层的点组织成链表，一个非常直观的思路是层次遍历。树的层次遍历基于广度优先搜索，它按照层的顺序遍历二叉树，在遍历第 $i$ 层前，一定会遍历完第 $i - 1$ 层。

算法如下：初始化一个队列 $q$，将根结点放入队列中。当队列不为空的时候，记录当前队列大小为 $n$，从队列中以此取出 $n$ 个元素并通过这 $n$ 个元素拓展新节点。如此循环，直到队列为空。我们不难写出这样的代码：

```c++
q.push(root);
while (!q.empty()) {
    int n = q.size();
    for (int i = 1; i <= n; ++i) {
        auto f = q.front();
        q.pop();
        // 拓展新节点
        if (f->left) {
            q.push(f->left);
        }
        if (f->right) {
            q.push(f->right);
        }
        // ... 遍历当前取出的 f
    }
}
```

这样做可以保证每次遍历的 $n$ 个点都是同一层的。我们可以在遍历每一层的时候修改这一层节点的 $next$ 指针，这样就可以把每一层都组织成链表。

**代码**

```c++
class Solution {
public:
    Node* connect(Node* root) {
        if (!root) {
            return nullptr;
        }
        queue<Node*> q;
        q.push(root);
        while (!q.empty()) {
            int n = q.size();
            Node *last = nullptr;
            for (int i = 1; i <= n; ++i) {
                Node *f = q.front();
                q.pop();
                if (f->left) {
                    q.push(f->left);
                }
                if (f->right) {
                    q.push(f->right);
                }
                if (i != 1) {
                    last->next = f;
                }
                last = f;
            }
        }
        return root;
    }
};
```

```java
class Solution {
    public Node connect(Node root) {
        if (root == null) {
            return null;
        }
        Queue<Node> queue = new ArrayDeque<Node>();
        queue.offer(root);
        while (!queue.isEmpty()) {
            int n = queue.size();
            Node last = null;
            for (int i = 1; i <= n; ++i) {
                Node f = queue.poll();
                if (f.left != null) {
                    queue.offer(f.left);
                }
                if (f.right != null) {
                    queue.offer(f.right);
                }
                if (i != 1) {
                    last.next = f;
                }
                last = f;
            }
        }
        return root;
    }
}
```

```python
class Solution:
    def connect(self, root: 'Node') -> 'Node':
        if root is None:
            return None
        queue = deque([root])
        while queue:
            n = len(queue)
            last = None
            for _ in range(n):
                node = queue.popleft()
                if node.left:
                    queue.append(node.left)
                if node.right:
                    queue.append(node.right)
                if last:
                    last.next = node
                last = node
        return root
```

```csharp
public class Solution {
    public Node Connect(Node root) {
        if (root == null) {
            return null;
        }
        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(root);
        while (queue.Count > 0) {
            int n = queue.Count;
            Node last = null;
            for (int i = 1; i <= n; ++i) {
                Node f = queue.Dequeue();
                if (f.left != null) {
                    queue.Enqueue(f.left);
                }
                if (f.right != null) {
                    queue.Enqueue(f.right);
                }
                if (i != 1) {
                    last.next = f;
                }
                last = f;
            }
        }
        return root;
    }
}
```

```javascript
var connect = function(root) {
    if (root === null) {
        return null;
    }
    const queue = [root];
    while (queue.length) {
        const n = queue.length;
        let last = null;
        for (let i = 1; i <= n; ++i) {
            let f = queue.shift();
            if (f.left !== null) {
                queue.push(f.left);
            }
            if (f.right !== null) {
                queue.push(f.right);
            }
            if (i !== 1) {
                last.next = f;
            }
            last = f;
        }
    }
    return root;
};
```

```go
func connect(root *Node) *Node {
    if root == nil {
        return nil
    }
    q := []*Node{root}
    for len(q) > 0 {
        tmp := q
        q = nil
        for i, node := range tmp {
            if i+1 < len(tmp) {
                node.Next = tmp[i+1]
            }
            if node.Left != nil {
                q = append(q, node.Left)
            }
            if node.Right != nil {
                q = append(q, node.Right)
            }
        }
    }
    return root
}
```

```c
struct Node *connect(struct Node *root) {
    if (!root) {
        return NULL;
    }
    struct Node *q[10001];
    int left = 0, right = 0;
    q[right++] = root;
    while (left < right) {
        int n = right - left;
        struct Node *last = NULL;
        for (int i = 1; i <= n; ++i) {
            struct Node *f = q[left++];
            if (f->left) {
                q[right++] = f->left;
            }
            if (f->right) {
                q[right++] = f->right;
            }
            if (i != 1) {
                last->next = f;
            }
            last = f;
        }
    }
    return root;
}
```

**复杂度分析**

记树上的点的个数为 $N$。

-   时间复杂度：$O(N)$。我们需要遍历这棵树上所有的点，时间复杂度为 $O(N)$。
-   空间复杂度：$O(N)$。即队列的空间代价。

#### 方法二：使用已建立的 $next$ 指针

**思路与算法**

因为必须处理树上的所有节点，所以无法降低时间复杂度，但是可以尝试降低空间复杂度。

在方法一中，因为对树的结构一无所知，所以使用队列保证有序访问同一层的所有节点，并建立它们之间的连接。然而不难发现：一旦在某层的节点之间建立了 $next$ 指针，那这层节点实际上形成了一个链表。因此，如果先去建立某一层的 $next$ 指针，再去遍历这一层，就无需再使用队列了。

基于该想法，提出降低空间复杂度的思路：如果第 $i$ 层节点之间已经建立 $next$ 指针，就可以通过 $next$ 指针访问该层的所有节点，同时对于每个第 $i$ 层的节点，我们又可以通过它的 $\rm left$ 和 $\rm right$ 指针知道其第 $i+1$ 层的孩子节点是什么，所以遍历过程中就能够按顺序为第 $i + 1$ 层节点建立 $next$ 指针。

具体来说：

-   从根节点开始。因为第 $0$ 层只有一个节点，不需要处理。可以在上一层为下一层建立 $next$ 指针。该方法最重要的一点是：位于第 $x$ 层时为第 $x + 1$ 层建立 $next$ 指针。一旦完成这些连接操作，移至第 $x + 1$ 层为第 $x + 2$ 层建立 $next$ 指针。
-   当遍历到某层节点时，该层节点的 $next$ 指针已经建立。这样就不需要队列从而节省空间。每次只要知道下一层的最左边的节点，就可以从该节点开始，像遍历链表一样遍历该层的所有节点。

**代码**

```c++
class Solution {
public:
    void handle(Node* &last, Node* &p, Node* &nextStart) {
        if (last) {
            last->next = p;
        } 
        if (!nextStart) {
            nextStart = p;
        }
        last = p;
    }

    Node* connect(Node* root) {
        if (!root) {
            return nullptr;
        }
        Node *start = root;
        while (start) {
            Node *last = nullptr, *nextStart = nullptr;
            for (Node *p = start; p != nullptr; p = p->next) {
                if (p->left) {
                    handle(last, p->left, nextStart);
                }
                if (p->right) {
                    handle(last, p->right, nextStart);
                }
            }
            start = nextStart;
        }
        return root;
    }
};
```

```java
class Solution {
    Node last = null, nextStart = null;

    public Node connect(Node root) {
        if (root == null) {
            return null;
        }
        Node start = root;
        while (start != null) {
            last = null;
            nextStart = null;
            for (Node p = start; p != null; p = p.next) {
                if (p.left != null) {
                    handle(p.left);
                }
                if (p.right != null) {
                    handle(p.right);
                }
            }
            start = nextStart;
        }
        return root;
    }

    public void handle(Node p) {
        if (last != null) {
            last.next = p;
        } 
        if (nextStart == null) {
            nextStart = p;
        }
        last = p;
    }
}
```

```python
class Solution:
    def connect(self, root: 'Node') -> 'Node':
        if not root:
            return None
        start = root
        while start:
            self.last = None
            self.nextStart = None
            p = start
            while p:
                if p.left:
                    self.handle(p.left)
                if p.right:
                    self.handle(p.right)
                p = p.next
            start = self.nextStart
        return root

    def handle(self, p):
        if self.last:
            self.last.next = p
        if not self.nextStart:
            self.nextStart = p
        self.last = p
```

```csharp
public class Solution {
    Node last = null, nextStart = null;

    public Node Connect(Node root) {
        if (root == null) {
            return null;
        }
        Node start = root;
        while (start != null) {
            last = null;
            nextStart = null;
            for (Node p = start; p != null; p = p.next) {
                if (p.left != null) {
                    Handle(p.left);
                }
                if (p.right != null) {
                    Handle(p.right);
                }
            }
            start = nextStart;
        }
        return root;
    }

    public void Handle(Node p) {
        if (last != null) {
            last.next = p;
        } 
        if (nextStart == null) {
            nextStart = p;
        }
        last = p;
    }
}
```

```javascript
let last = null, nextStart = null;
const handle = (p) => {
    if (last !== null) {
        last.next = p;
    } 
    if (nextStart === null) {
        nextStart = p;
    }
    last = p;
}
var connect = function(root) {
    if (root === null) {
        return null;
    }
    let start = root;
    while (start != null) {
        last = null;
        nextStart = null;
        for (let p = start; p !== null; p = p.next) {
            if (p.left !== null) {
                handle(p.left);
            }
            if (p.right !== null) {
                handle(p.right);
            }
        }
        start = nextStart;
    }
    return root;
};
```

```go
func connect(root *Node) *Node {
    start := root
    for start != nil {
        var nextStart, last *Node
        handle := func(cur *Node) {
            if cur == nil {
                return
            }
            if nextStart == nil {
                nextStart = cur
            }
            if last != nil {
                last.Next = cur
            }
            last = cur
        }
        for p := start; p != nil; p = p.Next {
            handle(p.Left)
            handle(p.Right)
        }
        start = nextStart
    }
    return root
}
```

```c
void handle(struct Node **last, struct Node **p, struct Node **nextStart) {
    if (*last) {
        (*last)->next = *p;
    }
    if (!(*nextStart)) {
        *nextStart = *p;
    }
    *last = *p;
}

struct Node *connect(struct Node *root) {
    if (!root) {
        return NULL;
    }
    struct Node *start = root;
    while (start) {
        struct Node *last = NULL, *nextStart = NULL;
        for (struct Node *p = start; p != NULL; p = p->next) {
            if (p->left) {
                handle(&last, &(p->left), &nextStart);
            }
            if (p->right) {
                handle(&last, &(p->right), &nextStart);
            }
        }
        start = nextStart;
    }
    return root;
}
```

**复杂度分析**

记树上的点的个数为 $N$。

-   时间复杂度：$O(N)$。我们需要遍历这棵树上所有的点，时间复杂度为 $O(N)$。
-   空间复杂度：$O(1)$。
