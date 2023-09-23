### [树上的操作](https://leetcode.cn/problems/operations-on-tree/solutions/2451105/shu-shang-de-cao-zuo-by-leetcode-solutio-60an/)

#### 方法一：深度优先搜索

**思路**

按照题目要求，依次实现各个函数即可：

-   $Lock$：可以用一个数组变量 $lockNodeUser$ 记录给各个节点上锁的用户，$lockNodeUser[num]$ 即表示给节点 $num$ 上锁的用户。当 $lockNodeUser[num] = -1$ 时，即表示 节点 $num$ 未被上锁，通过给 $lockNodeUser[num]$ 赋值实现上锁。
-   $Unlock$：通过比较变量 $lockNodeUser[num]$ 和 $user$ 是否先等来判断当前节点是否可以解锁，通过赋值来解锁。
-   $Upgrade$：实现较为复杂，首先需要判断三个条件是否同时成立，如果是，还需要给指定节点上锁并且给它的所有子孙节点解锁。三个条件中：
    -   指定节点当前状态为未上锁：通过变量 $lockNodeUser$ 来判断。
    -   指定节点没有任何上锁的祖先节点：需要依次遍历当前节点的父亲节点，通过变量 $lockNodeUser$ 和 $parent$ 来判断。具体代码中，我们利用一个函数 $hasLockedAncestor$ 来实现这一判断。
    -   指定节点至少有一个上锁状态的子孙节点：我们将这一判断放到第三步来进行，使得它可以和「给它的所有子孙节点解锁」同时实现。三个状态的判断，我们用「短路与」来连接，当只有前两步都为真，才会进行第三步。当第三步也为真，那么我们就需要进行「给它的所有子孙节点解锁」这一步；当第三步为假，就说明指定节点没有上锁的子孙节点，那么我们仍可以进行「给它的所有子孙节点解锁」这一步，并不影响树的状态。我们定义一个递归函数 $checkAndUnlockDescendant$ 来实现这一步，返回一个布尔值表示当前节点是否有上锁的子孙节点（也包括自己），同时将所有的子孙节点（也包括自己）解锁。遍历子孙节点时，我们提前构建一个变量 $children$，表示当前节点的孩子节点，这一步可以在初始化时完成。
    最后，如果这三个条件与的结果为真，将当前节点上锁。

**代码**

```python
class LockingTree:

    def __init__(self, parent: List[int]):
        n = len(parent)
        self.parent = parent
        self.lockNodeUser = [-1] * n
        self.children = [[] for _ in range(n)]
        for node, p in enumerate(parent):
            if p != -1:
                self.children[p].append(node)

    def lock(self, num: int, user: int) -> bool:
        if self.lockNodeUser[num] == -1:
            self.lockNodeUser[num] = user
            return True
        else:
            return False

    def unlock(self, num: int, user: int) -> bool:
        if self.lockNodeUser[num] == user:
            self.lockNodeUser[num] = -1
            return True
        else:
            return False

    def upgrade(self, num: int, user: int) -> bool:
        res = self.lockNodeUser[num] == -1 and not self.hasLockedAncestor(num) and self.checkAndUnlockDescendant(num)
        if res:
            self.lockNodeUser[num] = user
        return res
    
    def hasLockedAncestor(self, num: int) -> bool:
        num = self.parent[num]
        while num != -1:
            if self.lockNodeUser[num] != -1:
                return True
            else:
                num = self.parent[num]
        return False
    
    def checkAndUnlockDescendant(self, num:int) -> bool:
        res = self.lockNodeUser[num] != -1
        self.lockNodeUser[num] = -1
        for child in self.children[num]:
            res |= self.checkAndUnlockDescendant(child)
        return res
```

```java
class LockingTree {
    private int[] parent;
    private int[] lockNodeUser;
    private List<Integer>[] children;

    public LockingTree(int[] parent) {
        int n = parent.length;
        this.parent = parent;
        this.lockNodeUser = new int[n];
        Arrays.fill(this.lockNodeUser, -1);
        this.children = new List[n];
        for (int i = 0; i < n; i++) {
            this.children[i] = new ArrayList<Integer>();
        }
        for (int i = 0; i < n; i++) {
            int p = parent[i];
            if (p != -1) {
                children[p].add(i);
            }
        }
    }

    public boolean lock(int num, int user) {
        if (lockNodeUser[num] == -1) {
            lockNodeUser[num] = user;
            return true;
        } 
        return false;
    }

    public boolean unlock(int num, int user) {
        if (lockNodeUser[num] == user) {
            lockNodeUser[num] = -1;
            return true;
        }
        return false;
    }

    public boolean upgrade(int num, int user) {
        boolean res = lockNodeUser[num] == -1 && !hasLockedAncestor(num) && checkAndUnlockDescendant(num);
        if (res) {
            lockNodeUser[num] = user;
        }
        return res;
    }

    private boolean hasLockedAncestor(int num) {
        num = parent[num];
        while (num != -1) {
            if (lockNodeUser[num] != -1) {
                return true;
            }
            num = parent[num];
        }
        return false;
    }

    private boolean checkAndUnlockDescendant(int num) {
        boolean res = lockNodeUser[num] != -1;
        lockNodeUser[num] = -1;
        for (int child : children[num]) {
            res |= checkAndUnlockDescendant(child);
        }            
        return res;
    }
}
```

