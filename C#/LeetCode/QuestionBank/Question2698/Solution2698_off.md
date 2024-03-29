### [求一个整数的惩罚数](https://leetcode.cn/problems/find-the-punishment-number-of-an-integer/solutions/2496001/qiu-yi-ge-zheng-shu-de-cheng-fa-shu-by-l-ht5e/)

#### 方法一：回溯

**思路与算法**

题目给定的数据 $n$，需要求出 $n$「惩罚数」，对于 $n$「惩罚数」定义为满足以下条件 $i$ 的数的平方和：

-   $i \in [1,n]$；
-   $i^2$ 的十进制表示的字符串可以分割成若干连续子字符串，且这些子字符串对应的整数值之和等于 $i$。

根据以上分析可以知道题目的关键在于如何找到所有满足要求的数字 $i$，在此我们直接利用回溯即可。对于每个数字 $i$，首先需要将 $i^2$ 转换为字符串 $s$，然后依次将字符串 $s$ 进行枚举分割子串，分别枚举第一个子串 $s[0 \cdots i]$、第二个子串 $s[i+1 \cdots j]$，依次枚举剩余的子串，同时累加这些子串对应的十进制整数值之和为 $tot$，如果存在分割方案使得数值之和 $tot=i$，则说明 $i$ 符合要求，如果当前的 $tot$ 大于 $i$ 时则中止当前的搜索。依次检测在区间 $[1,n]$ 中有多少满足要求的数字 $i$，并返回这些数字 $i$ 的平方和。

**代码**

```cpp
class Solution {
public:
    bool dfs(string &s, int pos, int tot, int target) {
        if (pos == s.size()) {
            return tot == target;
        } 
        int sum = 0;
        for (int i = pos; i < s.size(); i++) {
            sum = sum * 10 + s[i] - '0';
            if (sum + tot > target) {
                break;
            }
            if (dfs(s, i + 1, sum + tot, target)) {
                return true;
            }
        }
        return false;
    }
    
    int punishmentNumber(int n) {
        int res = 0;
        for (int i = 1; i <= n; i++) {
            string s = to_string(i * i);
            if (dfs(s, 0, 0, i)) {
                res += i * i;
            }
        }
        return res;
    }
};
```

```c
bool dfs(const char *s, int pos, int tot, int target) {
    if (s[pos] == '\0') {
        return tot == target;
    } 
    int sum = 0;
    for (int i = pos; s[i] != '\0'; i++) {
        sum = sum * 10 + s[i] - '0';
        if (sum + tot > target) {
            break;
        }
        if (dfs(s, i + 1, sum + tot, target)) {
            return true;
        }
    }
    return false;
}

int punishmentNumber(int n){
    int res = 0;
    char s[32];
    for (int i = 1; i <= n; i++) {
        sprintf(s, "%d", i * i);
        if (dfs(s, 0, 0, i)) {
            res += i * i;
        }
    }
    return res;
}
```

```java
class Solution {
    public int punishmentNumber(int n) {
        int res = 0;
        for (int i = 1; i <= n; i++) {
            String s = Integer.toString(i * i);
            if (dfs(s, 0, 0, i)) {
                res += i * i;
            }
        }
        return res;
    }

    public boolean dfs(String s, int pos, int tot, int target) {
        if (pos == s.length()) {
            return tot == target;
        } 
        int sum = 0;
        for (int i = pos; i < s.length(); i++) {
            sum = sum * 10 + s.charAt(i) - '0';
            if (sum + tot > target) {
                break;
            }
            if (dfs(s, i + 1, sum + tot, target)) {
                return true;
            }
        }
        return false;
    }
}
```

```csharp
public class Solution {
    public int PunishmentNumber(int n) {
        int res = 0;
        for (int i = 1; i <= n; i++) {
            string s = (i * i).ToString();
            if (DFS(s, 0, 0, i)) {
                res += i * i;
            }
        }
        return res;
    }

    public bool DFS(string s, int pos, int tot, int target) {
        if (pos == s.Length) {
            return tot == target;
        } 
        int sum = 0;
        for (int i = pos; i < s.Length; i++) {
            sum = sum * 10 + s[i] - '0';
            if (sum + tot > target) {
                break;
            }
            if (DFS(s, i + 1, sum + tot, target)) {
                return true;
            }
        }
        return false;
    }
}
```

```python
class Solution:
    def punishmentNumber(self, n: int) -> int:
        def dfs(s: str, pos: int, tot: int, target: int) -> bool:
            if pos == len(s):
                return tot == target
            sum = 0
            for i in range(pos, len(s)):
                sum = sum * 10 + int(s[i])
                if sum + tot > target:
                    break
                if dfs(s, i + 1, sum + tot, target):
                    return True
            return False
        res = 0
        for i in range(1, n + 1):
            if dfs(str(i * i), 0, 0, i):
                res += i * i
        return res
```

```go
func punishmentNumber(n int) int {
    var dfs func(string, int, int, int) bool
    dfs = func(s string, pos int, tot int, target int) bool {
        if pos == len(s) {
            return tot == target
        }
        sum := 0
        for i := pos; i < len(s); i++ {
            sum = sum * 10 + int(s[i] - '0')
            if sum + tot > target {
                break
            }
            if dfs(s, i + 1, sum + tot, target) {
                return true
            }
        }
        return false
    }
    res := 0
    for i := 1; i <= n; i++ {
        if dfs(strconv.Itoa(i * i), 0, 0, i) {
            res += i * i
        }
    }
    return res
}
```

```javascript
var punishmentNumber = function(n) {
    const dfs = (s, pos, tot, target) => {
        if (pos == s.length) {
            return tot == target;
        }
        let sum = 0;
        for (let i = pos; i < s.length; i++) {
            sum = sum * 10 + parseInt(s[i]);
            if (tot + sum > target) {
                break;
            }
            if (dfs(s, i + 1, tot + sum, target)) {
                return true;
            }
        }
        return false;
    }
    let res = 0;
    for (let i = 1; i <= n; i++) {
        let s = (i * i).toString();
        if (dfs(s, 0, 0, i)) {
            res += i * i;
        }
    }
    return res;
};
```

**复杂度分析**

-   时间复杂度：$O(n^{1 + 2\log_{10}^2})$，其中 $n$ 表示给定的元素。对于给定的数 $i^2$，则将其转换为字符串的长度为 $m = \lfloor 1 + 2\log_{10}^{i} \rfloor$，回溯时的子状态有 $2^m$ 个，需要的时间为 $O(2^m) = O(i^{2\log_{10}^{2}})$，由于 $i$ 的取值范围为 $i \in [1,n]$，所以取其 $[1,n]$ 区间内的积分即为 $O(C_1 \times n^{1 + 2\log_{10}^2} - C_2)$，因此时间复杂度为 $O(n^{1 + 2\log_{10}^2})$。
-   空间复杂度：$O(\log n)$，其中 $n$ 表示给定的元素。每次递归需要占用空间，递归的最大深度为数字转换为字符串的长度，因此递归的最大深度为 $\log n$，因此空间复杂度为 $O(n \log n)$。
