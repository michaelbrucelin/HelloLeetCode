### [不同 XOR 三元组的数目 II](https://leetcode.cn/problems/number-of-unique-xor-triplets-ii/solutions/3998918/bu-tong-xor-san-yuan-zu-de-shu-mu-ii-by-blo1i/)

#### 方法一：枚举

**思路与算法**

注意到异或运算不会增加结果的二进制位数。设 $m$ 为 $nums$ 中的最大值，令 $U$ 为大于 $m$ 的最小 $2$ 的幂次，则任意两个或三个元素的异或值一定小于 $U$。我们只需要先遍历一遍数组找出 $m$，再计算出 $U$，就可以用大小为 $U$ 的数组记录可能值。

先用一个二重循环，计算任意两数异或的所有可能值（包括同一元素自身异或的情况），再将这些值分别与 $nums$ 中的每个元素异或，得到三元组的所有可能值。

具体步骤：

1. 遍历所有 $i\le j$ 的数对，计算 $nums[i]\oplus nums[j]$，将结果存入集合 $S$。
2. 遍历 $S$ 中的每个值 $x$，再遍历 $nums$ 中的每个元素 $v$，计算 $x\oplus v$，将结果存入集合 $T$。
3. 集合 $T$ 的大小即为答案。

由于值域受限，可以使用布尔数组代替哈希集合来进一步优化常数。

**代码**

```C++
class Solution {
public:
    int uniqueXorTriplets(vector<int>& nums) {
        int m = 0;
        for (int v : nums) {
            m = max(m, v);
        }
        int u = 1;
        while (u <= m) {
            u <<= 1;
        }
        vector<int> s(u);
        int n = nums.size();
        for (int i = 0; i < n; i++) {
            for (int j = i; j < n; j++) {
                s[nums[i] ^ nums[j]] = 1;
            }
        }
        vector<int> t(u);
        for (int x = 0; x < u; x++) {
            if (!s[x]) {
                continue;
            }
            for (int v : nums) {
                t[x ^ v] = 1;
            }
        }
        int ans = 0;
        for (int x = 0; x < u; x++) {
            if (t[x]) {
                ans++;
            }
        }
        return ans;
    }
};
```

```Python
class Solution:
    def uniqueXorTriplets(self, nums: List[int]) -> int:
        m = max(nums)
        u = 1
        while u <= m:
            u <<= 1
        s = [False] * u
        n = len(nums)
        for i in range(n):
            for j in range(i, n):
                s[nums[i] ^ nums[j]] = True
        t = [False] * u
        for x in range(u):
            if not s[x]:
                continue
            for v in nums:
                t[x ^ v] = True
        return sum(1 for b in t if b)
```

```Java
class Solution {
    public int uniqueXorTriplets(int[] nums) {
        int n = nums.length;
        int m = 0;
        for (int v : nums) {
            m = Math.max(m, v);
        }
        int u = 1;
        while (u <= m) {
            u <<= 1;
        }
        boolean[] s = new boolean[u];
        for (int i = 0; i < n; i++) {
            for (int j = i; j < n; j++) {
                s[nums[i] ^ nums[j]] = true;
            }
        }
        boolean[] t = new boolean[u];
        for (int x = 0; x < u; x++) {
            if (!s[x]) {
                continue;
            }
            for (int v : nums) {
                t[x ^ v] = true;
            }
        }
        int ans = 0;
        for (boolean b : t) {
            if (b) {
                ans++;
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int UniqueXorTriplets(int[] nums) {
        int n = nums.Length;
        int m = 0;
        foreach (int v in nums) {
            m = Math.Max(m, v);
        }
        int u = 1;
        while (u <= m) {
            u <<= 1;
        }
        bool[] s = new bool[u];
        for (int i = 0; i < n; i++) {
            for (int j = i; j < n; j++) {
                s[nums[i] ^ nums[j]] = true;
            }
        }
        bool[] t = new bool[u];
        for (int x = 0; x < u; x++) {
            if (!s[x]) {
                continue;
            }
            foreach (int v in nums) {
                t[x ^ v] = true;
            }
        }
        int ans = 0;
        foreach (bool b in t) {
            if (b) {
                ans++;
            }
        }
        return ans;
    }
}
```

