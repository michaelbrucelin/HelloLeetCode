#### [方法一：枚举](https://leetcode.cn/problems/remove-letter-to-equalize-frequency/solutions/2249048/shan-chu-zi-fu-shi-pin-lu-xiang-tong-by-bz1ix/)

**思路与算法**

题目要求选择一个下标并删除下标处的字符，使得 $word$ 中剩余每个字母出现频率相同。

暴力方法可以尝试删除不同下标处字符，复杂度为 $O(n^2)$，其中 $n$ 是字符串 $word$ 的长度。

注意到删除不同位置的相同字符，不会改变剩余字符的频率，我们可以进行优化，只枚举删除不同的字符即可。

首先遍历输入字符串 $word$，统计每一个字符出现的频率。然后我们按照字母序，遍历所有的字符。如果当前这个字符出现在原字符串中，我们假定要删除这个字符，把这个字符出现的频率减一，统计所有出现字符的频率集合。如果集合大小为 $1$，则说明剩余每个字母出现频率相同，我们直接返回 $true$，反之说明删除当前字符不可行，我们把这个字符的频率加一进行还原。

最后，当我们尝试过所有不同字符后，还没有找到能删除的字符，使得满足要求，我们返回 $false$。

**代码**

```cpp
class Solution {
public:
    bool equalFrequency(string word) {
        int charCount[26] = {0};
        for (char& c : word) {
            charCount[c - 'a']++;
        }
        for (int i = 0; i < 26; i++) {
            if (charCount[i] == 0) {
                continue;
            }
            charCount[i]--;
            unordered_set<int> frequency;
            for (int f : charCount) {
                if (f > 0) {
                    frequency.insert(f);
                }
            }
            if (frequency.size() == 1) {
                return true;
            }
            charCount[i]++;
        }
        return false;
    }
};
```

```java
class Solution {
    public boolean equalFrequency(String word) {
        int[] charCount = new int[26];
        int n = word.length();
        for (int i = 0; i < n; i++) {
            charCount[word.charAt(i) - 'a']++;
        }
        for (int i = 0; i < 26; i++) {
            if (charCount[i] == 0) {
                continue;
            }
            charCount[i]--;
            HashSet<Integer> frequency = new HashSet<Integer>();
            for (int f : charCount) {
                if (f > 0) {
                    frequency.add(f);
                }
            }
            if (frequency.size() == 1) {
                return true;
            }
            charCount[i]++;
        }
        return false;
    }
}
```

```python
class Solution:
    def equalFrequency(self, word: str) -> bool:
        charCount = [0] * 26
        for c in word:
            charCount[ord(c) - ord('a')] += 1
        for i in range(26):
            if charCount[i] == 0: continue
            charCount[i] -= 1
            frequency = set(f for f in charCount if f > 0)
            if len(frequency) == 1:
                return True
            charCount[i] += 1
        return False
```

```go
func equalFrequency(word string) bool {
    charCount := [26]int{}
    for _, c := range word {
        charCount[c - 'a']++
    }
    for i := 0; i < 26; i++ {
        if charCount[i] == 0 {
            continue
        }
        charCount[i]--
        frequency := make(map[int]bool)
        for _, f := range charCount {
            if f > 0 {
                frequency[f] = true
            }
        }
        if len(frequency) == 1 {
            return true
        }
        charCount[i]++
    }
    return false
}
```

```csharp
public class Solution {
    public bool EqualFrequency(string word) {
        int[] charCount = new int[26];
        foreach (char c in word) {
            charCount[c - 'a']++;
        }
        for (int i = 0; i < 26; i++) {
            if (charCount[i] == 0) {
                continue;
            }
            charCount[i]--;
            HashSet<int> frequency = new HashSet<int>();
            foreach (int f in charCount) {
                if (f > 0) {
                    frequency.Add(f);
                }
            }
            if (frequency.Count == 1) {
                return true;
            }
            charCount[i]++;
        }
        return false;
    }
}
```

```javascript
var equalFrequency = function(word) {
    const charCount = new Array(26).fill(0);
    for (let c of word) {
        charCount[c.charCodeAt(0) - 'a'.charCodeAt(0)]++;
    }
    for (let i = 0; i < 26; i++) {
        if (charCount[i] == 0) {
            continue;
        }
        charCount[i]--;
        const frequency = new Set();
        for (const f of charCount) {
            if (f > 0) {
                frequency.add(f);
            }
        }
        if (frequency.size == 1) {
            return true;
        }
        charCount[i]++;
    }
    return false;
};
```

```c
typedef struct {
    int key;
    UT_hash_handle hh;
} HashItem;

HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, int key) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = key;
    HASH_ADD_INT(*obj, key, pEntry);
    return true;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);
        free(curr);
    }
}

bool equalFrequency(char * word) {
    int charCount[26] = {0};
    int len = strlen(word);
    for (int i = 0; i < len; i++) {
        charCount[word[i] - 'a']++;
    }
    for (int i = 0; i < 26; i++) {
        if (charCount[i] == 0) {
            continue;
        }
        charCount[i]--;
        HashItem *frequency = NULL;
        for (int j = 0; j < 26; j++) {
            int freq = charCount[j];
            if (freq > 0) {
                hashAddItem(&frequency, freq);
            }
        }
        int total = HASH_COUNT(frequency);
        hashFree(&frequency);
        if (total == 1) {
            return true;
        }
        charCount[i]++;
    }
    return false;
}
```

**复杂度分析**

-   时间复杂度：$O(n+|\Sigma|^2)$，其中 $n$ 是字符串 $word$ 的长度, $\Sigma$ 为字符集，在本题中字符集为所有小写字母，$|\Sigma| = 26$。
-   空间复杂度：$O(|\Sigma|)$，$\Sigma$ 为字符集，在本题中字符集为所有小写字母，$|\Sigma| = 26$。
