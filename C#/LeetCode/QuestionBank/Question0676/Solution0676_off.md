### [实现一个魔法字典](https://leetcode.cn/problems/implement-magic-dictionary/solutions/1656423/shi-xian-yi-ge-mo-fa-zi-dian-by-leetcode-b35s/)

#### 方法一：枚举每个字典中的字符串并判断

**思路与算法**

对于本题来说，我们有两种做法：第一种是把字典中的所有字符串存储在数组中，而当进行 $search$ 操作时，我们将待查询的字符串和数组中的字符串依次进行比较；第二种是提前把字典中每个字符串替换任一字母的结果存在哈希表中，当进行 $search$ 操作时，我们只需要检查待查询的字符串本身是否在哈希表中即可。

记字典中字符串的个数为 $n$，平均长度为 $l$，查询的次数为 $q$，字符集为 $\sum$。那么：

- 第一种方法需要 $O(nl)$ 的时间把所有字符串存储在数组中，每一次查询也需要 $O(nl)$ 的时间，总时间复杂度为 $O(nl+qnl)=O(qnl)$；
- 第二种方法需要 $O(nl^2\vert \sum \vert)$ 的时间把所有字符串替换任一字母的结果存在哈希表中，每一次查询仅需要 $O(l)$ 的时间，总时间复杂度为 $O(nl^2\vert \sum \vert+ql)$。

在本题的数据范围中 $n,l,q \le 100$ 同阶，而 $\vert \sum \vert=26$，因此第一种方法的时间复杂度较低，下面的代码使用的是第一种方法。

**细节**

使用第一种方法比较两个字符串时，我们首先需要保证它们的长度相等，随后遍历这两个字符串，需要保证这两个字符串恰好有一个位置对应的字符不同。

**代码**

```C++
class MagicDictionary {
public:
    MagicDictionary() {}
    
    void buildDict(vector<string> dictionary) {
        words = dictionary;
    }
    
    bool search(string searchWord) {
        for (auto&& word: words) {
            if (word.size() != searchWord.size()) {
                continue;
            }

            int diff = 0;
            for (int i = 0; i < word.size(); ++i) {
                if (word[i] != searchWord[i]) {
                    ++diff;
                    if (diff > 1) {
                        break;
                    }
                }
            }
            if (diff == 1) {
                return true;
            }
        }
        return false;
    }

private:
    vector<string> words;
};
```

```Java
class MagicDictionary {
    private String[] words;

    public MagicDictionary() {

    }

    public void buildDict(String[] dictionary) {
        words = dictionary;
    }

    public boolean search(String searchWord) {
        for (String word : words) {
            if (word.length() != searchWord.length()) {
                continue;
            }

            int diff = 0;
            for (int i = 0; i < word.length(); ++i) {
                if (word.charAt(i) != searchWord.charAt(i)) {
                    ++diff;
                    if (diff > 1) {
                        break;
                    }
                }
            }
            if (diff == 1) {
                return true;
            }
        }
        return false;
    }
}
```

```CSharp
public class MagicDictionary {
    private string[] words;

    public MagicDictionary() {

    }
    
    public void BuildDict(string[] dictionary) {
        words = dictionary;
    }

    public bool Search(string searchWord) {
        foreach (string word in words) {
            if (word.Length != searchWord.Length) {
                continue;
            }

            int diff = 0;
            for (int i = 0; i < word.Length; ++i) {
                if (word[i] != searchWord[i]) {
                    ++diff;
                    if (diff > 1) {
                        break;
                    }
                }
            }
            if (diff == 1) {
                return true;
            }
        }
        return false;
    }
}
```

```Python
class MagicDictionary:

    def __init__(self):
        self.words = list()

    def buildDict(self, dictionary: List[str]) -> None:
        self.words = dictionary

    def search(self, searchWord: str) -> bool:
        for word in self.words:
            if len(word) != len(searchWord):
                continue
            
            diff = 0
            for chx, chy in zip(word, searchWord):
                if chx != chy:
                    diff += 1
                    if diff > 1:
                        break
            
            if diff == 1:
                return True
        
        return False
```

