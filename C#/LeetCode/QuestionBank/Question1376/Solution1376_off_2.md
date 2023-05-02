#### [方法二：广度优先搜索](https://leetcode.cn/problems/time-needed-to-inform-all-employees/solutions/2251785/tong-zhi-suo-you-yuan-gong-suo-xu-de-shi-503h/)

**思路与算法**

同样我们可以用「广度优先搜索」来实现「方法一」中信息传递的过程。每一个员工看作一个节点，总负责人为根节点，队列中存放二元组 $(node, time)$，其中 $node$ 表示当前员工，$time$ 为信息传递到该员工的时间。最初我们将二元组 $(headID, 0)$ 放入队列，每一个叶子节点的最大时间即为答案。

**代码**

```python
import queue
class Solution:
    def numOfMinutes(self, n: int, headID: int, manager: List[int], informTime: List[int]) -> int:
        # 使用 defaultdict 来方便地构建邻接表
        g = collections.defaultdict(list)
        for i in range(n):
            g[manager[i]].append(i)
        q = queue.Queue()
        # 将起点放入队列
        q.put((headID, 0))
        res = 0
        while not q.empty():
            tmp_id, val = q.get()
            # 如果当前节点没有下属，说明到达了叶子节点，更新结果
            if len(g[tmp_id]) == 0:
                res = max(res, val)
            else:   
                # 将当前节点的下属加入队列，更新时间
                for ne in g[tmp_id]:
                    q.put((ne, val + informTime[tmp_id]))
        return res
```

```java
class Solution {
    public int numOfMinutes(int n, int headID, int[] manager, int[] informTime) {
        Map<Integer, List<Integer>> g = new HashMap<Integer, List<Integer>>();
        // 构建邻接表
        for (int i = 0; i < n; i++) {
            g.putIfAbsent(manager[i], new ArrayList<Integer>());
            g.get(manager[i]).add(i);
        }
        Queue<int[]> queue = new ArrayDeque<int[]>();
        // 将起点放入队列
        queue.offer(new int[]{headID, 0});
        int res = 0;
        while (!queue.isEmpty()) {
            int[] arr = queue.poll();
            int tmpId = arr[0], val = arr[1];
            // 如果当前节点没有下属，说明到达了叶子节点，更新结果
            if (!g.containsKey(tmpId)) {
                res = Math.max(res, val);
            } else {
                // 将当前节点的下属加入队列，更新时间
                for (int ne : g.get(tmpId)) {
                    queue.offer(new int[]{ne, val + informTime[tmpId]});
                }
            }
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime) {
        IDictionary<int, IList<int>> g = new Dictionary<int, IList<int>>();
        // 构建邻接表
        for (int i = 0; i < n; i++) {
            g.TryAdd(manager[i], new List<int>());
            g[manager[i]].Add(i);
        }
        Queue<int[]> queue = new Queue<int[]>();
        // 将起点放入队列
        queue.Enqueue(new int[]{headID, 0});
        int res = 0;
        while (queue.Count > 0) {
            int[] arr = queue.Dequeue();
            int tmpId = arr[0], val = arr[1];
            // 如果当前节点没有下属，说明到达了叶子节点，更新结果
            if (!g.ContainsKey(tmpId)) {
                res = Math.Max(res, val);
            } else {
                // 将当前节点的下属加入队列，更新时间
                foreach (int ne in g[tmpId]) {
                    queue.Enqueue(new int[]{ne, val + informTime[tmpId]});
                }
            }
        }
        return res;
    }
}
```

```cpp
class Solution {
public:
    int numOfMinutes(int n, int headID, vector<int>& manager, vector<int>& informTime) {
        // 创建一个无序哈希表，键是管理者ID，值是直接汇报给他的员工的列表。
        unordered_map<int, vector<int>> g;
        // 将所有员工添加到各自的管理者的值（列表）中。
        for (int i = 0; i < n; i++) {
            g[manager[i]].emplace_back(i);
        }
        // 创建一个队列，第一个元素是员工ID，第二个元素是从头节点到这个员工的总时间。
        queue<pair<int, int>> q;
        // 添加第一个元素到队列中。
        q.emplace(headID, 0);
        // 保存最长时间。
        int res = 0;
        while (!q.empty()) {
            auto [tmp_id, val] = q.front();
            q.pop();
            // 如果这个员工没有管理其他员工，它就是公司最后一个员工，将总时间与结果中的最大值比较并更新结果。
            if (!g.count(tmp_id)) {
                res = max(res, val);
            } else {
                // 如果这个员工管理其他员工，将直接报告给它的员工加入到队列中。
                for (int neighbor : g[tmp_id]) {
                    q.emplace(neighbor, val + informTime[tmp_id]);
                }
            }
        }
        return res;
    }
};
```

