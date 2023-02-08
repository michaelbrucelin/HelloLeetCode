#### [方法二：字典树](https://leetcode.cn/problems/remove-sub-folders-from-the-filesystem/solutions/2097563/shan-chu-zi-wen-jian-jia-by-leetcode-sol-0x8d/)

**思路与算法**

我们也可以使用字典树来解决本题。文件夹的拓扑结构正好是树形结构，即字典树上的每一个节点就是一个文件夹。

对于字典树中的每一个节点，我们仅需要存储一个变量 $ref$，如果 $ref \geq 0$，说明该节点对应着 $folder[ref]$，否则（$ref=−1$）说明该节点只是一个中间节点。

我们首先将每一个文件夹按照 $“/”$ 进行分割，作为一条路径加入字典树中。随后我们对字典树进行一次深度优先搜索，搜索的过程中，如果我们走到了一个 $ref \geq 0$ 的节点，就将其加入答案，并且可以直接回溯，因为后续（更深的）所有节点都是该节点的子文件夹。

**代码**

```cpp
struct Trie {
    Trie(): ref(-1) {}

    unordered_map<string, Trie*> children;
    int ref;
};

class Solution {
public:
    vector<string> removeSubfolders(vector<string>& folder) {
        auto split = [](const string& s) -> vector<string> {
            vector<string> ret;
            string cur;
            for (char ch: s) {
                if (ch == '/') {
                    ret.push_back(move(cur));
                    cur.clear();
                }
                else {
                    cur.push_back(ch);
                }
            }
            ret.push_back(move(cur));
            return ret;
        };

        Trie* root = new Trie();
        for (int i = 0; i < folder.size(); ++i) {
            vector<string> path = split(folder[i]);
            Trie* cur = root;
            for (const string& name: path) {
                if (!cur->children.count(name)) {
                    cur->children[name] = new Trie();
                }
                cur = cur->children[name];
            }
            cur->ref = i;
        }

        vector<string> ans;

        function<void(Trie*)> dfs = [&](Trie* cur) {
            if (cur->ref != -1) {
                ans.push_back(folder[cur->ref]);
                return;
            }
            for (auto&& [_, child]: cur->children) {
                dfs(child);
            }
        };

        dfs(root);
        return ans;
    }
};
```

```java
class Solution {
    public List<String> removeSubfolders(String[] folder) {
        Trie root = new Trie();
        for (int i = 0; i < folder.length; ++i) {
            List<String> path = split(folder[i]);
            Trie cur = root;
            for (String name : path) {
                cur.children.putIfAbsent(name, new Trie());
                cur = cur.children.get(name);
            }
            cur.ref = i;
        }

        List<String> ans = new ArrayList<String>();
        dfs(folder, ans, root);
        return ans;
    }

    public List<String> split(String s) {
        List<String> ret = new ArrayList<String>();
        StringBuilder cur = new StringBuilder();
        for (int i = 0; i < s.length(); ++i) {
            char ch = s.charAt(i);
            if (ch == '/') {
                ret.add(cur.toString());
                cur.setLength(0);
            } else {
                cur.append(ch);
            }
        }
        ret.add(cur.toString());
        return ret;
    }

    public void dfs(String[] folder, List<String> ans, Trie cur) {
        if (cur.ref != -1) {
            ans.add(folder[cur.ref]);
            return;
        }
        for (Trie child : cur.children.values()) {
            dfs(folder, ans, child);
        }
    }
}

class Trie {
    int ref;
    Map<String, Trie> children;

    public Trie() {
        ref = -1;
        children = new HashMap<String, Trie>();
    }
}
```

```csharp
public class Solution {
    public IList<string> RemoveSubfolders(string[] folder) {
        Trie root = new Trie();
        for (int i = 0; i < folder.Length; ++i) {
            IList<string> path = Split(folder[i]);
            Trie cur = root;
            foreach (string name in path) {
                cur.children.TryAdd(name, new Trie());
                cur = cur.children[name];
            }
            cur.reference = i;
        }

        IList<string> ans = new List<string>();
        DFS(folder, ans, root);
        return ans;
    }

    public IList<string> Split(string s) {
        IList<string> ret = new List<string>();
        StringBuilder cur = new StringBuilder();
        foreach (char ch in s) {
            if (ch == '/') {
                ret.Add(cur.ToString());
                cur.Length = 0;
            } else {
                cur.Append(ch);
            }
        }
        ret.Add(cur.ToString());
        return ret;
    }

    public void DFS(string[] folder, IList<string> ans, Trie cur) {
        if (cur.reference != -1) {
            ans.Add(folder[cur.reference]);
            return;
        }
        foreach (Trie child in cur.children.Values) {
            DFS(folder, ans, child);
        }
    }
}

public class Trie {
    public int reference;
    public IDictionary<string, Trie> children;

    public Trie() {
        reference = -1;
        children = new Dictionary<string, Trie>();
    }
}
```

