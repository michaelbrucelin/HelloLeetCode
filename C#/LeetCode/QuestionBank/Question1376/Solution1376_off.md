#### [问题提示](https://leetcode.cn/problems/time-needed-to-inform-all-employees/solutions/2251785/tong-zhi-suo-you-yuan-gong-suo-xu-de-shi-503h/)

-   如何用代码表示员工之间的从属关系？
-   如何在代码中表示树形结构，并遍历整棵树？
-   如何优化遍历的效率，避免重复计算通知时间？

#### [前置知识](https://leetcode.cn/problems/time-needed-to-inform-all-employees/solutions/2251785/tong-zhi-suo-you-yuan-gong-suo-xu-de-shi-503h/)

-   树的遍历，包括深度优先遍历（DFS）和广度优先遍历（BFS）；
-   递归思想，包括递归函数的定义、调用、返回等；
-   一些基本的数据结构，例如数组、哈希表等。

#### [解题思路](https://leetcode.cn/problems/time-needed-to-inform-all-employees/solutions/2251785/tong-zhi-suo-you-yuan-gong-suo-xu-de-shi-503h/)

#### [方法一：深度优先搜索](https://leetcode.cn/problems/time-needed-to-inform-all-employees/solutions/2251785/tong-zhi-suo-you-yuan-gong-suo-xu-de-shi-503h/)

**思路与算法**

题目保证员工的从属关系可以用树结构显示，所以我们可以根据数组 $manager$ 来构建树模型，其中每一个员工为一个节点，每一个员工的上司为其父节点，总负责人为根节点。我们存储每一个节点的子节点，然后我们可以通过「自顶向下」的方式，从根节点开始往下「深度优先搜索」来传递信息传递的过程，计算从每一个节点往下传递信息的所需要的最大时间。

**代码**

```python
class Solution:
    def numOfMinutes(self, n: int, headID: int, manager: List[int], informTime: List[int]) -> int:
        # 使用 defaultdict 来构建图
        g = collections.defaultdict(list)
        for i in range(n):
            g[manager[i]].append(i)
        
        def dfs(cur):
            res = 0
            # 遍历当前节点的邻居节点
            for ne in g[cur]:
                res = max(res, dfs(ne))
            # 返回当前节点被通知需要的时间以及所有邻居节点被通知所需的最大时间
            return informTime[cur] + res
        
        # 从根节点开始进行 DFS 并返回总时间
        return dfs(headID)
```

```java
class Solution {
    public int numOfMinutes(int n, int headID, int[] manager, int[] informTime) {
        // 使用 HashMap 来构建图
        Map<Integer, List<Integer>> g = new HashMap<Integer, List<Integer>>();
        for (int i = 0; i < n; i++) {
            g.putIfAbsent(manager[i], new ArrayList<Integer>());
            g.get(manager[i]).add(i);
        }
        // 从根节点开始进行 DFS 并返回总时间
        return dfs(headID, informTime, g);
    }

    public int dfs(int cur, int[] informTime, Map<Integer, List<Integer>> g) {
        int res = 0;
        // 遍历当前节点的邻居节点
        for (int neighbor : g.getOrDefault(cur, new ArrayList<Integer>())) {
            res = Math.max(res, dfs(neighbor, informTime, g));
        }
        // 返回当前节点被通知需要的时间以及所有邻居节点被通知所需的最大时间
        return informTime[cur] + res;
    }
}
```

```csharp
public class Solution {
    public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime) {
        // 使用 Dictionary 来构建图
        IDictionary<int, IList<int>> g = new Dictionary<int, IList<int>>();
        for (int i = 0; i < n; i++) {
            g.TryAdd(manager[i], new List<int>());
            g[manager[i]].Add(i);
        }
        // 从根节点开始进行 DFS 并返回总时间
        return DFS(headID, informTime, g);
    }

    public int DFS(int cur, int[] informTime, IDictionary<int, IList<int>> g) {
        int res = 0;
        if (g.ContainsKey(cur)) {
            // 遍历当前节点的邻居节点
            foreach (int neighbor in g[cur]) {
                res = Math.Max(res, DFS(neighbor, informTime, g));
            }
        }
        // 返回当前节点被通知需要的时间以及所有邻居节点被通知所需的最大时间
        return informTime[cur] + res;
    }
}
```

