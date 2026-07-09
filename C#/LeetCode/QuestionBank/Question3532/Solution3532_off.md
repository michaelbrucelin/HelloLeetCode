### [针对图的路径存在性查询 I](https://leetcode.cn/problems/path-existence-queries-in-a-graph-i/solutions/3989690/zhen-dui-tu-de-lu-jing-cun-zai-xing-cha-9oduv/)

#### 方法一：二分查找

**思路与算法**

为了方便描述，我们约定若节点 $i$ 和节点 $j$ 之间存在路径，则节点 $i$ 和节点 $j$ 是连通的。

$nums$ 已经按非递减的顺序排序，因此如果有两个节点 $i$ 和 $j$ 连通，那么 $i$ 和 $j$ 之间的任何一个节点 $k$ 也和它们互相连通，其中 $i<k<j$。

因此最终整个 $nums$ 会被划分为若干个区间：

- 每两个相邻的区间，它们边界处的差值大于 $maxDiff$；
- 每个区间内部任意两个节点都互相连通。

对每个查询，若两个节点在同一个区间，则认为其之间存在路径。我们要记下来每个区间的右端点，通过二分查找快速定位待查询节点所在区间的右端点，进而判断两个节点是否处于同一区间。

**代码**

```C++
class Solution {
public:
    vector<bool> pathExistenceQueries(int n, vector<int>& nums, int maxDiff, vector<vector<int>>& queries) {
        vector<int> rights;
        for (int i = 1; i < n; i++) {
            if (nums[i] - nums[i - 1] > maxDiff) {
                rights.push_back(i - 1);
            }
        }
        rights.push_back(n - 1);

        vector<bool> res(queries.size());
        for (int i = 0; i < queries.size(); i++) {
            int x = queries[i][0];
            int y = queries[i][1];

            res[i] = ranges::lower_bound(rights, x) == ranges::lower_bound(rights, y);
        }
        return res;
    }
};
```

```Python
class Solution:
    def pathExistenceQueries(self, n: int, nums: List[int], maxDiff: int, queries: List[List[int]]) -> List[bool]:
        rights = [i - 1 for i in range(1, n) if nums[i] - nums[i - 1] > maxDiff]
        rights.append(n - 1)
        return [bisect_left(rights, x) == bisect_left(rights, y) for x, y in queries]
```

```Rust
impl Solution {
    pub fn path_existence_queries(n: i32, nums: Vec<i32>, max_diff: i32, queries: Vec<Vec<i32>>) -> Vec<bool> {
        let mut rights: Vec<i32> = (1..n)
            .filter(|&i| nums[i as usize] - nums[(i - 1) as usize] > max_diff)
            .map(|i| i - 1)
            .collect();
        rights.push(n - 1);

        queries
            .iter()
            .map(|q| {
                let x = q[0];
                let y = q[1];
                rights.partition_point(|&v| v < x) == rights.partition_point(|&v| v < y)
            })
            .collect()
    }
}
```

```Java
class Solution {
    public boolean[] pathExistenceQueries(int n, int[] nums, int maxDiff, int[][] queries) {
        List<Integer> rights = new ArrayList<>();
        for (int i = 1; i < n; i++) {
            if (nums[i] - nums[i - 1] > maxDiff) {
                rights.add(i - 1);
            }
        }
        rights.add(n - 1);

        boolean[] res = new boolean[queries.length];
        for (int i = 0; i < queries.length; i++) {
            int x = queries[i][0];
            int y = queries[i][1];

            int idxX = lowerBound(rights, x);
            int idxY = lowerBound(rights, y);
            res[i] = idxX == idxY;
        }
        return res;
    }

    private int lowerBound(List<Integer> list, int target) {
        int left = 0, right = list.size();
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (list.get(mid) < target) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    }
}
```

```CSharp
public class Solution {
    public bool[] PathExistenceQueries(int n, int[] nums, int maxDiff, int[][] queries) {
        List<int> rights = new List<int>();
        for (int i = 1; i < n; i++) {
            if (nums[i] - nums[i - 1] > maxDiff) {
                rights.Add(i - 1);
            }
        }
        rights.Add(n - 1);

        bool[] res = new bool[queries.Length];
        for (int i = 0; i < queries.Length; i++) {
            int x = queries[i][0];
            int y = queries[i][1];

            int idxX = LowerBound(rights, x);
            int idxY = LowerBound(rights, y);
            res[i] = idxX == idxY;
        }
        return res;
    }

    private int LowerBound(List<int> list, int target) {
        int left = 0, right = list.Count;
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (list[mid] < target) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    }
}
```

