### [不同三位偶数的数目](https://leetcode.cn/problems/unique-3-digit-even-numbers/solutions/4021995/bu-tong-san-wei-ou-shu-de-shu-mu-by-leet-jcq0/)

#### 方法一：枚举

**思路与算法**

枚举三个互不相同的下标 $i$、$j$ 和 $k$，依次将对应的数字作为三位数的百位、十位和个位。

一个合法的三位偶数需要满足：

- 百位不能为 $0$；
- 个位必须是偶数；
- 三个数字来自三个不同的下标。

由于数组中可能存在相同的数字，不同的下标组合可能得到同一个三位数。我们使用长度为 $1000$ 的布尔数组 $vis$ 记录每个三位数是否已经出现。每次得到一个合法且未出现过的三位数时，将其标记并令答案加一。

**代码**

```C++
class Solution {
public:
    int totalNumbers(vector<int>& digits) {
        int n = digits.size();
        bool vis[1000]{};
        int ans = 0;

        for (int i = 0; i < n; ++i) {
            if (digits[i] == 0) {
                continue;
            }
            for (int j = 0; j < n; ++j) {
                if (j == i) {
                    continue;
                }
                for (int k = 0; k < n; ++k) {
                    if (k == i || k == j || digits[k] % 2 != 0) {
                        continue;
                    }
                    int x = digits[i] * 100 + digits[j] * 10 + digits[k];
                    if (!vis[x]) {
                        vis[x] = true;
                        ++ans;
                    }
                }
            }
        }

        return ans;
    }
};
```

```Python
class Solution:
    def totalNumbers(self, digits: List[int]) -> int:
        n = len(digits)
        vis = [False] * 1000
        ans = 0

        for i in range(n):
            if digits[i] == 0:
                continue
            for j in range(n):
                if j == i:
                    continue
                for k in range(n):
                    if k == i or k == j or digits[k] % 2 != 0:
                        continue
                    x = digits[i] * 100 + digits[j] * 10 + digits[k]
                    if not vis[x]:
                        vis[x] = True
                        ans += 1

        return ans
```

```Rust
impl Solution {
    pub fn total_numbers(digits: Vec<i32>) -> i32 {
        let n = digits.len();
        let mut vis = [false; 1000];
        let mut ans = 0;

        for i in 0..n {
            if digits[i] == 0 {
                continue;
            }
            for j in 0..n {
                if j == i {
                    continue;
                }
                for k in 0..n {
                    if k == i || k == j || digits[k] % 2 != 0 {
                        continue;
                    }
                    let x = (digits[i] * 100 + digits[j] * 10 + digits[k]) as usize;
                    if !vis[x] {
                        vis[x] = true;
                        ans += 1;
                    }
                }
            }
        }

        ans
    }
}
```

```Java
class Solution {
    public int totalNumbers(int[] digits) {
        int n = digits.length;
        boolean[] vis = new boolean[1000];
        int ans = 0;

        for (int i = 0; i < n; ++i) {
            if (digits[i] == 0) {
                continue;
            }
            for (int j = 0; j < n; ++j) {
                if (j == i) {
                    continue;
                }
                for (int k = 0; k < n; ++k) {
                    if (k == i || k == j || digits[k] % 2 != 0) {
                        continue;
                    }
                    int x = digits[i] * 100 + digits[j] * 10 + digits[k];
                    if (!vis[x]) {
                        vis[x] = true;
                        ++ans;
                    }
                }
            }
        }

        return ans;
    }
}
```

```CSharp
public class Solution {
    public int TotalNumbers(int[] digits) {
        int n = digits.Length;
        bool[] vis = new bool[1000];
        int ans = 0;

        for (int i = 0; i < n; ++i) {
            if (digits[i] == 0) {
                continue;
            }
            for (int j = 0; j < n; ++j) {
                if (j == i) {
                    continue;
                }
                for (int k = 0; k < n; ++k) {
                    if (k == i || k == j || digits[k] % 2 != 0) {
                        continue;
                    }
                    int x = digits[i] * 100 + digits[j] * 10 + digits[k];
                    if (!vis[x]) {
                        vis[x] = true;
                        ++ans;
                    }
                }
            }
        }

        return ans;
    }
}
```

```Go
func totalNumbers(digits []int) int {
    n := len(digits)
    vis := make([]bool, 1000)
    ans := 0

    for i := 0; i < n; i++ {
        if digits[i] == 0 {
            continue
        }
        for j := 0; j < n; j++ {
            if j == i {
                continue
            }
            for k := 0; k < n; k++ {
                if k == i || k == j || digits[k]%2 != 0 {
                    continue
                }
                x := digits[i]*100 + digits[j]*10 + digits[k]
                if !vis[x] {
                    vis[x] = true
                    ans++
                }
            }
        }
    }

    return ans
}
```

```C
int totalNumbers(int* digits, int digitsSize) {
    int n = digitsSize;
    bool vis[1000] = {false};
    int ans = 0;

    for (int i = 0; i < n; ++i) {
        if (digits[i] == 0) {
            continue;
        }
        for (int j = 0; j < n; ++j) {
            if (j == i) {
                continue;
            }
            for (int k = 0; k < n; ++k) {
                if (k == i || k == j || digits[k] % 2 != 0) {
                    continue;
                }
                int x = digits[i] * 100 + digits[j] * 10 + digits[k];
                if (!vis[x]) {
                    vis[x] = true;
                    ++ans;
                }
            }
        }
    }

    return ans;
}
```

```JavaScript
var totalNumbers = function(digits) {
    const n = digits.length;
    const vis = new Array(1000).fill(false);
    let ans = 0;

    for (let i = 0; i < n; ++i) {
        if (digits[i] === 0) {
            continue;
        }
        for (let j = 0; j < n; ++j) {
            if (j === i) {
                continue;
            }
            for (let k = 0; k < n; ++k) {
                if (k === i || k === j || digits[k] % 2 !== 0) {
                    continue;
                }
                const x = digits[i] * 100 + digits[j] * 10 + digits[k];
                if (!vis[x]) {
                    vis[x] = true;
                    ++ans;
                }
            }
        }
    }

    return ans;
};
```

```TypeScript
function totalNumbers(digits: number[]): number {
    const n = digits.length;
    const vis: boolean[] = new Array(1000).fill(false);
    let ans: number = 0;

    for (let i = 0; i < n; ++i) {
        if (digits[i] === 0) {
            continue;
        }
        for (let j = 0; j < n; ++j) {
            if (j === i) {
                continue;
            }
            for (let k = 0; k < n; ++k) {
                if (k === i || k === j || digits[k] % 2 !== 0) {
                    continue;
                }
                const x = digits[i] * 100 + digits[j] * 10 + digits[k];
                if (!vis[x]) {
                    vis[x] = true;
                    ++ans;
                }
            }
        }
    }

    return ans;
};
```

**复杂度分析**

- 时间复杂度：$O(n^3)$，其中 $n$ 是数组 $digits$ 的长度，需要枚举三个数字的下标。
- 空间复杂度：$O(1)$。布尔数组的长度固定为 $1000$，与输入规模无关。
