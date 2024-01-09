### [字符串中的额外字符](https://leetcode.cn/problems/extra-characters-in-a-string/solutions/2590667/zi-fu-chuan-zhong-de-e-wai-zi-fu-by-leet-f0lu/)

#### 方法一：动态规划

##### 思路与算法

题目要求将字符串 $s$ 分割成若干个互不重叠的子字符串（以下简称为子串），同时要求每个子串都必须在 $dictionary$ 中出现。一些额外的字符可能不属于任何子串，而题目要求最小化这些额外字符的数量。

设 $n$ 是 $s$ 的长度，现在有两种基本的分割方案：

1. 把 $s$ 的最后一个字符 $s[n-1]$ 当做是额外字符，那么问题转为长度为 $n-1$ 的子问题。
2. 找到一个 $j$ 使得 $s$ 的后缀 $s[j...n-1]$ 构成的子串在 $dictionary$，那么问题转为长度为 $j-1$ 的子问题。

因此，定义 $d[i]$ 为 $s$ 前缀 $s[0...i-1]$ 的子问题，那么 $d[i]$ 取下面两种情况的最小值：

1. 把 $s[i-1]$ 当做是额外字符，$d[i] = d[i - 1] + 1$。
2. 遍历所有的 $j(j \in [0, i-1])$，如果子字符串 $s[j...i-1]$ 存在于 $dictionary$ 中，那么 $d[i] = \min d[j]$。

初始状态 $d[0] = 0$，最终答案为 $d[n]$。

查找子串 $s[j...i-1]$ 是否存在于 $dictionary$ 可以使用哈希表。另外在实现动态规划时，可以使用记忆化搜索，也可以使用递推，这两种方式在时空复杂度方面并没有明显差异。

##### 代码

```c++
class Solution {
public:
    int minExtraChar(string s, vector<string>& dictionary) {
        int n = s.size();
        vector<int> d(n + 1, INT_MAX);
        unordered_map<string, int> mp;
        for (auto s : dictionary) {
            mp[s]++;
        }
        d[0] = 0;
        for (int i = 1; i <= n; i++) {
            d[i] = d[i - 1] + 1;
            for (int j = i - 1; j >= 0; j--) {
                if (mp.count(s.substr(j, i - j))) {
                    d[i] = min(d[i], d[j]);
                }
            }
        }
        return d[n];
    }
};
```

```java
class Solution {
    public int minExtraChar(String s, String[] dictionary) {
        int n = s.length();
        int[] d = new int[n + 1];
        Arrays.fill(d, Integer.MAX_VALUE);
        Map<String, Integer> map = new HashMap<String, Integer>();
        for (String str : dictionary) {
            map.put(str, map.getOrDefault(str, 0) + 1);
        }
        d[0] = 0;
        for (int i = 1; i <= n; i++) {
            d[i] = d[i - 1] + 1;
            for (int j = i - 1; j >= 0; j--) {
                if (map.containsKey(s.substring(j, i))) {
                    d[i] = Math.min(d[i], d[j]);
                }
            }
        }
        return d[n];
    }
}
```

```csharp
public class Solution {
    public int MinExtraChar(string s, string[] dictionary) {
        int n = s.Length;
        int[] d = new int[n + 1];
        Array.Fill(d, int.MaxValue);
        IDictionary<string, int> dic = new Dictionary<string, int>();
        foreach (string str in dictionary) {
            dic.TryAdd(str, 0);
            dic[str]++;
        }
        d[0] = 0;
        for (int i = 1; i <= n; i++) {
            d[i] = d[i - 1] + 1;
            for (int j = i - 1; j >= 0; j--) {
                if (dic.ContainsKey(s.Substring(j, i - j))) {
                    d[i] = Math.Min(d[i], d[j]);
                }
            }
        }
        return d[n];
    }
}
```

```go
func minExtraChar(s string, dictionary []string) int {
    n := len(s)
    d := make([]int, n + 1)
    for i := 1; i <= n; i++ {
        d[i] = math.MaxInt
    }
    mp := map[string]int{}
    for _, e := range dictionary {
        mp[e]++
    }
    for i := 1; i <= n; i++ {
        d[i] = d[i - 1] + 1
        for j := i - 1; j >= 0; j-- {
            if _, ok := mp[s[j:i]]; ok {
                d[i] = min(d[i], d[j])
            }
        }
    }
    return d[n]
}
```

