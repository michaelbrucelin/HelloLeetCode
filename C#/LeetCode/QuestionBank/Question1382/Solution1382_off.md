### [将二叉搜索树变平衡](https://leetcode.cn/problems/balance-a-binary-search-tree/solutions/241897/jiang-er-cha-sou-suo-shu-bian-ping-heng-by-leetcod/)

#### 方法一：贪心构造

**思路**

「平衡」要求它是一棵空树或它的左右两个子树的高度差的绝对值不超过 $1$，这很容易让我们产生这样的想法——左右子树的大小越「平均」，这棵树会不会越平衡？于是一种贪心策略的雏形就形成了：我们可以通过中序遍历将原来的二叉搜索树转化为一个有序序列，然后对这个有序序列递归建树，对于区间 $[L,R]$：

- 取 $mid=\Big\lfloor\dfrac{L+R}{2}\Big\rfloor $，即中心位置作为当前节点的值；
- 如果 $L\le mid-1$，那么递归地将区间 $[L,mid-1]$ 作为当前节点的左子树；
- 如果 $mid+1\le R$，那么递归地将区间 $[mid+1,R]$ 作为当前节点的右子树。

**思考：如何证明这个贪心是正确的呢？**

要证明我们构造的这颗树是平衡的，就要证明这棵树根结点为空或者左右两个子树的高度差的绝对值不超过 $1$。

观察这个过程，我们不难发现它和二分查找非常相似。对于一个长度为 $x$ 的区间，由它构建出的二叉树的最大高度应该等于对长度为 $x$ 的有序序列进行二分查找「查找成功」时的「最大」比较次数，为 $\lfloor \log_2x\rfloor +1$，记为 $h(x)$。

---

**「引理 A」** 长度为 $k$ 的区间与长度为 $k+1$ 的区间（其中 $k\ge 1$）按照以上方法构造出的二叉树的最大高度差不超过 $1$。证明过程如下：

要证明「引理 A」即我们要证明：

$$h(k+1)-h(k)==[\lfloor \log_2(k+1)\rfloor +1]-[\lfloor \log_2(k)\rfloor +1]\lfloor \log_2(k+1)\rfloor -\lfloor \log_2(k)\rfloor \le 1$$

由此我们可以证明不等式：

$$\lfloor \log_2(k+1)\rfloor \le \lfloor \log_2(k)\rfloor +1$$

设 $k=2^r+b$，其中 $0\le b<2^r$，那么 $k\in [2^r,2^{r+1})$，$\lfloor \log k\rfloor =r$，不等式右边等于 $r+1$。因为 $k\in [2^r,2^{r+1})$，所以 $k+1\in (2^r,2^{r+1}]$，故 $\lceil \log_2(k+1)\rceil =r+1$，即右边等于 $\lceil \log_2(k+1)\rceil $。所以我们需要证明：

$$\lfloor \log_2(k+1)\rfloor \le \lceil \log_2(k+1)\rceil$$

显然成立，由此逆推可得，「引理 A」成立。

---

下面我们来证明这个贪心算法的正确性：即按照这个方法构造出的二叉树左右子树都是平衡的，并且左右子树的高度差不超过 $1$。

**「正确性证明」** 假设我们要讨论的区间长度为 $k$，我们用数学归纳法来证明：

- $k=1$，$k=2$ 时显然成立；
- 假设 $k=m$ 和 $k=m+1$ 时正确性成立。
  - 那么根据「引理 A」，长度为 $m$ 和 $m+1$ 的区间构造出的子树都是平衡的，并且它们的高度差不超过 $1$；
  - 当 $k=2(m+1)-1$ 时，创建出的节点的值等于第 $m+1$ 个元素的值，它的左边和右边各有长度为 $m$ 的区间，根据「假设推论」，$k=2(m+1)-1$ 时构造出的左右子树都是平衡树，且树形完全相同，故高度差为 $0$，所以 $k=2(m+1)-1$ 时，正确性成立；
  - 当 $k=2(m+1)$ 时，创建出的节点的值等于第 $m+1$ 个元素的值，它的左边的区间长度为 $m$，右边区间的长度为 $m+1$，那么 $k=2(m+1)$ 时构造出的左右子树都是平衡树，且高度差不超过 $1$，所以 $k=2(m+1)$ 时，正确性成立；
