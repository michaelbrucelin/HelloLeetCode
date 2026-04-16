### [距离最小相等元素查询](https://leetcode.cn/problems/closest-equal-element-queries/solutions/3947852/ju-chi-zui-xiao-xiang-deng-yuan-su-cha-x-vdfj/)

#### 方法一：哈希表 + 二分查找

首先需要明确的一点是，与元素 $x$ 的 **元素值** 相等的最近元素，一定是从元素 $x$ 出发，向左或向右找到的第一个 **元素值** 与 $x$ 相等的元素。

那么对于原数组中的元素，我们可以预处理出每个元素在原数组中的位置，使用一个哈希表来存储，键为元素值，值为一个数组，存储某个 **元素值** 在原数组中对应的位置。

其次，容易发现，对于一个元素值，在它对应的位置数组中，第一个位置左边没有相邻元素，最后一个位置右边没有相邻元素，这样的话需要进行边界判断，不方便计算最小距离。考虑到数组是循环的，那么我们可以在位置数组的开头添加一个元素，值为最后一个位置减去数组长度，在位置数组的末尾添加一个元素，值为第一个位置加上数组长度，这样就可以保证每个位置都有相邻元素，就不需要进行边界的判断了。

对于每个查询，我们可以通过哈希表找到在查询位置处 **元素值** 对应的位置数组，然后使用二分查找找到当前查询位置在位置数组中的索引，计算这个索引与前后索引对应位置的距离，取最小值即可。

```C++
class Solution {
public:
    vector<int> solveQueries(vector<int>& nums, vector<int>& queries) {
        int n = nums.size();
        unordered_map<int, vector<int>> numsPos;
        for (int i = 0; i < n; i++) {
            numsPos[nums[i]].push_back(i);
        }
        for (auto& [_, pos] : numsPos) {
            int x = pos[0];
            pos.insert(pos.begin(), pos.back() - n);
            pos.push_back(x + n);
        }
        int m = queries.size();
        for (int i = 0; i < m; i++) {
            int x = nums[queries[i]];
            if (numsPos[x].size() == 3) {
                queries[i] = -1;
                continue;
            }
            int pos = lower_bound(numsPos[x].begin(), numsPos[x].end(), queries[i]) - numsPos[x].begin();
            queries[i] = min(numsPos[x][pos + 1] - numsPos[x][pos], numsPos[x][pos] - numsPos[x][pos - 1]);
        }
        return queries;
    }
};
```

```Go
func solveQueries(nums []int, queries []int) []int {
    n := len(nums)
    numsPos := make(map[int][]int)

    for i := 0; i < n; i++ {
        numsPos[nums[i]] = append(numsPos[nums[i]], i)
    }

    for k, pos := range numsPos {
        x := pos[0]
        pos = append([]int{pos[len(pos)-1] - n}, pos...)
        pos = append(pos, x+n)
        numsPos[k] = pos
    }

    for i := 0; i < len(queries); i++ {
        x := nums[queries[i]]
        posList := numsPos[x]
        if (len(posList) == 3) {
            queries[i] = -1
            continue
        }
        pos := sort.SearchInts(posList, queries[i])
        queries[i] = min(posList[pos+1]-posList[pos], posList[pos]-posList[pos-1])
    }

    return queries
}
```

```Python
class Solution:
    def solveQueries(self, nums: List[int], queries: List[int]) -> List[int]:
        n = len(nums)
        nums_pos = defaultdict(list)

        for i in range(n):
            nums_pos[nums[i]].append(i)

        for pos in nums_pos.values():
            x = pos[0]
            pos.insert(0, pos[-1] - n)
            pos.append(x + n)

        for i in range(len(queries)):
            x = nums[queries[i]]
            pos_list = nums_pos[x]
            if len(pos_list) == 3:
                queries[i] = -1
                continue
            pos = bisect.bisect_left(pos_list, queries[i])
            queries[i] = min(pos_list[pos + 1] - pos_list[pos], pos_list[pos] - pos_list[pos - 1])

        return queries
```