```python
class Solution:
    def minExtraChar(self, s: str, dictionary: List[str]) -> int:
        n = len(s)
        d = [sys.maxsize] * (n + 1)
        d[0] = 0
        mp = dict()
        for e in dictionary:
            mp[e] = mp[e] + 1 if e in mp else 1
        for i in range (1, n + 1):
            d[i] = d[i - 1] + 1
            for j in range(i - 1, -1, -1):
                if s[j:i] in mp:
                    d[i] = min(d[i], d[j])
        return d[n]
```

#### 复杂度分析

- 时间复杂度：$O(n^3 + ml)$，其中 $n$ 是 $s$ 的长度，$m$ 是 $dictionary$ 的长度，$l$ 是 $dictionary$ 中字符串的最大长度。动态规划递推过程中需要递推 $O(n)$ 次，每次需要遍历 $O(n)$ 个子问题，每次转移查询哈希表的时间复杂度为 $O(n)$，因此这部分总复杂度为 $O(n^3)$。初始化哈希表的时间复杂度为 $O(ml)$。
- 空间复杂度：$O(n + ml)$。

#### 方法二：字典树优化

##### 思路与算法

注意到，方法一查找某个子串是否在 $dictionary$ 时效率很低，假设我们已经查找了子串 $s[j+1...i-1]$，接下来又要查找子串 $s[j...i-1]$，而后者只比前者多了一个字符 $s[j]$，却要花 $O(n)$ 的时间重复查找。

