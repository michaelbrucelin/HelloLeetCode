### [将元素分配到两个数组中 II](https://leetcode.cn/problems/distribute-elements-into-two-arrays-ii/solutions/2796537/jiang-yuan-su-fen-pei-dao-liang-ge-shu-z-d5mh/)

#### 方法一：树状数组 + 模拟

**思路与算法**

根据题意，要实现 $\textit{greaterCount}$ 函数，需要快速查找一个有序结构中，严格大于 $\textit{val}$ 的元素数量。我们可以使用「树状数组」来实现这个数据结构，其它「线段树」结构也可以实现相同功能。

首先，因为我们只关心数组元素的大小关系，我们可以将数组「离散化」。

然后我们根据题意进行模拟，初始化两个数组和其对应的树，依次遍历原数组中的元素，根据题目条件，将元素加入到对应数组中，并将元素离散化后的数组索引加入到树中。

最后，返回连接数组即可。

**代码**

```C++
class BinaryIndexedTree {
private:
    vector<int> tree;

public:
    BinaryIndexedTree(int n) : tree(n + 1) {}

    void add(int i) {
        while (i < tree.size()) {
            tree[i] += 1;
            i += i & -i;
        }
    }

    int get(int i) {
        int res = 0;
        while (i > 0) {
            res += tree[i];
            i &= i - 1;
        }
        return res;
    }
};

class Solution {
public:
    vector<int> resultArray(vector<int>& nums) {
        int n = nums.size();
        vector<int> sortedNums = nums;
        sort(sortedNums.begin(), sortedNums.end());
        unordered_map<int, int> index;
        for (int i = 0; i < n; ++i) {
            index[sortedNums[i]] = i + 1;
        }

        vector<int> arr1 = {nums[0]};
        vector<int> arr2 = {nums[1]};
        BinaryIndexedTree tree1(n), tree2(n);
        tree1.add(index[nums[0]]);
        tree2.add(index[nums[1]]);

        for (int i = 2; i < n; ++i) {
            int count1 = arr1.size() - tree1.get(index[nums[i]]);
            int count2 = arr2.size() - tree2.get(index[nums[i]]);
            if (count1 > count2 || (count1 == count2 && arr1.size() <= arr2.size())) {
                arr1.push_back(nums[i]);
                tree1.add(index[nums[i]]);
            } else {
                arr2.push_back(nums[i]);
                tree2.add(index[nums[i]]);
            }
        }

        arr1.insert(arr1.end(), arr2.begin(), arr2.end());
        return arr1;
    }
};
```

```C
typedef struct {
    int *tree;
    int treeSize;
} BinaryIndexedTree;

BinaryIndexedTree* createBinaryIndexedTree(int n) {
    BinaryIndexedTree *obj = (BinaryIndexedTree*)malloc(sizeof(BinaryIndexedTree));
    obj->tree = (int *)malloc(sizeof(int) * (n + 1));
    memset(obj->tree, 0, sizeof(int) * (n + 1));
    obj->treeSize = n + 1;
    return obj;
}

void add(BinaryIndexedTree* obj, int i) {
    while (i < obj->treeSize) {
        obj->tree[i] += 1;
        i += i & -i;
    }
}

int get(BinaryIndexedTree* obj, int i) {
    int res = 0;
    while (i > 0) {
        res += obj->tree[i];
        i &= i - 1;
    }
    return res;
}

static int cmp(const void *a, const void *b) {
    return *(int *)a - *(int *)b;
}

typedef struct {
    int key;
    int val;
    UT_hash_handle hh;
} HashItem; 

HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, int key, int val) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = key;
    pEntry->val = val;
    HASH_ADD_INT(*obj, key, pEntry);
    return true;
}

bool hashSetItem(HashItem **obj, int key, int val) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        hashAddItem(obj, key, val);
    } else {
        pEntry->val = val;
    }
    return true;
}

int hashGetItem(HashItem **obj, int key, int defaultVal) {
    HashItem *pEntry = hashFindItem(obj, key);
    if (!pEntry) {
        return defaultVal;
    }
    return pEntry->val;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);  
        free(curr);
    }
}

int* resultArray(int* nums, int numsSize, int* returnSize) {
    int n = numsSize;
    int sortedNums[n];
    memcpy(sortedNums, nums, sizeof(int) * numsSize);
    qsort(sortedNums, numsSize, sizeof(int), cmp);
    HashItem *index = NULL;
    for (int i = 0; i < n; ++i) {
        hashSetItem(&index, sortedNums[i], i + 1);
    }

    int arr1[n], arr2[n];
    int arr1Size = 0, arr2Size = 0;
    arr1[arr1Size++] = nums[0];
    arr2[arr2Size++] = nums[1];
    BinaryIndexedTree *tree1 = createBinaryIndexedTree(n);
    BinaryIndexedTree *tree2 = createBinaryIndexedTree(n);
    add(tree1, hashGetItem(&index, nums[0], 0));
    add(tree2, hashGetItem(&index, nums[1], 0));
    for (int i = 2; i < n; ++i) {
        int count1 = arr1Size - get(tree1, hashGetItem(&index, nums[i], 0));
        int count2 = arr2Size - get(tree2, hashGetItem(&index, nums[i], 0));
        if (count1 > count2 || (count1 == count2 && arr1Size <= arr2Size)) {
            arr1[arr1Size++] = nums[i];
            add(tree1, hashGetItem(&index, nums[i], 0));
        } else {
            arr2[arr2Size++] = nums[i];
            add(tree2, hashGetItem(&index, nums[i], 0));
        }
    }

    int *res = (int *)malloc(sizeof(int) * (arr1Size + arr2Size));
    memcpy(res, arr1, sizeof(int) * arr1Size);
    memcpy(res + arr1Size, arr2, sizeof(int) * arr2Size);
    *returnSize = arr1Size + arr2Size;
    hashFree(&index);
    return res;
}
```

```Java
class BinaryIndexedTree {
    private int[] tree;

    public BinaryIndexedTree(int n) {
        tree = new int[n + 1];
    }

    public void add(int i) {
        while (i < tree.length) {
            tree[i]++;
            i += i & -i;
        }
    }

    public int get(int i) {
        int sum = 0;
        while (i > 0) {
            sum += tree[i];
            i -= i & -i;
        }
        return sum;
    }
}

class Solution {
    public int[] resultArray(int[] nums) {
        int n = nums.length;
        int[] sortedNums = Arrays.copyOf(nums, n);
        Arrays.sort(sortedNums);

        Map<Integer, Integer> index = new HashMap<>();
        for (int i = 0; i < n; i++) {
            index.put(sortedNums[i], i + 1);
        }

        List<Integer> arr1 = new ArrayList<>(List.of(nums[0]));
        List<Integer> arr2 = new ArrayList<>(List.of(nums[1]));
        BinaryIndexedTree tree1 = new BinaryIndexedTree(n);
        BinaryIndexedTree tree2 = new BinaryIndexedTree(n);
        tree1.add(index.get(nums[0]));
        tree2.add(index.get(nums[1]));

        for (int i = 2; i < n; i++) {
            int count1 = arr1.size() - tree1.get(index.get(nums[i]));
            int count2 = arr2.size() - tree2.get(index.get(nums[i]));
            if (count1 > count2 || (count1 == count2 && arr1.size() <= arr2.size())) {
                arr1.add(nums[i]);
                tree1.add(index.get(nums[i]));
            } else {
                arr2.add(nums[i]);
                tree2.add(index.get(nums[i]));
            }
        }

        int i = 0;
        for (int a: arr1) {
            nums[i++] = a;
        }
        for (int a: arr2) {
            nums[i++] = a;
        }
        return nums;
    }
}
```

