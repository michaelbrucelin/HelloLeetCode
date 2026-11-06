### [统计没有收到请求的服务器数目](https://leetcode.cn/problems/count-zero-request-servers/solutions/4049404/tong-ji-mei-you-shou-dao-qing-qiu-de-fu-cfyk3/)

#### 方法一：排序与滑动窗口

**思路与算法**

将日志 $\log s$ 按时间排序，并将询问 $queries$ 连同原下标按时间排序。对于每个询问时间 $q=queries[i]$，使用双指针维护时间范围 $[q-x,q]$ 内的日志。

右指针不断加入时间不超过 $q$ 的日志。如果对应服务器的请求数从 $0$ 变为 $1$，说明它首次出现在窗口中，将服务器数量 $s$ 加一。随后左指针移除时间小于 $q-x$ 的日志；如果对应服务器的请求数减为 $0$，说明它已不在窗口中，将 $s$ 减一。此时窗口内共有 $s$ 台服务器收到过请求，因此答案为 $n-s$。

**代码**

```C++
class Solution {
public:
    vector<int> countServers(int n, vector<vector<int>>& logs, int x,
                             vector<int>& queries) {
        sort(logs.begin(), logs.end(), [](const auto& a, const auto& b) {
            return a[1] < b[1];
        });

        vector<int> ids(queries.size());
        iota(ids.begin(), ids.end(), 0);
        sort(ids.begin(), ids.end(), [&](int i, int j) {
            return queries[i] < queries[j];
        });

        vector<int> ans(queries.size()), cnt(n + 1);
        int left = 0, right = 0, active = 0;
        for (int i : ids) {
            int q = queries[i];
            while (right < logs.size() && logs[right][1] <= q) {
                int id = logs[right++][0];
                if (cnt[id]++ == 0) {
                    ++active;
                }
            }
            while (left < right && logs[left][1] < q - x) {
                int id = logs[left++][0];
                if (--cnt[id] == 0) {
                    --active;
                }
            }
            ans[i] = n - active;
        }
        return ans;
    }
};
```

```Python
class Solution:
    def countServers(self, n: int, logs: List[List[int]], x: int,
                     queries: List[int]) -> List[int]:
        logs.sort(key=lambda log: log[1])
        ids = sorted(range(len(queries)), key=lambda i: queries[i])
        ans = [0] * len(queries)
        cnt = [0] * (n + 1)
        left = right = active = 0

        for i in ids:
            q = queries[i]
            while right < len(logs) and logs[right][1] <= q:
                id = logs[right][0]
                if cnt[id] == 0:
                    active += 1
                cnt[id] += 1
                right += 1
            while left < right and logs[left][1] < q - x:
                id = logs[left][0]
                cnt[id] -= 1
                if cnt[id] == 0:
                    active -= 1
                left += 1
            ans[i] = n - active

        return ans
```

```Rust
impl Solution {
    pub fn count_servers(n: i32, mut logs: Vec<Vec<i32>>, x: i32, queries: Vec<i32>) -> Vec<i32> {
        logs.sort_unstable_by_key(|log| log[1]);
        let mut ids: Vec<usize> = (0..queries.len()).collect();
        ids.sort_unstable_by_key(|&i| queries[i]);

        let mut ans = vec![0; queries.len()];
        let mut cnt = vec![0; n as usize + 1];
        let (mut left, mut right, mut active) = (0, 0, 0);

        for i in ids {
            let q = queries[i];
            while right < logs.len() && logs[right][1] <= q {
                let id = logs[right][0] as usize;
                if cnt[id] == 0 {
                    active += 1;
                }
                cnt[id] += 1;
                right += 1;
            }
            while left < right && logs[left][1] < q - x {
                let id = logs[left][0] as usize;
                cnt[id] -= 1;
                if cnt[id] == 0 {
                    active -= 1;
                }
                left += 1;
            }
            ans[i] = n - active;
        }
        ans
    }
}
```

```Java
class Solution {
    public int[] countServers(int n, int[][] logs, int x, int[] queries) {
        Arrays.sort(logs, (a, b) -> Integer.compare(a[1], b[1]));

        int m = queries.length;
        Integer[] ids = new Integer[m];
        for (int i = 0; i < m; i++) ids[i] = i;
        Arrays.sort(ids, (i, j) -> Integer.compare(queries[i], queries[j]));

        int[] ans = new int[m];
        int[] cnt = new int[n + 1];
        int left = 0, right = 0, active = 0;

        for (int i : ids) {
            int q = queries[i];
            while (right < logs.length && logs[right][1] <= q) {
                int id = logs[right++][0];
                if (cnt[id]++ == 0) {
                    ++active;
                }
            }
            while (left < right && logs[left][1] < q - x) {
                int id = logs[left++][0];
                if (--cnt[id] == 0) {
                    --active;
                }
            }
            ans[i] = n - active;
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int[] CountServers(int n, int[][] logs, int x, int[] queries) {
        Array.Sort(logs, (a, b) => a[1].CompareTo(b[1]));

        int m = queries.Length;
        int[] ids = Enumerable.Range(0, m).ToArray();
        Array.Sort(ids, (i, j) => queries[i].CompareTo(queries[j]));

        int[] ans = new int[m];
        int[] cnt = new int[n + 1];
        int left = 0, right = 0, active = 0;

        foreach (int i in ids) {
            int q = queries[i];
            while (right < logs.Length && logs[right][1] <= q) {
                int id = logs[right++][0];
                if (cnt[id]++ == 0) {
                    ++active;
                }
            }
            while (left < right && logs[left][1] < q - x) {
                int id = logs[left++][0];
                if (--cnt[id] == 0) {
                    --active;
                }
            }
            ans[i] = n - active;
        }
        return ans;
    }
}
```

