#### [方法三：记忆化搜索](https://leetcode.cn/problems/time-needed-to-inform-all-employees/solutions/2251785/tong-zhi-suo-you-yuan-gong-suo-xu-de-shi-503h/)

**思路与算法**

上述「方法一」和「方法二」都是「自顶向下」的实现方式。同样我们可以通过「自底向上」的方式，从每一个员工开始往上进行搜索，记录每一个员工到根节点（员工总负责人）所需要的时间，其中所需要的最大时间即为答案。由于每一个员工到根节点的路径唯一，且每一个员工可能有多个下属，所以为了避免重复计算，我们可以通过「记忆化」的方式来进行处理。

**代码**

```python
class Solution:
    def numOfMinutes(self, n: int, headID: int, manager: List[int], informTime: List[int]) -> int:
        # 使用缓存，存储每个节点到根节点的最长时间
        @cache
        def dfs(cur):
            if cur == headID:  # 当前节点为根节点
                return 0
            # 递归遍历当前节点的直属上级节点，返回时间和
            # 由于 informTime 存储的是当前节点通知下属所需时间，所以使用 manager[cur] 获取上级节点
            return dfs(manager[cur]) + informTime[manager[cur]]
        # 对所有节点遍历，返回最长时间
        return max(dfs(i) for i in range(n))
```

```java
class Solution {
    int headID;  // 公司总负责人 ID
    int[] manager;  // manager[i] 表示第 i 名员工的直属负责人
    int[] informTime;  // informTime[i] 表示第 i 名员工通知直属下属所需时间
    Map<Integer, Integer> memo = new HashMap<Integer, Integer>();  // 记忆化搜索缓存

    public int numOfMinutes(int n, int headID, int[] manager, int[] informTime) {
        this.headID = headID;
        this.manager = manager;
        this.informTime = informTime;
        int res = 0;  // 记录最长时间
        for (int i = 0; i < n; i++) {
            res = Math.max(res, dfs(i));  // 对每个员工遍历，更新最长时间
        }
        return res;
    }

    public int dfs(int cur) {
        if (cur == headID) {  // 当前节点为根节点
            return 0;
        }
        if (!memo.containsKey(cur)) {  // 检查缓存中是否已经存在当前节点的时间
            int res = dfs(manager[cur]) + informTime[manager[cur]];  // 递归遍历当前节点的直属上级节点，返回时间和
            memo.put(cur, res);  // 将当前节点到根节点的时间加入缓存中
        }
        return memo.get(cur);  // 返回当前节点到根节点的时间
    }
}
```

```csharp
public class Solution {
    int headID;
    int[] manager;
    int[] informTime;
    IDictionary<int, int> memo = new Dictionary<int, int>();

    public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime) {
        this.headID = headID;
        this.manager = manager;
        this.informTime = informTime;
        int res = 0;
        for (int i = 0; i < n; i++) {
            res = Math.Max(res, DFS(i));
        }
        return res;
    }

    public int DFS(int cur) {
        if (cur == headID) {
            return 0;
        }
        if (!memo.ContainsKey(cur)) {
            int res = DFS(manager[cur]) + informTime[manager[cur]];
            memo.Add(cur, res);
        }
        return memo[cur];
    }
}
```

```cpp
class Solution {
public:
    int numOfMinutes(int n, int headID, vector<int>& manager, vector<int>& informTime) {
        unordered_map<int, int> memo;
        function<int(int)> dfs = [&](int cur) -> int {
            if (cur == headID) {
                return 0;
            }
            if (memo.count(cur)) {
                return memo[cur];
            }
            int res = dfs(manager[cur]) + informTime[manager[cur]];
            memo[cur] = res;
            return res;
        };
        int res = 0;
        for (int i = 0; i < n; i++) {
            res = max(res, dfs(i));
        }
        return res;
    }
};
```