```cpp
class Solution {
public:
    int numOfMinutes(int n, int headID, vector<int>& manager, vector<int>& informTime) {
        // 建立一个从 manager[i] 到 i 的有向图
        unordered_map<int, vector<int>> g;
        for (int i = 0; i < n; i++) {
            g[manager[i]].emplace_back(i);
        }
        // 定义一个 dfs 函数，遍历从 headID 开始的子树
        function<int(int)> dfs = [&](int cur) -> int {
            int res = 0;
            // 遍历当前节点的所有子节点，计算从子节点到当前节点的时间
            for (int neighbor : g[cur]) {
                res = max(res, dfs(neighbor));
            }
            // 加上当前节点到其上级节点的时间
            return informTime[cur] + res;
        };
        // 返回从 headID 到其所有子节点的最大时间
        return dfs(headID);
    }
};
```

```c
//定义哈希表元素结构
typedef struct {
    int key;  //键值为经理的编号
    struct ListNode *list; //指向经理下属的链表头结点
    UT_hash_handle hh;  //哈希表处理器
} HashItem;

//返回两个整数中的较大值
static int max(int a, int b) {
    return a > b ? a : b;
}

//创建新的链表结点
struct ListNode *listNodeCreat(int val) {
    struct ListNode *obj = (struct ListNode *)malloc(sizeof(struct ListNode));
    obj->val = val;
    obj->next = NULL;
    return obj;
}

//释放链表内存
void listFree(struct ListNode *head) {
    while (head) {
        struct ListNode *cur = head;
        head = head->next;
        free(cur);
    }
}

//在哈希表中查找元素
HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

//添加元素到哈希表中
bool hashAddItem(HashItem **obj, int key, int val) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (pEntry != NULL) { //如果经理已存在于哈希表中
        struct ListNode *cur = listNodeCreat(val); //创建一个链表结点
        cur->next = pEntry->list; //将新的结点插入链表中
        pEntry->list = cur;
    } else { //如果经理不存在于哈希表中
        pEntry = (HashItem *)malloc(sizeof(HashItem)); //创建新的哈希表元素
        pEntry->key = key; //设置键值
        pEntry->list = listNodeCreat(val); //创建链表头结点
        HASH_ADD_INT(*obj, key, pEntry); //将元素添加到哈希表中
    }
    return true;
}

//获取哈希表元素
struct ListNode * hashGetItem(HashItem **obj, int key) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        return NULL;
    } else {
        return pEntry->list;
    }
}

//释放哈希表内存
void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);  //从哈希表中删除当前元素
        listFree(curr->list);  //释放当前元素中链表的内存
        free(curr);             //释放当前元素的内存
    }
}

//深度优先遍历
int dfs(int cur, const int* informTime, HashItem **g) {
    int res = 0;
    HashItem *pEntry = hashFindItem(g, cur);
    if (pEntry) {
        for (struct ListNode *node = pEntry->list; node; node = node->next) {
            int neighbor = node->val;
            res = max(res, dfs(neighbor, informTime, g)); //遍历经理的下属
        }
    }
    return informTime[cur] + res;
}

int numOfMinutes(int n, int headID, int* manager, int managerSize, int* informTime, int informTimeSize) {
    HashItem *g = NULL;
    for (int i = 0; i < n; i++) {
        hashAddItem(&g, manager[i], i);
    }
    int ret = dfs(headID, informTime, &g);
    return ret;
}
```

```javascript
var numOfMinutes = function(n, headID, manager, informTime) {
    // 构建树的邻接表，使用 Map 存储
    const g = new Map();

    // 定义深度优先遍历函数
    const dfs = (cur, informTime, g) => {
        // res 存储当前节点的所有下属中，最大的通知时间
        let res = 0;

        // 遍历当前节点的每个下属
        for (const neighbor of g.get(cur) || []) {
            // 递归计算下属的通知时间，并更新 res
            res = Math.max(res, dfs(neighbor, informTime, g));
        }

        // 返回当前节点的通知时间（加上下属中最大的通知时间）
        return informTime[cur] + res;
    };

    // 遍历每个员工，将其加入其直接负责人的下属列表
    for (let i = 0; i < n; i++) {
        if (!g.has(manager[i])) {
            g.set(manager[i], []);
        }
        g.get(manager[i]).push(i);
    }

    // 从总负责人开始遍历整棵树，并计算总通知时间
    return dfs(headID, informTime, g);
}
```

```go
func numOfMinutes(n int, headID int, manager []int, informTime []int) int {
    g := map[int][]int{}
    for i, m := range manager {
        g[m] = append(g[m], i)
    }
    var dfs func(int) int
    dfs = func(cur int) (res int) {
        for _, neighbor := range g[cur] {
            res1 := dfs(neighbor)
            if res1 > res {
                res = res1
            }
        }
        return informTime[cur] + res
    }
    return dfs(headID)
}
```

**复杂度分析**

-   时间复杂度：$O(n)$。
-   空间复杂度：$O(n)$，主要为建图的空间开销。
