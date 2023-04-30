#### [方法二：摩尔投票 + 线段树](https://leetcode.cn/problems/online-majority-element-in-subarray/solutions/2228536/zi-shu-zu-zhong-zhan-jue-da-duo-shu-de-y-k1we/)

**前言**

本方法严重超纲。读者至少需要掌握：

-   「[169\. 多数元素](https://leetcode.cn/problems/majority-element/)」中的「Boyer-Moore 投票算法」；
-   「[线段树](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fds%2Fseg%2F)」的建立和区间查询。

**投票算法的结合性**

对于每一次查询，我们可以对子数组先进行一次遍历，使用投票算法找出可能的「绝对众数」$x'$，再使用一次遍历，记录 $x'$ 真正出现的次数，与 $threshold$ 进行比较并得出答案。

这样做的时间复杂度为 $O(l)$，其中 $l$ 是子数组的长度，并不是一种高效率的做法。但我们可以发现，摩尔投票中存储的两个值是具有结合性质的：

-   在摩尔投票中，我们会存储两个值 $(x', cnt)$，其中 $x'$ 表示答案，$cnt$ 表示 $x'$ 当前的价值。如果下一个数 $y' = x'$，那么 $cnt$ 的值加 $1$，否则减 $1$。当 $cnt$ 变为 $-1$ 时，会将 $x'$ 替换成 $y'$ 并将 $cnt$ 初始化为 $1$；
-   对于一个给定的数组，我们可以将它分成任意的两部分（即使不连续都可以），分别使用投票算法得到 $(x_0', cnt_0)$ 和 $(x_1', cnt_1)$。那么整个数组使用投票算法得到的结果为：
    -   如果 $′x_0' = x_1'$，结果为 $(x_0', cnt_0 + cnt_1)$；
    -   如果 $x_0' \neq x_1'$，结果为 $cnt_0$ 和 $cnt_1$ 中较大的那个对应的 $x'$，以及 $|cnt_0 - cnt_1|$。

我们可以使用通俗的解释证明正确性：投票算法本质上是在数组中不断找出两个不同的整数，把它们消除。当数组中只剩下一种整数时，这个整数就是 $x'$，它出现的次数就是 $cnt$。如果数组中存在「绝对众数」，那么它就是 $x'$，否则最后剩下的 $x'$ 可能是任何值。因此，我们先将数组分成任意的两部分，分别进行消除，得到了 $cnt_0$ 个 $x_0'$ 以及 $cnt_1$ 个 $x_1'$。再将它们进行消除，就得到了整个数组进行投票算法的结果：

-   如果数组中存在「绝对众数」$x'$，那么根据鸽巢原理，一定有一个部分的绝对众数也是 $x'$，它可以在 $(x_0', cnt_0)$ 或 $(x_1', cnt_1)$ 中得到保留；
-   如果不存在，那么 $(x_0', cnt_0)$ 和 $(x_1', cnt_1)$ 的值都无关紧要。

上述结合性可以推广到将数组拆分成任意多个部分的情形，因此我们就可以使用线段树，每个节点存储对应区间的 $(x', cnt)$。

**算法**

我们使用线段树解决本题。线段树的每个节点存储两个值，即对应区间的 $(x', cnt)$。

对于每个查询操作 $(left, right, threshold)$，我们在线段树上查询区间 $[left, right]$，合并所有区间的值，得到答案 $(x', cnt)$。随后我们使用与方法一中相同的哈希表，进行二分查找，判断 $x'$ 是否出现了至少 $threshold$ 次即可。

**代码**

```cpp
struct Node {
    Node(int x = 0, int cnt = 0): x(x), cnt(cnt) {}
    Node& operator+=(const Node& that) {
        if (x == that.x) {
            cnt += that.cnt;
        }
        else if (cnt >= that.cnt) {
            cnt -= that.cnt;
        }
        else {
            x = that.x;
            cnt = that.cnt - cnt;
        }
        return *this;
    }

    int x, cnt;
};

class MajorityChecker {
public:
    MajorityChecker(vector<int>& arr): arr(arr) {
        n = arr.size();
        for (int i = 0; i < n; ++i) {
            loc[arr[i]].push_back(i);
        }

        tree.resize(n * 4);
        seg_build(0, 0, n - 1);
    }
    
    int query(int left, int right, int threshold) {
        Node ans;
        seg_query(0, 0, n - 1, left, right, ans);
        vector<int>& pos = loc[ans.x];
        int occ = upper_bound(pos.begin(), pos.end(), right) - lower_bound(pos.begin(), pos.end(), left);
        return (occ >= threshold ? ans.x : -1);
    }

private:
    int n;
    const vector<int>& arr;
    unordered_map<int, vector<int>> loc;
    vector<Node> tree;

    void seg_build(int id, int l, int r) {
        if (l == r) {
            tree[id] = {arr[l], 1};
            return;
        }

        int mid = (l + r) / 2;
        seg_build(id * 2 + 1, l, mid);
        seg_build(id * 2 + 2, mid + 1, r);
        tree[id] += tree[id * 2 + 1];
        tree[id] += tree[id * 2 + 2];
    }

    void seg_query(int id, int l, int r, int ql, int qr, Node& ans) {
        if (l > qr || r < ql) {
            return;
        }
        if (ql <= l && r <= qr) {
            ans += tree[id];
            return;
        }

        int mid = (l + r) / 2;
        seg_query(id * 2 + 1, l, mid, ql, qr, ans);
        seg_query(id * 2 + 2, mid + 1, r, ql, qr, ans);
    }
};
```

```java
class MajorityChecker {
    private int n;
    private int[] arr;
    private Map<Integer, List<Integer>> loc;
    private Node[] tree;

    public MajorityChecker(int[] arr) {
        this.n = arr.length;
        this.arr = arr;
        this.loc = new HashMap<Integer, List<Integer>>();
        for (int i = 0; i < arr.length; ++i) {
            loc.putIfAbsent(arr[i], new ArrayList<Integer>());
            loc.get(arr[i]).add(i);
        }

        this.tree = new Node[n * 4];
        for (int i = 0; i < n * 4; i++) {
            tree[i] = new Node();
        }
        segBuild(0, 0, n - 1);
    }

    public int query(int left, int right, int threshold) {
        Node ans = new Node();
        segQuery(0, 0, n - 1, left, right, ans);
        List<Integer> pos = loc.getOrDefault(ans.x, new ArrayList<Integer>());
        int occ = searchEnd(pos, right) - searchStart(pos, left);
        return occ >= threshold ? ans.x : -1;
    }

    private void segBuild(int id, int l, int r) {
        if (l == r) {
            tree[id] = new Node(arr[l], 1);
            return;
        }

        int mid = (l + r) / 2;
        segBuild(id * 2 + 1, l, mid);
        segBuild(id * 2 + 2, mid + 1, r);
        tree[id].add(tree[id * 2 + 1]);
        tree[id].add(tree[id * 2 + 2]);
    }

    private void segQuery(int id, int l, int r, int ql, int qr, Node ans) {
        if (l > qr || r < ql) {
            return;
        }
        if (ql <= l && r <= qr) {
            ans.add(tree[id]);
            return;
        }

        int mid = (l + r) / 2;
        segQuery(id * 2 + 1, l, mid, ql, qr, ans);
        segQuery(id * 2 + 2, mid + 1, r, ql, qr, ans);
    }

    private int searchStart(List<Integer> pos, int target) {
        int low = 0, high = pos.size();
        while (low < high) {
            int mid = low + (high - low) / 2;
            if (pos.get(mid) >= target) {
                high = mid;
            } else {
                low = mid + 1;
            }
        }
        return low;
    }

    private int searchEnd(List<Integer> pos, int target) {
        int low = 0, high = pos.size();
        while (low < high) {
            int mid = low + (high - low) / 2;
            if (pos.get(mid) > target) {
                high = mid;
            } else {
                low = mid + 1;
            }
        }
        return low;
    }
}

class Node {
    int x;
    int cnt;

    public Node() {
        this(0, 0);
    }

    public Node(int x, int cnt) {
        this.x = x;
        this.cnt = cnt;
    }

    public void add(Node that) {
        if (x == that.x) {
            cnt += that.cnt;
        } else if (cnt >= that.cnt) {
            cnt -= that.cnt;
        } else {
            x = that.x;
            cnt = that.cnt - cnt;
        }
    }
}
```

```csharp
public class MajorityChecker {
    private int n;
    private int[] arr;
    private IDictionary<int, List<int>> loc;
    private Node[] tree;

    public MajorityChecker(int[] arr) {
        this.n = arr.Length;
        this.arr = arr;
        this.loc = new Dictionary<int, List<int>>();
        for (int i = 0; i < arr.Length; ++i) {
            loc.TryAdd(arr[i], new List<int>());
            loc[arr[i]].Add(i);
        }

        this.tree = new Node[n * 4];
        for (int i = 0; i < n * 4; i++) {
            tree[i] = new Node();
        }
        SegBuild(0, 0, n - 1);
    }

    public int Query(int left, int right, int threshold) {
        Node ans = new Node();
        SegQuery(0, 0, n - 1, left, right, ans);
        IList<int> pos = loc.ContainsKey(ans.x) ? loc[ans.x] : new List<int>();
        int occ = SearchEnd(pos, right) - SearchStart(pos, left);
        return occ >= threshold ? ans.x : -1;
    }

    private void SegBuild(int id, int l, int r) {
        if (l == r) {
            tree[id] = new Node(arr[l], 1);
            return;
        }

        int mid = (l + r) / 2;
        SegBuild(id * 2 + 1, l, mid);
        SegBuild(id * 2 + 2, mid + 1, r);
        tree[id].Add(tree[id * 2 + 1]);
        tree[id].Add(tree[id * 2 + 2]);
    }

    private void SegQuery(int id, int l, int r, int ql, int qr, Node ans) {
        if (l > qr || r < ql) {
            return;
        }
        if (ql <= l && r <= qr) {
            ans.Add(tree[id]);
            return;
        }

        int mid = (l + r) / 2;
        SegQuery(id * 2 + 1, l, mid, ql, qr, ans);
        SegQuery(id * 2 + 2, mid + 1, r, ql, qr, ans);
    }

    private int SearchStart(IList<int> pos, int target) {
        int low = 0, high = pos.Count;
        while (low < high) {
            int mid = low + (high - low) / 2;
            if (pos[mid] >= target) {
                high = mid;
            } else {
                low = mid + 1;
            }
        }
        return low;
    }

    private int SearchEnd(IList<int> pos, int target) {
        int low = 0, high = pos.Count;
        while (low < high) {
            int mid = low + (high - low) / 2;
            if (pos[mid] > target) {
                high = mid;
            } else {
                low = mid + 1;
            }
        }
        return low;
    }
}

class Node {
    public int x;
    public int cnt;

    public Node() : this(0, 0) {

    }

    public Node(int x, int cnt) {
        this.x = x;
        this.cnt = cnt;
    }

    public void Add(Node that) {
        if (x == that.x) {
            cnt += that.cnt;
        } else if (cnt >= that.cnt) {
            cnt -= that.cnt;
        } else {
            x = that.x;
            cnt = that.cnt - cnt;
        }
    }
}
```

```python
class Node:
    def __init__(self, x: int = 0, cnt: int = 0):
        self.x = x
        self.cnt = cnt
    
    def __iadd__(self, that: "Node") -> "Node":
        if self.x == that.x:
            self.cnt += that.cnt
        elif self.cnt >= that.cnt:
            self.cnt -= that.cnt
        else:
            self.x = that.x
            self.cnt = that.cnt - self.cnt
        return self

class MajorityChecker:
    def __init__(self, arr: List[int]):
        self.n = len(arr)
        self.arr = arr
        self.loc = defaultdict(list)

        for i, val in enumerate(arr):
            self.loc[val].append(i)
        
        self.tree = [Node() for _ in range(self.n * 4)]
        self.seg_build(0, 0, self.n - 1)

    def query(self, left: int, right: int, threshold: int) -> int:
        loc_ = self.loc

        ans = Node()
        self.seg_query(0, 0, self.n - 1, left, right, ans)
        pos = loc_[ans.x]
        occ = bisect_right(pos, right) - bisect_left(pos, left)
        return ans.x if occ >= threshold else -1
    
    def seg_build(self, idx: int, l: int, r: int):
        arr_ = self.arr
        tree_ = self.tree

        if l == r:
            tree_[idx] = Node(arr_[l], 1)
            return
        
        mid = (l + r) // 2
        self.seg_build(idx * 2 + 1, l, mid)
        self.seg_build(idx * 2 + 2, mid + 1, r)
        tree_[idx] += tree_[idx * 2 + 1]
        tree_[idx] += tree_[idx * 2 + 2]

    def seg_query(self, idx: int, l: int, r: int, ql: int, qr: int, ans: Node):
        tree_ = self.tree

        if l > qr or r < ql:
            return
        
        if ql <= l and r <= qr:
            ans += tree_[idx]
            return

        mid = (l + r) // 2
        self.seg_query(idx * 2 + 1, l, mid, ql, qr, ans)
        self.seg_query(idx * 2 + 2, mid + 1, r, ql, qr, ans)
```

```c
typedef struct Element {
    int *arr;
    int arrSize;
} Element;

typedef struct {
    int key;
    Element *val;
    UT_hash_handle hh;
} HashItem; 

typedef struct Node {
    int x;
    int cnt;
} Node;

HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, int key, Element *val) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = key;
    pEntry->val = val;
    HASH_ADD_INT(*obj, key, pEntry);
    return true;
}

Element* hashGetItem(HashItem **obj, int key) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        return NULL;
    }
    return pEntry->val;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);  
        free(curr->val->arr);
        free(curr->val);
        free(curr);             
    }
}

typedef struct {
    int *arr;
    int arrSize;
    HashItem *loc;
    Node *tree;
} MajorityChecker;

static int cmp(const void *pa, const void *pb) {
    int *a = (int *)pa;
    int *b = (int *)pb;
    return a[0] - b[0];
}

void addNode(Node *node, Node *that) {
    if (node->x == that->x) {
        node->cnt += that->cnt;
    } else if (node->cnt > that->cnt) {
        node->cnt -= that->cnt;
    } else {
        node->x = that->x;
        node->cnt = that->cnt - node->cnt;
    }
}

void seg_build(Node *tree, const int *arr, int id, int l, int r) {
    if (l == r) {
        tree[id].x = arr[l];
        tree[id].cnt = 1;
        return;
    }

    int mid = (l + r) / 2;
    seg_build(tree, arr, id * 2 + 1, l, mid);
    seg_build(tree, arr, id * 2 + 2, mid + 1, r);
    addNode(&tree[id], &tree[id * 2 + 1]);
    addNode(&tree[id], &tree[id * 2 + 2]);
}

void seg_query(Node *tree, int id, int l, int r, int ql, int qr, Node* ans) {
    if (l > qr || r < ql) {
        return;
    }
    if (ql <= l && r <= qr) {
        addNode(ans, &tree[id]);
        return;
    }
    int mid = (l + r) / 2;
    seg_query(tree, id * 2 + 1, l, mid, ql, qr, ans);
    seg_query(tree, id * 2 + 2, mid + 1, r, ql, qr, ans);
}

int searchStart(const int *pos, int posSize, int target) {
    int low = 0, high = posSize;
    while (low < high) {
        int mid = low + (high - low) / 2;
        if (pos[mid] >= target) {
            high = mid;
        } else {
            low = mid + 1;
        }
    }
    return low;
}

int searchEnd(const int *pos, int posSize, int target) {
    int low = 0, high = posSize;
    while (low < high) {
        int mid = low + (high - low) / 2;
        if (pos[mid] > target) {
            high = mid;
        } else {
            low = mid + 1;
        }
    }
    return low;
}

MajorityChecker* majorityCheckerCreate(int* arr, int arrSize) {
    MajorityChecker *obj = (MajorityChecker *)malloc(sizeof(MajorityChecker));
    obj->arr = arr;
    obj->arrSize = arrSize;
    obj->loc = NULL;
    int cnt[arrSize][2];
    for (int i = 0; i < arrSize; i++) {
        cnt[i][0] = arr[i];
        cnt[i][1] = i;
    }
    qsort(cnt, arrSize, sizeof(cnt[0]), cmp);
    for (int i = 0, j = 0; i <= arrSize; i++) {
        if (i == arrSize || cnt[i][0] != cnt[j][0]) {
            Element *cur = (Element *)malloc(sizeof(Element));
            cur->arr = (int *)malloc(sizeof(int) * (i - j));
            cur->arrSize = i - j;
            for (int k = 0; k < i - j; k++) {
                cur->arr[k] = cnt[j + k][1];
            }            
            hashAddItem(&obj->loc, cnt[j][0], cur);
            j = i;
        }
    }
    obj->tree = (Node *)malloc(sizeof(Node) * 4 * arrSize);
    memset(obj->tree, 0, sizeof(Node) * 4 * arrSize);
    seg_build(obj->tree, arr, 0, 0, arrSize - 1);
    return obj;
}

int majorityCheckerQuery(MajorityChecker* obj, int left, int right, int threshold) {
    Node ans;
    memset(&ans, 0, sizeof(ans));
    seg_query(obj->tree, 0, 0, obj->arrSize - 1, left, right, &ans);
    Element *cur = hashGetItem(&obj->loc, ans.x);
    int *pos = cur->arr;
    int posSize = cur->arrSize;
    int occ = searchEnd(pos, posSize, right) - searchStart(pos, posSize, left);
    return (occ >= threshold ? ans.x : -1);
}

void majorityCheckerFree(MajorityChecker* obj) {
    hashFree(&obj->loc);
    free(obj->tree);
    free(obj);
}
```

**复杂度分析**

-   时间复杂度：$O(n + q\log n)$，其中 $n$ 是数组 $arr$ 的长度，$q$ 是询问的次数。预处理哈希表和线段树需要 $O(n)$ 的时间，单次询问需要 $O(\log n)$ 的时间。
-   空间复杂度：$O(n)$，即为哈希表和线段树需要使用的空间。
