### [输入单词需要的最少按键次数 I](https://leetcode.cn/problems/minimum-number-of-pushes-to-type-word-i/solutions/4000040/shu-ru-dan-ci-xu-yao-de-zui-shao-an-jian-eygr/)

#### 方法一：贪心

**思路与算法**

我们有 $8$ 个按键，每个按键上第 $k$ 个字母需要按 $k$ 次。为了使总按键次数最少，应当优先使用按 $1$ 次的位置，用完后再使用按 $2$ 次的位置，以此类推。

因此，将字符串 $word$ 的 $n$ 个字母按 $0$ 到 $n-1$ 编号，第 $i$ 个字母的按键次数为 $\lfloor\dfrac{i}{8}\rfloor +1$，累加即为答案。

**代码**

```C++
class Solution {
public:
    int minimumPushes(string word) {
        int n = word.size();
        int ans = 0;
        for (int i = 0; i < n; ++i) {
            ans += i / 8 + 1;
        }
        return ans;
    }
};
```

```Python
class Solution:
    def minimumPushes(self, word: str) -> int:
        return sum(i // 8 + 1 for i in range(len(word)))
```

```Java
class Solution {
    public int minimumPushes(String word) {
        int n = word.length();
        int ans = 0;
        for (int i = 0; i < n; i++) {
            ans += i / 8 + 1;
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int MinimumPushes(string word) {
        int n = word.Length;
        int ans = 0;
        for (int i = 0; i < n; i++) {
            ans += i / 8 + 1;
        }
        return ans;
    }
}
```

```C
int minimumPushes(char* word) {
    int n = strlen(word);
    int ans = 0;
    for (int i = 0; i < n; i++) {
        ans += i / 8 + 1;
    }
    return ans;
}
```

```Go
func minimumPushes(word string) int {
    n := len(word)
    ans := 0
    for i := 0; i < n; i++ {
        ans += i / 8 + 1
    }
    return ans
}
```

```JavaScript
var minimumPushes = function(word) {
    const n = word.length;
    let ans = 0;
    for (let i = 0; i < n; i++) {
        ans += Math.floor(i / 8) + 1;
    }
    return ans;
};
```

```TypeScript
function minimumPushes(word: string): number {
    const n = word.length;
    let ans = 0;
    for (let i = 0; i < n; i++) {
        ans += Math.floor(i / 8) + 1;
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn minimum_pushes(word: String) -> i32 {
        let n = word.len();
        let mut ans = 0;

        for i in 0..n {
            ans += (i / 8 + 1) as i32;
        }

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是字符串 $word$ 的长度。
- 空间复杂度：$O(1)$。

#### 方法二：数学

**思路与算法**

贪心策略与方法一相同。我们可以用公式直接计算总按键次数，而无需逐个累加。

记字符串 $word$ 的长度为 $n$，$m=\lfloor\dfrac{n-1}{8}\rfloor +1$ 为按键次数的最大值。由方法一可知，按键次数小于 $m$ 的字母有 $m-1$ 组，每组 $8$ 个，总计贡献 $8\cdot\dfrac{m(m-1)}{2}=4m(m-1)$ 次按键。按键次数等于 $m$ 的字母有 $n-8(m-1)$ 个，贡献 $(n-8(m-1))\cdot m$ 次按键。因此总按键次数为：

$$4m(m-1)+(n-8(m-1))\cdot m$$

**代码**

```C++
class Solution {
public:
    int minimumPushes(string word) {
        int n = word.size();
        int m = (n - 1) / 8 + 1;
        return m * (m - 1) * 4 + (n - (m - 1) * 8) * m;
    }
};
```

```Python
class Solution:
    def minimumPushes(self, word: str) -> int:
        n = len(word)
        m = (n - 1) // 8 + 1
        return m * (m - 1) * 4 + (n - (m - 1) * 8) * m
```

```Java
class Solution {
    public int minimumPushes(String word) {
        int n = word.length();
        int m = (n - 1) / 8 + 1;
        return m * (m - 1) * 4 + (n - (m - 1) * 8) * m;
    }
}
```

```CSharp
public class Solution {
    public int MinimumPushes(string word) {
        int n = word.Length;
        int m = (n - 1) / 8 + 1;
        return m * (m - 1) * 4 + (n - (m - 1) * 8) * m;
    }
}
```

```C
int minimumPushes(char* word) {
    int n = strlen(word);
    int m = (n - 1) / 8 + 1;
    return m * (m - 1) * 4 + (n - (m - 1) * 8) * m;
}
```

```Go
func minimumPushes(word string) int {
    n := len(word)
    m := (n - 1) / 8 + 1
    return m * (m - 1) * 4 + (n - (m - 1) * 8) * m
}
```

```JavaScript
var minimumPushes = function(word) {
    const n = word.length;
    const m = Math.floor(n / 8) + 1;
    return m * (m - 1) * 4 + (n - (m - 1) * 8) * m;
};
```

```TypeScript
function minimumPushes(word: string): number {
    const n = word.length;
    const m = Math.floor(n / 8) + 1;
    return m * (m - 1) * 4 + (n - (m - 1) * 8) * m;
}
```

```Rust
impl Solution {
    pub fn minimum_pushes(word: String) -> i32 {
        let n = word.len() as i32;
        let m = n / 8 + 1;
        m * (m - 1) * 4 + (n - (m - 1) * 8) * m
    }
}
```

**复杂度分析**

- 时间复杂度：$O(1)$。
- 空间复杂度：$O(1)$。