```Go
func uniqueXorTriplets(nums []int) int {
    n := len(nums)
    m := 0
    for _, v := range nums {
        m = max(m, v)
    }
    u := 1
    for u <= m {
        u <<= 1
    }
    s := make([]bool, u)
    for i := 0; i < n; i++ {
        for j := i; j < n; j++ {
            s[nums[i]^nums[j]] = true
        }
    }
    t := make([]bool, u)
    for x := 0; x < u; x++ {
        if !s[x] {
            continue
        }
        for _, v := range nums {
            t[x^v] = true
        }
    }
    ans := 0
    for _, b := range t {
        if b {
            ans++
        }
    }
    return ans
}
```

```TypeScript
function uniqueXorTriplets(nums: number[]): number {
    const n = nums.length;
    let m = 0;
    for (const v of nums) {
        m = Math.max(m, v);
    }
    let u = 1;
    while (u <= m) {
        u <<= 1;
    }
    const s: boolean[] = new Array(u).fill(false);
    for (let i = 0; i < n; i++) {
        for (let j = i; j < n; j++) {
            s[nums[i] ^ nums[j]] = true;
        }
    }
    const t: boolean[] = new Array(u).fill(false);
    for (let x = 0; x < u; x++) {
        if (!s[x]) {
            continue;
        }
        for (const v of nums) {
            t[x ^ v] = true;
        }
    }
    let ans = 0;
    for (const b of t) {
        if (b) {
            ans++;
        }
    }
    return ans;
}
```

```JavaScript
var uniqueXorTriplets = function(nums) {
    const n = nums.length;
    let m = 0;
    for (const v of nums) {
        m = Math.max(m, v);
    }
    let u = 1;
    while (u <= m) {
        u <<= 1;
    }
    const s = new Array(u).fill(false);
    for (let i = 0; i < n; i++) {
        for (let j = i; j < n; j++) {
            s[nums[i] ^ nums[j]] = true;
        }
    }
    const t = new Array(u).fill(false);
    for (let x = 0; x < u; x++) {
        if (!s[x]) {
            continue;
        }
        for (const v of nums) {
            t[x ^ v] = true;
        }
    }
    let ans = 0;
    for (const b of t) {
        if (b) {
            ans++;
        }
    }
    return ans;
};
```

```C
int uniqueXorTriplets(int* nums, int numsSize) {
    int m = 0;
    for (int i = 0; i < numsSize; i++) {
        m = fmax(m, nums[i]);
    }
    int u = 1;
    while (u <= m) {
        u <<= 1;
    }
    bool* s = (bool*)calloc(u, sizeof(bool));
    for (int i = 0; i < numsSize; i++) {
        for (int j = i; j < numsSize; j++) {
            s[nums[i] ^ nums[j]] = true;
        }
    }
    bool* t = (bool*)calloc(u, sizeof(bool));
    for (int x = 0; x < u; x++) {
        if (!s[x]) {
            continue;
        }
        for (int k = 0; k < numsSize; k++) {
            t[x ^ nums[k]] = true;
        }
    }
    int ans = 0;
    for (int x = 0; x < u; x++) {
        if (t[x]) {
            ans++;
        }
    }
    free(s);
    free(t);
    return ans;
}
```

