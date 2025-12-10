### [统计计算机解锁顺序排列数](https://leetcode.cn/problems/count-the-number-of-computer-unlocking-permutations/solutions/3848629/tong-ji-ji-suan-ji-jie-suo-shun-xu-pai-l-tx3r/)

#### 方法一：脑筋急转弯

**思路与算法**

记编号为 $0$ 的计算机的密码复杂度为 $T=complexity[0]$。

如果存在编号大于 $0$，且密码复杂度小于等于 $T$ 的计算机，取其中密码复杂度最小的那一台，因为没有密码复杂度更小的计算机，因此它永远无法被解锁，答案为 $0$。

如果不存在编号大于 $0$，且密码复杂度小于等于 $T$ 的计算机，那么一开始它们就都可以被编号为 $0$ 的计算机解锁，并且能以任意顺序解锁，答案为 $(n-1)!$。

**代码**

```C++
class Solution {
public:
    int countPermutations(vector<int>& complexity) {
        int n = complexity.size();
        if (*min_element(complexity.begin() + 1, complexity.end()) <= complexity[0]) {
            return 0;
        }

        int mod = 1000000007;
        int ans = 1;
        for (int i = 2; i < n; ++i) {
            ans = static_cast<long long>(ans) * i % mod;
        }
        return ans;
    }
};
```

```Python
class Solution:
    def countPermutations(self, complexity: List[int]) -> int:
        n = len(complexity)
        for i in range(1, n):
            if complexity[i] <= complexity[0]:
                return 0
        
        ans, mod = 1, 10**9 + 7
        for i in range(2, n):
            ans = ans * i % mod
        return ans
```

```Java
class Solution {
    public int countPermutations(int[] complexity) {
        int n = complexity.length;
        for (int i = 1; i < n; i++) {
            if (complexity[i] <= complexity[0]) {
                return 0;
            }
        }
        
        int ans = 1;
        int mod = 1000000007;
        for (int i = 2; i < n; i++) {
            ans = (int)((long)ans * i % mod);
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int CountPermutations(int[] complexity) {
        int n = complexity.Length;
        for (int i = 1; i < n; i++) {
            if (complexity[i] <= complexity[0]) {
                return 0;
            }
        }
        
        int ans = 1;
        int mod = 1000000007;
        for (int i = 2; i < n; i++) {
            ans = (int)((long)ans * i % mod);
        }
        return ans;
    }
}
```

```Go
func countPermutations(complexity []int) int {
    n := len(complexity)
    for i := 1; i < n; i++ {
        if complexity[i] <= complexity[0] {
            return 0
        }
    }
    
    ans := 1
    mod := 1000000007
    for i := 2; i < n; i++ {
        ans = ans * i % mod
    }
    return ans
}
```

```C
int countPermutations(int* complexity, int complexitySize) {
    int n = complexitySize;
    for (int i = 1; i < n; i++) {
        if (complexity[i] <= complexity[0]) {
            return 0;
        }
    }
    
    long long ans = 1;
    int mod = 1000000007;
    for (int i = 2; i < n; i++) {
        ans = ans * i % mod;
    }
    return (int)ans;
}
```

```JavaScript
var countPermutations = function(complexity) {
    const n = complexity.length;
    for (let i = 1; i < n; i++) {
        if (complexity[i] <= complexity[0]) {
            return 0;
        }
    }
    
    let ans = 1;
    const mod = 1000000007;
    for (let i = 2; i < n; i++) {
        ans = (ans * i) % mod;
    }
    return ans;
};
```

```TypeScript
function countPermutations(complexity: number[]): number {
    const n = complexity.length;
    for (let i = 1; i < n; i++) {
        if (complexity[i] <= complexity[0]) {
            return 0;
        }
    }
    
    let ans = 1;
    const mod = 1000000007;
    for (let i = 2; i < n; i++) {
        ans = (ans * i) % mod;
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn count_permutations(complexity: Vec<i32>) -> i32 {
        let n = complexity.len();
        for i in 1..n {
            if complexity[i] <= complexity[0] {
                return 0;
            }
        }
        
        let mut ans: i64 = 1;
        let mod_val: i64 = 1_000_000_007;
        for i in 2..n {
            ans = (ans * i as i64) % mod_val;
        }
        ans as i32
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$。
- 空间复杂度：$O(1)$。
