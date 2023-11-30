### [确定两个字符串是否接近](https://leetcode.cn/problems/determine-if-two-strings-are-close/solutions/2539741/que-ding-liang-ge-zi-fu-chuan-shi-fou-ji-jdpa/)

#### 方法一：计数

两个字符串接近的充分必要条件为：

1. 两个字符串出现的字符集 $S_1$ 和 $S_2$ 相等，即 $S_1 = S_2$。
2. 分别将两个字符串的字符出现次数数组 $f_1$ 和 $f_2$ 进行排序后，两个数组从小到大一一相等。

> 充分条件：
>
> 首先分别将两个字符串的字符按照字符出现次数从小到大进行排序（基于操作 $1$），然后将字符按照从小到大的顺序进行交换（基于操作 $2$，交换后字符串非递减）。由条件 $1$ 和条件 $2$ 可知两个字符串相等，将两个字符串都按照其中一个字符串 $2$ 前面的操作逆序执行，那么就能从一个字符串 $1$ 得到另一个字符串 $2$，即两个字符串接近。

> 必要条件：
>
> 如果条件 $1$ 不成立，那么存在 $c \in S1$ 且 $c \notin S_2$ 或者存在 $c \in S_2$ 且 $c \notin S_1$，因此两个字符串不可能接近。
>
> 如果条件 $2$ 不成立，那么不管怎么进行操作 $2$ 的交换字符出现次数，总会存在 $c \in S1 \cap S2$ 且 $f_1[c] \neq f_2[c]$，因此一个字符串不可能通过操作得到另一个字符串，即两个字符串不可能接近。

```c++
class Solution {
public:
    bool closeStrings(string word1, string word2) {
        vector<int> count1(26), count2(26);
        for (char c : word1) {
            count1[c - 'a']++;
        }
        for (char c : word2) {
            count2[c - 'a']++;
        }
        for (int i = 0; i < 26; i++) {
            if (count1[i] > 0 && count2[i] == 0 || count1[i] == 0 && count2[i] > 0) {
                return false;
            }
        }
        sort(count1.begin(), count1.end());
        sort(count2.begin(), count2.end());
        return count1 == count2;
    }
};
```

```java
class Solution {
    public boolean closeStrings(String word1, String word2) {
        int[] count1 = new int[26], count2 = new int[26];
        for (char c : word1.toCharArray()) {
            count1[c - 'a']++;
        }
        for (char c : word2.toCharArray()) {
            count2[c - 'a']++;
        }
        for (int i = 0; i < 26; i++) {
            if (count1[i] > 0 && count2[i] == 0 || count1[i] == 0 && count2[i] > 0) {
                return false;
            }
        }
        Arrays.sort(count1);
        Arrays.sort(count2);
        return Arrays.equals(count1, count2);
    }
}
```

```csharp
public class Solution {
    public bool CloseStrings(string word1, string word2) {
        int[] count1 = new int[26], count2 = new int[26];
        foreach (char c in word1) {
            count1[c - 'a']++;
        }
        foreach (char c in word2) {
            count2[c - 'a']++;
        }
        for (int i = 0; i < 26; i++) {
            if (count1[i] > 0 && count2[i] == 0 || count1[i] == 0 && count2[i] > 0) {
                return false;
            }
        }
        Array.Sort(count1);
        Array.Sort(count2);
        return Enumerable.SequenceEqual(count1, count2);
    }
}
```

```c
int cmp(const void *p1, const void *p2) {
    return *(const int *)p1 < *(const int *)p2;
}

bool closeStrings(char* word1, char* word2) {
    int count1[26], count2[26];
    memset(count1, 0, sizeof(int) * 26);
    memset(count2, 0, sizeof(int) * 26);
    for (; *word1 != '\0'; word1++) {
        count1[*word1 - 'a']++;
    }
    for (; *word2 != '\0'; word2++) {
        count2[*word2 - 'a']++;
    }
    for (int i = 0; i < 26; i++) {
        if (count1[i] > 0 && count2[i] == 0 || count1[i] == 0 && count2[i] > 0) {
            return false;
        }
    }
    qsort(count1, 26, sizeof(int), cmp);
    qsort(count2, 26, sizeof(int), cmp);
    return memcmp(count1, count2, sizeof(int) * 26) == 0;
}
```

```javascript
var closeStrings = function(word1, word2) {
    let count1 = new Array(26).fill(0), count2 = new Array(26).fill(0);
    for (let i = 0; i < word1.length; i++) {
        count1[word1.charCodeAt(i) - 97]++;
    }
    for (let i = 0; i < word2.length; i++) {
        count2[word2.charCodeAt(i) - 97]++;
    }
    for (let i = 0; i < 26; i++) {
        if (count1[i] > 0 && count2[i] == 0 || count1[i] == 0 && count2[i] > 0) {
            return false;
        }
    }
    count1.sort();
    count2.sort();
    return count1.toString() == count2.toString();
};
```

```go
func closeStrings(word1 string, word2 string) bool {
    count1, count2 := make([]int, 26), make([]int, 26)
    for _, c := range word1 {
        count1[c - 'a']++
    }
    for _, c := range word2 {
        count2[c - 'a']++
    }
    for i := 0; i < 26; i++ {
        if count1[i] > 0 && count2[i] == 0 || count1[i] == 0 && count2[i] > 0 {
            return false
        }
    }
    sort.Ints(count1)
    sort.Ints(count2)
    return reflect.DeepEqual(count1, count2)
}
```

```python
class Solution:
    def closeStrings(self, word1: str, word2: str) -> bool:
        return Counter(word1).keys() == Counter(word2).keys() and sorted(Counter(word1).values()) == sorted(Counter(word2).values())
```

**复杂度分析**

-   时间复杂度：$O(\max \{n_1, n_2 \} + C \log C)$，其中 $n_1$ 和 $n_2$ 分别是字符串 $word1$ 和 $word2$ 的长度，$C = 26$ 是字符集大小。
-   空间复杂度：$O(C)$。
