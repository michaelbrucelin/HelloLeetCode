### [咒语和药水的成功对数](https://leetcode.cn/problems/successful-pairs-of-spells-and-potions/solutions/2477429/zhou-yu-he-yao-shui-de-cheng-gong-dui-sh-a22z/)

#### 方法一：二分查找

**思路与算法**

对于某一个咒语的能量，我们可以采用二分查找的方法来高效地找到符合条件的药水数量。首先，我们将 $potions$ 数组进行排序，以便能够利用有序性进行二分查找。然后，对于每个咒语 $spells[i]$，$0 \le i < n$，其中 $n$ 为数组 $spells$ 的长度，我们计算出目标值

$$target = \lceil \frac{success}{spells[i]} \rceil$$

其中 $\lceil x \rceil$ 表示不小于 $x$ 的最小整数。$target$ 代表了在当前咒语强度下，药水需要达到的最低强度。接下来，我们使用「二分查找」来在数组 $potions$ 中找到第一个大于等于 $target$ 的元素的索引 $idx$，进一步可以得到此时表示成功组合的药水数量为 $m - idx$，其中 $m$ 表示数组 $potions$ 的长度。

**代码**

```c++
class Solution {
public:
    vector<int> successfulPairs(vector<int>& spells, vector<int>& potions, long long success) {
        sort(potions.begin(), potions.end());
        vector<int> res;
        for (auto& i : spells) {
            long long t = (success + i - 1) / i - 1;
            res.push_back(potions.size() - (upper_bound(potions.begin(), potions.end(), t) - potions.begin()));
        }
        return res;
    }
};
```

```java
class Solution {
    public int[] successfulPairs(int[] spells, int[] potions, long success) {
        Arrays.sort(potions);
        int n = spells.length, m = potions.length;
        int[] res = new int[n];
        for (int i = 0; i < n; i++) {
            long t = (success + spells[i] - 1) / spells[i] - 1;
            res[i] = m - binarySearch(potions, 0, m - 1, t);
        }
        return res;
    }

    public int binarySearch(int[] arr, int lo, int hi, long target) {
        int res = hi + 1;
        while (lo <= hi) {
            int mid = lo + (hi - lo) / 2;
            if (arr[mid] > target) {
                res = mid;
                hi = mid - 1;
            } else {
                lo = mid + 1;
            }
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success) {
        Array.Sort(potions);
        int n = spells.Length, m = potions.Length;
        int[] res = new int[n];
        for (int i = 0; i < n; i++) {
            long t = (success + spells[i] - 1) / spells[i] - 1;
            res[i] = m - BinarySearch(potions, 0, m - 1, t);
        }
        return res;
    }

    public int BinarySearch(int[] arr, int lo, int hi, long target) {
        int res = hi + 1;
        while (lo <= hi) {
            int mid = lo + (hi - lo) / 2;
            if (arr[mid] > target) {
                res = mid;
                hi = mid - 1;
            } else {
                lo = mid + 1;
            }
        }
        return res;
    }
}
```

```c
static int cmp(const void *a, const void *b) {
    return *(int *)a - *(int *)b;
}

int binarySearch(const int *arr, int lo, int hi, long long target) {
    int res = hi + 1;
    while (lo <= hi) {
        int mid = lo + (hi - lo) / 2;
        if (arr[mid] > target) {
            res = mid;
            hi = mid - 1;
        } else {
            lo = mid + 1;
        }
    }
    return res;
}

int* successfulPairs(int* spells, int spellsSize, int* potions, int potionsSize, long long success, int* returnSize) {
    qsort(potions, potionsSize, sizeof(int), cmp);
    int *res = (int *)calloc(spellsSize, sizeof(int));
    for (int i = 0; i < spellsSize; i++) {
        long long t = (success - 1) / spells[i];
        res[i] = potionsSize - binarySearch(potions, 0, potionsSize - 1, t);
    }
    *returnSize = spellsSize;
    return res;
}
```

```python
class Solution:
    def successfulPairs(self, spells: List[int], potions: List[int], success: int) -> List[int]:
        potions.sort()
        return [len(potions) - bisect.bisect_right(potions, (success - 1) // i) for i in spells]
```