- 通过这种归纳方法，可以覆盖所有的 $k\ge 1$。故在 $k\ge 1$ 时，正确性成立，证毕。

```C++
class Solution {
public:
    vector<int> inorderSeq;

    void getInorder(TreeNode* o) {
        if (o->left) {
            getInorder(o->left);
        }
        inorderSeq.push_back(o->val);
        if (o->right) {
            getInorder(o->right);
        }
    }

    TreeNode* build(int l, int r) {
        int mid = (l + r) >> 1;
        TreeNode* o = new TreeNode(inorderSeq[mid]);
        if (l <= mid - 1) {
            o->left = build(l, mid - 1);
        }
        if (mid + 1 <= r) {
            o->right = build(mid + 1, r);
        }
        return o;
    }

    TreeNode* balanceBST(TreeNode* root) {
        getInorder(root);
        return build(0, inorderSeq.size() - 1);
    }
};
```

```Java
class Solution {
    List<Integer> inorderSeq = new ArrayList<Integer>();

    public TreeNode balanceBST(TreeNode root) {
        getInorder(root);
        return build(0, inorderSeq.size() - 1);
    }

    public void getInorder(TreeNode o) {
        if (o.left != null) {
            getInorder(o.left);
        }
        inorderSeq.add(o.val);
        if (o.right != null) {
            getInorder(o.right);
        }
    }

    public TreeNode build(int l, int r) {
        int mid = (l + r) >> 1;
        TreeNode o = new TreeNode(inorderSeq.get(mid));
        if (l <= mid - 1) {
            o.left = build(l, mid - 1);
        }
        if (mid + 1 <= r) {
            o.right = build(mid + 1, r);
        }
        return o;
    }
}
```

```Python
class Solution:
    def balanceBST(self, root: TreeNode) -> TreeNode:
        def getInorder(o):
            if o.left:
                getInorder(o.left)
            inorderSeq.append(o.val)
            if o.right:
                getInorder(o.right)

        def build(l, r):
            mid = (l + r) // 2
            o = TreeNode(inorderSeq[mid])
            if l <= mid - 1:
                o.left = build(l, mid - 1)
            if mid + 1 <= r:
                o.right = build(mid + 1, r)
            return o

        inorderSeq = list()
        getInorder(root)
        return build(0, len(inorderSeq) - 1)
```

```CSharp
public class Solution {
    private List<int> inorderSeq = new List<int>();

    public TreeNode BalanceBST(TreeNode root) {
        GetInorder(root);
        return Build(0, inorderSeq.Count - 1);
    }

    private void GetInorder(TreeNode o) {
        if (o.left != null) {
            GetInorder(o.left);
        }
        inorderSeq.Add(o.val);
        if (o.right != null) {
            GetInorder(o.right);
        }
    }

    private TreeNode Build(int l, int r) {
        int mid = (l + r) >> 1;
        TreeNode o = new TreeNode(inorderSeq[mid]);
        if (l <= mid - 1) {
            o.left = Build(l, mid - 1);
        }
        if (mid + 1 <= r) {
            o.right = Build(mid + 1, r);
        }
        return o;
    }
}
```

```Go
func balanceBST(root *TreeNode) *TreeNode {
    var inorderSeq []int

    var getInorder func(*TreeNode)
    getInorder = func(o *TreeNode) {
        if o.Left != nil {
            getInorder(o.Left)
        }
        inorderSeq = append(inorderSeq, o.Val)
        if o.Right != nil {
            getInorder(o.Right)
        }
    }

    var build func(int, int) *TreeNode
    build = func(l, r int) *TreeNode {
        mid := (l + r) >> 1
        o := &TreeNode{Val: inorderSeq[mid]}
        if l <= mid-1 {
            o.Left = build(l, mid-1)
        }
        if mid+1 <= r {
            o.Right = build(mid+1, r)
        }
        return o
    }

    getInorder(root)
    return build(0, len(inorderSeq)-1)
}
```