```Go
func pathExistenceQueries(n int, nums []int, maxDiff int, queries [][]int) []bool {
    rights := []int{}
    for i := 1; i < n; i++ {
        if nums[i] - nums[i-1] > maxDiff {
            rights = append(rights, i-1)
        }
    }
    rights = append(rights, n-1)

    res := make([]bool, len(queries))
    for i, query := range queries {
        x, y := query[0], query[1]
        idxX := sort.SearchInts(rights, x)
        idxY := sort.SearchInts(rights, y)
        res[i] = idxX == idxY
    }
    return res
}
```

```C
int lowerBound(int* arr, int size, int target) {
    int left = 0, right = size;
    while (left < right) {
        int mid = left + (right - left) / 2;
        if (arr[mid] < target) {
            left = mid + 1;
        } else {
            right = mid;
        }
    }
    return left;
}

bool* pathExistenceQueries(int n, int* nums, int numsSize, int maxDiff, int** queries, int queriesSize, int* queriesColSize, int* returnSize) {
    int* rights = (int*)malloc(n * sizeof(int));
    int rightsSize = 0;

    for (int i = 1; i < n; i++) {
        if (nums[i] - nums[i - 1] > maxDiff) {
            rights[rightsSize++] = i - 1;
        }
    }
    rights[rightsSize++] = n - 1;

    bool* res = (bool*)malloc(queriesSize * sizeof(bool));
    *returnSize = queriesSize;

    for (int i = 0; i < queriesSize; i++) {
        int x = queries[i][0];
        int y = queries[i][1];

        int idxX = lowerBound(rights, rightsSize, x);
        int idxY = lowerBound(rights, rightsSize, y);
        res[i] = (idxX == idxY);
    }

    free(rights);
    return res;
}
```

```JavaScript
var pathExistenceQueries = function(n, nums, maxDiff, queries) {
    const rights = [];
    for (let i = 1; i < n; i++) {
        if (nums[i] - nums[i - 1] > maxDiff) {
            rights.push(i - 1);
        }
    }
    rights.push(n - 1);

    const lowerBound = (arr, target) => {
        let left = 0, right = arr.length;
        while (left < right) {
            const mid = Math.floor((left + right) / 2);
            if (arr[mid] < target) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    };

    return queries.map(([x, y]) => {
        return lowerBound(rights, x) === lowerBound(rights, y);
    });
};
```

```TypeScript
function pathExistenceQueries(n: number, nums: number[], maxDiff: number, queries: number[][]): boolean[] {
    const rights: number[] = [];
    for (let i = 1; i < n; i++) {
        if (nums[i] - nums[i - 1] > maxDiff) {
            rights.push(i - 1);
        }
    }
    rights.push(n - 1);

    const lowerBound = (arr: number[], target: number): number => {
        let left = 0, right = arr.length;
        while (left < right) {
            const mid = Math.floor((left + right) / 2);
            if (arr[mid] < target) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    };

    return queries.map(([x, y]) => {
        return lowerBound(rights, x) === lowerBound(rights, y);
    });
}
```

**复杂度分析**

- 时间复杂度：$O(n+q\log n)$，其中 $n$ 是 $nums$ 的长度，$q$ 是查询次数。
- 空间复杂度：$O(n)$。

#### 方法二：并查集

**思路与算法**

我们可以使用并查集来维护节点之间的连通关系，轻松解决本题。

如方法一所述，本题中的 $nums$ 存在特殊性质，即互相连通的节点一定在一个下标连续的区间内，因此我们用一个数组来标记每个节点所属的连通集编号，从左到右遍历的过程中进行赋值。

我们定义 $tags[i]$ 为节点 $i$ 所属的集合编号，若两个节点 $i$ 和 $j$ 对应的 $tags[i]$ 等于 $tags[j]$，则认为他们在同一个集合内，存在连通路径。在从左到右遍历的过程中：

- 若 $nums[i]-nums[i-1]$ 大于 $maxDiff$，则将 $tags[i]$ 设为 $tags[i-1]+1$。
- 否则，将 $tags[i]$ 设为 $tags[i-1]$。

**代码**

```C++
class Solution {
public:
    vector<bool> pathExistenceQueries(int n, vector<int>& nums, int maxDiff, vector<vector<int>>& queries) {
        vector<int> tags(n);
        for (int i = 1; i < n; i++) {
            if (nums[i] - nums[i - 1] > maxDiff) {
                tags[i] = tags[i - 1] + 1;
            } else {
                tags[i] = tags[i - 1];
            }
        }
        vector<bool> res(queries.size());
        for (int i = 0; i < queries.size(); i++) {
            int x = queries[i][0];
            int y = queries[i][1];
            res[i] = tags[x] == tags[y];
        }
        return res;
    }
};
```