```Java
class Solution {
    public List<Integer> solveQueries(int[] nums, int[] queries) {
        int n = nums.length;
        HashMap<Integer, ArrayList<Integer>> numsPos = new HashMap<>();
        for (int i = 0; i < n; i++) {
            numsPos.computeIfAbsent(nums[i], k -> new ArrayList<>()).add(i);
        }
        for (ArrayList<Integer> pos : numsPos.values()) {
            int x = pos.get(0);
            int last = pos.get(pos.size() - 1);
            pos.add(0, last - n);
            pos.add(x + n);
        }
        List<Integer> result = new ArrayList<>();
        for (int q : queries) {
            int x = nums[q];
            ArrayList<Integer> posList = numsPos.get(x);

            if (posList.size() == 3) {
                result.add(-1);
                continue;
            }

            int idx = Collections.binarySearch(posList, q);
            if (idx < 0) idx = -idx - 1;

            int dist = Math.min(posList.get(idx + 1) - posList.get(idx),
                               posList.get(idx) - posList.get(idx - 1));
            result.add(dist);
        }
        return result;
    }
}
```

```CSharp
public class Solution {
    public int[] SolveQueries(int[] nums, int[] queries) {
        int n = nums.Length;
        Dictionary<int, List<int>> numsPos = new Dictionary<int, List<int>>();

        for (int i = 0; i < n; i++) {
            if (!numsPos.ContainsKey(nums[i])) {
                numsPos[nums[i]] = new List<int>();
            }
            numsPos[nums[i]].Add(i);
        }

        foreach (var pos in numsPos.Values.ToList()) {
            int x = pos[0];
            pos.Insert(0, pos[pos.Count - 1] - n);
            pos.Add(x + n);
        }

        for (int i = 0; i < queries.Length; i++) {
            int x = nums[queries[i]];
            List<int> posList = numsPos[x];
            if (posList.Count == 3) {
                queries[i] = -1;
                continue;
            }
            int pos = posList.BinarySearch(queries[i]);
            if (pos < 0) {
                pos = ~pos;
            }
            queries[i] = Math.Min(posList[pos + 1] - posList[pos], posList[pos] - posList[pos - 1]);
        }

        return queries;
    }
}
```

```C
typedef struct {
    int key;
    int* pos;
    int size;
    int capacity;
    UT_hash_handle hh;
} PosEntry;

PosEntry* findOrCreate(PosEntry** map, int key) {
    PosEntry* entry = NULL;
    HASH_FIND_INT(*map, &key, entry);
    if (entry == NULL) {
        entry = (PosEntry*)malloc(sizeof(PosEntry));
        entry->key = key;
        entry->pos = (int*)malloc(16 * sizeof(int));
        entry->size = 0;
        entry->capacity = 16;
        HASH_ADD_INT(*map, key, entry);
    }
    return entry;
}

void addPos(PosEntry* entry, int val) {
    if (entry->size >= entry->capacity) {
        entry->capacity *= 2;
        entry->pos = (int*)realloc(entry->pos, entry->capacity * sizeof(int));
    }
    entry->pos[entry->size++] = val;
}

void insertFront(PosEntry* entry, int val) {
    if (entry->size >= entry->capacity) {
        entry->capacity *= 2;
        entry->pos = (int*)realloc(entry->pos, entry->capacity * sizeof(int));
    }
    memmove(entry->pos + 1, entry->pos, entry->size * sizeof(int));
    entry->pos[0] = val;
    entry->size++;
}

int lowerBound(int* arr, int size, int target) {
    int lo = 0, hi = size;
    while (lo < hi) {
        int mid = lo + (hi - lo) / 2;
        if (arr[mid] < target) {
            lo = mid + 1;
        } else {
            hi = mid;
        }
    }
    return lo;
}

int minInt(int a, int b) {
    return a < b ? a : b;
}

int* solveQueries(int* nums, int numsSize, int* queries, int queriesSize, int* returnSize) {
    int n = numsSize;
    PosEntry* map = NULL;

    for (int i = 0; i < n; i++) {
        PosEntry* entry = findOrCreate(&map, nums[i]);
        addPos(entry, i);
    }

    PosEntry* entry, *tmp;
    HASH_ITER(hh, map, entry, tmp) {
        int x = entry->pos[0];
        int last = entry->pos[entry->size - 1];
        insertFront(entry, last - n);
        addPos(entry, x + n);
    }

    int* result = (int*)malloc(queriesSize * sizeof(int));
    *returnSize = queriesSize;

    for (int i = 0; i < queriesSize; i++) {
        int q = queries[i];
        int x = nums[q];
        PosEntry* entry = findOrCreate(&map, x);

        if (entry->size == 3) {
            result[i] = -1;
            continue;
        }

        int idx = lowerBound(entry->pos, entry->size, q);
        result[i] = minInt(entry->pos[idx + 1] - entry->pos[idx],
                          entry->pos[idx] - entry->pos[idx - 1]);
    }

    HASH_ITER(hh, map, entry, tmp) {
        free(entry->pos);
        HASH_DEL(map, entry);
        free(entry);
    }

    return result;
}
```

