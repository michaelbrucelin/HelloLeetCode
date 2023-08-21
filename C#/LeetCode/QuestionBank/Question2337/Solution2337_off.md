### [移动片段得到字符串](https://leetcode.cn/problems/move-pieces-to-obtain-a-string/solutions/1855012/yi-dong-pian-duan-de-dao-zi-fu-chuan-by-0j7py/)

#### 方法一：双指针

可能的移动操作有如下两种：

-   如果一个字符 $'L'$ 左侧的相邻字符是 $'\_'$，则将字符 $'L'$ 向左移动一位，将其左侧的 $'\_'$ 向右移动一位；
-   如果一个字符 $'R'$ 右侧的相邻字符是 $'\_'$，则将字符 $'R'$ 向右移动一位，将其右侧的 $'\_'$ 向左移动一位。

由于每次移动操作只是交换两个相邻字符，不会增加或删除字符，因此如果可以经过一系列移动操作将 $start$ 转换成 $target$，则 $start$ 和 $target$ 满足每一种字符的数量分别相同，字符 $'L'$ 和 $'R'$ 的相对顺序相同，且每个 $'L'$ 在 $target$ 中的下标小于等于对应的 $'L'$ 在 $start$ 中的下标，以及每个 $'R'$ 在 $target$ 中的下标大于等于对应的 $'R'$ 在 $start$ 中的下标。

因此，可以通过判断 $start$ 和 $target$ 中的所有 $'L'$ 和 $'R'$ 是否符合替换后的规则，判断是否可以经过一系列移动操作将 $start$ 转换成 $target$。

用 $n$ 表示 $start$ 和 $target$ 的长度，用 $i$ 和 $j$ 分别表示 $start$ 和 $target$ 中的下标，从左到右遍历 $start$ 和 $target$，跳过所有的 $'\_'$，当 $i$ 和 $j$ 都小于 $n$ 时，比较非 $'\_'$ 的字符：

-   如果 $start[i] \ne target[j]$，则 $start$ 和 $target$ 中的当前字符不匹配，返回 $false$；
-   如果 $start[i] = target[j]$，则当前字符是 $'L'$ 时应有 $i \ge j$，当前字符是 $'R'$ 时应有 $i \le j$，如果当前字符与两个下标的关系不符合该规则，返回 $false$。

如果 $i$ 和 $j$ 中有一个下标大于等于 $n$，则有一个字符串已经遍历到末尾，继续遍历另一个字符串中的其余字符，如果其余字符中出现非 $'\_'$ 的字符，则该字符不能与任意字符匹配，返回 $false$。

如果 $start$ 和 $target$ 遍历结束之后没有出现不符合移动操作的情况，则可以经过一系列移动操作将 $start$ 转换成 $target$，返回 $true$。

```python
class Solution:
    def canChange(self, start: str, target: str) -> bool:
        n = len(start)
        i = j = 0
        while i < n and j < n:
            while i < n and start[i] == '_':
                i += 1
            while j < n and target[j] == '_':
                j += 1
            if i < n and j < n:
                if start[i] != target[j]:
                    return False
                c = start[i]
                if c == 'L' and i < j or c == 'R' and i > j:
                    return False
                i += 1
                j += 1
        while i < n:
            if start[i] != '_':
                return False
            i += 1
        while j < n:
            if target[j] != '_':
                return False
            j += 1
        return True
```

```java
class Solution {
    public boolean canChange(String start, String target) {
        int n = start.length();
        int i = 0, j = 0;
        while (i < n && j < n) {
            while (i < n && start.charAt(i) == '_') {
                i++;
            }
            while (j < n && target.charAt(j) == '_') {
                j++;
            }
            if (i < n && j < n) {
                if (start.charAt(i) != target.charAt(j)) {
                    return false;
                }
                char c = start.charAt(i);
                if ((c == 'L' && i < j) || (c == 'R' && i > j)) {
                    return false;
                }
                i++;
                j++;
            }
        }
        while (i < n) {
            if (start.charAt(i) != '_') {
                return false;
            }
            i++;
        }
        while (j < n) {
            if (target.charAt(j) != '_') {
                return false;
            }
            j++;
        }
        return true;
    }
}
```