```CSharp
class BinaryIndexedTree {
    private int[] tree;

    public BinaryIndexedTree(int n) {
        tree = new int[n + 1];
    }

    public void Add(int i) {
        while (i < tree.Length) {
            tree[i]++;
            i += i & -i;
        }
    }

    public int Get(int i) {
        int sum = 0;
        while (i > 0) {
            sum += tree[i];
            i -= i & -i;
        }
        return sum;
    }
}

public class Solution {
    public int[] ResultArray(int[] nums) {
        int n = nums.Length;
        int[] sortedNums = nums.Take(n).ToArray();
        Array.Sort(sortedNums);

        IDictionary<int, int> index = new Dictionary<int, int>();
        for (int i = 0; i < n; i++) {
            index.TryAdd(sortedNums[i], i + 1);
        }

        IList<int> arr1 = new List<int>{nums[0]};
        IList<int> arr2 = new List<int>{nums[1]};
        BinaryIndexedTree tree1 = new BinaryIndexedTree(n);
        BinaryIndexedTree tree2 = new BinaryIndexedTree(n);
        tree1.Add(index[nums[0]]);
        tree2.Add(index[nums[1]]);

        for (int i = 2; i < n; i++) {
            int count1 = arr1.Count - tree1.Get(index[nums[i]]);
            int count2 = arr2.Count - tree2.Get(index[nums[i]]);
            if (count1 > count2 || (count1 == count2 && arr1.Count <= arr2.Count)) {
                arr1.Add(nums[i]);
                tree1.Add(index[nums[i]]);
            } else {
                arr2.Add(nums[i]);
                tree2.Add(index[nums[i]]);
            }
        }

        int idx = 0;
        foreach (int a in arr1) {
            nums[idx++] = a;
        }
        foreach (int a in arr2) {
            nums[idx++] = a;
        }
        return nums;
    }
}
```

```Python
class BinaryIndexedTree:
    def __init__(self, n):
        self.val = [0] * n

    def add(self, i):
        while i < len(self.val):
            self.val[i] += 1
            i += i & -i

    def get(self, i):
        res = 0
        while i > 0:
            res += self.val[i]
            i &= i - 1
        return res

class Solution:
    def resultArray(self, nums: List[int]) -> List[int]:
        n = len(nums)
        sorted_nums = sorted(nums)
        index = {}
        for i,a in enumerate(sorted_nums):
            index[a] = i + 1
        arr1 = [nums[0]]
        arr2 = [nums[1]]
        tree1 = BinaryIndexedTree(n + 1)
        tree2 = BinaryIndexedTree(n + 1)
        tree1.add(index[nums[0]])
        tree2.add(index[nums[1]])
        for i in range(2, n):
            count1 = len(arr1) - tree1.get(index[nums[i]])
            count2 = len(arr2) - tree2.get(index[nums[i]])
            if count1 > count2 or count1 == count2 and len(arr1) <= len(arr2):
                arr1.append(nums[i])
                tree1.add(index[nums[i]])
            else:
                arr2.append(nums[i])
                tree2.add(index[nums[i]])
        return arr1 + arr2
```

```JavaScript
class BinaryIndexedTree {
    constructor(n) {
        this.tree = new Array(n + 1).fill(0);
    }

    add(i) {
        while (i < this.tree.length) {
            this.tree[i]++;
            i += i & -i;
        }
    }

    get(i) {
        let sum = 0;
        while (i > 0) {
            sum += this.tree[i];
            i -= i & -i;
        }
        return sum;
    }
}

var resultArray = function(nums) {
    const n = nums.length;
    const sortedNums = [...nums].sort((a, b) => a - b);
    const index = {};
    for (let i = 0; i < n; i++) {
        index[sortedNums[i]] = i + 1;
    }

    const arr1 = [nums[0]];
    const arr2 = [nums[1]];
    const tree1 = new BinaryIndexedTree(n);
    const tree2 = new BinaryIndexedTree(n);
    tree1.add(index[nums[0]]);
    tree2.add(index[nums[1]]);

    for (let i = 2; i < n; i++) {
        const count1 = arr1.length - tree1.get(index[nums[i]]);
        const count2 = arr2.length - tree2.get(index[nums[i]]);
        if (count1 > count2 || (count1 === count2 && arr1.length <= arr2.length)) {
            arr1.push(nums[i]);
            tree1.add(index[nums[i]]);
        } else {
            arr2.push(nums[i]);
            tree2.add(index[nums[i]]);
        }
    }

    return arr1.concat(arr2);
};
```

