### [删除字符串中的所有相邻重复项 II](https://leetcode.cn/problems/remove-all-adjacent-duplicates-in-string-ii/solutions/99459/shan-chu-zi-fu-chuan-zhong-de-suo-you-xiang-lin--4/?envType=problem-list-v2&envId=ySsxoJfz)

#### 方法一：暴力解法

按照问题要求操作：对重复的相邻字母计数，当计数达到 `k` 时将其删除。重复此操作，直到没有删除的字符为止。

![](./assets/img/Solution1209_off_1.png)

**算法**

1. 记录字符串的长度。
2. 遍历字符串：
    - 如果当前字符与前一个相同，计数器加 $1$。
        - 否则，重置计数器为 `1`。
    - 如果计数器等于 `k`，删除这 `k` 个字符。
3. 如果字符串的长度被改变，从头开始重新遍历字符串。

```Java
public String removeDuplicates(String s, int k) {
    StringBuilder sb = new StringBuilder(s);
    int length = -1;
    while (length != sb.length()) {
        length = sb.length();
        for (int i = 0, count = 1; i < sb.length(); ++i) {
            if (i == 0 || sb.charAt(i) != sb.charAt(i - 1)) {
                count = 1;
            } else if (++count == k) {
                sb.delete(i - k + 1, i + 1);
                break;
            }
        }
    }
    return sb.toString();
}
```

```Cpp
string removeDuplicates(string s, int k) {
    int length = -1;
    while (length != s.size()) {
        length = s.size();
        for (int i = 0, count = 1; i < s.size(); ++i) {
            if (i == 0 || s[i] != s[i - 1]) {
                count = 1;
            } else if (++count == k) {
                s.erase(i - k + 1, k);
                break;
            }
        }
    }
    return s;
}
```

**复杂度分析**

- 时间复杂度：$O(n^2/k)$，其中 $n$ 是字符串的长度。字符串扫描不超过 $n/k$ 次。
- 空间复杂度：$O(1)$。某些语言会创建字符串的副本，但算法只在字符串本身上操作。

#### 方法二：记忆计数

从方法一中可以看出，如果为每个字符设置计数器，就不必每次删除完字符后从头开始。这种方法具有线性复杂度，但需要额外空间存储字符的计数器。

**算法**

1. 初始长度为 `n` 的数组 `counts`。
2. 遍历字符串：
    - 如果当前字符与上一个字符相等，令 `counts[i] = counts[i - 1] + 1`。
        - 否则，令 `counts[i] = 1`。
    - 如果 `counts[i] = k`，删除这 `k` 个字符，令 `i = i - k`。

```Java
public String removeDuplicates(String s, int k) {
    StringBuilder sb = new StringBuilder(s);
    int count[] = new int[sb.length()];
    for (int i = 0; i < sb.length(); ++i) {
        if (i == 0 || sb.charAt(i) != sb.charAt(i - 1)) {
            count[i] = 1;
        } else {
            count[i] = count[i - 1] + 1;
            if (count[i] == k) {
                sb.delete(i - k + 1, i + 1);
                i = i - k;
            }
        }
    }
    return sb.toString();
}
```

