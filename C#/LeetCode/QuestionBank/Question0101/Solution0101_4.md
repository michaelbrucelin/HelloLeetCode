#### [����һ���ݹ�](https://leetcode.cn/problems/symmetric-tree/solutions/268109/dui-cheng-er-cha-shu-by-leetcode-solution/)

**˼·���㷨**

���һ������������������������Գƣ���ô������ǶԳƵġ�

![](./assets/img/Solution0101_4_01.png)

��ˣ����������ת��Ϊ����������ʲô����»�Ϊ����

���ͬʱ�����������������������Ϊ����
-   ���ǵ���������������ͬ��ֵ
-   ÿ������������������һ����������������Գ�

![](./assets/img/Solution0101_4_02.png)

���ǿ���ʵ������һ���ݹ麯����ͨ����ͬ���ƶ�������ָ��ķ����������������$p$ ָ��� $q$ ָ��һ��ʼ��ָ��������ĸ������ $p$ ����ʱ��$q$ ���ƣ�$p$ ����ʱ��$q$ ���ơ�ÿ�μ�鵱ǰ $p$ �� $q$ �ڵ��ֵ�Ƿ���ȣ����������ж����������Ƿ�Գơ�

�������¡�

```cpp
class Solution {
public:
    bool check(TreeNode *p, TreeNode *q) {
        if (!p && !q) return true;
        if (!p || !q) return false;
        return p->val == q->val && check(p->left, q->right) && check(p->right, q->left);
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

    public boolean check(TreeNode p, TreeNode q) {
        if (p == null && q == null) {
            return true;
        }
        if (p == null || q == null) {
            return false;
        }
        return p.val == q.val && check(p.left, q.right) && check(p.right, q.left);
    }
}
```

```go
func isSymmetric(root *TreeNode) bool {
    return check(root, root)
}

func check(p, q *TreeNode) bool {
    if p == nil && q == nil {
        return true
    }
    if p == nil || q == nil {
        return false
    }
    return p.Val == q.Val && check(p.Left, q.Right) && check(p.Right, q.Left) 
}
```

```typescript
const check = (p: TreeNode | null, q: TreeNode | null): boolean => {
    if (!p && !q) return true;
    if (!p || !q) return false;
    return p.val === q.val && check(p.left, q.right) && check(p.right, q.left);
}
var isSymmetric = function(root: TreeNode | null): boolean {
    return check(root, root);
};
```

**���Ӷȷ���**

��������һ�� $n$ ���ڵ㡣
-   ʱ�临�Ӷȣ���������������������ʱ�临�Ӷ�Ϊ $O(n)$��
-   �ռ临�Ӷȣ�����Ŀռ临�ӶȺ͵ݹ�ʹ�õ�ջ�ռ��йأ�����ݹ���������� $n$���ʽ����ռ临�Ӷ�Ϊ $O(n)$��
