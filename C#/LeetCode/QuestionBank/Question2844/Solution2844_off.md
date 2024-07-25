### [生成特殊数字的最少操作](https://leetcode.cn/problems/minimum-operations-to-make-a-special-$num$ber/solutions/2852869/sheng-cheng-te-shu-shu-zi-de-zui-shao-ca-ffa4/)

#### 方法一：贪心

**思路**

一个数字要想被 $25$ 整除，它需要满足以下条件：

- 如果它的位数为 $1$，则它必须是 $0$。
- 如果它的位数为 $2$，则它必须是 $25$，$50$ 或者 $75$。
- 如果它的位数为大于等于 $3$，则它必须以 $00$，$25$，$50$ 或者 $75$结尾。

我们需要将字符串 $num$ 进行最少步数的操作，使其满足以上条件之一。题目又规定了 $num$ 不包含前导 $0$，因此不可能存在经过最少步数的操作，使得 $num$ 变为 $00$，所以这一特殊情况不在以上条件的讨论范围里。

我们从右至左遍历 $num$，

- 如果遇到 $0$ 或 $5$：
    - 如果在这之前遇到过 $0$，则将这之前的 $0$，当前的数字，以及当前的数字以左的数字都保留，其他的数字删除。记 $num$ 长度为 $n$，当前下标为 $i$，最少操作数即为 $n-i-2$。
    - 如果在这之前没有遇到过 $0$，则标记一下状态，表示遇到了 $0$ 或 $5$。
- 如果遇到 $2$ 或 $7$：
    - 如果在这之前遇到过 $5$，则将这之前的 $5$，当前的数字，以及当前的数字以左的数字都保留，其他的数字删除。记 $num$ 长度为 $n$，当前下标为 $i$，最少操作数即为 $n-i-2$。

如果遍历完都没有找到最少操作数，那么说明我们不可能通过操作来使得 $num$ 变得以 $00$，$25$，$50$ 或者 $75$结尾。

- 如果我们在遍历中遇到了 $0$，那么我们就删除其他所有数字，只保留这个 $0$，返回 $n-1$。
- 否则，我们将所有数字删除，返回 $n$。

**代码**

```Python
class Solution:
    def minimumOperations(self, num: str) -> int:
        n = len(num)
        find0 = find5 = False
        for i in range(n - 1, -1, -1):
            if num[i] in ['0', '5']:
                if find0:
                    return n - i - 2
                if num[i] == '0':
                    find0 = True
                else:
                    find5 = True
            elif num[i] in ['2', '7']:
                if find5:
                    return n - i - 2
        if find0:
            return n - 1
        return n
```

```C
class Solution {
public:
    int minimumOperations(string num) {
        int n = num.length();
        bool find0 = false, find5 = false;
        for (int i = n - 1; i >= 0; --i) {
            if (num[i] == '0' || num[i] == '5') {
                if (find0) {
                    return n - i - 2;
                }
                if (num[i] == '0') {
                    find0 = true;
                } else {
                    find5 = true;
                }
            } else if (num[i] == '2' || num[i] == '7') {
                if (find5) {
                    return n - i - 2;
                }
            }
        }
        if (find0) {
            return n - 1;
        }
        return n;
    }
};
```

```Java
class Solution {
    public int minimumOperations(String num) {
        int n = num.length();
        boolean find0 = false, find5 = false;
        for (int i = n - 1; i >= 0; --i) {
            if (num.charAt(i) == '0' || num.charAt(i) == '5') {
                if (find0) {
                    return n - i - 2;
                }
                if (num.charAt(i) == '0') {
                    find0 = true;
                } else {
                    find5 = true;
                }
            } else if (num.charAt(i) == '2' || num.charAt(i) == '7') {
                if (find5) {
                    return n - i - 2;
                }
            }
        }
        if (find0) {
            return n - 1;
        }
        return n;
    }
}
```

```CSharp
public class Solution {
    public int MinimumOperations(string num) {
        int n = num.Length;
        bool find0 = false, find5 = false;
        for (int i = n - 1; i >= 0; --i) {
            if (num[i] == '0' || num[i] == '5') {
                if (find0) {
                    return n - i - 2;
                }
                if (num[i] == '0') {
                    find0 = true;
                } else {
                    find5 = true;
                }
            } else if (num[i] == '2' || num[i] == '7') {
                if (find5) {
                    return n - i - 2;
                }
            }
        }
        if (find0) {
            return n - 1;
        }
        return n;
    }
}
```

```C
int minimumOperations(char* num){
    int n = strlen(num);
    bool find0 = false, find5 = false;
    for (int i = n - 1; i >= 0; --i) {
        if (num[i] == '0' || num[i] == '5') {
            if (find0) {
                return n - i - 2;
            }
            if (num[i] == '0') {
                find0 = true;
            } else {
                find5 = true;
            }
        } else if (num[i] == '2' || num[i] == '7') {
            if (find5) {
                return n - i - 2;
            }
        }
    }
    if (find0) {
        return n - 1;
    }
    return n;
}
```

```Go
func minimumOperations(num string) int {
    n := len(num)
    find0, find5 := false, false
    for i := n - 1; i >= 0; i-- {
        if num[i] == '0' || num[i] == '5' {
            if find0 {
                return n - i - 2
            }
            if num[i] == '0' {
                find0 = true
            } else {
                find5 = true
            }
        } else if num[i] == '2' || num[i] == '7' {
            if find5 {
                return n - i - 2
            }
        }
    }
    if find0 {
        return n - 1
    }
    return n
}
```

```JavaScript
var minimumOperations = function(num) {
    let n = num.length;
    let find0 = false, find5 = false;
    for (let i = n - 1; i >= 0; i--) {
        if (num[i] === '0' || num[i] === '5') {
            if (find0) {
                return n - i - 2;
            }
            if (num[i] === '0') {
                find0 = true;
            } else {
                find5 = true;
            }
        } else if (num[i] === '2' || num[i] === '7') {
            if (find5) {
                return n - i - 2;
            }
        }
    }
    if (find0) {
        return n - 1;
    }
    return n;
};
```

```TypeScript
function minimumOperations(num: string): number {
    let n = num.length;
    let find0 = false, find5 = false;

    for (let i = n - 1; i >= 0; i--) {
        if (num[i] === '0' || num[i] === '5') {
            if (find0) {
                return n - i - 2;
            }
            if (num[i] === '0') {
                find0 = true;
            } else {
                find5 = true;
            }
        } else if (num[i] === '2' || num[i] === '7') {
            if (find5) {
                return n - i - 2;
            }
        }
    }
    if (find0) {
        return n - 1;
    }
    return n;
};
```

```Rust
impl Solution {
    pub fn minimum_operations(num: String) -> i32 {
        let n = num.len();
        let mut find0 = false;
        let mut find5 = false;
        let num_chars: Vec<char> = num.chars().collect();

        for i in (0..n).rev() {
            if num_chars[i] == '0' || num_chars[i] == '5' {
                if find0 {
                    return (n - i - 2) as i32;
                }
                if num_chars[i] == '0' {
                    find0 = true;
                } else {
                    find5 = true;
                }
            } else if num_chars[i] == '2' || num_chars[i] == '7' {
                if find5 {
                    return (n - i - 2) as i32;
                }
            }
        }

        if find0 {
            return (n - 1) as i32;
        }
        return n as i32;
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是字符串 $num$ 的长度。
- 空间复杂度：$O(1)$。
