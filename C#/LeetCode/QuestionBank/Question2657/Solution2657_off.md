### [找到两个数组的前缀公共数组](https://leetcode.cn/problems/find-the-prefix-common-array-of-two-arrays/solutions/3965480/zhao-dao-liang-ge-shu-zu-de-qian-zhui-go-2arc/)

#### 方法一：哈希表

**思路与算法**

题目要求计算两个排列 $A$ 和 $B$ 的前缀公共数组 $C$，其中 $C[i]$ 表示在位置 $i$ 及之前同时在 $A$ 和 $B$ 中出现的数字个数。

我们用哈希表 $cnt_A$ 记录当前排列 $A$ 中已经出现的元素，哈希表 $cnt_B$ 记录当前排列 $B$ 中已经出现的元素，哈希表 $cnt$ 记录当前排列 $A$ 与 $B$ 共同出现的元素，当遍历新的下标 $i$ 时，此时我们只需要检测是否出现公共元素，此时过程如下：

- 检测哈希表 $cnt_B$ 是否包含当前元素 $A[i]$，则将 $A[i]$ 加入到哈希表 $cnt$；
- 检测哈希表 $cnt_A$ 是否包含当前元素 $B[i]$，则将 $B[i]$ 加入到哈希表 $cnt$；
- 此时哈希表 $cnt$ 中包含的元素数目即为当前公共元素的数目；

我们依次遍历每个下标并记录每个下标的公共元素数目，返回答案即可。

**代码**

```C++
class Solution {
public:
    vector<int> findThePrefixCommonArray(vector<int>& A, vector<int>& B) {
        int n = A.size();
        unordered_set<int> cntA, cntB;
        unordered_set<int> cnt;
        vector<int> ans;

        for (int i = 0; i < n; i++) {
            cntA.emplace(A[i]);
            cntB.emplace(B[i]);
            if (cntB.count(A[i])) {
                cnt.emplace(A[i]);
            }
            if (cntA.count(B[i])) {
                cnt.emplace(B[i]);
            }
            ans.emplace_back(cnt.size());
        }

        return ans;
    }
};
```

```Java
class Solution {
    public int[] findThePrefixCommonArray(int[] A, int[] B) {
        int n = A.length;
        Set<Integer> cntA = new HashSet<>();
        Set<Integer> cntB = new HashSet<>();
        Set<Integer> cnt = new HashSet<>();
        int[] ans = new int[n];

        for (int i = 0; i < n; i++) {
            cntA.add(A[i]);
            cntB.add(B[i]);
            if (cntB.contains(A[i])) {
                cnt.add(A[i]);
            }
            if (cntA.contains(B[i])) {
                cnt.add(B[i]);
            }
            ans[i] = cnt.size();
        }

        return ans;
    }
}
```

```CSharp
public class Solution {
    public int[] FindThePrefixCommonArray(int[] A, int[] B) {
        int n = A.Length;
        HashSet<int> cntA = new HashSet<int>();
        HashSet<int> cntB = new HashSet<int>();
        HashSet<int> cnt = new HashSet<int>();
        int[] ans = new int[n];

        for (int i = 0; i < n; i++) {
            cntA.Add(A[i]);
            cntB.Add(B[i]);
            if (cntB.Contains(A[i])) {
                cnt.Add(A[i]);
            }
            if (cntA.Contains(B[i])) {
                cnt.Add(B[i]);
            }
            ans[i] = cnt.Count;
        }

        return ans;
    }
}
```

```Go
func findThePrefixCommonArray(A []int, B []int) []int {
    n := len(A)
    cntA := make(map[int]bool)
    cntB := make(map[int]bool)
    cnt := make(map[int]bool)
    ans := make([]int, n)

    for i := 0; i < n; i++ {
        cntA[A[i]] = true
        cntB[B[i]] = true
        if cntB[A[i]] {
            cnt[A[i]] = true
        }
        if cntA[B[i]] {
            cnt[B[i]] = true
        }
        ans[i] = len(cnt)
    }

    return ans
}
```