```c
typedef struct {
    int key;        // key
    int val;        // value
    UT_hash_handle hh;  // 用于散列表的哈希句柄
} HashItem;

// 在散列表中查找特定的 key，返回对应的结构体指针，如果不存在则返回 NULL
HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

// 在散列表中添加一个 key-value 对，如果 key 已经存在，返回 false，否则添加成功并返回 true
bool hashAddItem(HashItem **obj, int key, int val) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem)); // 分配新结构体的内存
    pEntry->key = key;
    pEntry->val = val;
    HASH_ADD_INT(*obj, key, pEntry);  // 添加到散列表中
    return true;
}

// 更新散列表中指定 key 对应的 value，如果 key 不存在，则添加一个新的 key-value 对
bool hashSetItem(HashItem **obj, int key, int val) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        hashAddItem(obj, key, val);
    } else {
        pEntry->val = val;
    }
    return true;
}

// 在散列表中查找指定 key 对应的 value，如果 key 不存在，返回默认值 defaultVal
int hashGetItem(HashItem **obj, int key, int defaultVal) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        return defaultVal;
    }
    return pEntry->val;
}

// 释放整个散列表占用的内存
void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);  // 从散列表中删除
        free(curr);             // 释放结构体占用的内存
    }
}

// 求解从 cur 到 headID 的路径所需时间
int dfs(int cur, int headID, HashItem **memo, const int* manager, const int* informTime) {
    if (cur == headID) {
        return 0;
    }
    if (hashFindItem(memo, cur) != NULL) {  // 如果 memo 中已经有了 cur 的结果，直接返回
        return hashGetItem(memo, cur, 0);
    }
    int res = dfs(manager[cur], headID, memo, manager, informTime) + informTime[manager[cur]];
    hashAddItem(memo, cur, res);  // 记录结果到 memo 中
    return res;
}

// 求解整个组织机构中，从各个节点到 headID 的路径所需时间中的最大值
int numOfMinutes(int n, int headID, int* manager, int managerSize, int* informTime, int informTimeSize) {
    HashItem *memo = NULL;  // memo 存储已经求解过的路径长度
    int res = 0;
    for (int i = 0; i < n; i++) {
        res = max(res, dfs(i, headID, &memo, manager, informTime));
    }
    hashFree(&memo);
    return res;
}
```

```javascript
// 定义函数，输入为公司总人数 n，领导的 ID headID，每个员工的直接领导的 ID 数组 manager，员工被通知所需时间的数组 informTime
var numOfMinutes = function(n, headID, manager, informTime) {
    // 定义初始值为 0 的结果变量 res 和空 Map memo，用于存储已经计算过的员工所需时间
    let res = 0;
    const memo = new Map();
    // 定义 dfs 函数，参数为当前员工的 ID cur
    const dfs = (cur) => {
        // 若当前员工为领导，返回 0
        if (cur === headID) {
            return 0;
        }
        // 若 memo 中不存在当前员工的计算结果，进行 DFS 计算
        if (!memo.has(cur)) {
            const res = dfs(manager[cur]) + informTime[manager[cur]];
            // 将当前员工的计算结果存入 memo 中
            memo.set(cur, res);
        }
        // 返回 memo 中当前员工的计算结果
        return memo.get(cur);
    }
    // 遍历每个员工，计算其所需时间，并更新结果变量 res
    for (let i = 0; i < n; i++) {
        res = Math.max(res, dfs(i));
    }
    // 返回结果变量 res
    return res;
}
```

**复杂度分析**

-   时间复杂度：$O(n)$。
-   空间复杂度：$O(n)$，主要为对记忆化的空间开销。

#### 练习题目推荐

-   [员工的重要性](https://leetcode-cn.com/problems/employee-importance/)
-   [树的中心](https://leetcode-cn.com/problems/find-center-of-star-graph/)
-   [二叉树的最大深度](https://leetcode-cn.com/problems/maximum-depth-of-binary-tree/)
-   [二叉树的直径](https://leetcode-cn.com/problems/diameter-of-binary-tree/)
-   [填充每个节点的下一个右侧节点指针](https://leetcode-cn.com/problems/populating-next-right-pointers-in-each-node/)

#### 拓展思考

本题中每个人的信息处理时间都是一样的，如果不同的人处理时间不一样，能否用类似的算法解决问题呢？
