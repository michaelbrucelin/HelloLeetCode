#### [��ģ�壡BFS �� DFS �����Խ��]()

#### ����

�����������ǰѶ�������ÿһ��ڵ���뵽ͬһ���б��У���󷵻ظ�����б���ɵ��ܵ��б�

����ʹ�� BFS �� DFS �����

�����BFS�����ղ����������ͼ�ұ���DFS����һ·�ߵ��ף�Ȼ���ٻ�ͷ������

![](./assets/img/Solution0102_4.png)

#### BFS

BFSʹ�ö��У���ÿ����û���������ĵ����η�����У�Ȼ���ٵ������е�ͷ��Ԫ�ص�����ǰ�����㡣BFS�ܹ�������ģ�壺

1.  �������Ҫȷ����ǰ����������һ�㣬BFSģ�����¡�

```cpp
while queue ���գ�
    cur = queue.pop()
    for �ڵ� in cur���������ڽڵ㣺
        if �ýڵ���Ч��δ���ʹ���
            queue.push(�ýڵ�)
```

2.  ���Ҫȷ����ǰ����������һ�㣬BFSģ�����¡� ����������level��ʾ��ǰ�������������е���һ���ˣ�Ҳ�������Ϊ��һ��ͼ�У������Ѿ����˶��ٲ��ˡ�size��ʾ�ڵ�ǰ�������ж��ٸ�Ԫ�أ�Ҳ���Ƕ����е�Ԫ���������ǰ���ЩԪ��һ���Ա����꣬���ѵ�ǰ�������Ԫ�ض���������һ����

```cpp
level = 0
while queue ���գ�
    size = queue.size()
    while (size --) {
        cur = queue.pop()
        for �ڵ� in cur���������ڽڵ㣺
            if �ýڵ���Ч��δ�����ʹ���
                queue.push(�ýڵ�)
    }
    level ++;
```

����������ͨ��ģ�壬���κ���Ŀ�ж������ã���Ҫ��ס�ģ�

����Ҫ��������Ĳ�α���������ͬһ��Ľڵ�Ӧ�÷���һ�𣬹�ʹ��ģ�����

ʹ�ö��б���ÿ������нڵ㣬ÿ�ΰѶ������ԭ�����нڵ���г����в������ٰ�ÿ��Ԫ�صķǿ������ӽڵ������С���˼��ɵõ�ÿ��ı�����

�����ԵĴ������£�

```python
# Definition for a binary tree node.
# class TreeNode(object):
#     def __init__(self, x):
#         self.val = x
#         self.left = None
#         self.right = None

class Solution(object):
    def levelOrder(self, root):
        """
        :type root: TreeNode
        :rtype: List[List[int]]
        """
        queue = collections.deque()
        queue.append(root)
        res = []
        while queue:
            size = len(queue)
            level = []
            for _ in range(size):
                cur = queue.popleft()
                if not cur:
                    continue
                level.append(cur.val)
                queue.append(cur.left)
                queue.append(cur.right)
            if level:
                res.append(level)
        return res
```

```cpp
/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     TreeNode *left;
 *     TreeNode *right;
 *     TreeNode(int x) : val(x), left(NULL), right(NULL) {}
 * };
 */
class Solution {
public:
    vector<vector<int>> levelOrder(TreeNode* root) {
        queue<TreeNode*> que;
        que.push(root);
        vector<vector<int>> res;
        while (que.size() != 0) {
            int size = que.size();
            vector<int> level;
            while (size --) {
                TreeNode* cur = que.front();
                que.pop();
                if (!cur) {
                    continue;
                }
                level.push_back(cur->val);
                que.push(cur->left);
                que.push(cur->right);
            }
            if (level.size() != 0) {
                res.push_back(level);
            }
        }
        return res;
    }
};
```

```java
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode(int x) { val = x; }
 * }
 */
class Solution {
    public List<List<Integer>> levelOrder(TreeNode root) {
        List<List<Integer>> res = new ArrayList<>();
        Queue<TreeNode> q = new LinkedList<>();
        q.offer(root);
        while (!q.isEmpty()) {
            int size = q.size();
            List<Integer> level = new LinkedList<>();
            for (int i = 0; i < size; ++i) {
                TreeNode cur = q.peek();
                q.poll();
                if (cur == null) {
                    continue;
                }
                level.add(cur.val);
                q.offer(cur.left);
                q.offer(cur.right);
            }
            if (!level.isEmpty()) {
                res.add(level);
            }
        }
        return res;
    }
}
```

##### DFS

����ʹ�� DFS ͬ��������������ĿҪ��ÿһ��Ľڵ㶼�Ǵ����ұ�������˵ݹ�ʱҲҪ�ȵݹ����������ٵݹ���������

DFS ���������Ҫ�����ǣ� DFS ���ǰ��ղ�α����ġ�Ϊ���õݹ�Ĺ�����ͬһ��Ľڵ�ŵ�ͬһ���б��У��ڵݹ�ʱҪ��¼ÿ���ڵ����� level���ݹ鵽�½ڵ�Ҫ�Ѹýڵ���� level ��Ӧ�б��ĩβ��

��������һ���µ���� level�������ս�� res �л�û�д��� level ��Ӧ���б�ʱ��Ӧ���� res ���½�һ���б���������� level �����нڵ㡣

�����ԵĴ������£�

```python
# Definition for a binary tree node.
# class TreeNode(object):
#     def __init__(self, x):
#         self.val = x
#         self.left = None
#         self.right = None

class Solution(object):
    def levelOrder(self, root):
        """
        :type root: TreeNode
        :rtype: List[List[int]]
        """
        res = []
        self.level(root, 0, res)
        return res

    def level(self, root, level, res):
        if not root: return
        if len(res) == level: res.append([])
        res[level].append(root.val)
        if root.left: self.level(root.left, level + 1, res)
        if root.right: self.level(root.right, level + 1, res)
```

```cpp
/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     TreeNode *left;
 *     TreeNode *right;
 *     TreeNode(int x) : val(x), left(NULL), right(NULL) {}
 * };
 */
class Solution {
public:
    vector<vector<int>> levelOrder(TreeNode* root) {
        vector<vector<int>> res;
        dfs(res, root, 0);
        return res;
    }
    void dfs(vector<vector<int>>& res, TreeNode* root, int level) {
        if (!root) return;
        if (level >= res.size())
            res.push_back(vector<int>());
        res[level].push_back(root->val);
        dfs(res, root->left, level + 1);
        dfs(res, root->right, level + 1);
    }
};
```

```java
class Solution {
    public List<List<Integer>> levelOrder(TreeNode root) {
        List<List<Integer>> res  = new ArrayList<>();
        if(root != null){
            dfs(res, root, 0);
        }
        return res;
    }
    
    private void dfs(List<List<Integer>> res, TreeNode node, int level){
        if(res.size() - 1 < level){
            res.add(new ArrayList<Integer>());
        }
        res.get(level).add(node.val);
        if(node.left!=null){
            dfs(res, node.left, level + 1);
        }
        if(node.right!=null){
            dfs(res, node.right, level + 1);
        }
    }
}
```