```JavaScript
function solveQueries(nums, queries) {
    const n = nums.length;
    const numsPos = new Map();

    for (let i = 0; i < n; i++) {
        if (!numsPos.has(nums[i])) {
            numsPos.set(nums[i], []);
        }
        numsPos.get(nums[i]).push(i);
    }

    for (const [key, pos] of numsPos) {
        const x = pos[0];
        pos.unshift(pos[pos.length - 1] - n);
        pos.push(x + n);
    }

    for (let i = 0; i < queries.length; i++) {
        const x = nums[queries[i]];
        const posList = numsPos.get(x);
        if (posList.length === 3) {
            queries[i] = -1;
            continue;
        }
        const pos = binarySearch(posList, queries[i]);
        queries[i] = Math.min(posList[pos + 1] - posList[pos], posList[pos] - posList[pos - 1]);
    }

    return queries;
}

function binarySearch(arr, target) {
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
}
```

```TypeScript
function solveQueries(nums: number[], queries: number[]): number[] {
    const n = nums.length;
    const numsPos = new Map<number, number[]>();

    for (let i = 0; i < n; i++) {
        if (!numsPos.has(nums[i])) {
            numsPos.set(nums[i], []);
        }
        numsPos.get(nums[i])!.push(i);
    }

    for (const [key, pos] of numsPos) {
        const x = pos[0];
        pos.unshift(pos[pos.length - 1] - n);
        pos.push(x + n);
    }

    for (let i = 0; i < queries.length; i++) {
        const x = nums[queries[i]];
        const posList = numsPos.get(x)!;
        if (posList.length === 3) {
            queries[i] = -1;
            continue;
        }
        const pos = binarySearch(posList, queries[i]);
        queries[i] = Math.min(posList[pos + 1] - posList[pos], posList[pos] - posList[pos - 1]);
    }

    return queries;
}

function binarySearch(arr: number[], target: number): number {
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
}
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn solve_queries(nums: Vec<i32>, queries: Vec<i32>) -> Vec<i32> {
        let n = nums.len() as i32;

        let mut nums_pos: HashMap<i32, Vec<i32>> = HashMap::new();
        for i in 0..n {
            nums_pos.entry(nums[i as usize]).or_insert(Vec::new()).push(i);
        }

        for (_, pos) in nums_pos.iter_mut() {
            let x = pos[0];
            let last = *pos.last().unwrap();
            pos.insert(0, last - n);
            pos.push(x + n);
        }

        queries
            .iter()
            .map(|&q| {
                let x = nums[q as usize];
                let pos_list = nums_pos.get(&x).unwrap();

                if pos_list.len() == 3 {
                    return -1;
                }
                let idx = pos_list.partition_point(|&v| v < q);
                (pos_list[idx + 1] - pos_list[idx]).min(pos_list[idx] - pos_list[idx - 1])
            })
            .collect()
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n+m\log k)$，其中 $n$ 是数组 $nums$ 的长度，$m$ 是查询数组 $queries$ 的长度，$k$ 是某个元素值在数组中出现的次数（最坏情况 $k=O(n)$）；遍历 $nums$ 数组，需要 $O(n)$ 时间；处理查询：对于每个查询，使用二分查找需要 $O(\log k)$ 时间，$m$ 个查询总共需要 $O(m\log k)$ 时间。
- 空间复杂度：$O(n)$，其中 $n$ 是数组 $nums$ 的长度。哈希表 $numsPos$ 存储所有元素的位置，最坏情况下每个元素值都不同，需要 $O(n)$ 空间。

#### 方法二：预处理左右最近元素位置 + 哈希表

在方法二中，我们可以预处理出每个位置左边和右边最近的 **值相等** 元素的位置，使用两个数组来存储，分别为 $left$ 和 $right$，其中 $left[i]$ 表示位置 $i$ 左边最近的 **值相等** 元素的位置，$right[i]$ 表示位置 $i$ 右边最近的 **值相等** 元素的位置。

预处理的过程中，我们可以使用一个哈希表来存储每个元素最后一次出现的位置，遍历两次数组，第一次从左到右遍历（从 $-n$ 到 $n-1$），更新 $left$ 数组，第二次从右到左遍历（从 $2n-1$ 到 $0$），更新 $right$ 数组。

在进行查询的时候，对于查询位置 $i$，首先找到这个位置的元素值 $x$，首先判断当前查询位置与左边最近的 **值相等** 的元素位置的距离是否等于数组长度，如果相等的话说明这个元素只在数组中出现了一次，那么当前查询的值为 $-1$，否则的话计算查询位置与左右最近的 **值相等** 元素位置的距离，取最小值即可。

```C++
class Solution {
public:
    vector<int> solveQueries(vector<int>& nums, vector<int>& queries) {
        int n = nums.size();
        vector<int> left(n), right(n);
        unordered_map<int, int> pos;
        for (int i = -n; i < n; i++) {
            if (i >= 0) {
                left[i] = pos[nums[i]];
            }
            pos[nums[(i + n) % n]] = i;
        }
        pos.clear();
        for (int i = 2 * n - 1; i >= 0; i--) {
            if (i < n) {
                right[i] = pos[nums[i]];
            }
            pos[nums[i % n]] = i;
        }
        int m = queries.size();
        for (int i = 0; i < m; i++) {
            int x = queries[i];
            queries[i] = (x - left[x] == n) ? -1 : min(x - left[x], right[x] - x);
        }
        return queries;
    }
};
```

```Go
func solveQueries(nums []int, queries []int) []int {
    n := len(nums)
    left := make([]int, n)
    right := make([]int, n)
    pos := make(map[int]int)

    for i := -n; i < n; i++ {
        if i >= 0 {
            left[i] = pos[nums[i]]
        }
        pos[nums[(i+n)%n]] = i
    }

    pos = make(map[int]int)
    for i := 2 * n - 1; i >= 0; i-- {
        if i < n {
            right[i] = pos[nums[i]]
        }
        pos[nums[i%n]] = i
    }

    for i := 0; i < len(queries); i++ {
        x := queries[i]
        if x-left[x] == n {
            queries[i] = -1
        } else {
            queries[i] = min(x-left[x], right[x]-x)
        }
    }

    return queries
}
```

```Python
class Solution:
    def solveQueries(self, nums: List[int], queries: List[int]) -> List[int]:
        n = len(nums)
        left = [0] * n
        right = [0] * n
        pos = {}

        for i in range(-n, n):
            if i >= 0:
                left[i] = pos.get(nums[i], -n)
            pos[nums[(i + n) % n]] = i

        pos.clear()
        for i in range(2 * n - 1, -1, -1):
            if i < n:
                right[i] = pos.get(nums[i], 2 * n)
            pos[nums[i % n]] = i

        for i in range(len(queries)):
            x = queries[i]
            if x - left[x] == n:
                queries[i] = -1
            else:
                queries[i] = min(x - left[x], right[x] - x)

        return queries
