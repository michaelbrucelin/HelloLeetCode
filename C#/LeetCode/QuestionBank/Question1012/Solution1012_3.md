#### [方法二：组合数学](https://leetcode.cn/problems/numbers-with-repeated-digits/solutions/2178714/zhi-shao-you-1-wei-zhong-fu-de-shu-zi-by-0mvu/)

方法一只有两种情况需要继续进入搜索：

-   前面填入的数字与 $n$ 对应位置的数字相同，且当前填入的数字为 $t$；
-   前面填入的数字都是 $0$，即前缀 $0$，并且当前填入的数字也为 $0$。

其他情况可以直接利用组合数学进行计算，当前填入第 $i$ 位，那么剩余 $m - 1 - i$ 位待填入，记已经填入的数字数目为 $c$，那么可选的数字数目为 $10-c$，那么剩余的不重复数字的正整数个数等于组合数 $A^{c}_{10-c}$（$n$ 的数据范围保证了组合数合法）。

```python
class Solution:
    def numDupDigitsAtMostN(self, N: int) -> int:
        limit, s = list(map(int, str(N + 1))), set()
        n, res = len(limit), sum(9 * perm(9, i) for i in range(len(limit) - 1))
        for i, x in enumerate(limit):
            for y in range(i == 0, x):
                if y not in s:
                    res += perm(9 - i, n - i - 1)
            if x in s: 
                break
            s.add(x)
        return N - res
```

```cpp
class Solution {
public:
    int A(int x, int y) {
        int res = 1;
        for (int i = 0; i < x; i++) {
            res *= y--;
        }
        return res;
    }

    int f(int mask, const string &sn, int i, bool same) {
        if (i == sn.size()) {
            return 1;
        }
        int t = same ? sn[i] - '0' : 9, res = 0, c = __builtin_popcount(mask) + 1;
        for (int k = 0; k <= t; k++) {
            if (mask & (1 << k)) {
                continue;
            }
            if (same && k == t) {
                res += f(mask | (1 << t), sn, i + 1, true);
            } else if (mask == 0 && k == 0) {
                res += f(0, sn, i + 1, false);
            } else {
                res += A(sn.size() - 1 - i, 10 - c);
            }
        }
        return res;
    }

    int numDupDigitsAtMostN(int n) {
        string sn = to_string(n);
        return n + 1 - f(0, sn, 0, true);
    }
};
```

```java
class Solution {
    public int numDupDigitsAtMostN(int n) {
        String sn = String.valueOf(n);
        return n + 1 - f(0, sn, 0, true);
    }

    public int f(int mask, String sn, int i, boolean same) {
        if (i == sn.length()) {
            return 1;
        }
        int t = same ? sn.charAt(i) - '0' : 9, res = 0, c = Integer.bitCount(mask) + 1;
        for (int k = 0; k <= t; k++) {
            if ((mask & (1 << k)) != 0) {
                continue;
            }
            if (same && k == t) {
                res += f(mask | (1 << t), sn, i + 1, true);
            } else if (mask == 0 && k == 0) {
                res += f(0, sn, i + 1, false);
            } else {
                res += A(sn.length() - 1 - i, 10 - c);
            }
        }
        return res;
    }

    public int A(int x, int y) {
        int res = 1;
        for (int i = 0; i < x; i++) {
            res *= y--;
        }
        return res;
    }
}
```

```c
int A(int x, int y) {
    int res = 1;
    for (int i = 0; i < x; i++) {
        res *= y--;
    }
    return res;
}

int f(int mask, const char *sn, int i, bool same) {
    if (sn[i] == '\0') {
        return 1;
    }
    int t = same ? sn[i] - '0' : 9, res = 0, c = __builtin_popcount(mask) + 1;
    for (int k = 0; k <= t; k++) {
        if (mask & (1 << k)) {
            continue;
        }
        if (same && k == t) {
            res += f(mask | (1 << t), sn, i + 1, true);
        } else if (mask == 0 && k == 0) {
            res += f(0, sn, i + 1, false);
        } else {
            res += A(strlen(sn) - 1 - i, 10 - c);
        }
    }
    return res;
}

int numDupDigitsAtMostN(int n){
    char sn[32];
    sprintf(sn, "%d", n);
    return n + 1 - f(0, sn, 0, true);
}
```

```javascript
var numDupDigitsAtMostN = function(n) {
    const sn = '' + n;
    const f = (mask, sn, i, same) => {
        if (i === sn.length) {
            return 1;
        }
        let t = same ? sn[i].charCodeAt() - '0'.charCodeAt() : 9, res = 0, c = bitCount(mask) + 1;
        for (let k = 0; k <= t; k++) {
            if ((mask & (1 << k)) !== 0) {
                continue;
            }
            if (same && k === t) {
                res += f(mask | (1 << t), sn, i + 1, true);
            } else if (mask === 0 && k === 0) {
                res += f(0, sn, i + 1, false);
            } else {
                res += A(sn.length - 1 - i, 10 - c);
            }
        }
        return res;
    }
    return n + 1 - f(0, sn, 0, true);
}

const A = (x, y) => {
    let res = 1;
    for (let i = 0; i < x; i++) {
        res *= y--;
    }
    return res;
}

const bitCount = (n) => {
    return n.toString(2).split('0').join('').length;
}
```

**复杂度分析**

-   时间复杂度：$O(m \times w^2)$，其中 $m$ 是整数 $n$ 的十进制位数，$w=10$ 表示十进制数的数字类型数目。计算组合数需要 $O(w)$ 的时间，而前面提到的两种情况互斥，因此搜索过程最多只出现一种情况，搜索层数为 $m$ 层，因此总时间复杂度为 $O(m \times w^2)$。
-   空间复杂度：$O(m)$。递归需要 $O(m)$ 的栈空间。