```c
typedef struct {
    int key; // 节点的 id
    struct ListNode *list; // 节点的下属列表
    UT_hash_handle hh; // 宏定义，用于哈希表操作
} HashItem; 

// 比较两个整数的大小，返回较大值
static int max(int a, int b) {
    return a > b ? a : b;
}

// 创建一个链表节点，返回节点指针
struct ListNode *listNodeCreat(int val) {
    struct ListNode *obj = (struct ListNode *)malloc(sizeof(struct ListNode));
    obj->val = val;
    obj->next = NULL;
    return obj;
}

// 释放一个链表的内存空间
void listFree(struct ListNode *head) {
    while (head) {
        struct ListNode *cur = head;
        head = head->next;
        free(cur);
    }
}

// 在哈希表中查找指定 key 对应的节点，返回节点指针
HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry); // UT_hash 中的宏定义
    return pEntry;
}

// 将指定 key 和 val 的节点加入到哈希表中，返回是否添加成功
bool hashAddItem(HashItem **obj, int key, int val) {
    HashItem *pEntry = hashFindItem(obj, key); // 先在哈希表中查找是否已经有相同的 key
    if (pEntry != NULL) { // 如果已经有相同的 key，则将 val 添加到原有节点的下属列表中
        struct ListNode *cur = listNodeCreat(val);
        cur->next = pEntry->list;
        pEntry->list = cur;
    } else { // 如果没有相同的 key，则新建一个节点，并将节点添加到哈希表中
        pEntry = (HashItem *)malloc(sizeof(HashItem));
        pEntry->key = key;
        pEntry->list = listNodeCreat(val);
        HASH_ADD_INT(*obj, key, pEntry); // UT_hash 中的宏定义
    }
    return true;
}

// 获取哈希表中指定 key 对应的节点的下属列表
struct ListNode * hashGetItem(HashItem **obj, int key) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        return NULL;
    } else {
        return pEntry->list;
    }
}

// 释放哈希表的内存空间
void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) { // UT_hash 中的宏定义
        HASH_DEL(*obj, curr); // UT_hash 中的宏定义
        listFree(curr->list);
        free(curr);             
    }
}

// 计算从 headID 开始的传递时间
int numOfMinutes(int n, int headID, int* manager, int managerSize, int* informTime, int informTimeSize) {
    HashItem *g = NULL; // 哈希表，用于存储每个节点的下属

    // 遍历所有员工，将他们的下属添加到哈希表中
    for (int i = 0; i < n; i++) {
        hashAddItem(&g, manager[i], i);
    }

    int queue[n][2]; // 用数组实现队列
    int head = 0, tail = 0; // 队列头和尾的指针
    queue[tail][0] = headID; // 将起点加入队列
    queue[tail][1] = 0; // 起点的传递时间为0
    tail++;

    int res = 0; // 最终结果，即传递给所有员工所需的最短时间
    while (head != tail) {
        int tmp_id = queue[head][0]; // 取出队头员工的ID
        int val = queue[head][1]; // 取出队头员工接到信息所需的时间
        head++; // 出队

        HashItem *pEntry = hashFindItem(&g, tmp_id); // 查找该员工的下属
        if (pEntry) {
            // 遍历该员工的所有下属
            for (struct ListNode *node = pEntry->list; node; node = node->next) {
                int neighbor = node->val; // 取出下属的ID
                queue[tail][0] = neighbor; // 下属入队
                queue[tail][1] = val + informTime[tmp_id]; // 下属接到信息的时间为当前员工接到信息的时间加上传递时间
                tail++; // 队尾指针后移
            }
        } else {
            res = max(res, val); // 如果该员工没有下属，说明信息传递到该员工的时间已经确定，更新结果
        }
    }

    hashFree(&g); // 释放哈希表内存
    return res;
}
```

```javascript
var numOfMinutes = function(n, headID, manager, informTime) {
    // 初始化哈希表
    const g = new Map();
    for (let i = 0; i < n; i++) {
        if (!g.has(manager[i])) {
            g.set(manager[i], []);
        }
        g.get(manager[i]).push(i);
    }
    // 初始化队列
    const queue = [];
    queue.push([headID, 0]);

    // 初始化结果
    let res = 0;

    // BFS
    while (queue.length) {
        const arr = queue.shift();
        const tmpId = arr[0], val = arr[1];
        if (!g.has(tmpId)) {
            // 如果当前节点没有下属，更新结果
            res = Math.max(res, val);
        } else {
            // 遍历当前节点的下属，将其加入队列
            for (const ne of g.get(tmpId)) {
                queue.push([ne, val + informTime[tmpId]]);
            }
        }
    }
    return res;
}
```

**复杂度分析**

-   时间复杂度：$O(n)$。
-   空间复杂度：$O(n)$，主要为建图的空间开销。