```

```Java
class Solution {
    public List<Integer> solveQueries(int[] nums, int[] queries) {
        int n = nums.length;
        int[] left = new int[n];
        int[] right = new int[n];

        HashMap<Integer, Integer> pos = new HashMap<>();
        for (int i = -n; i < n; i++) {
            if (i >= 0) {
                left[i] = pos.getOrDefault(nums[i], i - n);
            }
            pos.put(nums[((i % n) + n) % n], i);
        }

        pos.clear();
        for (int i = 2 * n - 1; i >= 0; i--) {
            if (i < n) {
                right[i] = pos.getOrDefault(nums[i], i + n);
            }
            pos.put(nums[i % n], i);
        }

        List<Integer> result = new ArrayList<>();
        for (int i = 0; i < queries.length; i++) {
            int x = queries[i];
            if (x - left[x] == n) {
                result.add(-1);
            } else {
                result.add(Math.min(x - left[x], right[x] - x));
            }
        }
        return result;
    }
}
```

```CSharp
public class Solution {
    public int[] SolveQueries(int[] nums, int[] queries) {
        int n = nums.Length;
        int[] left = new int[n];
        int[] right = new int[n];
        Dictionary<int, int> pos = new Dictionary<int, int>();

        for (int i = -n; i < n; i++) {
            if (i >= 0) {
                left[i] = pos.ContainsKey(nums[i]) ? pos[nums[i]] : -n;
            }
            pos[nums[(i + n) % n]] = i;
        }

        pos.Clear();
        for (int i = 2 * n - 1; i >= 0; i--) {
            if (i < n) {
                right[i] = pos.ContainsKey(nums[i]) ? pos[nums[i]] : 2 * n;
            }
            pos[nums[i % n]] = i;
        }

        for (int i = 0; i < queries.Length; i++) {
            int x = queries[i];
            if (x - left[x] == n) {
                queries[i] = -1;
            } else {
                queries[i] = Math.Min(x - left[x], right[x] - x);
            }
        }

        return queries;
    }
}
```

```C
typedef struct {
    int key;
    int value;
    UT_hash_handle hh;
} HashItem;