```go
func successfulPairs(spells []int, potions []int, success int64) []int {
    sort.Ints(potions)
    res := make([]int, len(spells))
    for i, x := range spells {
        res[i] = len(potions) - sort.SearchInts(potions, (int(success) - 1) / x + 1)
    }
    return res
}
```

```javascript
var successfulPairs = function(spells, potions, success) {
    function binarySearch(nums, lo, hi, target) {
        let res = hi + 1;
        while (lo <= hi) {
            const mid = lo + Math.floor((hi - lo) / 2);
            if (nums[mid] > target) {
                res = mid;
                hi = mid - 1;
            } else {
                lo = mid + 1;
            }
        }
        return res;
    }

    potions.sort((a, b) => a - b);
    return spells.map((item) => {
        return potions.length - binarySearch(potions, 0, potions.length - 1, (success - 1) / item)
    })
};
```

**复杂度分析**

- 时间复杂度：$O(m \times \log m + n \times \log m)$，其中 $n$ 为数组 $spells$ 的长度，$m$ 是数组 $postion$ 的长度，主要为对数组 $potions$ 排序和对数组 $spells$ 中每一个元素对数组 $potions$ 进行「二分查找」的时间开销。
- 空间复杂度：$O(\log m)$，主要为对 $potions$ 排序的空间开销，其中返回的答案不计入空间复杂度。

#### 方法二：双指针

**思路与算法**

同样我们也可以通过「双指针」来解决这个问题：

首先我们对数组 $spells$ 下标按照其位置上的能量强度进行 **升序排序**，假设其排序后的数组为 $idx$，对数组 $potions$ 按照能量强度进行 **降序排序**。并初始化一个结果数组 $res$，长度为 $n$，$n$ 为数组 $spells$ 的长度，用于记录每个咒语成功组合的药水数目。

我们使用两个指针 $i$ 和 $j$ 分别指向数组 $idx$ 和 $potions$ 的起始位置，用指针 $i$ 遍历数组 $idx$，对于当前 $i$ 指向的咒语 $spells[idx[i]]$，若有

$$spells[idx[i]] \times potions[j] \ge sucess \tag{1}$$

成立，则对于任意 $i < k < n$，都有

$$spells[idx[k]] \times potions[j] \ge sucess \tag{2}$$

成立。对于每一个 $i$，指针 $j$ 不断右移直至 $j$ 不满足条件 $(1)$（其中右移前需要满足 $j < m$ 成立，$m$ 为 $potions$ 的长度）。对于指针 $i$，指针 $j$ 移动操作结束后，那么此时能成功组合的药水数量 $res[idx[i]] = j$。并且由于随着指针 $i$ 位置不断增大，指针 $j$ 的位置单调不减，所以指针 $i$ 不断右移的整个过程时间复杂度为 $O(n)$。

**代码**

```c++
class Solution {
public:
    vector<int> successfulPairs(vector<int>& spells, vector<int>& potions, long long success) {
        vector<int> res(spells.size());
        vector<int> idx(spells.size());
        iota(idx.begin(), idx.end(), 0);
        sort(idx.begin(), idx.end(), [&](int a, int b) {
            return spells[a] < spells[b];
        });
        sort(potions.begin(), potions.end(), [](int a, int b) {
            return a > b;
        });
        for (int i = 0, j = 0; i < spells.size(); ++i) {
            int p = idx[i];
            int v = spells[p];
            while (j < potions.size() && (long long) potions[j] * v >= success) {
                ++j;
            }
            res[p] = j;
        }
        return res;
    }
};
```

```java
class Solution {
    public int[] successfulPairs(int[] spells, int[] potions, long success) {
        int n = spells.length, m = potions.length;
        int[] res = new int[n];
        int[][] idx = new int[n][2];
        for (int i = 0; i < n; ++i) {
            idx[i][0] = spells[i];
            idx[i][1] = i;
        }
        Arrays.sort(potions);
        for (int i = 0, j = m - 1; i < j; ++i, --j) {
            int temp = potions[i];
            potions[i] = potions[j];
            potions[j] = temp;
        }
        Arrays.sort(idx, (a, b) -> a[0] - b[0]);
        for (int i = 0, j = 0; i < n; ++i) {
            int p = idx[i][1];
            int v = idx[i][0];
            while (j < m && (long) potions[j] * v >= success) {
                ++j;
            }
            res[p] = j;
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public int[] SuccessfulPairs(int[] spells, int[] potions, long success) {
        int n = spells.Length, m = potions.Length;
        int[] res = new int[n];
        int[][] idx = new int[n][];
        for (int i = 0; i < n; ++i) {
            idx[i] = new int[2];
            idx[i][0] = spells[i];
            idx[i][1] = i;
        }
        Array.Sort(potions);
        for (int i = 0, j = m - 1; i < j; ++i, --j) {
            int temp = potions[i];
            potions[i] = potions[j];
            potions[j] = temp;
        }
        Array.Sort(idx, (a, b) => a[0] - b[0]);
        for (int i = 0, j = 0; i < n; ++i) {
            int p = idx[i][1];
            int v = idx[i][0];
            while (j < m && (long) potions[j] * v >= success) {
                ++j;
            }
            res[p] = j;
        }
        return res;
    }
}
```

```c
static int cmp1(const void *a, const void *b) {
    return *(int *)b - *(int *)a;
}

static int cmp2(const void *a, const void *b) {
    return ((int *)a)[0] - ((int *)b)[0];
}

int* successfulPairs(int* spells, int spellsSize, int* potions, int potionsSize, long long success, int* returnSize) {
    int *res = (int *)calloc(spellsSize, sizeof(int));
    int idx[spellsSize][2];
    for (int i = 0; i < spellsSize; i++) {
        idx[i][0] = spells[i];
        idx[i][1] = i;
    }

    qsort(potions, potionsSize, sizeof(int), cmp1);
    qsort(idx, spellsSize, sizeof(idx[0]), cmp2);
    for (int i = 0, j = 0; i < spellsSize; ++i) {
        int p = idx[i][1];
        int v = idx[i][0];
        while (j < potionsSize && (long long) potions[j] * v >= success) {
            ++j;
        }
        res[p] = j;
    }
    *returnSize = spellsSize;
    return res;
}
```

```python
class Solution:
    def successfulPairs(self, spells: List[int], potions: List[int], success: int) -> List[int]:
        res = [0] * len(spells)
        idx = [i for i in range(len(spells))]
        idx.sort(key = lambda x: spells[x])
        potions.sort(key = lambda x : -x)
        j = 0
        for p in idx:
            v = spells[p]
            while j < len(potions) and potions[j] * v >= success:
                j += 1
            res[p] = j
        return res
```

```go
func successfulPairs(spells []int, potions []int, success int64) []int {
    res := make([]int, len(spells))
    idx := make([]int, len(spells))
    for i, _ := range idx {
        idx[i] = i
    }
    sort.Slice(potions, func(i, j int) bool {
        return potions[i] > potions[j]
    })
    sort.Slice(idx, func(i, j int) bool {
        return spells[idx[i]] < spells[idx[j]]
    })
    j := 0
    for _, p := range idx {
        v := spells[p]
        for j < len(potions) && int64(potions[j]) * int64(v) >= success {
            j++
        }
        res[p] = j
    }
    return res
}
```

```javascript
var successfulPairs = function(spells, potions, success) {
    const res = new Array(spells.length).fill(0);
    const idx = new Array(spells.length).fill(0).map((_, i) => i);
    idx.sort((a, b) => spells[a] - spells[b]);
    potions.sort((a, b) => b - a);
    let j = 0;
    for (p of idx) {
        let v = spells[p];
        while (j < potions.length && potions[j] * v >= success) {
            j++;
        }
        res[p] = j;
    }
    return res;
};
```

**复杂度分析**

- 时间复杂度：$O(n \times \log n + m \times \log m)$，其中 $n$ 为数组 $spells$ 的长度，$m$ 是数组 $postion$ 的长度，主要为对数组 $potions$ 和 $idx$ 排序的时间开销。
- 空间复杂度：$O(n + \log n + \log m)$，主要为数组 $idx$ 的空间开销和对数组 $potions$ 排序的空间开销，其中返回的答案不计入空间复杂度。