我们可以使用字典树来优化这一过程，不熟悉该数据结构的读者可以先阅读题目[「实现 Trie（前缀树）」](https://leetcode.cn/problems/implement-trie-prefix-tree/description/) 的题解。

由于我们总是查找 $s$ 的后缀是否存在，因此需要将 $dictionary$ 中的字符串翻转后插入字典树。在找到字典树上表示后缀 $s[j+1...i-1]$ 的节点后，只需要 $O(1)$ 的时间来判断表示后缀 $s[j...i-1]$ 的节点是否存在。因此，转移过程的总时间复杂度为 $O(n)$，动态规划整体求解的时间复杂度降低为 $O(n^2)$。

##### 代码

```c++
class Trie {
private:
    vector<Trie*> children;
    bool isEnd;

public:
    Trie() : children(26), isEnd(false) {}

    void insert(string word) {
        Trie* node = this;
        for (char ch : word) {
            ch -= 'a';
            if (node->children[ch] == nullptr) {
                node->children[ch] = new Trie();
            }
            node = node->children[ch];
        }
        node->isEnd = true;
    }

    bool track(Trie*& node, char ch) {
        if (node == nullptr || node->children[ch - 'a'] == nullptr) {
            node = nullptr;
            return false;
        }
        node = node->children[ch - 'a'];
        return node->isEnd;
    }
};

class Solution {
public:
    int minExtraChar(string s, vector<string>& dictionary) {
        int n = s.size();
        vector<int> d(n + 1, INT_MAX);
        Trie trie;
        for (auto s : dictionary) {
            reverse(s.begin(), s.end());
            trie.insert(s);
        }
        d[0] = 0;
        for (int i = 1; i <= n; i++) {
            d[i] = d[i - 1] + 1;
            Trie* node = &trie;
            for (int j = i - 1; j >= 0; j--) {
                if (trie.track(node, s[j])) {
                    d[i] = min(d[i], d[j]);
                }
            }
        }
        return d[n];
    }
};
```

```java
class Solution {
    public int minExtraChar(String s, String[] dictionary) {
        int n = s.length();
        int[] d = new int[n + 1];
        Arrays.fill(d, Integer.MAX_VALUE);
        Trie trie = new Trie();
        for (String str : dictionary) {
            StringBuilder sb = new StringBuilder(str).reverse();
            trie.insert(sb.toString());
        }
        d[0] = 0;
        for (int i = 1; i <= n; i++) {
            d[i] = d[i - 1] + 1;
            Trie node = trie;
            for (int j = i - 1; j >= 0; j--) {
                if (node != null) {
                    node = node.track(s.charAt(j));
                    if (node != null && node.isEnd()) {
                        d[i] = Math.min(d[i], d[j]);
                    }
                }
            }
        }
        return d[n];
    }
}

class Trie {
    private Trie[] children;
    private boolean isEnd;

    public Trie() {
        children = new Trie[26];
        isEnd = false;
    }

    public void insert(String word) {
        Trie node = this;
        for (int i = 0; i < word.length(); i++) {
            char ch = word.charAt(i);
            if (node.children[ch - 'a'] == null) {
                node.children[ch - 'a'] = new Trie();
            }
            node = node.children[ch - 'a'];
        }
        node.isEnd = true;
    }

    public Trie track(char ch) {
        Trie node = this;
        if (node == null || node.children[ch - 'a'] == null) {
            return null;
        }
        node = node.children[ch - 'a'];
        return node;
    }

    public boolean isEnd() {
        return isEnd;
    }
}
```

```csharp
public class Solution {
    public int MinExtraChar(string s, string[] dictionary) {
        int n = s.Length;
        int[] d = new int[n + 1];
        Array.Fill(d, int.MaxValue);
        Trie trie = new Trie();
        foreach (string str in dictionary) {
            StringBuilder sb = new StringBuilder();
            for (int i = str.Length - 1; i >= 0; i--) {
                sb.Append(str[i]);
            }
            trie.Insert(sb.ToString());
        }
        d[0] = 0;
        for (int i = 1; i <= n; i++) {
            d[i] = d[i - 1] + 1;
            Trie node = trie;
            for (int j = i - 1; j >= 0; j--) {
                if (node != null) {
                    node = node.Track(s[j]);
                    if (node != null && node.IsEnd) {
                        d[i] = Math.Min(d[i], d[j]);
                    }
                }
            }
        }
        return d[n];
    }
}

public class Trie {
    public Trie[] children;
    public bool IsEnd { get; set; }

    public Trie() {
        children = new Trie[26];
        IsEnd = false;
    }

    public void Insert(String word) {
        Trie node = this;
        foreach (char ch in word) {
            if (node.children[ch - 'a'] == null) {
                node.children[ch - 'a'] = new Trie();
            }
            node = node.children[ch - 'a'];
        }
        node.IsEnd = true;
    }

    public Trie Track(char ch) {
        Trie node = this;
        if (node == null || node.children[ch - 'a'] == null) {
            return null;
        }
        node = node.children[ch - 'a'];
        return node;
    }
}
```

```go
type Trie struct {
    children []*Trie
    isEnd bool
}

func NewTrie() *Trie {
    return &Trie{
        children: make([]*Trie, 26),
        isEnd: false,
    }
}

func insert(node *Trie, word string) {
    for i := len(word) - 1; i >= 0; i-- {
        ch := word[i] - 'a'
        if node.children[ch] == nil {
            node.children[ch] = NewTrie()
        }
        node = node.children[ch]
    }
    node.isEnd = true
}

func track(node *Trie, ch byte) (*Trie, bool) {
    if node == nil || node.children[ch - 'a'] == nil {
        return nil, false
    }
    node = node.children[ch - 'a']
    return node, node.isEnd
}

func minExtraChar(s string, dictionary []string) int {
    n := len(s)
    d := make([]int, n + 1)
    for i := 1; i <= n; i++ {
        d[i] = math.MaxInt
    }
    trie := NewTrie()
    for _, e := range dictionary {
        insert(trie, e)
    }
    for i := 1; i <= n; i++ {
        d[i] = d[i - 1] + 1
        node := trie
        for j := i - 1; j >= 0; j-- {
            var ok bool
            if node, ok = track(node, s[j]); ok {
                d[i] = min(d[i], d[j])
            }
        }
    }
    return d[n]
}
```

```python
class Trie:
    def __init__(self):
        self.children = [None for _ in range (26)]
        self.isEnd = False
    
    def insert(self, word):
        node = self
        for ch in word:
            k = ord(ch) - ord('a')
            if node.children[k] == None:
                node.children[k] = Trie()
            node = node.children[k]
        node.isEnd = True

    def track(self, node, ch):
        k = ord(ch) - ord('a')
        if node == None or node.children[k] == None:
            return None, False
        node = node.children[k]
        return node, node.isEnd

class Solution:
    def minExtraChar(self, s: str, dictionary: List[str]) -> int:
        n = len(s)
        d = [sys.maxsize] * (n + 1)
        d[0] = 0
        trie = Trie()
        for e in dictionary:
            trie.insert(reversed(e))
        for i in range (1, n + 1):
            d[i] = d[i - 1] + 1
            node = trie
            for j in range(i - 1, -1, -1):
                node, ok = trie.track(node, s[j])
                if ok:
                    d[i] = min(d[i], d[j])
        return d[n]
```

#### 复杂度分析

- 时间复杂度：$O(n^2 + ml)$，其中 $n$ 是 $s$ 的长度，$m$ 是 $dictionary$ 的长度，$l$ 是 $dictionary$ 中字符串的最大长度。动态规划部分的时间复杂度为 $O(n^2)$。初始化字典树的时间复杂度为 $O(ml)$。
- 空间复杂度：$O(n + mlC)$，其中 $C$ 是字符集大小，这部分空间用于保存字典树结构的子节点。