```C
typedef struct {
    char **words;
    int wordsSize;
} MagicDictionary;

MagicDictionary* magicDictionaryCreate() {
    MagicDictionary *obj = (MagicDictionary *)malloc(sizeof(MagicDictionary));
    return obj;
}

void magicDictionaryBuildDict(MagicDictionary* obj, char ** dictionary, int dictionarySize) {
    obj->words = dictionary;
    obj->wordsSize = dictionarySize;
}

bool magicDictionarySearch(MagicDictionary* obj, char * searchWord) {
    int len = strlen(searchWord);
    for (int j = 0; j < obj->wordsSize; j++) {
        if (strlen(obj->words[j]) != len) {
            continue;
        }
        int diff = 0;
        for (int i = 0; i < len; ++i) {
            if (obj->words[j][i] != searchWord[i]) {
                ++diff;
                if (diff > 1) {
                    break;
                }
            }
        }
        if (diff == 1) {
            return true;
        }
    }
    return false;
}

void magicDictionaryFree(MagicDictionary* obj) {
    free(obj);
}
```

```Go
type MagicDictionary []string

func Constructor() MagicDictionary {
    return MagicDictionary{}
}

func (d *MagicDictionary) BuildDict(dictionary []string) {
    *d = dictionary
}

func (d *MagicDictionary) Search(searchWord string) bool {
next:
    for _, word := range *d {
        if len(word) != len(searchWord) {
            continue
        }
        diff := false
        for i := range word {
            if word[i] != searchWord[i] {
                if diff {
                    continue next
                }
                diff = true
            }
        }
        if diff {
            return true
        }
    }
    return false
}
```

```JavaScript
var MagicDictionary = function() {

};

MagicDictionary.prototype.buildDict = function(dictionary) {
    this.words = dictionary;
};

MagicDictionary.prototype.search = function(searchWord) {
    for (const word of this.words) {
        if (word.length !== searchWord.length) {
            continue;
        }

        let diff = 0;
        for (let i = 0; i < word.length; ++i) {
            if (word[i] !== searchWord[i]) {
                ++diff;
                if (diff > 1) {
                    break;
                }
            }
        }
        if (diff === 1) {
            return true;
        }
    }
    return false;
};
```

**复杂度分析**

- 时间复杂度：$O(qnl)$，其中 $n$ 是数组 $dictionary$ 的长度，$l$ 是数组 $dictionary$ 中字符串的平均长度，$q$ 是函数 $search(searchWord)$ 的调用次数。
- 空间复杂度：$O(nl)$，即为数组需要使用的空间。

#### 方法二：使用字典树优化枚举

**思路与算法**

我们也可以使用字典树代替数组，将所有字符串进行存储。这一部分需要的时间是相同的。

在查询时，我们可以使用递归 + 回溯的方法，使用递归函数 $dfs(node,pos,modified)$，其中的变量分别表示：当前遍历到的字典树上的节点是 $node$ 以及待查询字符串 $searchWord$ 的第 $pos$ 个字符，并且在之前的遍历中是否已经替换过恰好一个字符（如果替换过，那么 $modified$ 为 $true$，否则为 $false$）。

如果 $node$ 有一个值为 $searchWord[pos]$ 的子节点，那么我们就可以继续进行递归。同时，如果 $modified$ 为 $false$，我们可以将 $searchWord[pos]$ 替换成任意一个是 $node$ 子节点的字符，将 $modified$ 置为 $true$ 并继续进行递归。

当 $pos$ 等于 $searchWord$ 的长度时，说明递归完成。此时我们需要检查 $node$ 是否是一个字典树上的结束节点（即一个单词的末尾），同时需要保证 $modified$ 为 $true$，因为我们必须进行一次修改。

**代码**

```C++
struct Trie {
    bool is_finished;
    Trie* child[26];

    Trie() {
        is_finished = false;
        fill(begin(child), end(child), nullptr);
    }
};

class MagicDictionary {
public:
    MagicDictionary() {
        root = new Trie();
    }
    
    void buildDict(vector<string> dictionary) {
        for (auto&& word: dictionary) {
            Trie* cur = root;
            for (char ch: word) {
                int idx = ch - 'a';
                if (!cur->child[idx]) {
                    cur->child[idx] = new Trie();
                }
                cur = cur->child[idx];
            }
            cur->is_finished = true;
        }
    }
    
    bool search(string searchWord) {
        function<bool(Trie*, int, bool)> dfs = [&](Trie* node, int pos, bool modified) {
            if (pos == searchWord.size()) {
                return modified && node->is_finished;
            }
            int idx = searchWord[pos] - 'a';
            if (node->child[idx]) {
                if (dfs(node->child[idx], pos + 1, modified)) {
                    return true;
                }
            }
            if (!modified) {
                for (int i = 0; i < 26; ++i) {
                    if (i != idx && node->child[i]) {
                        if (dfs(node->child[i], pos + 1, true)) {
                            return true;
                        }
                    }
                }
            }
            return false;
        };

        return dfs(root, 0, false);
    }

private:
    Trie* root;
};
```

