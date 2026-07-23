### [不同 XOR 三元组的数目 I](https://leetcode.cn/problems/number-of-unique-xor-triplets-i/solutions/3998917/bu-tong-xor-san-yuan-zu-de-shu-mu-i-by-l-7psy/)

#### 方法一：找规律

**思路与算法**

虽然题目要求三元组的下标满足 $i\le j\le k$，但由于异或运算满足交换律 $a\oplus b=b\oplus a$，实际上我们只需要从 $nums$ 中可重复地选取三个数，计算其异或值即可。

由于 $nums$ 是 $[1,n]$ 的排列，它包含 $1$ 到 $n$ 中的所有整数。

当 $n=1$ 时，只能选三个 $1$，异或值为 $1$，答案为 $1$。

当 $n=2$ 时，只能从 ${1,2}$ 中选择。可能的异或值有 $1\oplus 1\oplus 1=1$、$1\oplus 1\oplus 2=2$、$1\oplus 2\oplus 2=1$、$2\oplus 2\oplus 2=2$，不同值为 ${1,2}$，答案为 $2$。

当 $n\ge 3$ 时，情况完全不同。设 $n$ 的最高二进制位为 $2^k$（即 $2^k\le n<2^{k+1}$）。我们可以构造出 $[0,2^{k+1}-1]$ 中的所有整数。具体来说：

- 对于 $0$，使用 $1\oplus 2\oplus 3$ 得到（$n\ge 3$ 时 $1,2,3$ 均在数组中）。
- 对于 $x\in [1,n]$，可以用 $1\oplus 1\oplus x$ 得到（$1$ 和 $x$ 都在数组中）。
- 对于 $x\in [n+1,2^{k+1}-1]$，令 $y=x\oplus 2^k$，由于 $x>n\ge 2^k$，$x$ 的二进制第 $k$ 位必为 $1$，故 $y=x-2^k<2^k\le n$，即 $y$ 在数组中。可以在 $[1,n]$ 中取两个数 $a$ 和 $b$ 使得 $a\oplus b=y$，从而三个数均在数组中，异或即得 $x$：
  - 若 $y\ne 1$，取 $a=1,b=1\oplus y $（ $1\oplus y\le y+1\le n$）。
  - 若 $y=1$，则取 $a=2,b=3$（2\oplus $3=1$）。

因此，当 $n\ge 3$ 时，所有 $[0,2^{k+1}-1]$ 范围内的非负整数都可以被构造出来，答案为 $2^{k+1}$，即大于 $n$ 的最小的 $2$ 的幂。

**代码**

```C++
class Solution {
public:
    int uniqueXorTriplets(vector<int>& nums) {
        int n = nums.size();
        if (n <= 2) {
            return n;
        }
        int ans = 1;
        while (ans <= n) {
            ans <<= 1;
        }
        return ans;
    }
};
```

```Python
class Solution:
    def uniqueXorTriplets(self, nums: List[int]) -> int:
        n = len(nums)
        if n <= 2:
            return n
        ans = 1
        while ans <= n:
            ans <<= 1
        return ans
```

```Java
class Solution {
    public int uniqueXorTriplets(int[] nums) {
        int n = nums.length;
        if (n <= 2) {
            return n;
        }
        int ans = 1;
        while (ans <= n) {
            ans <<= 1;
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int UniqueXorTriplets(int[] nums) {
        int n = nums.Length;
        if (n <= 2) {
            return n;
        }
        int ans = 1;
        while (ans <= n) {
            ans <<= 1;
        }
        return ans;
    }
}
```

```Go
func uniqueXorTriplets(nums []int) int {
    n := len(nums)
    if n <= 2 {
        return n
    }
    ans := 1
    for ans <= n {
        ans <<= 1
    }
    return ans
}
```

```TypeScript
function uniqueXorTriplets(nums: number[]): number {
    const n = nums.length;
    if (n <= 2) {
        return n;
    }
    let ans = 1;
    while (ans <= n) {
        ans <<= 1;
    }
    return ans;
}
```

```JavaScript
var uniqueXorTriplets = function(nums) {
    const n = nums.length;
    if (n <= 2) {
        return n;
    }
    let ans = 1;
    while (ans <= n) {
        ans <<= 1;
    }
    return ans;
};
```

```C
int uniqueXorTriplets(int* nums, int numsSize) {
    int n = numsSize;
    if (n <= 2) {
        return n;
    }
    int ans = 1;
    while (ans <= n) {
        ans <<= 1;
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn unique_xor_triplets(nums: Vec<i32>) -> i32 {
        let n = nums.len() as i32;
        if n <= 2 {
            return n;
        }
        let mut ans = 1;
        while ans <= n {
            ans <<= 1;
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(\log n)$。循环执行 $O(\log n)$ 次。
- 空间复杂度：$O(1)$。
