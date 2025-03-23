### [判断一个括号字符串是否有效](https://leetcode.cn/problems/check-if-a-parentheses-string-can-be-valid/solutions/1179134/pan-duan-yi-ge-gua-hao-zi-fu-chuan-shi-f-0s47/)

#### 方法一：数学

**思路与算法**

我们可以如下定义并计算一个括号字符串的「分数」：

> 考虑一个初值为 $0$ 的整数，遍历该字符串，如果遇到左括号，则将该整数加上 $1$，如果遇到右括号，则将该整数减去 $1$。最终得到的数值即为括号字符串的分数。

那么，根据有效括号字符串的定义，我们可以利用「分数」的概念给出该定义的**等价条件**：

> 该字符串的分数为 $0$，且该字符串**任意前缀**的分数均大于等于 $0$。

读者可以自行尝试证明上述两个条件的等价性。

我们同样可以用「分数」的概念判断一个部分可变的括号字符串 $s$ 能否变为有效字符串。

为叙述方便，我们首先给出「有效前缀」的定义：

> 如果括号字符串的某个前缀字符串满足它本身及它的所有前缀的分数均大于等于 $0$，则称该前缀为有效前缀。

可以看出，一个有效括号字符串的任意前缀均为「有效前缀」。

我们可以对字符串 $s$，定义对应的最大分数数组 $mx$ 和最小有效分数数组 $mn$。具体地：

- $mx[i+1]$ 代表前缀 $s[0..i]$ **可以达到的最大分数**；
- $mn[i+1]$ 为前缀 $s[0..i]$ **可以达到的最小分数**及**作为有效前缀所需的最小分数**两者的**较大值**。
    其中「作为有效前缀所需的最小分数」的取值，由于字符串分数的奇偶性一定与字符串长度的**奇偶性相同**，因此取值会有以下两种情况：
    - $i$ 为偶数，此时最小分数为 $0$;
    - $i$ 为奇数，此时最小分数为 $1$。
    用公式表达，即为 $(i+1)mod2$。

对于 $i=0$ 的情况，有 $mx[0]=mn[0]=0$。

我们从左至右遍历字符串 $s$，并相应维护 $mx$ 和 $mn$ 数组。具体地，当遍历到下标 $i$ 时，根据 $locked[i]$ 的不同取值，会有以下两种情况：

- $locked[i]=1$，此时 $s[i]$ 的取值无法更改。因此 $mx[i+1]=mx[i]+diff$，其中 $diff$ 为 $s[i]$ 的分数。同理，$mn[i+1]=max(mn[i]+diff,(i+1)mod2)$。
- $locked[i]=0$，此时 $s[i]$ 的取值可以更改。因此 $mx[i+1]=mx[i]+1$，且 $mn[i+1]=max(mn[i]−1,(i+1)mod2)$。

在遍历的过程中，如果对于某一下标 $i$，有 $mx[i]<mn[i]$，那么 $s[0..i]$ 无法通过变换成为有效前缀，也就是说 $s$ **无法通过变换成为有效字符串**，此时直接返回 $false$。

当遍历完成后，我们只需要确定 $s$ 是否可以通过变换使得分数为 $0$ 即可。假设 $s$ 的长度为 $n$，这等价于判断 $mn[n]$ 是否为 $0$。如果 $mn[n]=0$，则 $s$ 可以通过变换成为有效括号字符串，我们应返回 $true$；反之则不能，应返回 $false$。

**细节**

由上述的推导过程，我们容易发现，在计算 $mx[i+1]$ 与 $mn[i+1]$ 时，我们**并不**需要用到整个 $mx$ 和 $mn$ 数组，只需要 $mx[i]$ 与 $mn[i]$ 的取值。因此，我们可以用**两个同名整数来替代** $mx$ 和 $mn$ 数组。具体转移如下：

- $mx$ 和 $mn$ 的初值为 $0$；
- $locked[i]=1$ 时，有 $mx=mx+diff$，$mn=max(mn+diff,(i+1)mod2)$；
- $locked[i]=0$ 时，有 $mx=mx+1$，$mn=max(mn−1,(i+1)mod2)$；

**代码**

```C++
class Solution {
public:
    bool canBeValid(string s, string locked) {
        int n = s.size();
        int mx = 0;   // 可以达到的最大分数
        int mn = 0;   // 可以达到的最小分数 与 最小有效前缀对应分数 的较大值
        for (int i = 0; i < n; ++i) {
            if (locked[i] == '1') {
                // 此时对应字符无法更改
                int diff;
                if (s[i] == '(') {
                    diff = 1;
                }
                else {
                    diff = -1;
                }
                mx += diff;
                mn = max(mn + diff, (i + 1) % 2);
            }
            else {
                // 此时对应字符可以更改
                ++mx;
                mn = max(mn - 1, (i + 1) % 2);
            }
            if (mx < mn) {
                // 此时该前缀无法变为有效前缀
                return false;
            }
        }
        // 最终确定 s 能否通过变换使得分数为 0（成为有效字符串）
        return mn == 0;
    }
};
```

```Python
class Solution:
    def canBeValid(self, s: str, locked: str) -> bool:
        n = len(s)
        mx = 0   # 可以达到的最大分数
        mn = 0   # 可以达到的最小分数 与 最小有效前缀对应分数 的较大值
        for i in range(n):
            if locked[i] == '1':
                # 此时对应字符无法更改
                if s[i] == '(':
                    diff = 1
                else:
                    diff = -1
                mx += diff
                mn = max(mn + diff, (i + 1) % 2)
            else:
                # 此时对应字符可以更改
                mx += 1
                mn = max(mn - 1, (i + 1) % 2)
            if mx < mn:
                # 此时该前缀无法变为有效前缀
                return False
        # 最终确定 s 能否通过变换使得分数为 0（成为有效字符串）
        return mn == 0
```

```Java
class Solution {
    public boolean canBeValid(String s, String locked) {
        int n = s.length();
        int mx = 0;   // 可以达到的最大分数
        int mn = 0;   // 可以达到的最小分数 与 最小有效前缀对应分数 的较大值
        for (int i = 0; i < n; ++i) {
            if (locked.charAt(i) == '1') {
                // 此时对应字符无法更改
                int diff;
                if (s.charAt(i) == '(') {
                    diff = 1;
                } else {
                    diff = -1;
                }
                mx += diff;
                mn = Math.max(mn + diff, (i + 1) % 2);
            } else {
                // 此时对应字符可以更改
                ++mx;
                mn = Math.max(mn - 1, (i + 1) % 2);
            }
            if (mx < mn) {
                // 此时该前缀无法变为有效前缀
                return false;
            }
        }
        // 最终确定 s 能否通过变换使得分数为 0（成为有效字符串）
        return mn == 0;
    }
}
```

```CSharp
public class Solution {
    public bool CanBeValid(string s, string locked) {
         int n = s.Length;
        int mx = 0;   // 可以达到的最大分数
        int mn = 0;   // 可以达到的最小分数 与 最小有效前缀对应分数 的较大值
        for (int i = 0; i < n; ++i) {
            if (locked[i] == '1') {
                // 此时对应字符无法更改
                int diff;
                if (s[i] == '(') {
                    diff = 1;
                } else {
                    diff = -1;
                }
                mx += diff;
                mn = Math.Max(mn + diff, (i + 1) % 2);
            } else {
                // 此时对应字符可以更改
                ++mx;
                mn = Math.Max(mn - 1, (i + 1) % 2);
            }
            if (mx < mn) {
                // 此时该前缀无法变为有效前缀
                return false;
            }
        }
        // 最终确定 s 能否通过变换使得分数为 0（成为有效字符串）
        return mn == 0;
    }
}
```

```Go
func canBeValid(s string, locked string) bool {
    n := len(s)
    mx := 0   // 可以达到的最大分数
    mn := 0   // 可以达到的最小分数 与 最小有效前缀对应分数 的较大值
    for i := 0; i < n; i++ {
        if locked[i] == '1' {
            // 此时对应字符无法更改
            var diff int
            if s[i] == '(' {
                diff = 1
            } else {
                diff = -1
            }
            mx += diff
            mn = int(math.Max(float64(mn+diff), float64((i+1)%2)))
        } else {
            // 此时对应字符可以更改
            mx++
            mn = int(math.Max(float64(mn-1), float64((i+1)%2)))
        }
        if mx < mn {
            // 此时该前缀无法变为有效前缀
            return false
        }
    }
    // 最终确定 s 能否通过变换使得分数为 0（成为有效字符串）
    return mn == 0
}
```