```Go
func countServers(n int, logs [][]int, x int, queries []int) []int {
    sort.Slice(logs, func(a, b int) bool {
        return logs[a][1] < logs[b][1]
    })

    m := len(queries)
    ids := make([]int, m)
    for i := range ids {
        ids[i] = i
    }
    sort.Slice(ids, func(a, b int) bool {
        return queries[ids[a]] < queries[ids[b]]
    })

    ans := make([]int, m)
    cnt := make([]int, n+1)
    left, right, active := 0, 0, 0

    for _, i := range ids {
        q := queries[i]
        for right < len(logs) && logs[right][1] <= q {
            id := logs[right][0]
            right++
            cnt[id]++
            if cnt[id] == 1 {
                active++
            }
        }
        for left < right && logs[left][1] < q-x {
            id := logs[left][0]
            left++
            cnt[id]--
            if cnt[id] == 0 {
                active--
            }
        }
        ans[i] = n - active
    }
    return ans
}
```

```C
typedef struct {
    int id;
    int time;
} LogEntry;

static int cmp_log(const void *a, const void *b) {
    const LogEntry *la = (const LogEntry *)a;
    const LogEntry *lb = (const LogEntry *)b;
    if (la->time < lb->time) {
        return -1;
    }
    if (la->time > lb->time) {
        return 1;
    }
    return 0;
}

typedef struct {
    int idx;
    int q;
} QueryEntry;

static int cmp_query(const void *a, const void *b) {
    const QueryEntry *qa = (const QueryEntry *)a;
    const QueryEntry *qb = (const QueryEntry *)b;
    if (qa->q < qb->q) {
        return -1;
    }
    if (qa->q > qb->q) {
        return 1;
    }
    return 0;
}

int* countServers(int n, int** logs, int logsSize, int* logsColSize, int x,
                  int* queries, int queriesSize, int* returnSize) {
    LogEntry *entries = (LogEntry *)malloc(sizeof(LogEntry) * (logsSize > 0 ? logsSize : 1));
    for (int i = 0; i < logsSize; ++i) {
        entries[i].id = logs[i][0];
        entries[i].time = logs[i][1];
    }
    qsort(entries, logsSize, sizeof(LogEntry), cmp_log);

    QueryEntry *qEntries = (QueryEntry *)malloc(sizeof(QueryEntry) * queriesSize);
    for (int i = 0; i < queriesSize; ++i) {
        qEntries[i].idx = i;
        qEntries[i].q = queries[i];
    }
    qsort(qEntries, queriesSize, sizeof(QueryEntry), cmp_query);

    int *ans = (int *)malloc(sizeof(int) * queriesSize);
    int *cnt = (int *)calloc(n + 1, sizeof(int));
    int left = 0, right = 0, active = 0;

    for (int k = 0; k < queriesSize; ++k) {
        int i = qEntries[k].idx;
        int q = qEntries[k].q;

        while (right < logsSize && entries[right].time <= q) {
            int id = entries[right++].id;
            if (cnt[id]++ == 0) ++active;
        }
        while (left < right && entries[left].time < q - x) {
            int id = entries[left++].id;
            if (--cnt[id] == 0) --active;
        }

        ans[i] = n - active;
    }

    free(entries);
    free(qEntries);
    free(cnt);

    *returnSize = queriesSize;
    return ans;
}
```

```JavaScript
var countServers = function(n, logs, x, queries) {
    logs.sort((a, b) => a[1] - b[1]);

    const m = queries.length;
    const ids = Array.from({ length: m }, (_, i) => i);
    ids.sort((i, j) => queries[i] - queries[j]);

    const ans = new Array(m).fill(0);
    const cnt = new Array(n + 1).fill(0);
    let left = 0, right = 0, active = 0;

    for (const i of ids) {
        const q = queries[i];
        while (right < logs.length && logs[right][1] <= q) {
            const id = logs[right++][0];
            if (cnt[id]++ === 0) {
                ++active;
            }
        }
        while (left < right && logs[left][1] < q - x) {
            const id = logs[left++][0];
            if (--cnt[id] === 0) {
                --active;
            }
        }
        ans[i] = n - active;
    }
    return ans;
};
```

```TypeScript
function countServers(n: number, logs: number[][], x: number, queries: number[]): number[] {
    logs.sort((a, b) => a[1] - b[1]);

    const m = queries.length;
    const ids: number[] = Array.from({ length: m }, (_, i) => i);
    ids.sort((i, j) => queries[i] - queries[j]);

    const ans: number[] = new Array(m).fill(0);
    const cnt: number[] = new Array(n + 1).fill(0);
    let left = 0, right = 0, active = 0;

    for (const i of ids) {
        const q = queries[i];
        while (right < logs.length && logs[right][1] <= q) {
            const id = logs[right++][0];
            if (cnt[id]++ === 0) {
                ++active;
            }
        }
        while (left < right && logs[left][1] < q - x) {
            const id = logs[left++][0];
            if (--cnt[id] === 0) {
                --active;
            }
        }
        ans[i] = n - active;
    }
    return ans;
}
```

**复杂度分析**

- 时间复杂度：$O(n+m\log m+q\log q)$，其中 $n$ 是服务器数量，$m$ 是日志数，$q$ 是询问数。初始化哈希表数组 $cnt$ 需要 $O(n)$ 的时间，排序需要 $O(m\log m+q\log q)$ 的时间，双指针求解还需要有 $O(m+q)$ 的时间。
- 空间复杂度：$O(n+q+\log m+\log q)$。哈希表使用了 $O(n)$ 的空间，临时数组使用了 $O(q)$ 的空间，排序所需空间为 $O(\log m+\log q)$。