```Java
class MagicDictionary {
    Trie root;

    public MagicDictionary() {
        root = new Trie();
    }

    public void buildDict(String[] dictionary) {
        for (String word : dictionary) {
            Trie cur = root;
            for (int i = 0; i < word.length(); ++i) {
                char ch = word.charAt(i);
                int idx = ch - 'a';
                if (cur.child[idx] == null) {
                    cur.child[idx] = new Trie();
                }
                cur = cur.child[idx];
            }
            cur.isFinished = true;
        }
    }

    public boolean search(String searchWord) {
        return dfs(searchWord, root, 0, false);
    }

    private boolean dfs(String searchWord, Trie node, int pos, boolean modified) {
        if (pos == searchWord.length()) {
            return modified && node.isFinished;
        }
        int idx = searchWord.charAt(pos) - 'a';
        if (node.child[idx] != null) {
            if (dfs(searchWord, node.child[idx], pos + 1, modified)) {
                return true;
            }
        }
        if (!modified) {
            for (int i = 0; i < 26; ++i) {
                if (i != idx && node.child[i] != null) {
                    if (dfs(searchWord, node.child[i], pos + 1, true)) {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}

class Trie {
    boolean isFinished;
    Trie[] child;

    public Trie() {
        isFinished = false;
        child = new Trie[26];
    }
}
```

```CSharp
public class MagicDictionary {
    Trie root;

    public MagicDictionary() {
        root = new Trie();
    }

    public void BuildDict(string[] dictionary) {
        foreach (string word in dictionary) {
            Trie cur = root;
            foreach (char ch in word) {
                int idx = ch - 'a';
                if (cur.Child[idx] == null) {
                    cur.Child[idx] = new Trie();
                }
                cur = cur.Child[idx];
            }
            cur.IsFinished = true;
        }
    }

    public bool Search(string searchWord) {
        return DFS(searchWord, root, 0, false);
    }

    private bool DFS(string searchWord, Trie node, int pos, bool modified) {
        if (pos == searchWord.Length) {
            return modified && node.IsFinished;
        }
        int idx = searchWord[pos] - 'a';
        if (node.Child[idx] != null) {
            if (DFS(searchWord, node.Child[idx], pos + 1, modified)) {
                return true;
            }
        }
        if (!modified) {
            for (int i = 0; i < 26; ++i) {
                if (i != idx && node.Child[i] != null) {
                    if (DFS(searchWord, node.Child[i], pos + 1, true)) {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}

class Trie {
    public bool IsFinished { get; set; }
    public Trie[] Child { get; set; }

    public Trie() {
        IsFinished = false;
        Child = new Trie[26];
    }
}
```

```Python
class Trie:
    def __init__(self):
        self.is_finished = False
        self.child = dict()


class MagicDictionary:

    def __init__(self):
        self.root = Trie()

    def buildDict(self, dictionary: List[str]) -> None:
        for word in dictionary:
            cur = self.root
            for ch in word:
                if ch not in cur.child:
                    cur.child[ch] = Trie()
                cur = cur.child[ch]
            cur.is_finished = True

    def search(self, searchWord: str) -> bool:
        def dfs(node: Trie, pos: int, modified: bool) -> bool:
            if pos == len(searchWord):
                return modified and node.is_finished
            
            ch = searchWord[pos]
            if ch in node.child:
                if dfs(node.child[ch], pos + 1, modified):
                    return True
                
            if not modified:
                for cnext in node.child:
                    if ch != cnext:
                        if dfs(node.child[cnext], pos + 1, True):
                            return True
            
            return False
        
        return dfs(self.root, 0, False)
```

