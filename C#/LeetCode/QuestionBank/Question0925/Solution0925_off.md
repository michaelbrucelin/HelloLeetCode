### [长按键入](https://leetcode.cn/problems/long-pressed-name/solutions/454180/chang-an-jian-ru-by-leetcode-solution/)

#### 方法一：双指针

**思路与算法**

根据题意能够分析得到：字符串 $typed$ 的每个字符，有且只有两种「用途」：

- 作为 $name$ 的一部分。此时会「匹配」$name$ 中的一个字符
- 作为长按键入的一部分。此时它应当与前一个字符相同。

如果 $typed$ 中存在一个字符，它两个条件均不满足，则应当直接返回 $false$；否则，当 $typed$ 扫描完毕后，我们再检查 $name$ 的每个字符是否都被「匹配」了。

实现上，我们使用两个下标 $i,j$ 追踪 $name$ 和 $typed$ 的位置。

- 当 $name[i]=typed[j]$ 时，说明两个字符串存在一对匹配的字符，此时将 $i,j$ 都加 $1$。
- 否则，如果 $typed[j]=typed[j−1]$，说明存在一次长按键入，此时只将 $j$ 加 $1$。

最后，如果 $i=name.length$，说明 $name$ 的每个字符都被「匹配」了。

**代码**

```C++
class Solution {
public:
    bool isLongPressedName(string name, string typed) {
        int i = 0, j = 0;
        while (j < typed.length()) {
            if (i < name.length() && name[i] == typed[j]) {
                i++;
                j++;
            } else if (j > 0 && typed[j] == typed[j - 1]) {
                j++;
            } else {
                return false;
            }
        }
        return i == name.length();
    }
};
```

```Java
class Solution {
    public boolean isLongPressedName(String name, String typed) {
        int i = 0, j = 0;
        while (j < typed.length()) {
            if (i < name.length() && name.charAt(i) == typed.charAt(j)) {
                i++;
                j++;
            } else if (j > 0 && typed.charAt(j) == typed.charAt(j - 1)) {
                j++;
            } else {
                return false;
            }
        }
        return i == name.length();
    }
}
```

```C
bool isLongPressedName(char* name, char* typed) {
    int n = strlen(name), m = strlen(typed);
    int i = 0, j = 0;
    while (j < m) {
        if (i < n && name[i] == typed[j]) {
            i++;
            j++;
        } else if (j > 0 && typed[j] == typed[j - 1]) {
            j++;
        } else {
            return false;
        }
    }
    return i == n;
}
```

```JavaScript
var isLongPressedName = function(name, typed) {
    const n = name.length, m = typed.length;
    let i = 0, j = 0;
    while (j < m) {
        if (i < n && name[i] === typed[j]) {
            i++;
            j++;
        } else if (j > 0 && typed[j] === typed[j - 1]) {
            j++;
        } else {
            return false;
        }
    }
    return i === n;
};
```

```Go
func isLongPressedName(name string, typed string) bool {
    i, j := 0, 0
    for j < len(typed) {
        if i < len(name) && name[i] == typed[j] {
            i++
            j++
        } else if j > 0 && typed[j] == typed[j-1] {
            j++
        } else {
            return false
        }
    }
    return i == len(name)
}
```

**复杂度分析**

- 时间复杂度：$O(N+M)$，其中 $M,N$ 分别为两个字符串的长度。
- 空间复杂度：$O(1)$。