```csharp
public class LockingTree {
    private int[] parent;
    private int[] lockNodeUser;
    private IList<int>[] children;

    public LockingTree(int[] parent) {
        int n = parent.Length;
        this.parent = parent;
        this.lockNodeUser = new int[n];
        Array.Fill(this.lockNodeUser, -1);
        this.children = new IList<int>[n];
        for (int i = 0; i < n; i++) {
            this.children[i] = new List<int>();
        }
        for (int i = 0; i < n; i++) {
            int p = parent[i];
            if (p != -1) {
                children[p].Add(i);
            }
        }
    }
    
    public bool Lock(int num, int user) {
        if (lockNodeUser[num] == -1) {
            lockNodeUser[num] = user;
            return true;
        } 
        return false;
    }
    
    public bool Unlock(int num, int user) {
        if (lockNodeUser[num] == user) {
            lockNodeUser[num] = -1;
            return true;
        }
        return false;
    }
    
    public bool Upgrade(int num, int user) {
        bool res = lockNodeUser[num] == -1 && !HasLockedAncestor(num) && CheckAndUnlockDescendant(num);
        if (res) {
            lockNodeUser[num] = user;
        }
        return res;
    }

    private bool HasLockedAncestor(int num) {
        num = parent[num];
        while (num != -1) {
            if (lockNodeUser[num] != -1) {
                return true;
            }
            num = parent[num];
        }
        return false;
    }

    private bool CheckAndUnlockDescendant(int num) {
        bool res = lockNodeUser[num] != -1;
        lockNodeUser[num] = -1;
        foreach (int child in children[num]) {
            res |= CheckAndUnlockDescendant(child);
        }            
        return res;
    }
}
```

```cpp
class LockingTree {
public:
    LockingTree(vector<int>& parent) {
        int n = parent.size();
        this->parent = parent;
        this->lockNodeUser = vector<int>(n, -1);
        this->children = vector<vector<int>>(n);
        for (int i = 0; i < n; i++) {
            int p = parent[i];
            if (p != -1) {
                children[p].emplace_back(i);
            }
        }
    }
    
    bool lock(int num, int user) {
        if (lockNodeUser[num] == -1) {
            lockNodeUser[num] = user;
            return true;
        } 
        return false;
    }
    
    bool unlock(int num, int user) {
        if (lockNodeUser[num] == user) {
            lockNodeUser[num] = -1;
            return true;
        }
        return false;
    }
    
    bool upgrade(int num, int user) {
        bool res = lockNodeUser[num] == -1 \
                   && !hasLockedAncestor(num) \
                   && checkAndUnlockDescendant(num);
        if (res) {
            lockNodeUser[num] = user;
        }
        return res;
    }

    bool hasLockedAncestor(int num) {
        num = parent[num];
        while (num != -1) {
            if (lockNodeUser[num] != -1) {
                return true;
            }
            num = parent[num];
        }
        return false;
    }
        
    bool checkAndUnlockDescendant(int num) {
        bool res = lockNodeUser[num] != -1;
        lockNodeUser[num] = -1;
        for (int child : children[num]) {
            res |= checkAndUnlockDescendant(child);
        }            
        return res;
    }
        
private:
    vector<int> parent;
    vector<int> lockNodeUser;
    vector<vector<int>> children;
};
```

```c
typedef struct {
    int nodeSize;
    int *parent;
    int *lockNodeUser;
    struct ListNode **children;
} LockingTree;

struct ListNode *createListNode(int val) {
    struct ListNode *obj = (struct ListNode *)malloc(sizeof(struct ListNode));
    obj->val = val;
    obj->next = NULL;
    return obj;
}

LockingTree* lockingTreeCreate(int* parent, int parentSize) {
    LockingTree *obj = (LockingTree *)malloc(sizeof(LockingTree));
    obj->nodeSize = parentSize;
    obj->parent = (int *)malloc(sizeof(int) * parentSize);
    obj->lockNodeUser = (int *)malloc(sizeof(int) * parentSize);
    obj->children = (struct ListNode **)malloc(sizeof(struct ListNode *) * parentSize);
    memcpy(obj->parent, parent, sizeof(int) * parentSize);
    for (int i = 0; i < parentSize; i++) {
        obj->lockNodeUser[i] = -1;
        obj->children[i] = NULL;
    }
    for (int i = 0; i < parentSize; i++) {
        int p = parent[i];
        if (p != -1) {
            struct ListNode *node = createListNode(i);
            node->next = obj->children[p];
            obj->children[p] = node;
        }
    }
    return obj;
}

bool lockingTreeLock(LockingTree* obj, int num, int user) {
    if (obj->lockNodeUser[num] == -1) {
        obj->lockNodeUser[num] = user;
        return true;
    } 
    return false;
}

bool lockingTreeUnlock(LockingTree* obj, int num, int user) {
    if (obj->lockNodeUser[num] == user) {
        obj->lockNodeUser[num] = -1;
        return true;
    }
    return false;
}

bool hasLockedAncestor(LockingTree* obj, int num) {
    num = obj->parent[num];
    while (num != -1) {
        if (obj->lockNodeUser[num] != -1) {
            return true;
        }
        num = obj->parent[num];
    }
    return false;
}
        
bool checkAndUnlockDescendant(LockingTree* obj, int num) {
    bool res = obj->lockNodeUser[num] != -1;
    obj->lockNodeUser[num] = -1;
    for (struct ListNode *node = obj->children[num]; node; node = node->next) {
        res |= checkAndUnlockDescendant(obj, node->val);
    }         
    return res;
}

bool lockingTreeUpgrade(LockingTree* obj, int num, int user) {
    bool res = obj->lockNodeUser[num] == -1 \
                && !hasLockedAncestor(obj, num) \
                && checkAndUnlockDescendant(obj, num);
    if (res) {
        obj->lockNodeUser[num] = user;
    }
    return res;
}

void freeList(struct ListNode *list) {
    while (list) {
        struct ListNode *cur = list;
        list = list->next;
        free(cur);
    }
}

void lockingTreeFree(LockingTree* obj) {
    free(obj->parent);
    free(obj->lockNodeUser);
    for (int i = 0; i < obj->nodeSize; i++) {
        freeList(obj->children[i]);
    }
    free(obj);
}
```

```go
type LockingTree struct {
    parent []int
    lockNodeUser []int
    children [][]int
}

func Constructor(parent []int) LockingTree {
    n := len(parent)
    lockNodeUser := make([]int, n)
    children := make([][]int, n)
    for i := 0; i < n; i++ {
        lockNodeUser[i] = -1
        p := parent[i]
        if p != -1 {
            children[p] = append(children[p], i)
        }
    }
    return LockingTree{parent, lockNodeUser, children}
}

func (this *LockingTree) Lock(num int, user int) bool {
    if this.lockNodeUser[num] == -1 {
        this.lockNodeUser[num] = user
        return true
    } 
    return false
}

func (this *LockingTree) Unlock(num int, user int) bool {
    if this.lockNodeUser[num] == user {
        this.lockNodeUser[num] = -1
        return true
    }
    return false
}

func (this *LockingTree) Upgrade(num int, user int) bool {
    res := this.lockNodeUser[num] == -1 && !this.hasLockedAncestor(num) && this.checkAndUnlockDescendant(num)
    if res {
        this.lockNodeUser[num] = user
    }
    return res
}

func (this *LockingTree) hasLockedAncestor(num int) bool {
    num = this.parent[num]
    for num != -1 {
        if this.lockNodeUser[num] != -1 {
            return true
        }
        num = this.parent[num]
    }
    return false
}

func (this *LockingTree) checkAndUnlockDescendant(num int) bool {
    res := false
    if this.lockNodeUser[num] != -1 {
        res = true
    }
    this.lockNodeUser[num] = -1
    for _, child := range this.children[num] {
        if this.checkAndUnlockDescendant(child) {
            res = true
        }
    }            
    return res
}
```

```javascript
var LockingTree = function(parent) {
    const n = parent.length;
    this.parent = parent;
    this.lockNodeUser = new Array(n).fill(-1);
    this.children = new Array(n).fill(0).map(() => new Array());
    for (let i = 0; i < n; i++) {
        const p = parent[i];
        if (p != -1) {
            this.children[p].push(i);
        }
    }
};

LockingTree.prototype.lock = function(num, user) {
    if (this.lockNodeUser[num] == -1) {
        this.lockNodeUser[num] = user;
        return true;
    }
    return false;
};

LockingTree.prototype.unlock = function(num, user) {
    if (this.lockNodeUser[num] == user) {
        this.lockNodeUser[num] = -1
        return true;
    }
    return false;
};

LockingTree.prototype.upgrade = function(num, user) {
    res = this.lockNodeUser[num] == -1 && !this.hasLockedAncestor(num)
                                       && this.checkAndUnlockDescendant(num)
    if (res) {
        this.lockNodeUser[num] = user;
    }
    return res;
};

LockingTree.prototype.hasLockedAncestor = function(num) {
    num = this.parent[num];
    while (num != -1) {
        if (this.lockNodeUser[num] != -1) {
            return true;
        } else {
            num = this.parent[num];
        }
    }
    return false;
}

LockingTree.prototype.checkAndUnlockDescendant = function(num) {
    res = this.lockNodeUser[num] != -1;
    this.lockNodeUser[num] = -1;
    for (const child of this.children[num]) {
        res |= this.checkAndUnlockDescendant(child);
    }
    return res;
}
```

**复杂度分析**

-   时间复杂度：初始化：构建 $children$ 消耗 $O(n)$，$Lock$ 和 $Unlock$ 都消耗 $O(1)$，$Upgrade$ 消耗 $O(n)$。
-   空间复杂度：初始化消耗 $O(n)$，$Lock$ 和 $Unlock$ 都消耗 $O(1)$，$Upgrade$ 消耗 $O(n)$。