```TypeScript
class BinaryIndexedTree {
    tree;

    constructor(n) {
        this.tree = new Array(n + 1).fill(0);
    }

    add(i) {
        while (i < this.tree.length) {
            this.tree[i]++;
            i += i & -i;
        }
    }

    get(i) {
        let sum = 0;
        while (i > 0) {
            sum += this.tree[i];
            i -= i & -i;
        }
        return sum;
    }
}

function resultArray(nums: number[]): number[] {
    const n = nums.length;
    const sortedNums = [...nums].sort((a, b) => a - b);
    const index = {};
    for (let i = 0; i < n; i++) {
        index[sortedNums[i]] = i + 1;
    }

    const arr1 = [nums[0]];
    const arr2 = [nums[1]];
    const tree1 = new BinaryIndexedTree(n);
    const tree2 = new BinaryIndexedTree(n);
    tree1.add(index[nums[0]]);
    tree2.add(index[nums[1]]);

    for (let i = 2; i < n; i++) {
        const count1 = arr1.length - tree1.get(index[nums[i]]);
        const count2 = arr2.length - tree2.get(index[nums[i]]);
        if (count1 > count2 || (count1 === count2 && arr1.length <= arr2.length)) {
            arr1.push(nums[i]);
            tree1.add(index[nums[i]]);
        } else {
            arr2.push(nums[i]);
            tree2.add(index[nums[i]]);
        }
    }

    return arr1.concat(arr2);
};
```

```Go
type BinaryIndexedTree struct {
    tree []int
}

func NewBinaryIndexedTree(n int) *BinaryIndexedTree {
    return &BinaryIndexedTree{tree: make([]int, n+1)}
}

func (bit *BinaryIndexedTree) Add(i int) {
    for i < len(bit.tree) {
        bit.tree[i]++
        i += i & -i
    }
}

func (bit *BinaryIndexedTree) Get(i int) int {
    sum := 0
    for i > 0 {
        sum += bit.tree[i]
        i -= i & -i
    }
    return sum
}

func resultArray(nums []int) []int {
    n := len(nums)
    sortedNums := make([]int, n)
    copy(sortedNums, nums)
    sort.Ints(sortedNums)
    index := make(map[int]int)
    for i, num := range sortedNums {
        index[num] = i + 1
    }

    arr1, arr2 := []int{nums[0]}, []int{nums[1]}
    tree1, tree2 := NewBinaryIndexedTree(n), NewBinaryIndexedTree(n)
    tree1.Add(index[nums[0]])
    tree2.Add(index[nums[1]])

    for i := 2; i < n; i++ {
        count1 := len(arr1) - tree1.Get(index[nums[i]])
        count2 := len(arr2) - tree2.Get(index[nums[i]])
        if count1 > count2 || (count1 == count2 && len(arr1) <= len(arr2)) {
            arr1 = append(arr1, nums[i])
            tree1.Add(index[nums[i]])
        } else {
            arr2 = append(arr2, nums[i])
            tree2.Add(index[nums[i]])
        }
    }

    return append(arr1, arr2...)
}
```

```Rust
use std::collections::HashMap;

struct BinaryIndexedTree {
    tree: Vec<i32>,
}

impl BinaryIndexedTree {
    fn new(n: usize) -> Self {
        BinaryIndexedTree {
            tree: vec![0; n + 1],
        }
    }

    fn add(&mut self, mut i: usize) {
        while i < self.tree.len() {
            self.tree[i] += 1;
            i += i & (!i + 1);
        }
    }

    fn get(&self, mut i: usize) -> i32 {
        let mut sum = 0;
        while i > 0 {
            sum += self.tree[i];
            i -= i & (!i + 1);
        }
        sum
    }
}

impl Solution {
    pub fn result_array(nums: Vec<i32>) -> Vec<i32> {
        let n = nums.len();
        let mut sorted_nums = nums.clone();
        sorted_nums.sort();
        let mut index = HashMap::new();
        for i in 0..n {
            index.insert(sorted_nums[i], i + 1);
        }

        let mut arr1 = vec![nums[0]];
        let mut arr2 = vec![nums[1]];
        let mut tree1 = BinaryIndexedTree::new(n);
        let mut tree2 = BinaryIndexedTree::new(n);
        tree1.add(index[&nums[0]]);
        tree2.add(index[&nums[1]]);

        for i in 2..n {
            let count1 = arr1.len() as i32 - tree1.get(index[&nums[i]]);
            let count2 = arr2.len() as i32 - tree2.get(index[&nums[i]]);
            if count1 > count2 || (count1 == count2 && arr1.len() <= arr2.len()) {
                arr1.push(nums[i]);
                tree1.add(index[&nums[i]]);
            } else {
                arr2.push(nums[i]);
                tree2.add(index[&nums[i]]);
            }
        }

        arr1.extend(arr2);
        arr1
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n)$，其中 $n$ 表示 $nums$ 数组的长度。
- 空间复杂度：$O(n)$。