```Python
class Solution:
    def findThePrefixCommonArray(self, A: List[int], B: List[int]) -> List[int]:
        n = len(A)
        cntA = set()
        cntB = set()
        cnt = set()
        ans = []

        for i in range(n):
            cntA.add(A[i])
            cntB.add(B[i])
            if B[i] in cntA:
                cnt.add(B[i])
            if A[i] in cntB:
                cnt.add(A[i])
            ans.append(len(cnt))

        return ans
```

```C
typedef struct {
    int key;
    UT_hash_handle hh;
} HashItem;

HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, int key) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = key;
    HASH_ADD_INT(*obj, key, pEntry);
    return true;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);
        free(curr);
    }
}

int* findThePrefixCommonArray(int* A, int ASize, int* B, int BSize, int* returnSize) {
    *returnSize = ASize;
    int* ans = (int*)malloc(ASize * sizeof(int));

    HashItem *cntA = NULL;
    HashItem *cntB = NULL;
    HashItem *cnt = NULL;

    for (int i = 0; i < ASize; i++) {
        hashAddItem(&cntA, A[i]);
        hashAddItem(&cntB, B[i]);
        if (hashFindItem(&cntB, A[i])) {
            hashAddItem(&cnt, A[i]);
        }
        if (hashFindItem(&cntA, B[i])) {
            hashAddItem(&cnt, B[i]);
        }
        ans[i] = HASH_COUNT(cnt);
    }

    hashFree(&cntA);
    hashFree(&cntB);
    hashFree(&cnt);

    return ans;
}
```

```JavaScript
var findThePrefixCommonArray = function(A, B) {
    const n = A.length;
    const cntA = new Set();
    const cntB = new Set();
    const cnt = new Set();
    const ans = [];

    for (let i = 0; i < n; i++) {
        cntA.add(A[i]);
        cntB.add(B[i]);

        if (cntB.has(A[i])) {
            cnt.add(A[i]);
        }
        if (cntA.has(B[i])) {
            cnt.add(B[i]);
        }

        ans.push(cnt.size);
    }

    return ans;
};
```

```TypeScript
function findThePrefixCommonArray(A: number[], B: number[]): number[] {
    const n: number = A.length;
    const cntA: Set<number> = new Set();
    const cntB: Set<number> = new Set();
    const cnt: Set<number> = new Set();
    const ans: number[] = [];

    for (let i = 0; i < n; i++) {
        cntA.add(A[i]);
        cntB.add(B[i]);

        if (cntB.has(A[i])) {
            cnt.add(A[i]);
        }
        if (cntA.has(B[i])) {
            cnt.add(B[i]);
        }

        ans.push(cnt.size);
    }

    return ans;
}
```

```Rust
use std::collections::HashSet;

impl Solution {
    pub fn find_the_prefix_common_array(A: Vec<i32>, B: Vec<i32>) -> Vec<i32> {
        let n = A.len();
        let mut cntA = HashSet::new();
        let mut cntB = HashSet::new();
        let mut cnt = HashSet::new();
        let mut ans = Vec::with_capacity(n);

        for i in 0..n {
            cntA.insert(A[i]);
            cntB.insert(B[i]);

            if cntB.contains(&A[i]) {
                cnt.insert(A[i]);
            }
            if cntA.contains(&B[i]) {
                cnt.insert(B[i]);
            }

            ans.push(cnt.len() as i32);
        }

        ans
    }
}
```

**复杂度分析**

- **时间复杂度**：$O(n)$，其中 $n$ 是数组 $A$ 的长度。只需遍历一次数组即可，因此时间复杂度为 $O(n)$。
- **空间复杂度**：$O(n)$，其中 $n$ 是数组 $A$ 的长度。哈希表保持当前出现的元素和共同出现的元素，哈希表中最多存储 $n$ 个元素。

#### 方法二：位运算

**思路与算法**