```Rust
impl Solution {
    pub fn unique_xor_triplets(nums: Vec<i32>) -> i32 {
        let n = nums.len();
        let max_val = nums.iter().max().copied().unwrap_or(0) as usize;
        let mut u = 1;
        while u <= max_val {
            u <<= 1;
        }
        let mut s = vec![false; u];
        for i in 0..n {
            for j in i..n {
                s[(nums[i] ^ nums[j]) as usize] = true;
            }
        }
        let mut t = vec![false; u];
        for x in 0..u {
            if !s[x] {
                continue;
            }
            for &v in &nums {
                t[x ^ v as usize] = true;
            }
        }
        t.iter().filter(|&&b| b).count() as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2+nm)$，其中 $n$ 为数组长度，$m$ 为数组的元素最大值。第一重二重循环枚举所有两数异或值，复杂度 $O(n^2)$；第二重枚举两数异或值与第三个数异或，复杂度 $O(nm)$。
- 空间复杂度：$O(m)$。需要两个大小为 $O(m)$ 的数组。

#### 方法二：枚举（优化）

**思路与算法**

可以使用动态规划的思想，分阶段地构建异或值集合。

定义：

- $one$ 表示所有单个元素能得到的异或值集合（即元素自身的值）。
- $two$ 表示所有两个元素（可重复选取）能得到的异或值集合。
- $three$ 表示所有三个元素（可重复选取）能得到的异或值集合。

第一阶段：构建 $one$ 和 $two$。遍历数组 $nums$，对于每个元素 $v$：

- 将 $v$ 加入 $one$。
- 对于 $one$ 中已有的每个值 $x$，将 $x\oplus v$ 加入 $two$。

第二阶段：构建 $three$。此时 $two$ 已经包含了所有两元素异或值。遍历 $nums$，对于每个元素 $v$ 和 $two$ 中的每个值 $x$，x\oplus $v$ 加入 $three$。

最终 $three$ 的大小即为答案。由于值域有限，可以使用数组代替集合。

**代码**

```C++
class Solution {
public:
    int uniqueXorTriplets(vector<int>& nums) {
        int m = 0;
        for (int v : nums) {
            m = max(m, v);
        }
        int u = 1;
        while (u <= m) {
            u <<= 1;
        }
        vector<int> one(u), two(u), three(u);
        for (int v : nums) {
            one[v] = 1;
            for (int x = 0; x < u; x++) {
                if (one[x]) {
                    two[x ^ v] = 1;
                }
            }
        }
        for (int v : nums) {
            for (int x = 0; x < u; x++) {
                if (two[x]) {
                    three[x ^ v] = 1;
                }
            }
        }
        int ans = 0;
        for (int x = 0; x < u; x++) {
            if (three[x]) {
                ans++;
            }
        }
        return ans;
    }
};
```

```Python
class Solution:
    def uniqueXorTriplets(self, nums: List[int]) -> int:
        m = max(nums)
        u = 1
        while u <= m:
            u <<= 1
        one = [False] * u
        two = [False] * u
        three = [False] * u
        for v in nums:
            one[v] = True
            for x in range(u):
                if one[x]:
                    two[x ^ v] = True
        for v in nums:
            for x in range(u):
                if two[x]:
                    three[x ^ v] = True
        return sum(1 for b in three if b)
