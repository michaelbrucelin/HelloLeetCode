#### [������������](https://leetcode.cn/problems/symmetric-tree/solutions/268109/dui-cheng-er-cha-shu-by-leetcode-solution/)

**˼·���㷨**

������һ���������õݹ�ķ���ʵ���˶Գ��Ե��жϣ���ô����õ����ķ���ʵ���أ�������������һ�����У����ǰѵݹ�����д�ɵ�������ĳ��÷�������ʼ��ʱ���ǰѸ��ڵ�������Ρ�ÿ����ȡ������㲢�Ƚ����ǵ�ֵ��������ÿ���������Ľ��Ӧ������ȵģ��������ǵ�������Ϊ���񣩣�Ȼ���������������ӽ�㰴�෴��˳���������С�������Ϊ��ʱ���������Ǽ�⵽�����Գƣ����Ӷ�����ȡ����������ȵ�������㣩ʱ�����㷨������

```cpp
class Solution {
public:
    bool check(TreeNode *u, TreeNode *v) {
        queue <TreeNode*> q;
        q.push(u); q.push(v);
        while (!q.empty()) {
            u = q.front(); q.pop();
            v = q.front(); q.pop();
            if (!u && !v) continue;
            if ((!u || !v) || (u->val != v->val)) return false;

            q.push(u->left); 
            q.push(v->right);

            q.push(u->right); 
            q.push(v->left);
        }
        return true;
    }

    bool isSymmetric(TreeNode* root) {
        return check(root, root);
    }
};
```

```java
class Solution {
    public boolean isSymmetric(TreeNode root) {
        return check(root, root);
    }

    public boolean check(TreeNode u, TreeNode v) {
        Queue<TreeNode> q = new LinkedList<TreeNode>();
        q.offer(u);
        q.offer(v);
        while (!q.isEmpty()) {
            u = q.poll();
            v = q.poll();
            if (u == null && v == null) {
                continue;
            }
            if ((u == null || v == null) || (u.val != v.val)) {
                return false;
            }

            q.offer(u.left);
            q.offer(v.right);

            q.offer(u.right);
            q.offer(v.left);
        }
        return true;
    }
}
```

```go
func isSymmetric(root *TreeNode) bool {
    u, v := root, root
    q := []*TreeNode{}
    q = append(q, u)
    q = append(q, v)
    for len(q) > 0 {
        u, v = q[0], q[1]
        q = q[2:]
        if u == nil && v == nil {
            continue
        }
        if u == nil || v == nil {
            return false
        }
        if u.Val != v.Val {
            return false
        }
        q = append(q, u.Left)
        q = append(q, v.Right)

        q = append(q, u.Right)
        q = append(q, v.Left)
    }
    return true
}
```

```typescript
const check = (u: TreeNode | null, v: TreeNode | null): boolean => {
    const q: (TreeNode | null)[] = [];
    q.push(u),q.push(v);

    while (q.length) {
        u = q.shift()!;
        v = q.shift()!;

        if (!u && !v) continue;
        if ((!u || !v) || (u.val !== v.val)) return false;

        q.push(u.left); 
        q.push(v.right);

        q.push(u.right); 
        q.push(v.left);
    }
    return true;
}
var isSymmetric = function(root: TreeNode | null): boolean {
    return check(root, root);
};
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$��ͬ������һ����
-   �ռ临�Ӷȣ�������Ҫ��һ��������ά���ڵ㣬ÿ���ڵ�������һ�Σ�����һ�Σ���������಻�ᳬ�� $n$ ���㣬�ʽ����ռ临�Ӷ�Ϊ $O(n)$��
