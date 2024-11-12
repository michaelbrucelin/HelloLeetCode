### [统计满足 k 约束的子字符串数量 I](https://leetcode.cn/problems/count-substrings-that-satisfy-k-constraint-i/solutions/2976327/tong-ji-man-zu-k-yue-shu-de-zi-zi-fu-chu-4ved/)

#### 方法一：枚举

**思路与算法**

枚举所有子字符串的开始位置，从开始位置向右侧遍历，并且统计字符串内 $0$ 和 $1$ 的个数。
如果符合 $k$ 约束，就更新结果，如果不符合则跳出遍历，从下一个字符重新开始遍历。
最后可以遍历到所有符合条件的子字符串，返回它们的数量作为结果。

**代码**

```C++
class Solution {
public:
    int countKConstraintSubstrings(string s, int k) {
        int n = s.size(), res = 0;
        for (int i = 0; i < n; ++i) {
            int count[2] = {0};
            for (int j = i; j < n; ++j) {
                count[s[j] - '0']++;
                if (count[0] > k && count[1] > k) {
                    break;
                }
                res++;
            }
        }
        return res;
    }
};
```

```Java
class Solution {
    public int countKConstraintSubstrings(String s, int k) {
        int n = s.length(), res = 0;
        for (int i = 0; i < n; ++i) {
            int[] count = new int[2];
            for (int j = i; j < n; ++j) {
                count[s.charAt(j) - '0']++;
                if (count[0] > k && count[1] > k) {
                    break;
                }
                res++;
            }
        }
        return res;
    }
}
```

```Python
class Solution:
    def countKConstraintSubstrings(self, s: str, k: int) -> int:
        n = len(s)
        res = 0
        for i in range(n):
            count = [0, 0]
            for j in range(i, n):
                count[int(s[j])] += 1
                if count[0] > k and count[1] > k:
                    break
                res += 1
        return res
```

```JavaScript
var countKConstraintSubstrings = function(s, k) {
    const n = s.length;
    let res = 0;
    for (let i = 0; i < n; ++i) {
        const count = [0, 0];
        for (let j = i; j < n; ++j) {
            count[parseInt(s[j], 10)]++;
            if (count[0] > k && count[1] > k) {
                break;
            }
            res++;
        }
    }
    return res;
};
```

```TypeScript
function countKConstraintSubstrings(s: string, k: number): number {
    const n = s.length;
    let res = 0;
    for (let i = 0; i < n; ++i) {
        const count = [0, 0];
        for (let j = i; j < n; ++j) {
            count[parseInt(s[j], 10)]++;
            if (count[0] > k && count[1] > k) {
                break;
            }
            res++;
        }
    }
    return res;
};
```

```Go
func countKConstraintSubstrings(s string, k int) int {
    n := len(s)
    res := 0
    for i := 0; i < n; i++ {
        count := [2]int{}
        for j := i; j < n; j++ {
            count[int(s[j]-'0')]++
            if count[0] > k && count[1] > k {
                break
            }
            res++
        }
    }
    return res
}
```

```CSharp
public class Solution {
    public int CountKConstraintSubstrings(string s, int k) {
        int n = s.Length, res = 0;
        for (int i = 0; i < n; ++i) {
            int[] count = new int[2];
            for (int j = i; j < n; ++j) {
                count[s[j] - '0']++;
                if (count[0] > k && count[1] > k) {
                    break;
                }
                res++;
            }
        }
        return res;
    }
}
```

```C
int countKConstraintSubstrings(char* s, int k) {
    int n = strlen(s), res = 0;
    for (int i = 0; i < n; ++i) {
        int count[2] = {0};
        for (int j = i; j < n; ++j) {
            count[s[j] - '0']++;
            if (count[0] > k && count[1] > k) {
                break;
            }
            res++;
        }
    }
    return res;
}
```

```Rust
impl Solution {
    pub fn count_k_constraint_substrings(s: String, k: i32) -> i32 {
        let n = s.len();
        let s: Vec<u8> = s.bytes().collect();
        let mut res = 0;
        for i in 0..n {
            let mut count = [0, 0];
            for j in i..n {
                count[s[j] as usize - b'0' as usize] += 1;
                if count[0] > k && count[1] > k {
                    break;
                }
                res += 1;
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n \times n)$，其中 $n$ 是数组的长度。
- 空间复杂度：$O(1)$，其中 $n$ 是数组的长度。

#### 方法二：滑动窗口 + 前缀数组

**思路与算法**

我们使用「滑动窗口」的技巧。
首先，我们枚举每一个子字符串结束位置 $j$，更新子字符串 $0$ 和 $1$ 的数量统计。如果当前子字符串不再满足 $k$ 约束，则对于当前左端点 $i$，字符串的右端点在 $j$ 开始不符合 $k$ 约束，我们记录 $right[i]=j$。然后我们向右移动左端点，重复这个过程直到子字符串满足 $k$ 约束。

此时子字符串长度为 $j-i+1$，以位置 $j$ 结束的子字符串，小于等于这个长度都满足 $k$ 约束，我们更新前缀数组，用于计算滑动窗口找到的子字符串数量的前缀和。

对于每一个查询 $[l,r]$，我们分为两部分：

1. 右端点在 $i=right[l]$ 之前的子字符串全都满足 $k$ 约束， 总共数量为 $(i-l+1) \times (i-l)/2$。
2. 右端点在 $i$ 及其之后的子字符串, 我们用前缀数组计算，数量为 $prefix[r+1]-prefix[i]$。

两部分相加即为查询结果，最后返回所有查询的结果。

**代码**

```C++
class Solution {
public:
    vector<long long> countKConstraintSubstrings(string s, int k, vector<vector<int>>& queries) {
        int n = s.size();
        vector<int> count(2, 0);
        vector<int> right(n, n);
        vector<long long> prefix(n + 1, 0);
        int i = 0;
        for (int j = 0; j < n; ++j) {
            count[s[j] - '0']++;
            while (count[0] > k && count[1] > k) {
                count[s[i] - '0']--;
                right[i] = j;
                i++;
            }
            prefix[j + 1] = prefix[j] + j - i + 1;
        }

        vector<long long> res;
        for (auto& query : queries) {
            int l = query[0], r = query[1];
            int i = min(right[l], r + 1);
            long long part1 = 1LL * (i - l + 1) * (i - l) / 2;
            long long part2 = prefix[r + 1] - prefix[i];
            res.push_back(part1 + part2);
        }
        return res;
    }
};
```

```Java
class Solution {
    public long[] countKConstraintSubstrings(String s, int k, int[][] queries) {
        int n = s.length();
        int[] count = new int[2];
        int[] right = new int[n];
        Arrays.fill(right, n);
        long[] prefix = new long[n + 1];
        for (int i = 0, j = 0; j < n; ++j) {
            count[s.charAt(j) - '0']++;
            while (count[0] > k && count[1] > k) {
                count[s.charAt(i) - '0']--;
                right[i] = j;
                i++;
            }
            prefix[j + 1] = prefix[j] + j - i + 1;
        }

        long[] res = new long[queries.length];
        for (int q = 0; q < queries.length; q++) {
            int l = queries[q][0], r = queries[q][1];
            int i = Math.min(right[l], r + 1);
            long part1 = (long) (i - l + 1) * (i - l) / 2;
            long part2 = prefix[r + 1] - prefix[i];
            res[q] = part1 + part2;
        }
        return res;
    }
}
```

```Python
class Solution:
    def countKConstraintSubstrings(self, s: str, k: int, queries: List[List[int]]) -> List[int]:
        n = len(s)
        count = [0, 0]
        prefix = [0] * (n + 1)
        right = [n] * n
        i = 0
        for j in range(n):
            count[int(s[j])] += 1
            while count[0] > k and count[1] > k:
                count[int(s[i])] -= 1
                right[i] = j
                i += 1
            prefix[j + 1] = prefix[j] + j - i + 1

        res = []
        for l, r in queries:
            i = min(right[l], r + 1)
            part1 = (i - l + 1) * (i - l) // 2
            part2 = prefix[r + 1] - prefix[i]
            res.append(part1 + part2)
        return res
```

```JavaScript
var countKConstraintSubstrings = function(s, k, queries) {
    const n = s.length;
    const count = [0, 0];
    const right = Array(n).fill(n);
    const prefix = Array(n + 1).fill(0);
    let i = 0;
    for (let j = 0; j < n; ++j) {
        count[s[j] - '0']++;
        while (count[0] > k && count[1] > k) {
            count[s[i] - '0']--;
            right[i] = j;
            i++;
        }
        prefix[j + 1] = prefix[j] + j - i + 1;
    }

    const res = [];
    for (const query of queries) {
        const l = query[0], r = query[1];
        const i = Math.min(right[l], r + 1);
        const part1 = Math.floor((i - l + 1) * (i - l) / 2);
        const part2 = prefix[r + 1] - prefix[i];
        res.push(part1 + part2);
    }
    return res;
};
```

```TypeScript
function countKConstraintSubstrings(s: string, k: number, queries: number[][]): number[] {
    const n = s.length;
    const count = [0, 0];
    const right = Array(n).fill(n);
    const prefix = Array(n + 1).fill(0);
    let i = 0;
    for (let j = 0; j < n; ++j) {
        count[parseInt(s[j], 10)]++;
        while (count[0] > k && count[1] > k) {
            count[parseInt(s[i], 10)]--;
            right[i] = j;
            i++;
        }
        prefix[j + 1] = prefix[j] + j - i + 1;
    }

    const res = [];
    for (const query of queries) {
        const l = query[0], r = query[1];
        const i = Math.min(right[l], r + 1);
        const part1 = Math.floor((i - l + 1) * (i - l) / 2);
        const part2 = prefix[r + 1] - prefix[i];
        res.push(part1 + part2);
    }
    return res;
};
```

```Go
func countKConstraintSubstrings(s string, k int, queries [][]int) []int64 {
    n := len(s)
    count := [2]int{}
    right := make([]int, n)
    for i := range right {
        right[i] = n
    }
    prefix := make([]int64, n+1)
    i := 0
    for j := 0; j < n; j++ {
        count[int(s[j]-'0')]++
        for count[0] > k && count[1] > k {
            count[int(s[i]-'0')]--
            right[i] = j
            i++
        }
        prefix[j+1] = prefix[j] + int64(j-i+1)
    }

    res := make([]int64, 0, len(queries))
    for _, query := range queries {
        l, r := query[0], query[1]
        i := min(right[l], r+1)
        part1 := int64(i-l+1) * int64(i-l) / 2
        part2 := prefix[r+1] - prefix[i]
        res = append(res, part1+part2)
    }
    return res
}

func min(a, b int) int {
    if a < b {
        return a
    }
    return b
}
```

```CSharp
public class Solution {
    public long[] CountKConstraintSubstrings(string s, int k, int[][] queries) {
        int n = s.Length;
        int[] count = new int[2];
        int[] right = new int[n];
        Array.Fill(right, n);
        long[] prefix = new long[n + 1];
        for (int i = 0, j = 0; j < n; ++j) {
            count[s[j] - '0']++;
            while (count[0] > k && count[1] > k) {
                count[s[i] - '0']--;
                right[i] = j;
                i++;
            }
            prefix[j + 1] = prefix[j] + j - i + 1;
        }

        long[] res = new long[queries.Length];
        for (int q = 0; q < queries.Length; q++) {
            int l = queries[q][0], r = queries[q][1];
            int i = Math.Min(right[l], r + 1);
            long part1 = (long)(i - l + 1) * (i - l) / 2;
            long part2 = prefix[r + 1] - prefix[i];
            res[q] = part1 + part2;
        }
        return res;
    }
}
```

```C
long long* countKConstraintSubstrings(char* s, int k, int** queries, int queriesSize, int* queriesColSize, int* returnSize) {
    int n = strlen(s);
    int count[2] = {0};
    int *right = (int*)malloc(sizeof(int) * n);
    for (int i = 0; i < n; i++) {
        right[i] = n;
    }
    long long *prefix = (long long*)malloc(sizeof(long long) * (n + 1));
    memset(prefix, 0, sizeof(long long) * (n + 1));
    int i = 0;
    for (int j = 0; j < n; ++j) {
        count[s[j] - '0']++;
        while (count[0] > k && count[1] > k) {
            count[s[i] - '0']--;
            right[i] = j;
            i++;
        }
        prefix[j + 1] = prefix[j] + j - i + 1;
    }

    *returnSize = queriesSize;
    long long *res = (long long*)malloc(sizeof(long long) * queriesSize);
    for (int q = 0; q < queriesSize; q++) {
        int l = queries[q][0], r = queries[q][1];
        int i = (right[l] < r + 1) ? right[l] : r + 1;
        long long part1 = (long long)(i - l + 1) * (i - l) / 2;
        long long part2 = prefix[r + 1] - prefix[i];
        res[q] = part1 + part2;
    }
    free(right);
    free(prefix);
    return res;
}
```

```Rust
impl Solution {
    pub fn count_k_constraint_substrings(s: String, k: i32, queries: Vec<Vec<i32>>) -> Vec<i64> {
        let n = s.len();
        let s: Vec<u8> = s.bytes().collect(); // Convert to bytes for faster access
        let mut count = [0, 0];
        let mut right: Vec<usize> = vec![n; n];
        let mut prefix: Vec<i64> = vec![0; n + 1];
        let mut i = 0;

        for j in 0..n {
            count[s[j] as usize - b'0' as usize] += 1; // Direct byte access
            while count[0] > k && count[1] > k {
                count[s[i] as usize - b'0' as usize] -= 1;
                right[i] = j;
                i += 1;
            }
            prefix[j + 1] = prefix[j] + (j - i + 1) as i64;
        }

        let mut res: Vec<i64> = Vec::with_capacity(queries.len()); // Pre-allocate for efficiency
        for query in queries {
            let l = query[0] as usize;
            let r = query[1] as usize;
            let i = std::cmp::min(right[l], r + 1);
            let part1 = (i - l + 1) * (i - l) / 2;
            let part2 = prefix[r + 1] - prefix[i];
            res.push(part1 as i64 + part2);
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n+q)$，其中 $n$ 是数组的长度，$q$ 是查询的数量。
- 空间复杂度：$O(n)$，其中 $n$ 是数组的长度，不包含返回结果。