```

```Java
class Solution {
    public int uniqueXorTriplets(int[] nums) {
        int m = 0;
        for (int v : nums) {
            m = Math.max(m, v);
        }
        int u = 1;
        while (u <= m) {
            u <<= 1;
        }
        boolean[] one = new boolean[u];
        boolean[] two = new boolean[u];
        boolean[] three = new boolean[u];
        for (int v : nums) {
            one[v] = true;
            for (int x = 0; x < u; x++) {
                if (one[x]) {
                    two[x ^ v] = true;
                }
            }
        }
        for (int v : nums) {
            for (int x = 0; x < u; x++) {
                if (two[x]) {
                    three[x ^ v] = true;
                }
            }
        }
        int ans = 0;
        for (boolean b : three) {
            if (b) {
                ans++;
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int UniqueXorTriplets(int[] nums) {
        int m = 0;
        foreach (int v in nums) {
            m = Math.Max(m, v);
        }
        int u = 1;
        while (u <= m) {
            u <<= 1;
        }
        bool[] one = new bool[u];
        bool[] two = new bool[u];
        bool[] three = new bool[u];
        foreach (int v in nums) {
            one[v] = true;
            for (int x = 0; x < u; x++) {
                if (one[x]) {
                    two[x ^ v] = true;
                }
            }
        }
        foreach (int v in nums) {
            for (int x = 0; x < u; x++) {
                if (two[x]) {
                    three[x ^ v] = true;
                }
            }
        }
        int ans = 0;
        foreach (bool b in three) {
            if (b) {
                ans++;
            }
        }
        return ans;
    }
}
```

```Go
func uniqueXorTriplets(nums []int) int {
    m := 0
    for _, v := range nums {
        m = max(m, v)
    }
    u := 1
    for u <= m {
        u <<= 1
    }
    one := make([]bool, u)
    two := make([]bool, u)
    three := make([]bool, u)
    for _, v := range nums {
        one[v] = true
        for x := 0; x < u; x++ {
            if one[x] {
                two[x^v] = true
            }
        }
    }
    for _, v := range nums {
        for x := 0; x < u; x++ {
            if two[x] {
                three[x^v] = true
            }
        }
    }
    ans := 0
    for _, b := range three {
        if b {
            ans++
        }
    }
    return ans
}
```

```TypeScript
function uniqueXorTriplets(nums: number[]): number {
    let m = 0;
    for (const v of nums) {
        m = Math.max(m, v);
    }
    let u = 1;
    while (u <= m) {
        u <<= 1;
    }
    const one: boolean[] = new Array(u).fill(false);
    const two: boolean[] = new Array(u).fill(false);
    const three: boolean[] = new Array(u).fill(false);
    for (const v of nums) {
        one[v] = true;
        for (let x = 0; x < u; x++) {
            if (one[x]) {
                two[x ^ v] = true;
            }
        }
    }
    for (const v of nums) {
        for (let x = 0; x < u; x++) {
            if (two[x]) {
                three[x ^ v] = true;
            }
        }
    }
    let ans = 0;
    for (const b of three) {
        if (b) {
            ans++;
        }
    }
    return ans;
}
```

```JavaScript
var uniqueXorTriplets = function(nums) {
    let m = 0;
    for (const v of nums) {
        m = Math.max(m, v);
    }
    let u = 1;
    while (u <= m) {
        u <<= 1;
    }
    const one = new Array(u).fill(false);
    const two = new Array(u).fill(false);
    const three = new Array(u).fill(false);
    for (const v of nums) {
        one[v] = true;
        for (let x = 0; x < u; x++) {
            if (one[x]) {
                two[x ^ v] = true;
            }
        }
    }
    for (const v of nums) {
        for (let x = 0; x < u; x++) {
            if (two[x]) {
                three[x ^ v] = true;
            }
        }
    }
    let ans = 0;
    for (const b of three) {
        if (b) {
            ans++;
        }
    }
    return ans;
};
```

```C
int uniqueXorTriplets(int* nums, int numsSize) {
    int m = 0;
    for (int i = 0; i < numsSize; i++) {
        m = fmax(m, nums[i]);
    }
    int u = 1;
    while (u <= m) {
        u <<= 1;
    }
    bool* one = (bool*)calloc(u, sizeof(bool));
    bool* two = (bool*)calloc(u, sizeof(bool));
    bool* three = (bool*)calloc(u, sizeof(bool));
    for (int i = 0; i < numsSize; i++) {
        int v = nums[i];
        one[v] = true;
        for (int x = 0; x < u; x++) {
            if (one[x]) {
                two[x ^ v] = true;
            }
        }
    }
    for (int i = 0; i < numsSize; i++) {
        int v = nums[i];
        for (int x = 0; x < u; x++) {
            if (two[x]) {
                three[x ^ v] = true;
            }
        }
    }
    int ans = 0;
    for (int x = 0; x < u; x++) {
        if (three[x]) {
            ans++;
        }
    }
    free(one);
    free(two);
    free(three);
    return ans;
}
```

```Rust
impl Solution {
    pub fn unique_xor_triplets(nums: Vec<i32>) -> i32 {
        let max_val = nums.iter().max().copied().unwrap_or(0) as usize;
        let mut u = 1;
        while u <= max_val {
            u <<= 1;
        }
        let mut one = vec![false; u];
        let mut two = vec![false; u];
        let mut three = vec![false; u];
        for &v in &nums {
            one[v as usize] = true;
            for x in 0..u {
                if one[x] {
                    two[x ^ v as usize] = true;
                }
            }
        }
        for &v in &nums {
            for x in 0..u {
                if two[x] {
                    three[x ^ v as usize] = true;
                }
            }
        }
        three.iter().filter(|&&b| b).count() as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nm)$，其中 $n$ 为数组长度，$m$ 为数组元素最大值。每个元素需要遍历整个值域进行状态转移。
- 空间复杂度：$O(m)$。需要三个大小为 $O(m)$ 的数组。