```C
void getInorder(struct TreeNode* o, int* seq, int* index) {
    if (o->left) {
        getInorder(o->left, seq, index);
    }
    seq[(*index)++] = o->val;
    if (o->right) {
        getInorder(o->right, seq, index);
    }
}

int getSize(struct TreeNode* root) {
    if (!root) return 0;
    return 1 + getSize(root->left) + getSize(root->right);
}

struct TreeNode* build(int* seq, int l, int r) {
    int mid = (l + r) >> 1;
    struct TreeNode* o = (struct TreeNode*)malloc(sizeof(struct TreeNode));
    o->val = seq[mid];
    o->left = o->right = NULL;

    if (l <= mid - 1) {
        o->left = build(seq, l, mid - 1);
    }
    if (mid + 1 <= r) {
        o->right = build(seq, mid + 1, r);
    }
    return o;
}

struct TreeNode* balanceBST(struct TreeNode* root) {
    int size = getSize(root);
    int* inorderSeq = (int*)malloc(size * sizeof(int));
    int index = 0;

    getInorder(root, inorderSeq, &index);
    struct TreeNode* result = build(inorderSeq, 0, size - 1);

    free(inorderSeq);
    return result;
}
```

```JavaScript
var balanceBST = function(root) {
    const inorderSeq = [];

    const getInorder = (o) => {
        if (o.left) {
            getInorder(o.left);
        }
        inorderSeq.push(o.val);
        if (o.right) {
            getInorder(o.right);
        }
    };

    const build = (l, r) => {
        const mid = (l + r) >> 1;
        const o = new TreeNode(inorderSeq[mid]);
        if (l <= mid - 1) {
            o.left = build(l, mid - 1);
        }
        if (mid + 1 <= r) {
            o.right = build(mid + 1, r);
        }
        return o;
    };

    getInorder(root);
    return build(0, inorderSeq.length - 1);
};
```

```TypeScript
function balanceBST(root: TreeNode | null): TreeNode | null {
    const inorderSeq: number[] = [];

    const getInorder = (o: TreeNode | null): void => {
        if (!o) return;
        if (o.left) {
            getInorder(o.left);
        }
        inorderSeq.push(o.val);
        if (o.right) {
            getInorder(o.right);
        }
    };

    const build = (l: number, r: number): TreeNode | null => {
        if (l > r) return null;
        const mid = (l + r) >> 1;
        const o = new TreeNode(inorderSeq[mid]);
        o.left = build(l, mid - 1);
        o.right = build(mid + 1, r);
        return o;
    };

    getInorder(root);
    return build(0, inorderSeq.length - 1);
}
```

```Rust
use std::rc::Rc;
use std::cell::RefCell;

impl Solution {
    pub fn balance_bst(root: Option<Rc<RefCell<TreeNode>>>) -> Option<Rc<RefCell<TreeNode>>> {
        let mut inorder_seq = Vec::new();

        Self::get_inorder(&root, &mut inorder_seq);
        Self::build(&inorder_seq, 0, inorder_seq.len() as i32 - 1)
    }

    fn get_inorder(root: &Option<Rc<RefCell<TreeNode>>>, seq: &mut Vec<i32>) {
        if let Some(node) = root {
            let node_ref = node.borrow();
            Self::get_inorder(&node_ref.left, seq);
            seq.push(node_ref.val);
            Self::get_inorder(&node_ref.right, seq);
        }
    }

    fn build(seq: &[i32], l: i32, r: i32) -> Option<Rc<RefCell<TreeNode>>> {
        if l > r {
            return None;
        }
        let mid = (l + r) >> 1;
        let mut node = TreeNode::new(seq[mid as usize]);
        node.left = Self::build(seq, l, mid - 1);
        node.right = Self::build(seq, mid + 1, r);
        Some(Rc::new(RefCell::new(node)))
    }
}
```

**复杂度分析**

假设节点总数为 $n$。

- 时间复杂度：获得中序遍历的时间代价是 $O(n)$；建立平衡二叉树的时建立每个点的时间代价为 $O(1)$，总时间也是 $O(n)$。故渐进时间复杂度为 $O(n)$。
- 空间复杂度：这里使用了一个数组作为辅助空间，存放中序遍历后的有序序列，故渐进空间复杂度为 $O(n)$。
