#### [����һ�������������](https://leetcode.cn/problems/binary-tree-level-order-traversal/solutions/241885/er-cha-shu-de-ceng-xu-bian-li-by-leetcode-solution/)

**˼·���㷨**

���ǿ����ù�������������������⡣

���ǿ����뵽�����صķ�������һ����Ԫ�� `(node, level)` ����ʾ״̬������ʾĳ���ڵ�������ڵĲ�����ÿ���½����еĽڵ�� `level` ֵ���Ǹ��׽ڵ�� `level` ֵ��һ��������ÿ����� `level` �Ե���з��࣬�����ʱ�����ǿ������ù�ϣ��ά��һ���� `level` Ϊ������Ӧ�ڵ�ֵ��ɵ�����Ϊֵ������������������Ժ󰴼� `level` ��С����ȡ������ֵ����ɴ𰸷��ؼ��ɡ�

��������Ż��ռ俪������β��ù�ϣӳ�䣬����ֻ��һ������ `node` ��ʾ״̬��ʵ����������أ�

���ǿ�����һ������ķ����޸Ĺ������������

-   ���ȸ�Ԫ�����
-   �����в�Ϊ�յ�ʱ��
    -   ��ǰ���еĳ��� $s_i$
    -   ���δӶ�����ȡ $s_i$ ��Ԫ�ؽ�����չ��Ȼ�������һ�ε���

������ͨ��������������������ڣ���ͨ�����������ÿ��ֻȡһ��Ԫ����չ��������ÿ��ȡ $s_i$ ��Ԫ�ء������������еĵ� i �ε����͵õ��˶������ĵ� i ��� $s_i$ ��Ԫ�ء�

Ϊʲô��ô���ǶԵ��أ����ǹ۲�����㷨�����Թ��ɳ�������[ѭ������ʽ](https://leetcode.cn/link/?target=https%3A%2F%2Fbaike.baidu.com%2Fitem%2F%E5%BE%AA%E7%8E%AF%E4%B8%8D%E5%8F%98%E5%BC%8F)���� i �ε���ǰ�������е�����Ԫ�ؾ��ǵ� i �������Ԫ�أ����Ұ��մ������ҵ�˳�����С�֤�������������ʣ���Ҳ���԰���������ѧ���ɷ�����
-   **��ʼ��**��i = 1 ��ʱ�򣬶�������ֻ�� `root`����Ψһ�Ĳ���Ϊ 1 ��Ԫ�أ���Ϊֻ��һ��Ԫ�أ�����Ҳ��Ȼ���㡸�����������С���
-   **����**����� i = k ʱ���ʳ��������� k ���г��� $s_k$ ��Ԫ���ǵ� k �������Ԫ�أ�����˳������ҡ���Ϊ�������й������������ʱ���ɵ� k ��ĵ���չ���ĵ�һ��Ҳֻ���� k + 1 ��ĵ㣬���� k + 1 ��ĵ�ֻ���ɵ� k ��ĵ���չ������������ $s_k$ ��������չ����һ�����е� $s_{k+1}$ ���㡣����Ϊ���е��Ƚ��ȳ���FIFO�����ԣ���Ȼ�� k ��ĵ�ĳ���˳���Ǵ������ң���ô�� k + 1 ��Ҳһ���Ǵ������ҡ�**���ˣ������Ѿ�����ͨ����ѧ���ɷ�֤��ѭ������ʽ����ȷ�ԡ�**
-   **��ֹ**����Ϊ��ѭ������ʽ����ȷ�ģ����԰��������������֮��ÿ�ε����õ���Ҳ���ǵ�ǰ��Ĳ�α��������**���ˣ�����֤�����㷨����ȷ�ġ�**

**����**

```cpp
class Solution {
public:
    vector<vector<int>> levelOrder(TreeNode* root) {
        vector <vector <int>> ret;
        if (!root) {
            return ret;
        }

        queue <TreeNode*> q;
        q.push(root);
        while (!q.empty()) {
            int currentLevelSize = q.size();
            ret.push_back(vector <int> ());
            for (int i = 1; i <= currentLevelSize; ++i) {
                auto node = q.front(); q.pop();
                ret.back().push_back(node->val);
                if (node->left) q.push(node->left);
                if (node->right) q.push(node->right);
            }
        }
        
        return ret;
    }
};
```

```java
class Solution {
    public List<List<Integer>> levelOrder(TreeNode root) {
        List<List<Integer>> ret = new ArrayList<List<Integer>>();
        if (root == null) {
            return ret;
        }

        Queue<TreeNode> queue = new LinkedList<TreeNode>();
        queue.offer(root);
        while (!queue.isEmpty()) {
            List<Integer> level = new ArrayList<Integer>();
            int currentLevelSize = queue.size();
            for (int i = 1; i <= currentLevelSize; ++i) {
                TreeNode node = queue.poll();
                level.add(node.val);
                if (node.left != null) {
                    queue.offer(node.left);
                }
                if (node.right != null) {
                    queue.offer(node.right);
                }
            }
            ret.add(level);
        }
        
        return ret;
    }
}
```

```javascript
var levelOrder = function(root) {
    const ret = [];
    if (!root) {
        return ret;
    }

    const q = [];
    q.push(root);
    while (q.length !== 0) {
        const currentLevelSize = q.length;
        ret.push([]);
        for (let i = 1; i <= currentLevelSize; ++i) {
            const node = q.shift();
            ret[ret.length - 1].push(node.val);
            if (node.left) q.push(node.left);
            if (node.right) q.push(node.right);
        }
    }
        
    return ret;
};
```

```go
func levelOrder(root *TreeNode) [][]int {
    ret := [][]int{}
    if root == nil {
        return ret
    }
    q := []*TreeNode{root}
    for i := 0; len(q) > 0; i++ {
        ret = append(ret, []int{})
        p := []*TreeNode{}
        for j := 0; j < len(q); j++ {
            node := q[j]
            ret[i] = append(ret[i], node.Val)
            if node.Left != nil {
                p = append(p, node.Left)
            }
            if node.Right != nil {
                p = append(p, node.Right)
            }
        }
        q = p
    }
    return ret
}
```

**���Ӷȷ���**

���������нڵ�ĸ���Ϊ n��
-   ʱ�临�Ӷȣ�ÿ������ӳ��Ӹ�һ�Σ��ʽ���ʱ�临�Ӷ�Ϊ $O(n)$��
-   �ռ临�Ӷȣ�������Ԫ�صĸ��������� n �����ʽ����ռ临�Ӷ�Ϊ $O(n)$��
