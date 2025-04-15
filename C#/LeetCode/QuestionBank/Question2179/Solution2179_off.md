### [统计数组中好三元组数目](https://leetcode.cn/problems/count-good-triplets-in-an-array/solutions/3650507/tong-ji-shu-zu-zhong-hao-san-yuan-zu-shu-u13d/)

#### 方法一：树状数组

**思路**

如果 $i,j,k$ 满足 $0 \le i < j < k < n$，且 $0 \le pos2_{nums1[i]}​ < pos2_{nums1[j]} ​< pos2_{nums1[k]} ​< n$，则 $nums1[i], nums1[j], nums1[k]$ 就构成一个好三元组。因为 $nums1$ 和 $nums2$ 都是 $0$ 到 $n-1$ 的排列，因此，我们可以通过计算符合条件的 $i,j,k$ 的三元组数，来计统计题目要求的好三元组数。

用另一个数组 $indexMapping$ 来表述上述关系，其中 $indexMapping[i]=pos2_{nums1[i]}$​，且 $indexMapping$ 也是 $0$ 到 $n-1$ 的排列。求符合条件的 $i,j,k$ 的三元组数时，我们可以首先固定 $j$，然后统计 $indexMapping$ 中，在下标 $j$ 左侧有多少小于 $indexMapping[j]$ 的数，记为 $left$，再统计下标 $j$ 右侧有多少大于 $indexMapping[j]$ 的数，记为 $right$。这样，$left \times right$ 就表示中间元素为 $j$ 的三元组数。遍历所有的 $j$ 即可算出答案。

上述计算过程可以参考[「315. 计算右侧小于当前元素的个数」](https://leetcode.cn/problems/count-of-smaller-numbers-after-self/description/)，用树状数组来求解。树状数组可以在 $O(logn)$ 的时间内完成对某个下标的增减和求前缀和。在应用树状数组时，我们要按照 $indexMapping$ 中值从小到大遍历，对当前下标 $pos$ 求前缀和即表示下标 $pos$ 左侧有多少小于 $indexMapping[pos]$ 的数，还可以通过计算得到下标 $pos$ 右侧有多少大于 $indexMapping[pos]$ 的数，然后再将当前下标的值加 $1$。因为是按照值的大小遍历，因此我们需要另一个数组 $reversedIndexMapping$ 来保存 $indexMapping$ 中各个值的下标。代码中，可以省去 $indexMapping$ 这一变量。遍历完后即可返回结果。

**代码**

```Python
class FenwickTree:
    def __init__(self, size):
        self.tree = [0] * (size + 1)  

    def update(self, index, delta):
        index += 1
        while index <= len(self.tree) - 1:
            self.tree[index] += delta
            index += index & -index  

    def query(self, index):
        index += 1
        res = 0
        while index > 0:
            res += self.tree[index]
            index -= index & -index  
        return res

class Solution:
    def goodTriplets(self, nums1: List[int], nums2: List[int]) -> int:
        n = len(nums1)
        pos2, reversedIndexMapping = [0] * n, [0] * n
        for i, num2 in enumerate(nums2):
            pos2[num2] = i
        for i, num1 in enumerate(nums1):
            reversedIndexMapping[pos2[num1]] = i
        tree = FenwickTree(n)
        res = 0
        for value in range(n):
            pos = reversedIndexMapping[value]
            left = tree.query(pos)
            tree.update(pos, 1)
            right = (n - 1 - pos) - (value - left)
            res += left * right
        return res
```

```C++
class FenwickTree {
private:
    vector<int> tree;
public:
    FenwickTree(int size) : tree(size + 1, 0) {}

    void update(int index, int delta) {
        index++;
        while (index < tree.size()) {
            tree[index] += delta;
            index += index & -index;
        }
    }

    int query(int index) {
        index++;
        int res = 0;
        while (index > 0) {
            res += tree[index];
            index -= index & -index;
        }
        return res;
    }
};

class Solution {
public:
    long long goodTriplets(vector<int>& nums1, vector<int>& nums2) {
        int n = nums1.size();
        vector<int> pos2(n), reversedIndexMapping(n);
        for (int i = 0; i < n; i++) {
            pos2[nums2[i]] = i;
        }
        for (int i = 0; i < n; i++) {
            reversedIndexMapping[pos2[nums1[i]]] = i;
        }
        FenwickTree tree(n);
        long long res = 0;
        for (int value = 0; value < n; value++) {
            int pos = reversedIndexMapping[value];
            int left = tree.query(pos);
            tree.update(pos, 1);
            int right = (n - 1 - pos) - (value - left);
            res += (long long)left * right;
        }
        return res;
    }
};
```

```Java
class FenwickTree {
    private int[] tree;

    public FenwickTree(int size) {
        tree = new int[size + 1];
    }

    public void update(int index, int delta) {
        index++;
        while (index < tree.length) {
            tree[index] += delta;
            index += index & -index;
        }
    }

    public int query(int index) {
        index++;
        int res = 0;
        while (index > 0) {
            res += tree[index];
            index -= index & -index;
        }
        return res;
    }
}

class Solution {
    public long goodTriplets(int[] nums1, int[] nums2) {
        int n = nums1.length;
        int[] pos2 = new int[n], reversedIndexMapping = new int[n];
        for (int i = 0; i < n; i++) {
            pos2[nums2[i]] = i;
        }
        for (int i = 0; i < n; i++) {
            reversedIndexMapping[pos2[nums1[i]]] = i;
        }
        FenwickTree tree = new FenwickTree(n);
        long res = 0;
        for (int value = 0; value < n; value++) {
            int pos = reversedIndexMapping[value];
            int left = tree.query(pos);
            tree.update(pos, 1);
            int right = (n - 1 - pos) - (value - left);
            res += (long) left * right;
        }
        return res;
    }
}
```

```CSharp
public class FenwickTree {
    private int[] tree;

    public FenwickTree(int size) {
        tree = new int[size + 1];
    }

    public void Update(int index, int delta) {
        index++;
        while (index < tree.Length) {
            tree[index] += delta;
            index += index & -index;
        }
    }

    public int Query(int index) {
        index++;
        int res = 0;
        while (index > 0) {
            res += tree[index];
            index -= index & -index;
        }
        return res;
    }
}

public class Solution {
    public long GoodTriplets(int[] nums1, int[] nums2) {
        int n = nums1.Length;
        int[] pos2 = new int[n], reversedIndexMapping = new int[n];
        for (int i = 0; i < n; i++) {
            pos2[nums2[i]] = i;
        }
        for (int i = 0; i < n; i++) {
            reversedIndexMapping[pos2[nums1[i]]] = i;
        }
        FenwickTree tree = new FenwickTree(n);
        long res = 0;
        for (int value = 0; value < n; value++) {
            int pos = reversedIndexMapping[value];
            int left = tree.Query(pos);
            tree.Update(pos, 1);
            int right = (n - 1 - pos) - (value - left);
            res += (long) left * right;
        }
        return res;
    }
}
```

```Go
type FenwickTree struct {
    tree []int
}

func fenwickTree(size int) *FenwickTree {
    return &FenwickTree{tree: make([]int, size+1)}
}

func (ft *FenwickTree) update(index, delta int) {
    index++
    for index < len(ft.tree) {
        ft.tree[index] += delta
        index += index & -index
    }
}

func (ft *FenwickTree) query(index int) int {
    index++
    res := 0
    for index > 0 {
        res += ft.tree[index]
        index -= index & -index
    }
    return res
}

func goodTriplets(nums1 []int, nums2 []int) int64 {
    n := len(nums1)
    pos2, reversedIndexMapping := make([]int, n), make([]int, n)
    for i, num := range nums2 {
        pos2[num] = i
    }
    
    for i, num := range nums1 {
        reversedIndexMapping[pos2[num]] = i
    }
    tree := fenwickTree(n)
    var res int64
    for value := 0; value < n; value++ {
        pos := reversedIndexMapping[value]
        left := tree.query(pos)
        tree.update(pos, 1)
        right := (n - 1 - pos) - (value - left)
        res += int64(left * right)
    }
    return res
}
```

```C
typedef struct {
    int* tree;
    int size;
} FenwickTree;

FenwickTree* fenwickTreeCreate(int size) {
    FenwickTree* obj = (FenwickTree*)malloc(sizeof(FenwickTree));
    obj->tree = (int*)calloc(size + 1, sizeof(int));
    obj->size = size;
    return obj;
}

void fenwickTreeUpdate(FenwickTree* obj, int index, int delta) {
    index++;
    while (index <= obj->size) {
        obj->tree[index] += delta;
        index += index & -index;
    }
}

int fenwickTreeQuery(FenwickTree* obj, int index) {
    index++;
    int res = 0;
    while (index > 0) {
        res += obj->tree[index];
        index -= index & -index;
    }
    return res;
}

void fenwickTreeFree(FenwickTree* obj) {
    free(obj->tree);
    free(obj);
}

long long goodTriplets(int* nums1, int nums1Size, int* nums2, int nums2Size) {
    int n = nums1Size;
    int* pos2 = (int*)malloc(n * sizeof(int)), *reversedIndexMapping = (int*)malloc(n * sizeof(int));
    for (int i = 0; i < n; i++) {
        pos2[nums2[i]] = i;
    }
    for (int i = 0; i < n; i++) {
        reversedIndexMapping[pos2[nums1[i]]] = i;
    }
    FenwickTree* tree = fenwickTreeCreate(n);
    long long res = 0;
    for (int value = 0; value < n; value++) {
        int pos = reversedIndexMapping[value];
        int left = fenwickTreeQuery(tree, pos);
        fenwickTreeUpdate(tree, pos, 1);
        int right = (n - 1 - pos) - (value - left);
        res += (long long)left * right;
    }
    free(pos2);
    free(reversedIndexMapping);
    fenwickTreeFree(tree);
    return res;
}
```

```JavaScript
class FenwickTree {
    constructor(size) {
        this.tree = new Array(size + 1).fill(0);
    }

    update(index, delta) {
        index++;
        while (index < this.tree.length) {
            this.tree[index] += delta;
            index += index & -index;
        }
    }

    query(index) {
        index++;
        let res = 0;
        while (index > 0) {
            res += this.tree[index];
            index -= index & -index;
        }
        return res;
    }
}

var goodTriplets = function(nums1, nums2) {
    const n = nums1.length;
    const pos2 = new Array(n), reversedIndexMapping = new Array(n);;
    for (let i = 0; i < n; i++) {
        pos2[nums2[i]] = i;
    }
    for (let i = 0; i < n; i++) {
        reversedIndexMapping[pos2[nums1[i]]] = i;
    }
    const tree = new FenwickTree(n);
    let res = 0;
    for (let value = 0; value < n; value++) {
        const pos = reversedIndexMapping[value];
        const left = tree.query(pos);
        tree.update(pos, 1);
        const right = (n - 1 - pos) - (value - left);
        res += left * right;
    }
    return res;
};
```

```TypeScript
class FenwickTree {
    private tree: number[];

    constructor(size: number) {
        this.tree = new Array(size + 1).fill(0);
    }

    update(index: number, delta: number): void {
        index++;
        while (index < this.tree.length) {
            this.tree[index] += delta;
            index += index & -index;
        }
    }

    query(index: number): number {
        index++;
        let res = 0;
        while (index > 0) {
            res += this.tree[index];
            index -= index & -index;
        }
        return res;
    }
}

function goodTriplets(nums1: number[], nums2: number[]): number {
    const n = nums1.length;
    const pos2 = new Array(n), reversedIndexMapping = new Array(n);;
    for (let i = 0; i < n; i++) {
        pos2[nums2[i]] = i;
    }
    for (let i = 0; i < n; i++) {
        reversedIndexMapping[pos2[nums1[i]]] = i;
    }
    const tree = new FenwickTree(n);
    let res = 0;
    for (let value = 0; value < n; value++) {
        const pos = reversedIndexMapping[value];
        const left = tree.query(pos);
        tree.update(pos, 1);
        const right = (n - 1 - pos) - (value - left);
        res += left * right;
    }
    return res;
}
```

```Rust
struct FenwickTree {
    tree: Vec<i32>,
}

impl FenwickTree {
    fn new(size: usize) -> Self {
        FenwickTree {
            tree: vec![0; size + 1],
        }
    }

    fn update(&mut self, index: usize, delta: i32) {
        let mut idx = index + 1;
        while idx < self.tree.len() {
            self.tree[idx] += delta;
            idx += idx & (!idx + 1);
        }
    }

    fn query(&self, index: usize) -> i32 {
        let mut idx = index + 1;
        let mut res = 0;
        while idx > 0 {
            res += self.tree[idx];
            idx -= idx & (!idx + 1);
        }
        res
    }
}

impl Solution {
    pub fn good_triplets(nums1: Vec<i32>, nums2: Vec<i32>) -> i64 {
        let n = nums1.len();
        let mut pos2 = vec![0; n];
        for (i, &num) in nums2.iter().enumerate() {
            pos2[num as usize] = i;
        }
        let mut reversed_index_mapping = vec![0; n];
        for (i, &num) in nums1.iter().enumerate() {
            reversed_index_mapping[pos2[num as usize]] = i;
        }
        let mut tree = FenwickTree::new(n);
        let mut res = 0i64;
        for value in 0..n {
            let pos = reversed_index_mapping[value];
            let left = tree.query(pos) as i64;
            tree.update(pos, 1);
            let right = (n - 1 - pos) as i64 - (value as i64 - left);
            res += left * right;
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n \times logn)$。
- 空间复杂度：$O(n)$。