```csharp
public class Solution {
    public bool CanChange(string start, string target) {
        int n = start.Length;
        int i = 0, j = 0;
        while (i < n && j < n) {
            while (i < n && start[i] == '_') {
                i++;
            }
            while (j < n && target[j] == '_') {
                j++;
            }
            if (i < n && j < n) {
                if (start[i] != target[j]) {
                    return false;
                }
                char c = start[i];
                if ((c == 'L' && i < j) || (c == 'R' && i > j)) {
                    return false;
                }
                i++;
                j++;
            }
        }
        while (i < n) {
            if (start[i] != '_') {
                return false;
            }
            i++;
        }
        while (j < n) {
            if (target[j] != '_') {
                return false;
            }
            j++;
        }
        return true;
    }
}
```

```cpp
class Solution {
public:
    bool canChange(string start, string target) {
        int n = start.length();
        int i = 0, j = 0;
        while (i < n && j < n) {
            while (i < n && start[i] == '_') {
                i++;
            }
            while (j < n && target[j] == '_') {
                j++;
            }
            if (i < n && j < n) {
                if (start[i] != target[j]) {
                    return false;
                }
                char c = start[i];
                if ((c == 'L' && i < j) || (c == 'R' && i > j)) {
                    return false;
                }
                i++;
                j++;
            }
        }
        while (i < n) {
            if (start[i] != '_') {
                return false;
            }
            i++;
        }
        while (j < n) {
            if (target[j] != '_') {
                return false;
            }
            j++;
        }
        return true;
    }
};
```

```c
bool canChange(char * start, char * target) {
    int n = strlen(start);
    int i = 0, j = 0;
    while (i < n && j < n) {
        while (i < n && start[i] == '_') {
            i++;
        }
        while (j < n && target[j] == '_') {
            j++;
        }
        if (i < n && j < n) {
            if (start[i] != target[j]) {
                return false;
            }
            char c = start[i];
            if ((c == 'L' && i < j) || (c == 'R' && i > j)) {
                return false;
            }
            i++;
            j++;
        }
    }
    while (i < n) {
        if (start[i] != '_') {
            return false;
        }
        i++;
    }
    while (j < n) {
        if (target[j] != '_') {
            return false;
        }
        j++;
    }
    return true;
}
```

```javascript
var canChange = function(start, target) {
    const n = start.length;
    let i = 0, j = 0;
    while (i < n && j < n) {
        while (i < n && start[i] === '_') {
            i++;
        }
        while (j < n && target[j] === '_') {
            j++;
        }
        if (i < n && j < n) {
            if (start[i] !== target[j]) {
                return false;
            }
            const c = start[i];
            if ((c === 'L' && i < j) || (c === 'R' && i > j)) {
                return false;
            }
            i++;
            j++;
        }
    }
    while (i < n) {
        if (start[i] !== '_') {
            return false;
        }
        i++;
    }
    while (j < n) {
        if (target[j] !== '_') {
            return false;
        }
        j++;
    }
    return true;
};
```

```go
func canChange(start string, target string) bool {
    i, j, n := 0, 0, len(start)
    for i < n && j < n {
        for i < n && start[i] == '_' {
            i++
        }
        for j < n && target[j] == '_' {
            j++
        }
        if i < n && j < n {
            if start[i] != target[j] {
                return false
            }
            c := start[i]
            if c == 'L' && i < j || c == 'R' && i > j {
                return false
            }
            i++
            j++
        }
    }
    for i < n {
        if start[i] != '_' {
            return false
        }
        i++
    }
    for j < n {
        if target[j] != '_' {
            return false
        }
        j++
    }
    return true
}
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 是字符串 $start$ 和 $target$ 的长度。需要遍历两个字符串各一次。
-   空间复杂度：$O(1)$。只需要使用常量的额外空间。