```Cpp
string removeDuplicates(string s, int k) {
    vector<int> count(s.size());
    for (int i = 0; i < s.size(); ++i) {
        if (i == 0 || s[i] != s[i - 1]) {
            count[i] = 1;
        } else {
            count[i] = count[i - 1] + 1;
            if (count[i] == k) {
                s.erase(i - k + 1, k);
                i = i - k;
            }
        };
    }
    return s;
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是字符串长度。每个字符仅被处理一次。
- 空间复杂度：$O(n)$，存储每个字符的计数器。

#### 方法三：栈

当前字符与前一个不同时，往栈中压入 `1`。否则栈顶元素加 `1`。

![](./assets/img/Solution1209_off_3.png)

**算法**

1. 迭代字符串：
    - 如果当前字符与前一个相同，栈顶元素加 $1$。
        - 否则，往栈中压入 `1`。
    - 如果栈顶元素等于 `k`，则从字符串中删除这 `k` 个字符，并将 `k` 从栈顶移除。

> 注意：因为在 $Java$ 中 `Integer` 是不可变的，需要先弹出栈顶元素，然后加 $1$，再压入栈顶。

```Java
public String removeDuplicates(String s, int k) {
    StringBuilder sb = new StringBuilder(s);
    Stack<Integer> counts = new Stack<>();
    for (int i = 0; i < sb.length(); ++i) {
        if (i == 0 || sb.charAt(i) != sb.charAt(i - 1)) {
            counts.push(1);
        } else {
            int incremented = counts.pop() + 1;
            if (incremented == k) {
                sb.delete(i - k + 1, i + 1);
                i = i - k;
            } else {
                counts.push(incremented);
            }
        }
    }
    return sb.toString();
}
```

```Cpp
string removeDuplicates(string s, int k) {
    stack<int> counts;
    for (int i = 0; i < s.size(); ++i) {
        if (i == 0 || s[i] != s[i - 1]) {
            counts.push(1);
        } else if (++counts.top() == k) {
            counts.pop();
            s.erase(i - k + 1, k);
            i = i - k;
        }
    }
    return s;
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是字符串长度。每个字符只处理一次。
- 空间复杂度：$O(n)$，栈空间。

#### 方法四：栈重建

如果将计数器和字符都存储在栈中，则不需要修改字符串，只需要根据栈中结果重建字符串即可。

**算法**

1. 迭代字符串：
    - 如果当前字符与栈顶元素相同，则栈顶元素计数器加 $1$。
        - 否则，计数器设为 `1`，当前字符压入栈。
    - 如果栈顶元素计数器等于 `k`，则弹出栈顶元素。
2. 使用栈中元素和计数器构建结果字符串。

```Java
class Pair {
    int cnt;
    char ch;
    public Pair(int cnt, char ch) {
        this.ch = ch;
        this.cnt = cnt;
    }
}
public String removeDuplicates(String s, int k) {
    Stack<Pair> counts = new Stack<>();
    for (int i = 0; i < s.length(); ++i) {
        if (counts.empty() || s.charAt(i) != counts.peek().ch) {
            counts.push(new Pair(1, s.charAt(i)));
        } else {
            if (++counts.peek().cnt == k) {
                counts.pop();
            }
        }
    }
    StringBuilder b = new StringBuilder();
    while (!counts.empty()) {
        Pair p = counts.pop();
        for (int i = 0; i < p.cnt; i++) {
            b.append(p.ch);
        }
    }
    return b.reverse().toString();
}
```

```Cpp
string removeDuplicates(string s, int k) {
    vector<pair<int, char>> counts;
    for (int i = 0; i < s.size(); ++i) {
        if (counts.empty() || s[i] != counts.back().second) {
            counts.push_back({ 1, s[i] });
        } else if (++counts.back().first == k) {
            counts.pop_back();
        }
    }
    s = "";
    for (auto &p : counts) {
        s += string(p.first, p.second);
    }
    return s;
}
```

**复杂度分析**

- 与方法三相同。

#### 方法五：双指针

该方法由[lee215](https://leetcode.cn/u/lee215/)提出，使用双指针可以优化方法二和三中的字符串操作。这里，使用快慢指针复制字符。每次需要删除 `k` 个元素时，只需要将慢指针回退 `k` 个位置。

![](./assets/img/Solution1209_off_5.png)

**算法**

1. 初始慢指针 `j` 等于 $0$。
2. 使用快指针 `i` 遍历字符串：
    - 令 `s[i] = s[j]`。
    - 如果 `s[j] = s[j - 1]`，则栈顶元素加 $1$。
        - 否则，栈中压入 `1`。
    - 如果计数器等于 `k`，`j $= j - k`$，并弹出栈顶元素。
3. 返回字符串的前 `j` 个字符。

```Java
public String removeDuplicates(String s, int k) {
    Stack<Integer> counts = new Stack<>();
    char[] sa = s.toCharArray();
    int j = 0;
    for (int i = 0; i < s.length(); ++i, ++j) {
        sa[j] = sa[i];
        if (j == 0 || sa[j] != sa[j - 1]) {
            counts.push(1);
        } else {
            int incremented = counts.pop() + 1;
            if (incremented == k) {
                j = j - k;
            } else {
                counts.push(incremented);
            }
        }
    }
    return new String(sa, 0, j);
}
```

```Cpp
string removeDuplicates(string s, int k) {
    auto j = 0;
    stack<int> counts;
    for (auto i = 0; i < s.size(); ++i, ++j) {
        s[j] = s[i];
        if (j == 0 || s[j] != s[j - 1]) {
            counts.push(1);
        } else if (++counts.top() == k) {
            counts.pop();
            j -= k;
        }
    }
    return s.substr(0, j);
}
```

**复杂度分析**

- 与方法三相同。