我们观察到题目给定的数组元素范围为：$1\le A[i],B[i]\le n$，且 $n$ 的范围为 $1\le n\le 50$，此时我们可以将一个集合压缩成一个数的二进制，第 $i$ 为 $1$ 表示存在数字 $i$，两个数的**按位与**就代表集合的交集，交集的大小就是二进制中 $1$ 的个数。

**代码**

```C++
class Solution {
public:
    vector<int> findThePrefixCommonArray(vector<int>& A, vector<int>& B) {
        uint64_t p = 0, q = 0;
        for (int i = 0; i < A.size(); i++) {
            p |= 1ULL << A[i];
            q |= 1ULL << B[i];
            A[i] = popcount(p & q);
        }
        return A;
    }
};
```

```Java
class Solution {
    public int[] findThePrefixCommonArray(int[] A, int[] B) {
        long p = 0, q = 0;
        for (int i = 0; i < A.length; i++) {
            p |= 1L << A[i];
            q |= 1L << B[i];
            A[i] = Long.bitCount(p & q);
        }
        return A;
    }
}
```

```CSharp
public class Solution {
    public int[] FindThePrefixCommonArray(int[] A, int[] B) {
        long p = 0, q = 0;
        for (int i = 0; i < A.Length; i++) {
            p |= 1L << A[i];
            q |= 1L << B[i];
            A[i] = BitOperations.PopCount((ulong)(p & q));
        }
        return A;
    }
}
```

```Go
func findThePrefixCommonArray(A []int, B []int) []int {
    var p, q uint64 = 0, 0
    for i := 0; i < len(A); i++ {
        p |= 1 << uint(A[i])
        q |= 1 << uint(B[i])
        A[i] = bits.OnesCount64(p & q)
    }
    return A
}
```

```Python
class Solution:
    def findThePrefixCommonArray(self, A: List[int], B: List[int]) -> List[int]:
        p = q = 0
        for i in range(len(A)):
            p |= 1 << A[i]
            q |= 1 << B[i]
            A[i] = (p & q).bit_count()
        return A
```

```C
int* findThePrefixCommonArray(int* A, int ASize, int* B, int BSize, int* returnSize) {
    *returnSize = ASize;
    unsigned long long p = 0, q = 0;
    for (int i = 0; i < ASize; i++) {
        p |= 1ULL << A[i];
        q |= 1ULL << B[i];
        A[i] = __builtin_popcountll(p & q);
    }

    return A;
}
```

```JavaScript
var findThePrefixCommonArray = function(A, B) {
    let p = 0n, q = 0n;
    for (let i = 0; i < A.length; i++) {
        p |= 1n << BigInt(A[i]);
        q |= 1n << BigInt(B[i]);
        A[i] = (p & q).toString(2).split('1').length - 1;
    }
    return A;
};
```

```TypeScript
function findThePrefixCommonArray(A: number[], B: number[]): number[] {
    let p: bigint = 0n, q: bigint = 0n;
    for (let i = 0; i < A.length; i++) {
        p |= 1n << BigInt(A[i]);
        q |= 1n << BigInt(B[i]);
        A[i] = bitCount(p & q);
    }
    return A;
}

function bitCount(n: bigint): number {
    return n.toString(2).split('1').length - 1;
}
```

```Rust
impl Solution {
    pub fn find_the_prefix_common_array(A: Vec<i32>, B: Vec<i32>) -> Vec<i32> {
        let mut A = A;
        let (mut p, mut q) = (0u64, 0u64);

        for i in 0..A.len() {
            p |= 1u64 << (A[i] as u64);
            q |= 1u64 << (B[i] as u64);
            A[i] = (p & q).count_ones() as i32;
        }

        A
    }
}
```

**复杂度分析**

- **时间复杂度**：$O(n)$，其中 $n$ 是数组长度。需要遍历整个数组一遍即可。
- **空间复杂度**：$O(1)$。除返回值外不需要额外的空间。
