### [统计将重叠区间合并成组的方案数](https://leetcode.cn/problems/count-ways-to-group-overlapping-ranges/solutions/2706464/tong-ji-jiang-zhong-die-qu-jian-he-bing-be3bs/)

#### 方法一：区间合并

##### 思路与算法

题目要求我们将一组区间分成两组，其中有交集的区间必须在同一组。因此，首先将有交集的区间合并一个集合，集合与集合之间不存在有交集的区间，因此每个集合可以选择分到第一组还是第二组。如果最终得到 $k$ 个集合，那么方案数就是 $2^k$。

区间合并的思路与「[56. 合并区间](https://leetcode.cn/problems/merge-intervals/description/)」一致，我们首先按照左端点从小到大对区间进行排序，然后对于第 $i$ 个区间，不断地向右扩展与它有交集的区间。令 $r=\textit{ranges}[i][1]$，$r$ 是当前右端点。过程中还需不断更新右端点，直到下一个区间不再与之相交为止。具体来说，$j=i+1$，当 $j \lt n$，并且 $\textit{ranges}[j][0] \le r$ 时，就继续合并第 $j$ 个区间，更新 $r=\max(r, \textit{ranges}[j][1])$，然后令 $j$ 加 $1$。当条件不满足时，$k$ 增加 $1$。

##### 代码

```c++
class Solution {
public:
    static constexpr int mod = 1e9 + 7;
    int countWays(vector<vector<int>>& ranges) {
        sort(ranges.begin(), ranges.end());
        int n = ranges.size();
        long long res = 1;
        for (int i = 0; i < n; ) {
            int r = ranges[i][1];
            int j = i + 1;
            while (j < n && ranges[j][0] <= r) {
                r = max(r, ranges[j][1]);
                j++;
            }
            res = res * 2 % mod;
            i = j;
        }
        return res;
    }
};
```

```java
class Solution {
    static final int MOD = 1000000007;

    public int countWays(int[][] ranges) {
        Arrays.sort(ranges, (a, b) -> a[0] - b[0]);
        int n = ranges.length;
        int res = 1;
        for (int i = 0; i < n; ) {
            int r = ranges[i][1];
            int j = i + 1;
            while (j < n && ranges[j][0] <= r) {
                r = Math.max(r, ranges[j][1]);
                j++;
            }
            res = res * 2 % MOD;
            i = j;
        }
        return res;
    }
}
```

```csharp
public class Solution {
    const int MOD = 1000000007;

    public int CountWays(int[][] ranges) {
        Array.Sort(ranges, (a, b) => a[0] - b[0]);
        int n = ranges.Length;
        int res = 1;
        for (int i = 0; i < n; ) {
            int r = ranges[i][1];
            int j = i + 1;
            while (j < n && ranges[j][0] <= r) {
                r = Math.Max(r, ranges[j][1]);
                j++;
            }
            res = res * 2 % MOD;
            i = j;
        }
        return res;
    }
}
```

```c
const int mod = 1e9 + 7;

int cmp(const void *a, const void *b) {
    return (*(int **)a)[0] - (*(int **)b)[0];
}

int countWays(int** ranges, int rangesSize, int* rangesColSize) {
    qsort(ranges, rangesSize, sizeof(int *), cmp);
    long long res = 1;
    for (int i = 0; i < rangesSize; ) {
        int r = ranges[i][1];
        int j = i + 1;
        while (j < rangesSize && ranges[j][0] <= r) {
            r = fmax(r, ranges[j][1]);
            j++;
        }
        res = res * 2 % mod;
        i = j;
    }
    return res;
}
```

```python
class Solution:
    def countWays(self, ranges: List[List[int]]) -> int:
        MOD = 10**9 + 7
        ranges.sort()
        n = len(ranges)
        res = 1
        i = 0
        while i < n:
            r = ranges[i][1]
            j = i + 1
            while j < n and ranges[j][0] <= r:
                r = max(r, ranges[j][1])
                j += 1
            res = (res * 2) % MOD
            i = j
        return res
```

```go
func countWays(ranges [][]int) int {
    const mod = int(1e9 + 7)
    sort.Slice(ranges, func(i, j int) bool {
        return ranges[i][0] < ranges[j][0]
    })

    n := len(ranges)
    res := int64(1)
    for i := 0; i < n; {
        r := ranges[i][1]
        j := i + 1
        for j < n && ranges[j][0] <= r {
            r = max(r, ranges[j][1])
            j++
        }
        res = (res * 2) % int64(mod)
        i = j
    }
    return int(res)
}
```

```javascript
var countWays = function(ranges) {
    const mod = 1e9 + 7;
    ranges.sort((a, b) => a[0] - b[0]);

    let n = ranges.length;
    let res = 1;
    for (let i = 0; i < n; ) {
        let r = ranges[i][1];
        let j = i + 1;
        while (j < n && ranges[j][0] <= r) {
            r = Math.max(r, ranges[j][1]);
            j++;
        }
        res = (res * 2) % mod;
        i = j;
    }
    return res;
};
```

```typescript
function countWays(ranges: number[][]): number {
    const mod: number = 1e9 + 7;
    ranges.sort((a, b) => a[0] - b[0]);

    let n = ranges.length;
    let res = 1;
    for (let i = 0; i < n; ) {
        let r = ranges[i][1];
        let j = i + 1;
        while (j < n && ranges[j][0] <= r) {
        r = Math.max(r, ranges[j][1]);
        j++;
        }
        res = (res * 2) % mod;
        i = j;
    }
    return res;
};
```

```rust
impl Solution {
    pub fn count_ways(ranges: Vec<Vec<i32>>) -> i32 {
        let mut ranges = ranges;
        const MOD: i64 = 1_000_000_007;
        ranges.sort_by(|a, b| a[0].cmp(&b[0]));

        let n = ranges.len();
        let mut res: i64 = 1;
        let mut i = 0;
        while i < n {
            let mut r = ranges[i][1];
            let mut j = i + 1;
            while j < n && ranges[j][0] <= r {
                r = r.max(ranges[j][1]);
                j += 1;
            }
            res = (res * 2) % MOD;
            i = j;
        }
        res as i32
    }
}
```

##### 复杂度分析

- 时间复杂度：$O(n\log n)$，其中 $n$ 是 $\textit{ranges}$ 的长度。排序的时间复杂度为 $O(n\log n)$，合并区间的时间复杂度为 $O(n)$。
- 空间复杂度：$O(\log n)$。排序所用的栈空间为 $O(\log n)$，其他步骤只用到若干额外变量，空间复杂度为 $O(1)$。