```C
typedef struct Trie {
    bool is_finished;
    struct Trie* child[26];
} Trie;

typedef struct {
    Trie *root;
} MagicDictionary;

Trie* trieCreate() {
    Trie *node = (Trie *)malloc(sizeof(Trie));
    for (int i = 0; i < 26; i++) {
        node->child[i] = NULL;
    }
    node->is_finished = false;
    return node;
}

MagicDictionary* magicDictionaryCreate() {
    MagicDictionary *obj = (MagicDictionary *)malloc(sizeof(MagicDictionary));
    obj->root = trieCreate();
    return obj;
}

void magicDictionaryBuildDict(MagicDictionary* obj, char ** dictionary, int dictionarySize) {
    for (int j = 0; j < dictionarySize; j++) {
        Trie* cur = obj->root;
        int len = strlen(dictionary[j]);
        for (int i = 0; i < len; i++) {
            int idx = dictionary[j][i] - 'a';
            if (!cur->child[idx]) {
                cur->child[idx] = trieCreate();
            }
            cur = cur->child[idx];
        }
        cur->is_finished = true;
    }
}

static bool dfs(Trie* node, char *searchWord, int pos, bool modified) {
    if (pos == strlen(searchWord)) {
        return modified && node->is_finished;
    }
    int idx = searchWord[pos] - 'a';
    if (node->child[idx]) {
        if (dfs(node->child[idx], searchWord, pos + 1, modified)) {
            return true;
        }
    }
    if (!modified) {
        for (int i = 0; i < 26; ++i) {
            if (i != idx && node->child[i]) {
                if (dfs(node->child[i], searchWord, pos + 1, true)) {
                    return true;
                }
            }
        }
    }
    return false;
};

bool magicDictionarySearch(MagicDictionary* obj, char * searchWord) {
    return dfs(obj->root, searchWord, 0, false);
}

static void trieFree(Trie *root) {
    for (int i = 0; i < 26; i++) {
        if (root->child[i]) {
            free(root->child[i]);
        }
    }
    free(root);
}

void magicDictionaryFree(MagicDictionary* obj) {
    trieFree(obj->root);
    free(obj);
}
```

```Go
type trie struct {
    children   [26]*trie
    isFinished bool
}

type MagicDictionary struct {
    *trie
}

func Constructor() MagicDictionary {
    return MagicDictionary{&trie{}}
}

func (d *MagicDictionary) BuildDict(dictionary []string) {
    for _, word := range dictionary {
        cur := d.trie
        for _, c := range word {
            c -= 'a'
            if cur.children[c] == nil {
                cur.children[c] = &trie{}
            }
            cur = cur.children[c]
        }
        cur.isFinished = true
    }
}

func dfs(node *trie, searchWord string, modified bool) bool {
    if searchWord == "" {
        return modified && node.isFinished
    }
    c := searchWord[0] - 'a'
    if node.children[c] != nil && dfs(node.children[c], searchWord[1:], modified) {
        return true
    }
    if !modified {
        for i, child := range node.children {
            if i != int(c) && child != nil && dfs(child, searchWord[1:], true) {
                return true
            }
        }
    }
    return false
}

func (d *MagicDictionary) Search(searchWord string) bool {
    return dfs(d.trie, searchWord, false)
}
```

```JavaScript
var MagicDictionary = function() {
    this.root = new Trie();
};

MagicDictionary.prototype.buildDict = function(dictionary) {
    for (const word of dictionary) {
        let cur = this.root;
        for (let i = 0; i < word.length; ++i) {
            const ch = word[i];
            const idx = ch.charCodeAt() - 'a'.charCodeAt();
            if (!cur.child[idx]) {
                cur.child[idx] = new Trie();
            }
            cur = cur.child[idx];
        }
        cur.isFinished = true;
    }
};

MagicDictionary.prototype.search = function(searchWord) {
    return dfs(searchWord, this.root, 0, false);
};

const dfs = (searchWord, node, pos, modified) => {
    if (pos === searchWord.length) {
        return modified && node.isFinished;
    }
    let idx = searchWord[pos].charCodeAt() - 'a'.charCodeAt();
    if (node.child[idx]) {
        if (dfs(searchWord, node.child[idx], pos + 1, modified)) {
            return true;
        }
    }
    if (!modified) {
        for (let i = 0; i < 26; ++i) {
            if (i !== idx && node.child[i]) {
                if (dfs(searchWord, node.child[i], pos + 1, true)) {
                    return true;
                }
            }
        }
    }
    return false;
}

class Trie {
    constructor() {
        this.isFinished = false;
        this.child = new Array(26).fill(0);
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nl+ql\vert \sum \vert)$，其中 $n$ 是数组 $dictionary$ 的长度，$l$ 是数组 $dictionary$ 中字符串的平均长度，$q$ 是函数 $search(searchWord)$ 的调用次数，$\sum$ 是字符集。初始化需要的时间为 $O(nl)$，每一次查询最多会把与 $searchWord$ 相差一个字符的单词全部遍历一遍，因此时间复杂度为 $O(l\vert \sum \vert)$。
- 空间复杂度：$O(nl)$，即为字典树需要使用的空间。