HashItem* hashFindItem(HashItem** table, int key) {
    HashItem* item = NULL;
    HASH_FIND_INT(*table, &key, item);
    return item;
}

void hashAddOrUpdateItem(HashItem** table, int key, int value) {
    HashItem* item = hashFindItem(table, key);
    if (item == NULL) {
        item = (HashItem*)malloc(sizeof(HashItem));
        item->key = key;
        HASH_ADD_INT(*table, key, item);
    }
    item->value = value;
}

int hashGetItem(HashItem** table, int key, int defaultValue) {
    HashItem* item = hashFindItem(table, key);
    return item == NULL ? defaultValue : item->value;
}

int minInt(int a, int b) {
    return a < b ? a : b;
}

int* solveQueries(int* nums, int numsSize, int* queries, int queriesSize, int* returnSize) {
    int n = numsSize;
    int* left = (int*)malloc(sizeof(int) * n);
    int* right = (int*)malloc(sizeof(int) * n);
    HashItem* pos = NULL;

    for (int i = -n; i < n; i++) {
        if (i >= 0) {
            left[i] = hashGetItem(&pos, nums[i], -n);
        }
        hashAddOrUpdateItem(&pos, nums[(i + n) % n], i);
    }

    HashItem *current, *tmp;
    HASH_ITER(hh, pos, current, tmp) {
        HASH_DEL(pos, current);
        free(current);
    }
    for (int i = 2 * n - 1; i >= 0; i--) {
        if (i < n) {
            right[i] = hashGetItem(&pos, nums[i], 2 * n);
        }
        hashAddOrUpdateItem(&pos, nums[i % n], i);
    }

    for (int i = 0; i < queriesSize; i++) {
        int x = queries[i];
        if (x - left[x] == n) {
            queries[i] = -1;
        } else {
            queries[i] = minInt(x - left[x], right[x] - x);
        }
    }

    *returnSize = queriesSize;

    HASH_ITER(hh, pos, current, tmp) {
        HASH_DEL(pos, current);
        free(current);
    }
    free(left);
    free(right);

    return queries;
}
```

```JavaScript
function solveQueries(nums, queries) {
    const n = nums.length;
    const left = new Array(n);
    const right = new Array(n);
    const pos = new Map();

    for (let i = -n; i < n; i++) {
        if (i >= 0) {
            left[i] = pos.has(nums[i]) ? pos.get(nums[i]) : -n;
        }
        pos.set(nums[(i + n) % n], i);
    }

    pos.clear();
    for (let i = 2 * n - 1; i >= 0; i--) {
        if (i < n) {
            right[i] = pos.has(nums[i]) ? pos.get(nums[i]) : 2 * n;
        }
        pos.set(nums[i % n], i);
    }

    for (let i = 0; i < queries.length; i++) {
        const x = queries[i];
        if (x - left[x] === n) {
            queries[i] = -1;
        } else {
            queries[i] = Math.min(x - left[x], right[x] - x);
        }
    }

    return queries;
}
```

```TypeScript
function solveQueries(nums: number[], queries: number[]): number[] {
    const n = nums.length;
    const left = new Array<number>(n);
    const right = new Array<number>(n);
    const pos = new Map<number, number>();

    for (let i = -n; i < n; i++) {
        if (i >= 0) {
            left[i] = pos.has(nums[i]) ? pos.get(nums[i])! : -n;
        }
        pos.set(nums[(i + n) % n], i);
    }

    pos.clear();
    for (let i = 2 * n - 1; i >= 0; i--) {
        if (i < n) {
            right[i] = pos.has(nums[i]) ? pos.get(nums[i])! : 2 * n;
        }
        pos.set(nums[i % n], i);
    }

    for (let i = 0; i < queries.length; i++) {
        const x = queries[i];
        if (x - left[x] === n) {
            queries[i] = -1;
        } else {
            queries[i] = Math.min(x - left[x], right[x] - x);
        }
    }

    return queries;
}
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn solve_queries(nums: Vec<i32>, queries: Vec<i32>) -> Vec<i32> {
        let n = nums.len() as i32;
        let nu = n as usize;
        let mut left = vec![0i32; nu];
        let mut right = vec![0i32; nu];
        let mut pos: HashMap<i32, i32> = HashMap::new();
        for i in -n..n {
            if i >= 0 {
                let idx = i as usize;
                left[idx] = *pos.get(&nums[idx]).unwrap_or(&(i - n));
            }
            let wrap = ((i % n + n) % n) as usize;
            pos.insert(nums[wrap], i);
        }

        pos.clear();
        for i in (0..2 * n).rev() {
            if i < n {
                let idx = i as usize;
                right[idx] = *pos.get(&nums[idx]).unwrap_or(&(i + n));
            }
            let wrap = (i % n) as usize;
            pos.insert(nums[wrap], i);
        }

        queries
            .iter()
            .map(|&q| {
                let x = q as usize;
                let xi = q;
                if xi - left[x] == n {
                    -1
                } else {
                    (xi - left[x]).min(right[x] - xi)
                }
            })
            .collect()
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n+m)$，其中 $n$ 是数组 $nums$ 的长度，$m$ 是查询数组 $queries$ 的长度。预处理 $left$ 数组需要 $(n)$ 时间；对于每个查询，只需 $O(1)$ 时间计算距离，$m$ 个查询总共需要 $O(m)$ 时间。
- 空间复杂度：$O(n)$，其中 $n$ 是数组 $nums$ 的长度。$left$ 数组：存储每个位置左边最近相等元素的位置，需要 $O(n)$ 空间；$right$ 数组：存储每个位置右边最近相等元素的位置，需要 $O(n)$ 空间；哈希表 $pos$：存储元素值到位置的映射，最坏情况下需要 $O(n)$ 空间。