```C
bool canBeValid(char* s, char* locked) {
    int n = strlen(s);
    int mx = 0;   // 可以达到的最大分数
    int mn = 0;   // 可以达到的最小分数 与 最小有效前缀对应分数 的较大值
    for (int i = 0; i < n; ++i) {
        if (locked[i] == '1') {
            // 此时对应字符无法更改
            int diff;
            if (s[i] == '(') {
                diff = 1;
            } else {
                diff = -1;
            }
            mx += diff;
            mn = fmax(mn + diff, (i + 1) % 2);
        } else {
            // 此时对应字符可以更改
            ++mx;
            mn = fmax(mn - 1, (i + 1) % 2);
        }
        if (mx < mn) {
            // 此时该前缀无法变为有效前缀
            return false;
        }
    }
    // 最终确定 s 能否通过变换使得分数为 0（成为有效字符串）
    return mn == 0;
}
```

```JavaScript
var canBeValid = function(s, locked) {
    let n = s.length;
    let mx = 0;   // 可以达到的最大分数
    let mn = 0;   // 可以达到的最小分数 与 最小有效前缀对应分数 的较大值
    for (let i = 0; i < n; ++i) {
        if (locked[i] === '1') {
            // 此时对应字符无法更改
            let diff;
            if (s[i] === '(') {
                diff = 1;
            } else {
                diff = -1;
            }
            mx += diff;
            mn = Math.max(mn + diff, (i + 1) % 2);
        } else {
            // 此时对应字符可以更改
            ++mx;
            mn = Math.max(mn - 1, (i + 1) % 2);
        }
        if (mx < mn) {
            // 此时该前缀无法变为有效前缀
            return false;
        }
    }
    // 最终确定 s 能否通过变换使得分数为 0（成为有效字符串）
    return mn === 0;
};
```

```TypeScript
function canBeValid(s: string, locked: string): boolean {
    const n = s.length;
    let mx = 0;   // 可以达到的最大分数
    let mn = 0;   // 可以达到的最小分数 与 最小有效前缀对应分数 的较大值
    for (let i = 0; i < n; ++i) {
        if (locked[i] === '1') {
            // 此时对应字符无法更改
            let diff: number;
            if (s[i] === '(') {
                diff = 1;
            } else {
                diff = -1;
            }
            mx += diff;
            mn = Math.max(mn + diff, (i + 1) % 2);
        } else {
            // 此时对应字符可以更改
            ++mx;
            mn = Math.max(mn - 1, (i + 1) % 2);
        }
        if (mx < mn) {
            // 此时该前缀无法变为有效前缀
            return false;
        }
    }
    // 最终确定 s 能否通过变换使得分数为 0（成为有效字符串）
    return mn === 0;
};
```

```Rust
impl Solution {
    pub fn can_be_valid(s: String, locked: String) -> bool {
        let n = s.len();
        let mut mx = 0; // 可以达到的最大分数
        let mut mn = 0; // 可以达到的最小分数 与 最小有效前缀对应分数 的较大值
        for (i, (sc, lc)) in s.chars().zip(locked.chars()).enumerate() {
            if lc == '1' {
                // 此时对应字符无法更改
                let diff = if sc == '(' { 1 } else { -1 };
                mx += diff;
                mn = std::cmp::max(mn + diff, (i as i32 + 1) % 2);
            } else {
                // 此时对应字符可以更改
                mx += 1;
                mn = std::cmp::max(mn - 1, (i as i32 + 1) % 2);
            }
            if mx < mn {
                // 此时该前缀无法变为有效前缀
                return false;
            }
        }
        // 最终确定 s 能否通过变换使得分数为 0（成为有效字符串）
        mn == 0
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 为 $s$ 的长度。即为遍历字符串维护 $mx$ 和 $mn$ 并判断 $s$ 能否变为有效字符串的时间复杂度。
- 空间复杂度：$O(1)$。