```Python
class Solution:
    def pathExistenceQueries(self, n: int, nums: List[int], maxDiff: int, queries: List[List[int]]) -> List[bool]:
        tags = [0] * n
        for i in range(1, n):
            tags[i] = tags[i - 1] + (1 if nums[i] - nums[i - 1] > maxDiff else 0)

        return [tags[x] == tags[y] for x, y in queries]
```

```Rust
impl Solution {
    pub fn path_existence_queries(n: i32, nums: Vec<i32>, max_diff: i32, queries: Vec<Vec<i32>>) -> Vec<bool> {
        let mut tags = vec![0; n as usize];
        for i in 1..n as usize {
            tags[i] = tags[i - 1] + if nums[i] - nums[i - 1] > max_diff { 1 } else { 0 };
        }

        queries.iter()
            .map(|q| tags[q[0] as usize] == tags[q[1] as usize])
            .collect()
    }
}
```

```Java
class Solution {
    public boolean[] pathExistenceQueries(int n, int[] nums, int maxDiff, int[][] queries) {
        int[] tags = new int[n];
        for (int i = 1; i < n; i++) {
            if (nums[i] - nums[i - 1] > maxDiff) {
                tags[i] = tags[i - 1] + 1;
            } else {
                tags[i] = tags[i - 1];
            }
        }

        boolean[] res = new boolean[queries.length];
        for (int i = 0; i < queries.length; i++) {
            int x = queries[i][0];
            int y = queries[i][1];
            res[i] = tags[x] == tags[y];
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public bool[] PathExistenceQueries(int n, int[] nums, int maxDiff, int[][] queries) {
        int[] tags = new int[n];
        for (int i = 1; i < n; i++) {
            if (nums[i] - nums[i - 1] > maxDiff) {
                tags[i] = tags[i - 1] + 1;
            } else {
                tags[i] = tags[i - 1];
            }
        }

        bool[] res = new bool[queries.Length];
        for (int i = 0; i < queries.Length; i++) {
            int x = queries[i][0];
            int y = queries[i][1];
            res[i] = tags[x] == tags[y];
        }
        return res;
    }
}
```

```Go
func pathExistenceQueries(n int, nums []int, maxDiff int, queries [][]int) []bool {
    tags := make([]int, n)
    for i := 1; i < n; i++ {
        if nums[i] - nums[i-1] > maxDiff {
            tags[i] = tags[i-1] + 1
        } else {
            tags[i] = tags[i-1]
        }
    }

    res := make([]bool, len(queries))
    for i, query := range queries {
        x, y := query[0], query[1]
        res[i] = tags[x] == tags[y]
    }
    return res
}
```

```C
bool* pathExistenceQueries(int n, int* nums, int numsSize, int maxDiff, int** queries, int queriesSize, int* queriesColSize, int* returnSize) {
    int* tags = (int*)malloc(n * sizeof(int));
    tags[0] = 0;

    for (int i = 1; i < n; i++) {
        if (nums[i] - nums[i - 1] > maxDiff) {
            tags[i] = tags[i - 1] + 1;
        } else {
            tags[i] = tags[i - 1];
        }
    }

    bool* res = (bool*)malloc(queriesSize * sizeof(bool));
    *returnSize = queriesSize;

    for (int i = 0; i < queriesSize; i++) {
        int x = queries[i][0];
        int y = queries[i][1];
        res[i] = (tags[x] == tags[y]);
    }

    free(tags);
    return res;
}
```

```JavaScript
var pathExistenceQueries = function(n, nums, maxDiff, queries) {
    const tags = new Array(n);
    tags[0] = 0;

    for (let i = 1; i < n; i++) {
        if (nums[i] - nums[i - 1] > maxDiff) {
            tags[i] = tags[i - 1] + 1;
        } else {
            tags[i] = tags[i - 1];
        }
    }

    return queries.map(([x, y]) => tags[x] === tags[y]);
};
```

```TypeScript
function pathExistenceQueries(n: number, nums: number[], maxDiff: number, queries: number[][]): boolean[] {
    const tags: number[] = new Array(n);
    tags[0] = 0;

    for (let i = 1; i < n; i++) {
        if (nums[i] - nums[i - 1] > maxDiff) {
            tags[i] = tags[i - 1] + 1;
        } else {
            tags[i] = tags[i - 1];
        }
    }

    return queries.map(([x, y]) => tags[x] === tags[y]);
}
```

**复杂度分析**

- 时间复杂度：$O(n+q)$，其中 $n$ 是 $nums$ 的长度，$q$ 是查询次数。
- 空间复杂度：$O(n)$。