```python
class Trie:
    def __init__(self):
        self.children = dict()
        self.ref = -1

class Solution:
    def removeSubfolders(self, folder: List[str]) -> List[str]:
        root = Trie()
        for i, path in enumerate(folder):
            path = path.split("/")
            cur = root
            for name in path:
                if name not in cur.children:
                    cur.children[name] = Trie()
                cur = cur.children[name]
            cur.ref = i
        
        ans = list()

        def dfs(cur: Trie):
            if cur.ref != -1:
                ans.append(folder[cur.ref])
                return
            for child in cur.children.values():
                dfs(child)

        dfs(root)
        return ans
```

```c
typedef struct {
    char *key;
    struct Trie *val;
    UT_hash_handle hh;
} HashItem; 

typedef struct Trie {
    HashItem *children;
    int ref;
} Trie;

Trie *creatTrie() {
    Trie *obj = (Trie *)malloc(sizeof(Trie));
    obj->children = NULL;
    obj->ref = -1;
    return obj;
}

HashItem *hashFindItem(HashItem **obj, char *key) {
    HashItem *pEntry = NULL;
    HASH_FIND_STR(*obj, key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, char *key, Trie *val) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = key;
    pEntry->val = val;
    HASH_ADD_STR(*obj, key, pEntry);
    return true;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);  
        free(curr);             
    }
}

char **split(char *str, int *returnSize) {
    int len = strlen(str);
    char **ret = (char *)malloc(sizeof(char *) * len);
    char *p = strtok(str, "/");
    int pos = 0;
    while (p != NULL) {
        ret[pos++] = p;
        p = strtok(NULL, "/");
    }
    *returnSize = pos;
    return ret;
}

void dfs(Trie* cur, char **res, int *pos, char **folder) {
    if (cur->ref != -1) {
        res[(*pos)++] = folder[cur->ref];
        return;
    }

    for (HashItem *pEntry = cur->children; pEntry != NULL; pEntry = pEntry->hh.next) {
        dfs(pEntry->val, res, pos, folder);
    }
};

void freeTrie(Trie* root) {
    for (HashItem *pEntry = root->children; pEntry != NULL; pEntry = pEntry->hh.next) {
        freeTrie(pEntry->val);
    }
}

char ** removeSubfolders(char ** folder, int folderSize, int* returnSize) {
    Trie *root = creatTrie();
    char **copy = (char **)malloc(sizeof(char *) * folderSize); 
    for (int i = 0; i < folderSize; ++i) {
        copy[i] = (char *)malloc(sizeof(char) * (strlen(folder[i]) + 1));
        strcpy(copy[i], folder[i]);
        int pathSize = 0;
        char **path = split(copy[i], &pathSize);
        Trie *cur = root;
        for (int j = 0; j < pathSize; j++) {
            char *name = path[j];
            HashItem *pEntry = hashFindItem(&cur->children, name);
            Trie *node = NULL;
            if (pEntry == NULL) {
                node = creatTrie();
                hashAddItem(&cur->children, name, node);
            } else {
                node = pEntry->val;
            }
            cur = node;
        }
        free(path);
        cur->ref = i;
    }
    char **ans = (char **)malloc(sizeof(char *) * folderSize);
    int pos = 0;
    dfs(root, ans, &pos, folder);
    freeTrie(root);
    for (int i = 0; i < folderSize; i++) {
        free(copy[i]);
    }
    free(copy);
    *returnSize = pos;
    return ans;
}
```

```javascript
var removeSubfolders = function(folder) {
    const root = new Trie();
    for (let i = 0; i < folder.length; ++i) {
        const path = split(folder[i]);
        let cur = root;
        for (const name of path) {
            if (!cur.children.has(name)) {
                cur.children.set(name, new Trie());
            }
            cur = cur.children.get(name);
        }
        cur.ref = i;
    }

    const ans = [];

    const dfs = (folder, ans, cur) => {
        if (cur.ref !== -1) {
            ans.push(folder[cur.ref]);
            return;
        }
        for (const child of cur.children.values()) {
            dfs(folder, ans, child);
        }
    }

    dfs(folder, ans, root);
    return ans;
}

const split = (s) => {
    const ret = [];
    let cur = '';
    for (let i = 0; i < s.length; ++i) {
        const ch = s[i];
        if (ch === '/') {
            ret.push(cur);
            cur = ''
        } else {
            cur += ch;
        }
    }
    ret.push(cur);
    return ret;
}

class Trie {
    constructor() {
        this.ref = -1;
        this.children = new Map();
    }
}
```

**复杂度分析**

-   时间复杂度：$O(nl)$，其中 $n$ 和 $l$ 分别是数组 $folder$ 的长度和文件夹的平均长度。即为构造字典树和答案需要的时间。
-   空间复杂度：$O(nl)$，即为字典树需要使用的空间。注意这里不计入返回值占用的空间。
