#### [�������������������](https://leetcode.cn/problems/maximum-depth-of-binary-tree/solutions/349250/er-cha-shu-de-zui-da-shen-du-by-leetcode-solution/)

**˼·���㷨**

����Ҳ�����á���������������ķ�������������Ŀ����������Ҫ�������һЩ�޸ģ���ʱ���ǹ�����������Ķ������ŵ��ǡ���ǰ������нڵ㡹��ÿ����չ��һ���ʱ�򣬲�ͬ�ڹ������������ÿ��ֻ�Ӷ������ó�һ���ڵ㣬������Ҫ������������нڵ㶼�ó���������չ�������ܱ�֤ÿ����չ���ʱ��������ŵ��ǵ�ǰ������нڵ㣬��������һ��һ��ؽ�����չ�����������һ������ $ans$ ��ά����չ�Ĵ������ö������������ȼ�Ϊ $ans$��

```cpp
class Solution {
public:
    int maxDepth(TreeNode* root) {
        if (root == nullptr) return 0;
        queue<TreeNode*> Q;
        Q.push(root);
        int ans = 0;
        while (!Q.empty()) {
            int sz = Q.size();
            while (sz > 0) {
                TreeNode* node = Q.front();Q.pop();
                if (node->left) Q.push(node->left);
                if (node->right) Q.push(node->right);
                sz -= 1;
            }
            ans += 1;
        } 
        return ans;
    }
};
```

```java
class Solution {
    public int maxDepth(TreeNode root) {
        if (root == null) {
            return 0;
        }
        Queue<TreeNode> queue = new LinkedList<TreeNode>();
        queue.offer(root);
        int ans = 0;
        while (!queue.isEmpty()) {
            int size = queue.size();
            while (size > 0) {
                TreeNode node = queue.poll();
                if (node.left != null) {
                    queue.offer(node.left);
                }
                if (node.right != null) {
                    queue.offer(node.right);
                }
                size--;
            }
            ans++;
        }
        return ans;
    }
}
```

```go
func maxDepth(root *TreeNode) int {
    if root == nil {
        return 0
    }
    queue := []*TreeNode{}
    queue = append(queue, root)
    ans := 0
    for len(queue) > 0 {
        sz := len(queue)
        for sz > 0 {
            node := queue[0]
            queue = queue[1:]
            if node.Left != nil {
                queue = append(queue, node.Left)
            }
            if node.Right != nil {
                queue = append(queue, node.Right)
            }
            sz--
        }
        ans++
    }
    return ans
}
```

```c
struct QueNode {
    struct TreeNode *p;
    struct QueNode *next;
};

void init(struct QueNode **p, struct TreeNode *t) {
    (*p) = (struct QueNode *)malloc(sizeof(struct QueNode));
    (*p)->p = t;
    (*p)->next = NULL;
}

int maxDepth(struct TreeNode *root) {
    if (root == NULL) return 0;
    struct QueNode *left, *right;
    init(&left, root);
    right = left;
    int ans = 0, sz = 1, tmp = 0;
    while (left != NULL) {
        tmp = 0;
        while (sz > 0) {
            if (left->p->left != NULL) {
                init(&right->next, left->p->left);
                right = right->next;
                tmp++;
            }
            if (left->p->right != NULL) {
                init(&right->next, left->p->right);
                right = right->next;
                tmp++;
            }
            left = left->next;
            sz--;
        }
        sz += tmp;
        ans++;
    }
    return ans;
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$������ $n$ Ϊ�������Ľڵ�������뷽��һͬ���ķ�����ÿ���ڵ�ֻ�ᱻ����һ�Ρ�
-   �ռ临�Ӷȣ��˷����ռ������ȡ���ڶ��д洢��Ԫ�����������������»�ﵽ $O(n)$��
