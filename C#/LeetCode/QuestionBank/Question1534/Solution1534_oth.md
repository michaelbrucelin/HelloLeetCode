### [三种方法：暴力枚举 / 前缀和 / 排序+三指针（Python/Java/C++/C/Go/JS/Rust）](https://leetcode.cn/problems/count-good-triplets/solutions/3622921/liang-chong-fang-fa-bao-li-mei-ju-qian-z-apcv/)

#### 方法一：暴力枚举

把 $arr$ 简记为 $A$。

暴力枚举 $i,j,k$，如果同时满足

$$ \vert A_i-A_j \vert \le a \\ \vert A_j-A_k \vert \le b \\ \vert A_i-A_k \vert \le c$$

则把答案加一。

```Python
class Solution:
    def countGoodTriplets(self, arr: List[int], a: int, b: int, c: int) -> int:
        n = len(arr)
        ans = 0
        for i in range(n):
            for j in range(i + 1, n):
                for k in range(j + 1, n):
                    if abs(arr[i] - arr[j]) <= a and abs(arr[j] - arr[k]) <= b and abs(arr[i] - arr[k]) <= c:
                        ans += 1
        return ans
```

```Java
class Solution {
    public int countGoodTriplets(int[] arr, int a, int b, int c) {
        int n = arr.length;
        int ans = 0;
        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                for (int k = j + 1; k < n; k++) {
                    if (Math.abs(arr[i] - arr[j]) <= a && Math.abs(arr[j] - arr[k]) <= b && Math.abs(arr[i] - arr[k]) <= c) {
                        ans++;
                    }
                }
            }
        }
        return ans;
    }
}
```

```C++
class Solution {
public:
    int countGoodTriplets(vector<int>& arr, int a, int b, int c) {
        int n = arr.size(), ans = 0;
        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                for (int k = j + 1; k < n; k++) {
                    if (abs(arr[i] - arr[j]) <= a && abs(arr[j] - arr[k]) <= b && abs(arr[i] - arr[k]) <= c) {
                        ans++;
                    }
                }
            }
        }
        return ans;
    }
};
```

```C
int countGoodTriplets(int* arr, int arrSize, int a, int b, int c) {
    int ans = 0;
    for (int i = 0; i < arrSize; i++) {
        for (int j = i + 1; j < arrSize; j++) {
            for (int k = j + 1; k < arrSize; k++) {
                if (abs(arr[i] - arr[j]) <= a && abs(arr[j] - arr[k]) <= b && abs(arr[i] - arr[k]) <= c) {
                    ans++;
                }
            }
        }
    }
    return ans;
}
```

```Go
func countGoodTriplets(arr []int, a, b, c int) (ans int) {
    n := len(arr)
    for i, x := range arr {
        for j := i + 1; j < n; j++ {
            for k := j + 1; k < n; k++ {
                if abs(x-arr[j]) <= a && abs(arr[j]-arr[k]) <= b && abs(x-arr[k]) <= c {
                    ans++
                }
            }
        }
    }
    return
}

func abs(x int) int { if x < 0 { return -x }; return x }
```

```JavaScript
var countGoodTriplets = function(arr, a, b, c) {
    const n = arr.length;
    let ans = 0;
    for (let i = 0; i < n; i++) {
        for (let j = i + 1; j < n; j++) {
            for (let k = j + 1; k < n; k++) {
                if (Math.abs(arr[i] - arr[j]) <= a && Math.abs(arr[j] - arr[k]) <= b && Math.abs(arr[i] - arr[k]) <= c) {
                    ans++;
                }
            }
        }
    }
    return ans;
};
```

```Rust
impl Solution {
    pub fn count_good_triplets(arr: Vec<i32>, a: i32, b: i32, c: i32) -> i32 {
        let n = arr.len();
        let mut ans = 0;
        for i in 0..n {
            for j in i + 1..n {
                for k in j + 1..n {
                    if (arr[i] - arr[j]).abs() <= a && (arr[j] - arr[k]).abs() <= b && (arr[i] - arr[k]).abs() <= c {
                        ans += 1;
                    }
                }
            }
        }
        ans
    }
}
```

#### 复杂度分析

- 时间复杂度：$O(n^3)$，其中 $n$ 是 $arr$ 的长度。
- 空间复杂度：$O(1)$。

## 方法二：前缀和

枚举 $j$ 和 $k$，可以确定 $A_i$ 的范围。

- $\vert A_i-A_j \vert \le a$ 等价于 $A_j-a \le A_i \le A_j+a$。
- $\vert A_i-A_k \vert \le c$ 等价于 $A_k-c \le A_i \le A_k+c$。
- 此外还有 $0 \le A_i \le max(A)$。

计算这三个范围（区间）的交集，得到 $A_i$ 的范围为

$$[max(A_j-a,A_k-c,0),min(A_j+a,A_k+c,max(A))]$$

如果交集为空，则没有符合要求的 $A_i$。

如何快速计算交集中的 $A_i$ 的个数？由于交集是一段区间，这启发我们用 [前缀和](https://leetcode.cn/problems/range-sum-query-immutable/solution/qian-zhui-he-ji-qi-kuo-zhan-fu-ti-dan-py-vaar/) 维护。

维护每个 $A_i$ 的出现次数，记到 $cnt$ 数组中。比如 $0$ 出现 $3$ 次，$1$ 出现 $2$ 次，$3$ 出现 $4$ 次，那么有

$$cnt=[3,2,0,4,\cdots]$$

统计一个范围中有多少个数，等价于求 $cnt$ 的子数组的元素和。比如求 $[1,3]$ 中的元素个数，就是 $cnt[1]+cnt[2]+cnt[3]$。维护 $cnt$ 数组的前缀和 $s$，就可以 $O(1)$ 求 $cnt$ 的子数组的元素和了。

代码实现时，无需维护 $cnt$，而是直接维护 $s$：根据前缀和的递推式 $s[i+1]=s[i]+cnt[i]$，如果 $cnt[i]$ 加一了，那么下标 $\ge i+1$ 的前缀和都要加一。

```Python
class Solution:
    def countGoodTriplets(self, arr: List[int], a: int, b: int, c: int) -> int:
        ans = 0
        mx = max(arr)
        s = [0] * (mx + 2)  # cnt 数组的前缀和
        for j, y in enumerate(arr):
            for z in arr[j + 1:]:
                if abs(y - z) > b:
                    continue
                l = max(y - a, z - c, 0)
                r = min(y + a, z + c, mx)
                ans += max(s[r + 1] - s[l], 0)  # 如果 l > r + 1，s[r + 1] - s[l] 可能是负数
            for v in range(y + 1, mx + 2):
                s[v] += 1  # 把 y 加到 cnt 数组中，更新所有受到影响的前缀和
        return ans
```

```Java
class Solution {
    public int countGoodTriplets(int[] arr, int a, int b, int c) {
        int mx = 0;
        for (int x : arr) {
            mx = Math.max(mx, x);
        }
        int[] s = new int[mx + 2]; // cnt 数组的前缀和

        int ans = 0;
        for (int j = 0; j < arr.length; j++) {
            int y = arr[j];
            for (int k = j + 1; k < arr.length; k++) {
                int z = arr[k];
                if (Math.abs(y - z) > b) {
                    continue;
                }
                int l = Math.max(Math.max(y - a, z - c), 0);
                int r = Math.min(Math.min(y + a, z + c), mx);
                ans += Math.max(s[r + 1] - s[l], 0); // 如果 l > r + 1，s[r + 1] - s[l] 可能是负数
            }
            for (int v = y + 1; v < s.length; v++) {
                s[v]++; // 把 y 加到 cnt 数组中，更新所有受到影响的前缀和
            }
        }
        return ans;
    }
}
```

```C++
class Solution {
public:
    int countGoodTriplets(vector<int>& arr, int a, int b, int c) {
        int n = arr.size(), mx = ranges::max(arr), ans = 0;
        vector<int> s(mx + 2); // cnt 数组的前缀和
        for (int j = 0; j < arr.size(); j++) {
            int y = arr[j];
            for (int k = j + 1; k < arr.size(); k++) {
                int z = arr[k];
                if (abs(y - z) > b) {
                    continue;
                }
                int l = max({y - a, z - c, 0});
                int r = min({y + a, z + c, mx});
                ans += max(s[r + 1] - s[l], 0); // 如果 l > r + 1，s[r + 1] - s[l] 可能是负数
            }
            for (int v = y + 1; v < mx + 2; v++) {
                s[v]++; // 把 y 加到 cnt 数组中，更新所有受到影响的前缀和
            }
        }
        return ans;
    }
};
```

```C
#define MIN(a, b) ((b) < (a) ? (b) : (a))
#define MAX(a, b) ((b) > (a) ? (b) : (a))

int countGoodTriplets(int* arr, int arrSize, int a, int b, int c) {
    int ans = 0, mx = 0;
    for (int i = 0; i < arrSize; i++) {
        mx = MAX(mx, arr[i]);
    }
    int* s = calloc(mx + 2, sizeof(int)); // cnt 数组的前缀和
    for (int j = 0; j < arrSize; j++) {
        int y = arr[j];
        for (int k = j + 1; k < arrSize; k++) {
            int z = arr[k];
            if (abs(y - z) > b) {
                continue;
            }
            int l = MAX(MAX(y - a, z - c), 0);
            int r = MIN(MIN(y + a, z + c), mx);
            ans += MAX(s[r + 1] - s[l], 0); // 如果 l > r + 1，s[r + 1] - s[l] 可能是负数
        }
        for (int v = y + 1; v < mx + 2; v++) {
            s[v]++; // 把 y 加到 cnt 数组中，更新所有受到影响的前缀和
        }
    }
    free(s);
    return ans;
}
```

```Go
func countGoodTriplets(arr []int, a, b, c int) (ans int) {
    mx := slices.Max(arr)
    s := make([]int, mx+2) // cnt 数组的前缀和
    for j, y := range arr {
        for _, z := range arr[j+1:] {
            if abs(y-z) > b {
                continue
            }
            l := max(y-a, z-c, 0)
            r := min(y+a, z+c, mx)
            ans += max(s[r+1]-s[l], 0) // 如果 l > r + 1，s[r + 1] - s[l] 可能是负数
        }
        for v := y + 1; v < mx+2; v++ {
            s[v]++ // 把 y 加到 cnt 数组中，更新所有受到影响的前缀和
        }
    }
    return
}

func abs(x int) int { if x < 0 { return -x }; return x }
```

```JavaScript
var countGoodTriplets = function(arr, a, b, c) {
    const mx = Math.max(...arr);
    const s = Array(mx + 2).fill(0); // cnt 数组的前缀和
    let ans = 0;
    for (let j = 0; j < arr.length; j++) {
        const y = arr[j];
        for (let k = j + 1; k < arr.length; k++) {
            const z = arr[k];
            if (Math.abs(y - z) > b) {
                continue;
            }
            const l = Math.max(y - a, z - c, 0);
            const r = Math.min(y + a, z + c, mx);
            ans += Math.max(s[r + 1] - s[l], 0); // 如果 l > r + 1，s[r + 1] - s[l] 可能是负数
        }
        for (let v = y + 1; v < mx + 2; v++) {
            s[v]++; // 把 y 加到 cnt 数组中，更新所有受到影响的前缀和
        }
    }
    return ans;
};
```

```Rust
impl Solution {
    pub fn count_good_triplets(arr: Vec<i32>, a: i32, b: i32, c: i32) -> i32 {
        let mut ans = 0;
        let mx = *arr.iter().max().unwrap();
        let mut s = vec![0; (mx + 2) as usize]; // cnt 数组的前缀和
        for (j, &y) in arr.iter().enumerate() {
            for &z in &arr[j + 1..] {
                if (y - z).abs() > b {
                    continue;
                }
                let l = (y - a).max(z - c).max(0);
                let r = (y + a).min(z + c).min(mx);
                // 如果 l > r + 1，s[r + 1] - s[l] 可能是负数
                ans += 0.max(s[(r + 1) as usize] - s[l as usize]);
            }
            for v in y + 1..mx + 2 {
                s[v as usize] += 1; // 把 y 加到 cnt 数组中，更新所有受到影响的前缀和
            }
        }
        ans
    }
}
```

#### 复杂度分析

- 时间复杂度：$O(n(n+U))$，其中 $n$ 是 $arr$ 的长度，$U=max(arr)$。
- 空间复杂度：$O(U)$。$Python$ 忽略切片空间。

## 方法三：排序 + 枚举中间 + 三指针

如果 $A_i \le 10^9$，方法二会超时，怎么办？能否做到时间复杂度和 $U$ 无关？
如果 $A$ 是有序的就好了，这样有更好的性质方便我们计算。

直接排序？不行，题目要求 $i<j<k$，不能打乱顺序。

改成创建一个 $[0,n-1]$ 的下标数组 $idx$，对下标数组按照 $A_i$ 的值从小到大排序。

然后遍历 $idx$ 的元素，作为下标 $j$。（枚举中间）

- 把满足 $i<j$ 且 $\vert A_i-A_j \vert \le a$ 的 $A_i$ 保存到数组 $left$ 中。
- 把满足 $k>j$ 且 $\vert A_k-A_j \vert \le b$ 的 $A_k$ 保存到数组 $right$ 中。

由于排序了，我们得到的是两个有序数组。现在问题变成：

- 给定两个有序数组，从两个数组中各选一个数，计算绝对差 $\le c$ 的数对个数。

遍历 $left$ 中的元素 $x$，计算 $right$ 中有多少个元素 $z$ 满足 $\vert x-z \vert \le c$，也就是在 $[x-c,x+c]$ 中的 $z$ 的个数。

怎么求？类似前缀和的思想，这等价于：

- $right$ 中的 $\le x+c$ 的元素个数，减去 $right$ 中的 $< x-c$ 的元素个数。

这可以用**三指针**解决：

1. 初始化 $k_1=k_2=0$。
2. 遍历 $left$ 中的元素 $x$。
3. 如果 $right[k_2] \le x+c$，那么增大 $k_2$，直到不满足。此时 $k_2$ 就是 $right$ 中的 $\le x+c$ 的元素个数。
4. 如果 $right[k_1] < x-c$，那么增大 $k_1$，直到不满足。此时 $k_1$ 就是 $right$ 中的 $< x-c$ 的元素个数。
5. 把 $k_2-k_1$ 加入答案。

```Python
class Solution:
    def countGoodTriplets(self, arr: List[int], a: int, b: int, c: int) -> int:
        idx = sorted(range(len(arr)), key=lambda i: arr[i])

        ans = 0
        for j in idx:
            y = arr[j]
            left = [arr[i] for i in idx if i < j and abs(arr[i] - y) <= a]
            right = [arr[k] for k in idx if k > j and abs(arr[k] - y) <= b]

            k1 = k2 = 0
            for x in left:
                while k2 < len(right) and right[k2] <= x + c:
                    k2 += 1
                while k1 < len(right) and right[k1] < x - c:
                    k1 += 1
                ans += k2 - k1
        return ans
```

```Java
class Solution {
    public int countGoodTriplets(int[] arr, int a, int b, int c) {
        Integer[] idx = new Integer[arr.length];
        Arrays.setAll(idx, i -> i);
        Arrays.sort(idx, (i, j) -> arr[i] - arr[j]);

        int ans = 0;
        for (int j : idx) {
            int y = arr[j];
            List<Integer> left = new ArrayList<>();
            for (int i : idx) {
                if (i < j && Math.abs(arr[i] - y) <= a) {
                    left.add(arr[i]);
                }
            }

            List<Integer> right = new ArrayList<>();
            for (int k : idx) {
                if (k > j && Math.abs(arr[k] - y) <= b) {
                    right.add(arr[k]);
                }
            }

            int k1 = 0;
            int k2 = 0;
            for (int x : left) {
                while (k2 < right.size() && right.get(k2) <= x + c) {
                    k2++;
                }
                while (k1 < right.size() && right.get(k1) < x - c) {
                    k1++;
                }
                ans += k2 - k1;
            }
        }
        return ans;
    }
}
```

```C++
class Solution {
public:
    int countGoodTriplets(vector<int>& arr, int a, int b, int c) {
        vector<int> idx(arr.size());
        ranges::iota(idx, 0);
        ranges::sort(idx, {}, [&](int i) { return arr[i]; });

        int ans = 0;
        for (int j : idx) {
            int y = arr[j];
            vector<int> left, right;
            for (int i : idx) {
                if (i < j && abs(arr[i] - y) <= a) {
                    left.push_back(arr[i]);
                }
            }
            for (int k : idx) {
                if (k > j && abs(arr[k] - y) <= b) {
                    right.push_back(arr[k]);
                }
            }

            int k1 = 0, k2 = 0;
            for (int x : left) {
                while (k2 < right.size() && right[k2] <= x + c) {
                    k2++;
                }
                while (k1 < right.size() && right[k1] < x - c) {
                    k1++;
                }
                ans += k2 - k1;
            }
        }
        return ans;
    }
};
```

```C
int* _arr;
int cmp(const void* i, const void* j) {
    return _arr[*(int*)i] - _arr[*(int*)j];
}

int countGoodTriplets(int* arr, int arrSize, int a, int b, int c) {
    int* idx = malloc(arrSize * sizeof(int));
    for (int i = 0; i < arrSize; i++) {
        idx[i] = i;
    }

    _arr = arr;
    qsort(idx, arrSize, sizeof(int), cmp);

    int ans = 0;
    int* left = malloc(arrSize * sizeof(int));
    int* right = malloc(arrSize * sizeof(int));

    for (int p = 0; p < arrSize; p++) {
        int j = idx[p];
        int y = arr[j];

        int left_len = 0;
        for (int q = 0; q < arrSize; q++) {
            int i = idx[q];
            if (i < j && abs(arr[i] - y) <= a) {
                left[left_len++] = arr[i];
            }
        }

        int right_len = 0;
        for (int q = 0; q < arrSize; q++) {
            int k = idx[q];
            if (k > j && abs(arr[k] - y) <= b) {
                right[right_len++] = arr[k];
            }
        }

        int k1 = 0, k2 = 0;
        for (int i = 0; i < left_len; i++) {
            int x = left[i];
            while (k2 < right_len && right[k2] <= x + c) {
                k2++;
            }
            while (k1 < right_len && right[k1] < x - c) {
                k1++;
            }
            ans += k2 - k1;
        }
    }

    free(idx);
    free(left);
    free(right);

    return ans;
}
```

```Go
func countGoodTriplets(arr []int, a, b, c int) (ans int) {
    idx := make([]int, len(arr))
    for i := range idx {
        idx[i] = i
    }
    slices.SortFunc(idx, func(i, j int) int { return arr[i] - arr[j] })

    for _, j := range idx {
        y := arr[j]
        var left, right []int
        for _, i := range idx {
            if i < j && abs(arr[i]-y) <= a {
                left = append(left, arr[i])
            }
        }
        for _, k := range idx {
            if k > j && abs(arr[k]-y) <= b {
                right = append(right, arr[k])
            }
        }

        k1, k2 := 0, 0
        for _, x := range left {
            for k2 < len(right) && right[k2] <= x+c {
                k2++
            }
            for k1 < len(right) && right[k1] < x-c {
                k1++
            }
            ans += k2 - k1
        }
    }
    return
}

func abs(x int) int { if x < 0 { return -x }; return x }
```

```JavaScript
var countGoodTriplets = function(arr, a, b, c) {
    const idx = _.range(arr.length).sort((i, j) => arr[i] - arr[j]);

    let ans = 0;
    for (const j of idx) {
        const y = arr[j];
        const left = [];
        for (const i of idx) {
            if (i < j && Math.abs(arr[i] - y) <= a) {
                left.push(arr[i]);
            }
        }

        const right = [];
        for (const k of idx) {
            if (k > j && Math.abs(arr[k] - y) <= b) {
                right.push(arr[k]);
            }
        }

        let k1 = 0, k2 = 0;
        for (const x of left) {
            while (k2 < right.length && right[k2] <= x + c) {
                k2++;
            }
            while (k1 < right.length && right[k1] < x - c) {
                k1++;
            }
            ans += k2 - k1;
        }
    }
    return ans;
};
```

```Rust
impl Solution {
    pub fn count_good_triplets(arr: Vec<i32>, a: i32, b: i32, c: i32) -> i32 {
        let mut idx = (0..arr.len()).collect::<Vec<_>>();
        idx.sort_unstable_by_key(|&i| arr[i]);

        let mut ans = 0;
        for &j in &idx {
            let y = arr[j];
            let mut left = vec![];
            for &i in &idx {
                if i < j && (arr[i] - y).abs() <= a {
                    left.push(arr[i]);
                }
            }

            let mut right = vec![];
            for &k in &idx {
                if k > j && (arr[k] - y).abs() <= b {
                    right.push(arr[k]);
                }
            }

            let mut k1 = 0;
            let mut k2 = 0;
            for x in left {
                while k2 < right.len() && right[k2] <= x + c {
                    k2 += 1;
                }
                while k1 < right.len() && right[k1] < x - c {
                    k1 += 1;
                }
                ans += k2 - k1;
            }
        }
        ans as _
    }
}
```

#### 复杂度分析

- 时间复杂度：$O(n^2)$，其中 $n$ 是 $arr$ 的长度。
- 空间复杂度：$O(n)$。

#### 分类题单

[如何科学刷题？](https://leetcode.cn/circle/discuss/RvFUtj/)

1. [滑动窗口与双指针（定长/不定长/单序列/双序列/三指针/分组循环）](https://leetcode.cn/circle/discuss/0viNMK/)
2. [二分算法（二分答案/最小化最大值/最大化最小值/第K小）](https://leetcode.cn/circle/discuss/SqopEo/)
3. [单调栈（基础/矩形面积/贡献法/最小字典序）](https://leetcode.cn/circle/discuss/9oZFK9/)
4. [网格图（DFS/BFS/综合应用）](https://leetcode.cn/circle/discuss/YiXPXW/)
5. [位运算（基础/性质/拆位/试填/恒等式/思维）](https://leetcode.cn/circle/discuss/dHn9Vk/)
6. [图论算法（DFS/BFS/拓扑排序/最短路/最小生成树/二分图/基环树/欧拉路径）](https://leetcode.cn/circle/discuss/01LUak/)
7. [动态规划（入门/背包/状态机/划分/区间/状压/数位/数据结构优化/树形/博弈/概率期望）](https://leetcode.cn/circle/discuss/tXLS3i/)
8. [常用数据结构（前缀和/差分/栈/队列/堆/字典树/并查集/树状数组/线段树）](https://leetcode.cn/circle/discuss/mOr1u6/)
9. [数学算法（数论/组合/概率期望/博弈/计算几何/随机算法）](https://leetcode.cn/circle/discuss/IYT3ss/)
10. [贪心与思维（基本贪心策略/反悔/区间/字典序/数学/思维/脑筋急转弯/构造）](https://leetcode.cn/circle/discuss/g6KTKL/)
11. [链表、二叉树与回溯（前后指针/快慢指针/DFS/BFS/直径/LCA/一般树）](https://leetcode.cn/circle/discuss/K0n2gO/)
12. [字符串（KMP/Z函数/Manacher/字符串哈希/AC自动机/后缀数组/子序列自动机）](https://leetcode.cn/circle/discuss/SJFwQI/)
